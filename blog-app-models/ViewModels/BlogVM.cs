using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog_app_models.ViewModels
{
    public class BlogVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string>? Tags { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt{ get; set; }
        public DateTime? DeletedAt{ get; set; }
    }
}
