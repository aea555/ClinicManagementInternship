using ClinicManagementInternship.Dto.PrescriptionDrug;
using ClinicManagementInternship.Models;
using ClinicManagementInternship.Templates;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementInternship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionDrugController(IGenericService<CreatePrescriptionDrug, UpdatePrescriptionDrug, PrescriptionDrug> service) : GenericController<CreatePrescriptionDrug, UpdatePrescriptionDrug, Models.PrescriptionDrug>(service)
    {
    }
}
