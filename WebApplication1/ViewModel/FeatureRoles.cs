using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.ViewModel
{
    public class FeatureRoles
    {
        public IEnumerable<Roles> Role { get; set; }
        public IEnumerable<Features> Feature { get; set; }
    }
}