using Application.Entities.Base;
using Application.Response;

namespace Application.Interface.IServices
{
    public interface ICompanyFormService
    {
        Task<APIResponse> CreateActivityForm(Activity activityForm);
    }
}
