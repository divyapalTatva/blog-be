using System;
using System.Collections.Generic;

namespace blog_app_models.Models;

public partial class BlogTag
{
    public long Id { get; set; }

    public long BlogId { get; set; }

    public long TagId { get; set; }

    public virtual Blog Blog { get; set; } = null!;

    public virtual Tag Tag { get; set; } = null!;
}
