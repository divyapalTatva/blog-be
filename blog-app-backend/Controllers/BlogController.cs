using blog_app_common.GenericResponse;
using blog_app_models.ViewModels;
using blog_app_services.ServiceInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace blog_app_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {

        #region Dependency Injection
        private readonly IBlogService BlogService;

        public BlogController(IBlogService _BlogService)
        {
            BlogService = _BlogService;
        }
        #endregion

        #region GetAllBlogs
        //[Authorize]
        [HttpGet("GetAllBlogs")]
        public async Task<JsonResult> GetAllBlogs(string? search)
        {
            return await BlogService.GetAllBlogs(search);
            //return new JsonResult(new GenericResponse<string> { Message = ResponseMessages.InternalServerError, StatusCode = blog_app_models.GenericResponse.StatusCodes.BadRequest, Result = false });

        }

        #endregion 
        #region GetBlogById
        //[Authorize]
        [HttpGet("GetBlogById")]
        public async Task<JsonResult> GetBlogById(int? id)
        {
            return await BlogService.GetBlogById(id);
            //return new JsonResult(new GenericResponse<string> { Message = ResponseMessages.InternalServerError, StatusCode = blog_app_models.GenericResponse.StatusCodes.BadRequest, Result = false });

        }
        #endregion 

        #region AddUpdateBlog
        [Authorize]
        [HttpPut("AddUpdateBlogData")]
        public async Task<JsonResult> AddUpdateBlog([FromBody] BlogVM? blogData)
        {
            return await BlogService.AddUpdateBlogData(blogData);
            //return new JsonResult(new GenericResponse<string> { Message = ResponseMessages.InternalServerError, StatusCode = blog_app_models.GenericResponse.StatusCodes.BadRequest, Result = false });

        }
        #endregion 
        
        #region DeleteBlogData
        [Authorize]
        [HttpDelete("DeleteBlogData")]
        public async Task<JsonResult> DeleteBlogData(int id)
        {
            return await BlogService.DeleteBlogData(id);
            //return new JsonResult(new GenericResponse<string> { Message = ResponseMessages.InternalServerError, StatusCode = blog_app_models.GenericResponse.StatusCodes.BadRequest, Result = false });

        }
        #endregion
    }
}
