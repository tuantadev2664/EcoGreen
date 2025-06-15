using Application.Entities.Base;
using Application.Interface;
using Application.Interface.IRepositories;
using InfrasStructure.EntityFramework.Data;

namespace InfrasStructure.EntityFramework.Repository
{
    public class CompanyFormRepository : ICompanyFormRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public CompanyFormRepository(ApplicationDBContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;

        }

        public async Task CreateActivityForm(Activity activityForm)
        {
            activityForm.Date = DateTime.SpecifyKind(activityForm.Date, DateTimeKind.Utc);
            await _context.Activities.AddAsync(activityForm);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
