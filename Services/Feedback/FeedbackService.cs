using ClinicManagementInternship.Dto.Feedback;
using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Services.Feedback
{
    public class FeedbackService(IGenericRepository<Models.Feedback> repository) : GenericService<CreateFeedback, UpdateFeedback, Models.Feedback>(repository), IFeedbackService
    {
    }
}
