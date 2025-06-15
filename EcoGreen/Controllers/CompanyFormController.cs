using Application.Entities.Base;
using Application.Interface.IServices;
using Application.Response;
using Microsoft.AspNetCore.Mvc;

namespace EcoGreen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyFormController : ControllerBase
    {
        private readonly ICompanyFormService _companyFormService;
        public CompanyFormController(ICompanyFormService companyFormService)
        {
            _companyFormService = companyFormService;
        }

        [HttpPost("create-activity")]
        public async Task<IActionResult> CreateActivity([FromBody] Activity activity)
        {
            APIResponse response = await _companyFormService.CreateActivityForm(activity);

            return StatusCode((int)response.StatusCode, response);
        }
    }
}
