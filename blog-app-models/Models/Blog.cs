using System;
using System.Collections.Generic;

namespace blog_app_models.Models;

public partial class Blog
{
    public long BlogId { get; set; }

    public string BlogTitle { get; set; } = null!;

    public string BlogDescription { get; set; } = null!;

    public string BlogImage { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<BlogTag> BlogTags { get; set; } = new List<BlogTag>();
}
