using ClinicManagementInternship.Dto.ClinicRoom;
using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Services.ClinicRoom
{
    public class ClinicRoomService(IGenericRepository<Models.ClinicRoom> repository) : GenericService<CreateClinicRoom, UpdateClinicRoom, Models.ClinicRoom>(repository), IClinicRoomService
    {
    }
}
