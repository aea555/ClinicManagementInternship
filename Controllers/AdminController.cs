using ClinicManagementInternship.Dto.Admin;
using ClinicManagementInternship.Models;
using ClinicManagementInternship.Templates;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementInternship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController(IGenericService<CreateAdmin, UpdateAdmin, Admin> service) : GenericController<CreateAdmin, UpdateAdmin, Admin>(service)
    {
    }
}
