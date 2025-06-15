using Application.Entities.Base;

namespace Application.Interface.IRepositories
{
    public interface ICompanyFormRepository
    {
        Task CreateActivityForm(Activity activityForm);
    }
}
