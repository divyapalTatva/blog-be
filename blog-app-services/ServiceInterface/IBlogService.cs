using blog_app_models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog_app_services.ServiceInterface
{
    public interface IBlogService
    {
        public Task<JsonResult> GetAllBlogs(string? search);
        public Task<JsonResult> GetBlogById(int? id);
        public Task<JsonResult> AddUpdateBlogData(BlogVM blogData);
        public Task<JsonResult> DeleteBlogData(int id);
    }
}
