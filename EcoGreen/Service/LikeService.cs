using Application.Entities.Base.Post;
using Application.Interface.IRepositories;
using Application.Interface.IServices;
using Application.Response;
using Common.Error;
using System.Net;

namespace EcoGreen.Service
{
    public class LikeService : ILikeService
    {
        private readonly ILikeRepository _likeRepository;

        public LikeService(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }

        public async Task<APIResponse> ToggleLikeAsync(Guid postId, Guid userId)
        {
            var response = new APIResponse();

            try
            {
                var existingLike = await _likeRepository.GetLikeByPostAndUserAsync(postId, userId);

                if (existingLike != null)
                {
                    await _likeRepository.RemoveLikeAsync(existingLike);
                    await _likeRepository.SaveChangesAsync();

                    response.Result = new { liked = false };
                    response.StatusCode = HttpStatusCode.OK;
                    response.isSuccess = true;
                }
                else
                {
                    await _likeRepository.AddLikeAsync(new Like
                    {
                        PostId = postId,
                        UserId = userId
                    });

                    await _likeRepository.SaveChangesAsync();

                    response.Result = new { liked = true };
                    response.StatusCode = HttpStatusCode.OK;
                    response.isSuccess = true;
                }
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
