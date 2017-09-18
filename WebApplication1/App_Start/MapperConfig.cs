using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Models;
using System.Web;
using WebApplication1.ViewModel;

namespace WebApplication1.App_Start
{
    public class MapperConfig
    {
        public static void Mappers()
        {
            Mapper.Initialize(
                x => x.CreateMap<EmployeeVM, Employee>().ReverseMap()
                );
        }
    }
}