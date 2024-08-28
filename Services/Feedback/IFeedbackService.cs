using ClinicManagementInternship.Dto.Feedback;
using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Services.Feedback
{
    public interface IFeedbackService : IGenericService<CreateFeedback, UpdateFeedback, Models.Feedback>
    {
    }
}
