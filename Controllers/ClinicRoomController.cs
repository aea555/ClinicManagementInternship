using ClinicManagementInternship.Dto.ClinicRoom;
using ClinicManagementInternship.Models;
using ClinicManagementInternship.Templates;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementInternship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicRoomController(IGenericService<CreateClinicRoom, UpdateClinicRoom, ClinicRoom> service) : GenericController<CreateClinicRoom, UpdateClinicRoom, Models.ClinicRoom>(service)
    {
    }
}
