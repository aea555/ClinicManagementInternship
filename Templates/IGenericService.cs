using ClinicManagementInternship.Utils;

namespace ClinicManagementInternship.Templates
{
    public interface IGenericService<TCreateDto, TUpdateDto, TClass>
         where TCreateDto : GenericDTO
         where TUpdateDto : GenericUpdateDTO
    {
        Task<ServiceResult<TClass>> GetById(int id);
        Task<ServiceResult<TClass>> CreateNew(TCreateDto createDto);
        Task<ServiceResult<TClass>> Update(TUpdateDto updateDto);
        Task<ServiceResult<TClass>> DeleteById(int id);
        Task<ServiceResult<List<TClass>>> GetAll();
    }
}
