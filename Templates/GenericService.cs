using ClinicManagementInternship.Models;
using ClinicManagementInternship.Utils;

namespace ClinicManagementInternship.Templates
{
    public class GenericService<TCreateDto, TUpdateDto, TEntity>(IGenericRepository<TEntity> repository) : IGenericService<TCreateDto, TUpdateDto, TEntity>
    where TCreateDto : GenericDTO
    where TUpdateDto : GenericUpdateDTO
    where TEntity : ModelBase
    {
        private readonly IGenericRepository<TEntity> _repository = repository;

        public virtual async Task<ServiceResult<TEntity>> GetById(int id)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(id);
                if (entity == null)
                {
                    return new ServiceResult<TEntity>
                    {
                        Success = false,
                        ErrorMessage = $"{typeof(TEntity).Name} not found.",
                        StatusCode = 404
                    };
                }

                return new ServiceResult<TEntity>
                {
                    Success = true,
                    Data = entity
                };
            }
            catch (Exception e)
            {
                return new ServiceResult<TEntity>
                {
                    Success = false,
                    ErrorMessage = "An unexpected error occurred. During getting " + nameof(TEntity) + " caused by: " + e.Message,
                    StatusCode = 500
                };
            }

        }


        public virtual async Task<ServiceResult<TEntity>> CreateNew(TCreateDto createDto)
        {
            try
            {
                TEntity entity = GenericService<TCreateDto, TUpdateDto, TEntity>.MapCreateDtoToEntity(createDto);

                var result = await _repository.CreateAsync(entity);

                return new ServiceResult<TEntity>
                {
                    Success = true,
                    Data = result
                };
            }
            catch (Exception e)
            {
                return new ServiceResult<TEntity>
                {
                    Success = false,
                    ErrorMessage = "An unexpected error occurred. During creating " + nameof(TEntity) + " caused by: " + e.Message,
                    StatusCode = 500
                };
            }
        }


        public virtual async Task<ServiceResult<TEntity>> Update(TUpdateDto updateDto)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(updateDto.Id);
                if (entity == null)
                {
                    return new ServiceResult<TEntity>
                    {
                        Success = false,
                        ErrorMessage = $"{typeof(TEntity).Name} not found.",
                        StatusCode = 404
                    };
                }

                GenericService<TCreateDto, TUpdateDto, TEntity>.MapUpdateDtoToEntity(updateDto, entity);

                entity.UpdatedAt = DateTime.UtcNow;

                var result = await _repository.UpdateAsync(entity);

                return new ServiceResult<TEntity>
                {
                    Success = true,
                    Data = result
                };
            }
            catch (Exception e)
            {
                return new ServiceResult<TEntity>
                {
                    Success = false,
                    ErrorMessage = "An unexpected error occurred. During updating " + nameof(TEntity) + " caused by: " + e.Message,
                    StatusCode = 500
                };
            }
        }

        public virtual async Task<ServiceResult<TEntity>> DeleteById(int id)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(id);
                if (entity == null)
                {
                    return new ServiceResult<TEntity>
                    {
                        Success = false,
                        ErrorMessage = $"{typeof(TEntity).Name} not found.",
                        StatusCode = 404
                    };
                }

                entity.UpdatedAt = DateTime.UtcNow;
                entity.IsDeleted = true;

                var result = await _repository.UpdateAsync(entity);

                return new ServiceResult<TEntity>
                {
                    Success = true,
                    Message = $"{typeof(TEntity).Name} with ID {id} deleted successfully."
                };
            }
            catch (Exception e)
            {
                return new ServiceResult<TEntity>
                {
                    Success = false,
                    ErrorMessage = "An unexpected error occurred. During deleting " + nameof(TEntity) + " caused by: " + e.Message,
                    StatusCode = 500
                };
            }
        }

        public virtual async Task<ServiceResult<List<TEntity>>> GetAll()
        {
            try
            {
                var entities = await _repository.GetAllAsync();

                return new ServiceResult<List<TEntity>>
                {
                    Success = true,
                    Data = entities
                };
            }
            catch (Exception e)
            {
                return new ServiceResult<List<TEntity>>
                {
                    Success = false,
                    ErrorMessage = "An unexpected error occurred. During getting all " + nameof(TEntity) + " caused by: " + e.Message,
                    StatusCode = 500
                };
            }
        }

        private static TEntity MapCreateDtoToEntity(TCreateDto createDto)
        {
            var entity = Activator.CreateInstance<TEntity>();
            if (entity == null)
            {
                throw new InvalidOperationException($"Could not create an instance of {typeof(TEntity).FullName}.");
            }

            foreach (var property in typeof(TCreateDto).GetProperties())
            {
                var entityProperty = typeof(TEntity).GetProperty(property.Name);
                if (entityProperty != null && entityProperty.CanWrite)
                {
                    var value = property.GetValue(createDto);
                    entityProperty.SetValue(entity, value);
                }
            }

            return entity;
        }

        private static void MapUpdateDtoToEntity(TUpdateDto updateDto, TEntity entity)
        {
            foreach (var property in typeof(TUpdateDto).GetProperties())
            {
                var entityProperty = typeof(TEntity).GetProperty(property.Name);
                if (entityProperty != null)
                {
                    var value = property.GetValue(updateDto);
                    if (value != null)
                    {
                        entityProperty.SetValue(entity, value);
                    }
                }
            }
        }
    }
}
