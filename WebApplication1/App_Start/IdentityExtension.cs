﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;

namespace WebApplication1.App_Start
{
    public static class IdentityExtensions
    {
        public static ApplicationUser GetUser(this IIdentity identity)
        {
            return GetClaim<ApplicationUser>(identity, UserClaims.User);
        }
    }
}