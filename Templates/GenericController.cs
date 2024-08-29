using ClinicManagementInternship.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementInternship.Templates
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController<TCreateDto, TUpdateDto, TClass>(IGenericService<TCreateDto, TUpdateDto, TClass> service) : ControllerBase
    where TCreateDto : GenericDTO
    where TUpdateDto : GenericUpdateDTO
    {
        private readonly IGenericService<TCreateDto, TUpdateDto, TClass> _service = service;

        [HttpGet("{id}")]
        [Authorize(Roles = "ADMIN,PATIENT,DOCTOR,BIOCHEMIST")]
        public async virtual Task<ActionResult<ServiceResult<TClass>>> GetById(int id)
        {
            var response = await _service.GetById(id);
            return HandleResponse(response);
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async virtual Task<ActionResult<ServiceResult<TClass>>> CreateNew([FromBody] TCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _service.CreateNew(dto);
            return HandleResponse(response);
        }

        [HttpPut]
        [Authorize(Roles = "ADMIN")]
        public async virtual Task<ActionResult<ServiceResult<TClass>>> Update([FromBody] TUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _service.Update(dto);
            return HandleResponse(response);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async virtual Task<ActionResult<ServiceResult<string>>> DeleteById(int id)
        {
            var response = await _service.DeleteById(id);
            return HandleResponse(response);
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN,PATIENT,DOCTOR,BIOCHEMIST")]
        public async virtual Task<ActionResult<ServiceResult<List<TClass>>>> GetAll()
        {
            var response = await _service.GetAll();
            return HandleResponse(response);
        }

        public ActionResult<ServiceResult<T>> HandleResponse<T>(ServiceResult<T> response)
        {
            if (response.Success)
            {
                return Ok(response);
            }
            return StatusCode(response.StatusCode, response.ErrorMessage);
        }
    }
}
