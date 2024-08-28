using ClinicManagementInternship.Dto.Prescription;
using ClinicManagementInternship.Models;
using ClinicManagementInternship.Templates;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementInternship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController(IGenericService<CreatePrescription, UpdatePrescription, Prescription> service) : GenericController<CreatePrescription, UpdatePrescription, Models.Prescription>(service)
    {
    }
}
