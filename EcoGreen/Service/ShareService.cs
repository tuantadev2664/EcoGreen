using Application.Entities.Base.Post;
using Application.Interface.IRepositories;
using Application.Interface.IServices;
using Application.Response;
using System.Net;

namespace EcoGreen.Service
{
    public class ShareService : IShareService
    {
        private readonly IShareRepository _shareRepository;

        public ShareService(IShareRepository shareRepository)
        {
            _shareRepository = shareRepository;
        }

        public async Task<APIResponse> SharePostAsync(Share share)
        {
            var response = new APIResponse();

            try
            {
                share.SharedAt = DateTime.UtcNow;

                await _shareRepository.AddShareAsync(share);
                await _shareRepository.SaveChangesAsync();

                string shareUrl = $"http://localhost:5173/{share.PostId}";

                response.Result = new { url = shareUrl };
                response.StatusCode = HttpStatusCode.OK;
                response.isSuccess = true;
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.isSuccess = false;
                response.ErrorMessages.Add(ex.Message);
            }

            return response;
        }
    }
}
