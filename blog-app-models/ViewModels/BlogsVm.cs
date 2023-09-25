using blog_app_models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog_app_models.ViewModels
{
    public class BlogsVm
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<BlogTagData> Tags { get; set; }
        public string ImageUrl { get; set; }
    }
}
