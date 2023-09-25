using blog_app_common.GenericResponse;
using blog_app_models.BlogSpotContext;
using blog_app_models.Models;
using blog_app_models.ViewModels;
using blog_app_services.ServiceInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace blog_app_services.ServiceRepository
{


    public class BlogService : IBlogService
    {


        #region Dependency Injection of DbContext 

        private readonly BlogSpotContext BlogContext;

        public BlogService(BlogSpotContext _BlogContext)
        {
            BlogContext = _BlogContext;
        }
        #endregion

      

        #region GetAllBlogs
        public async Task<JsonResult> GetAllBlogs(string? search)
        {
            try
            {
                //var AllBlogs = Blogs.Values.ToList();
                var AllBlogsData = BlogContext.Blogs.ToList();

                List<BlogsVm> blogsData = new List<BlogsVm>();
                foreach (var blogData in AllBlogsData)
                {
                    List<BlogTagData> blogTags = BlogContext.BlogTags.Where(x => x.BlogId == blogData.BlogId).Include(x => x.Tag).
                        Select(x => new BlogTagData() { TagId = (int)x.TagId, TagName = x.Tag.TagName })
                    .ToList();
                    BlogsVm data = new BlogsVm()
                    {
                        Description = blogData.BlogDescription,
                        Id = (int)blogData.BlogId,
                        ImageUrl = blogData.BlogImage,
                        Title = blogData.BlogTitle,
                        Tags = blogTags
                    };

                    blogsData.Add(data);

                }


                if (string.IsNullOrEmpty(search))
                {
                    return new JsonResult(new GenericResponse<List<BlogsVm>> { Data = blogsData, StatusCode = StatusCodes.OK, Result = true });
                }
                else
                {

                    var SearchedBlog = blogsData.Where(b => b.Title.ToLower().Contains(search.ToLower()) || b.Description.ToLower().Contains(search.ToLower())).ToList();
                    return new JsonResult(new GenericResponse<List<BlogsVm>> { Data = SearchedBlog, StatusCode = StatusCodes.OK, Result = true });
                }
            }
            catch
            {
                return new JsonResult(new GenericResponse<string> { Message = ResponseMessages.InternalServerError, StatusCode = StatusCodes.InternalServerError, Result = false });
            }
        }

        

        #endregion

        #region GetAllTags

        public async Task<JsonResult> GetAllTags()
        {
            try
            {
                List<Tag> AllTags = BlogContext.Tags.ToList();
                return new JsonResult(new GenericResponse<List<Tag>> { Data = AllTags, StatusCode = StatusCodes.OK, Result = true });
            }
            catch
            {
                return new JsonResult(new GenericResponse<string> { Message = ResponseMessages.InternalServerError, StatusCode = StatusCodes.InternalServerError, Result = false });
            }

        }
        #endregion

        #region AddNewTag
        public async Task<JsonResult> AddNewTag(BlogTagData newTag)
        {
            try
            {
                Tag newTagToBeAdded = new()
                {
                    TagName = newTag.TagName,
                };

                BlogContext.Tags.Add(newTagToBeAdded);
                BlogContext.SaveChanges();

                return new JsonResult(new GenericResponse<Tag> { Data = newTagToBeAdded, StatusCode = StatusCodes.OK, Result = true });
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
                    var BlogData = BlogContext.Blogs.Where(b => b.BlogId == id).FirstOrDefault();
                    if (BlogData != null)
                    {
                        List<BlogTagData> blogTags = BlogContext.BlogTags.Where(x => x.BlogId == BlogData.BlogId).Include(x => x.Tag).
                            Select(x => new BlogTagData() { TagId = (int)x.TagId, TagName = x.Tag.TagName })
                        .ToList();
                        BlogsVm blogsData = new BlogsVm()
                        {
                            Description = BlogData.BlogDescription,
                            Id = (int)BlogData.BlogId,
                            ImageUrl = BlogData.BlogImage,
                            Title = BlogData.BlogTitle,
                            Tags = blogTags
                        };

                        return new JsonResult(new GenericResponse<BlogsVm> { Data = blogsData, StatusCode = StatusCodes.OK, Result = true });
                    }
                    else
                    {
                        return new JsonResult(new GenericResponse<List<BlogVM>> { Message = ResponseMessages.NoDataFound, StatusCode = StatusCodes.NotFound, Result = true });
                    }
                }
                else
                {
                    return new JsonResult(new GenericResponse<List<BlogVM>> { Message = ResponseMessages.NoDataFound, StatusCode = StatusCodes.NotFound, Result = true });
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
                    //int newBlogId = Blogs.Keys.Last() + 1;
                    //blogData.Id = newBlogId;
                    //Blogs.Add(newBlogId, blogData);

                    Blog newBlog = new()
                    {
                        BlogTitle = blogData.Title,
                        BlogDescription = blogData.Description,
                        BlogImage = blogData.ImageUrl,
                    };
                    BlogContext.Blogs.Add(newBlog);
                    BlogContext.SaveChanges();

                    foreach (var id in blogData.Tags)
                    {
                        BlogTag newTag = new()
                        {
                            BlogId = newBlog.BlogId,
                            TagId = id,
                        };
                        BlogContext.BlogTags.Add(newTag);
                        BlogContext.SaveChanges();

                    }
                    return new JsonResult(new GenericResponse<List<BlogVM>> { Message = ResponseMessages.BlogAddedSuccess, Data = null, StatusCode = StatusCodes.OK, Result = true });
                }
                else
                {
                    Blog blog = BlogContext.Blogs.Where(b=>b.BlogId == blogData.Id).FirstOrDefault();


                    if (blog!=null)
                    {

                        blog.UpdatedAt = DateTime.Now;
                        blog.BlogTitle = blogData.Title;
                        blog.BlogDescription = blogData.Description;
                        blog.BlogImage = blogData.ImageUrl;

                        BlogContext.Blogs.Update(blog);
                        BlogContext.SaveChanges();

                        var oldTags=BlogContext.BlogTags.Where(bt=>bt.BlogId==blogData.Id).ToList();

                        foreach (var tag in oldTags)
                        {
                            BlogContext.Remove(tag);
                            BlogContext.SaveChanges();
                        }

                        foreach (var id in blogData.Tags)
                        {
                            BlogTag newTag = new()
                            {
                                TagId = id,
                                BlogId = blogData.Id
                            };
                            BlogContext.BlogTags.Add(newTag);
                            BlogContext.SaveChanges();
                        }

                        return new JsonResult(new GenericResponse<string> { Message = ResponseMessages.BlogUpdatedSuccess, StatusCode = StatusCodes.OK, Result = true });
                    }
                    else
                    {
                        return new JsonResult(new GenericResponse<string> { Message = ResponseMessages.SomethingWentWrong, StatusCode = StatusCodes.InternalServerError, Result = true });
                    }

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
                if (id!=0)
                {
                    Blog blogToBeDeleted = BlogContext.Blogs.Where(b => b.BlogId == id).FirstOrDefault();
                    if (blogToBeDeleted != null)
                    {
                        blogToBeDeleted.DeletedAt = DateTime.Now;
                        BlogContext.Blogs.Update(blogToBeDeleted);
                        BlogContext.SaveChanges();

                        var tagsToBeRemoved = BlogContext.BlogTags.Where(bt => bt.BlogId == blogToBeDeleted.BlogId).ToList();

                        foreach (var tag in tagsToBeRemoved)
                        {
                            BlogContext.Remove(tag);
                        }
                        return new JsonResult(new GenericResponse<string> { Message = ResponseMessages.BlogDeletedSuccess, StatusCode = StatusCodes.OK, Result = true });

                    }
                    else
                    {
                        return new JsonResult(new GenericResponse<string> { Message = ResponseMessages.BlogDeletedFailure, StatusCode = StatusCodes.BadRequest, Result = true });
                    }
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
