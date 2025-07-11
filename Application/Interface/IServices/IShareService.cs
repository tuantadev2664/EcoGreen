using Application.Entities.Base.Post;
using Application.Response;

namespace Application.Interface.IServices
{
    public interface IShareService
    {
        Task<APIResponse> SharePostAsync(Share share);
    }
}
