using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.ViewModel
{
    public class Roles
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
    }
}
