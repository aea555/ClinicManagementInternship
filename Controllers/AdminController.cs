using ClinicManagementInternship.Dto.Admin;
using ClinicManagementInternship.Models;
using ClinicManagementInternship.Services.Admin;
using ClinicManagementInternship.Templates;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementInternship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController(IAdminService service) : GenericController<CreateAdmin, UpdateAdmin, Admin>(service)
    {
    }
}
