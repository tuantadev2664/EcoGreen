using Application.Response;

namespace Application.Interface.IServices
{
    public interface ILikeService
    {
        Task<APIResponse> ToggleLikeAsync(Guid postId, Guid userId);
    }

}
