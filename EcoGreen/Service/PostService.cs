using Application.Entities.Base.Post;
using Application.Interface.IRepositories;
using Application.Interface.IServices;
using Application.Request.Activity;
using Application.Request.Post;
using Application.Response;
using Common.Error;
using System.Linq.Expressions;
using System.Net;

namespace EcoGreen.Service
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<APIResponse> CreatePost(Post Post)
        {
            var response = new APIResponse();

            try
            {
                var companyUser = await _postRepository.GetUserById(Post.UserId);
                if (companyUser == null)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.isSuccess = false;
                    response.ErrorMessages.Add($"User with ID {Post.UserId} not found.");
                    return response;
                }

                await _postRepository.CreatePost(Post);

                response.Result = "Post created successfully";
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

        public async Task<APIResponse> DeletePost(Guid activityId)
        {
            var response = new APIResponse();
            try
            {
                await _postRepository.DeletePost(activityId);
                response.Result = "Post deleted successfully";
                response.StatusCode = HttpStatusCode.OK;
                response.isSuccess = true;
            }
            catch (KeyNotFoundException ex)
            {
                var error = new APIException((int)HttpStatusCode.NotFound, ex.Message, ex.StackTrace);
                response.StatusCode = HttpStatusCode.NotFound;
                response.isSuccess = false;
                response.ErrorMessages.Add(error.Message);
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

        public async Task<APIResponse> GetAllPosts()
        {
            var response = new APIResponse();
            try
            {
                var result = await _postRepository.GetAllPost();
                response.Result = result;
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

        public async Task<APIResponse> GetAllPostsBy(Expression<Func<Post, bool>> predicate)
        {
            var response = new APIResponse();
            try
            {
                var result = await _postRepository.GetAllPostBy(predicate);
                response.Result = result;
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

        public async Task<APIResponse> GetAllPostsWithSearchAndSort(PostSearchRequest request)
        {
            var response = new APIResponse();
            try
            {
                if (!string.IsNullOrWhiteSpace(request.SortBy) && !ActivitySortFields.IsValidSortField(request.SortBy))
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.isSuccess = false;
                    response.ErrorMessages.Add($"Invalid sort field '{request.SortBy}'. Valid fields are: {string.Join(", ", ActivitySortFields.ValidFields)}");
                    return response;
                }

                var result = await _postRepository.GetAllPostWithSearchAndSort(request);
                response.Result = result;
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

        public async Task<APIResponse> GetPostBy(Expression<Func<Post, bool>> predicate)
        {
            var response = new APIResponse();
            try
            {
                var result = await _postRepository.GetPostBy(predicate);
                if (result is null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.isSuccess = false;
                    response.ErrorMessages.Add("Not Found");
                }
                else
                {
                    response.Result = result;
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

        public async Task<APIResponse> GetPostById(Guid postId)
        {
            var response = new APIResponse();
            try
            {
                var result = await _postRepository.GetPostById(postId);
                if (result is null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.isSuccess = false;
                    response.ErrorMessages.Add("Not Found");
                }
                else
                {
                    response.Result = result;
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

        public async Task<APIResponse> UpdatePost(Post Post)
        {
            var response = new APIResponse();
            try
            {
                await _postRepository.UpdatePost(Post);
                response.Result = "Post updated successfully.";
                response.StatusCode = HttpStatusCode.OK;
                response.isSuccess = true;
            }
            catch (KeyNotFoundException ex)
            {
                var error = new APIException((int)HttpStatusCode.NotFound, ex.Message, ex.StackTrace);
                response.StatusCode = HttpStatusCode.NotFound;
                response.isSuccess = false;
                response.ErrorMessages.Add(error.Message);
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
