using blog_app_common.GenericResponse;
using blog_app_models.ViewModels;
using blog_app_services.ServiceInterface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog_app_services.ServiceRepository
{


    public class BlogService : IBlogService
    {

        private static readonly Dictionary<int, BlogVM> Blogs = InitialData.BlogData();

        #region GetAllMissionApplication
        public async Task<JsonResult> GetAllBlogs(string? search)
        {
            try
            {
                if (string.IsNullOrEmpty(search))
                {
                    var AllBlogs = Blogs.Values.ToList();
                    return new JsonResult(new GenericResponse<List<BlogVM>> { Data = AllBlogs, StatusCode = StatusCodes.OK, Result = true });
                }
                else
                {
                    var SearchedBlog = Blogs.Values.Where(b => b.Title.Contains(search) || b.Description.Contains(search) || b.Tags.Contains(search)).ToList();
                    return new JsonResult(new GenericResponse<List<BlogVM>> { Data = SearchedBlog, StatusCode = StatusCodes.OK, Result = true });
                }
            }
            catch
            {
                return new JsonResult(new GenericResponse<string> { Message = ResponseMessages.InternalServerError, StatusCode = StatusCodes.InternalServerError, Result = false });
            }
        }
        #endregion

        #region GetBlogById
        public async Task<JsonResult> GetBlogById(int? id)
        {
            try
            {
                if (id != 0)
                {
                    var SearchedBlog = Blogs.Values.Where(b => b.Id.Equals(id)).ToList();
                    return new JsonResult(new GenericResponse<List<BlogVM>> { Data = SearchedBlog, StatusCode = StatusCodes.OK, Result = true });
                }
                else
                {
                    return new JsonResult(new GenericResponse<string> { Message = ResponseMessages.SomethingWentWrong, StatusCode = StatusCodes.InternalServerError, Result = true });
                }
            }
            catch
            {
                return new JsonResult(new GenericResponse<string> { Message = ResponseMessages.InternalServerError, StatusCode = StatusCodes.InternalServerError, Result = false });
            }
        }
        #endregion


        #region AddUpdateBlogData
        public async Task<JsonResult> AddUpdateBlogData(BlogVM blogData)
        {
            try
            {
                if (blogData.Id == 0)
                {
                    int newBlogId = Blogs.Keys.Last() + 1;
                    blogData.Id = newBlogId;
                    Blogs.Add(newBlogId, blogData);
                    return new JsonResult(new GenericResponse<List<BlogVM>> { Message = ResponseMessages.BlogAddedSuccess, Data = null, StatusCode = StatusCodes.OK, Result = true });
                }
                else
                {
                    var blogDataToBeUpdated = Blogs[blogData.Id];
                    blogDataToBeUpdated.UpdatedAt = DateTime.Now;
                    blogDataToBeUpdated.Title = blogData.Title;
                    blogDataToBeUpdated.Tags = blogData.Tags;
                    blogDataToBeUpdated.Description = blogData.Description;
                    blogDataToBeUpdated.ImageUrl = blogData.ImageUrl;
                    Blogs[blogData.Id] = blogDataToBeUpdated;
                    return new JsonResult(new GenericResponse<string> { Message = ResponseMessages.BlogUpdatedSuccess, StatusCode = StatusCodes.OK, Result = true });
                }
            }
            catch
            {
                return new JsonResult(new GenericResponse<string> { Message = ResponseMessages.InternalServerError, StatusCode = StatusCodes.InternalServerError, Result = false });
            }
        }
        #endregion

        #region DeleteBlogData
        public async Task<JsonResult> DeleteBlogData(int id)
        {
            try
            {
                if (id != 0)
                {
                    Blogs.Remove(id);
                    return new JsonResult(new GenericResponse<string> { Message = ResponseMessages.BlogDeletedSuccess, StatusCode = StatusCodes.OK, Result = true });
                }
                else
                {
                    return new JsonResult(new GenericResponse<string> { Message = ResponseMessages.InternalServerError, StatusCode = StatusCodes.InternalServerError, Result = false });
                }

            }
            catch
            {
                return new JsonResult(new GenericResponse<string> { Message = ResponseMessages.InternalServerError, StatusCode = StatusCodes.InternalServerError, Result = false });

            }
        }
        #endregion
    }
}
