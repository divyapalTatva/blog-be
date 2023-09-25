using System;
using System.Collections.Generic;

namespace blog_app_models.Models;

public partial class Tag
{
    public long TagId { get; set; }

    public string TagName { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<BlogTag> BlogTags { get; set; } = new List<BlogTag>();
}
