using ClinicManagementInternship.Dto.ClinicRoom;
using ClinicManagementInternship.Services.ClinicRoom;
using ClinicManagementInternship.Templates;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementInternship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicRoomController(IClinicRoomService service) : GenericController<CreateClinicRoom, UpdateClinicRoom, Models.ClinicRoom>(service)
    {
    }
}
