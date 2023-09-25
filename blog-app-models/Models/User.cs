using System;
using System.Collections.Generic;

namespace blog_app_models.Models;

public partial class User
{
    public long UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;
}
