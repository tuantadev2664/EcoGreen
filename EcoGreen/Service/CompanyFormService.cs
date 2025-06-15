using Application.Entities.Base;
using Application.Interface.IRepositories;
using Application.Interface.IServices;
using Application.Response;
using Common.Error;
using System.Net;

namespace EcoGreen.Service
{
    public class CompanyFormService : ICompanyFormService
    {
        private readonly ICompanyFormRepository _companyFormRepository;

        public CompanyFormService(ICompanyFormRepository companyFormRepository)
        {
            _companyFormRepository = companyFormRepository;
        }

        public async Task<APIResponse> CreateActivityForm(Activity activityForm)
        {
            var response = new APIResponse();

            try
            {
                await _companyFormRepository.CreateActivityForm(activityForm);

                response.Result = "Form created successfully";
                response.StatusCode = HttpStatusCode.OK;
                response.isSuccess = true;
            }
            catch (Exception ex)
            {
                var error = new APIException((int)HttpStatusCode.BadRequest, ex.Message, ex.StackTrace);

                response.StatusCode = HttpStatusCode.BadRequest;
                response.isSuccess = false;
                response.ErrorMessages.Add(error.Message);
            }

            return response;
        }

    }
}
