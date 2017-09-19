﻿using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace WebApplication1.ViewModel
{
    public class EmployeeVM : BaseEntity
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Department { get; set; }
        public String Designation { get; set; }
        public float Salary { get; set; }
        public SelectList Country { get; set; }
        public SelectList Gender { get; set; }
    }
}