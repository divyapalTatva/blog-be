using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog_app_services.ServiceInterface
{
    public interface IAuthService
    {
        public Task<JsonResult> AuthUser(string? password);
    }
}
