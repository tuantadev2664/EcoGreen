using Application.Entities.Base;
using Application.Entities.DTOs;
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

        [HttpGet("get-all-activities")]
        public async Task<IActionResult> GetAllActivities()
        {
            APIResponse response = await _companyFormService.GetAllActivityForms();
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpGet("search-activities")]
        public async Task<IActionResult> SearchActivities([FromQuery] ActivitySearchRequest request)
        {
            APIResponse response = await _companyFormService.GetAllActivityFormsWithSearchAndSort(request);
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpGet("get-activity/{activityId}")]
        public async Task<IActionResult> GetActivityById(Guid activityId)
        {
            APIResponse response = await _companyFormService.GetActivityFormById(activityId);
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpPost("create-activity")]
        public async Task<IActionResult> CreateActivity([FromBody] CreateActivityRequest request)
        {
            // Map DTO to Entity
            var activity = new Activity
            {
                ActivityId = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                Location = request.Location,
                AmountOfPeople = request.AmountOfPeople,
                Date = request.Date,
                CreatedByCompanyId = request.CreatedByCompanyId,
                IsApproved = request.IsApproved
            };

            APIResponse response = await _companyFormService.CreateActivityForm(activity);

            return StatusCode((int)response.StatusCode, response);
        }

        [HttpPut("update-activity")]
        public async Task<IActionResult> UpdateActivity([FromBody] Activity activity)
        {
            APIResponse response = await _companyFormService.UpdateActivityForm(activity);
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpDelete("delete-activity/{activityId}")]
        public async Task<IActionResult> DeleteActivity(Guid activityId)
        {
            APIResponse response = await _companyFormService.DeleteActivityForm(activityId);
            return StatusCode((int)response.StatusCode, response);
        }
    }
}
