using AutoMapper;
using DataAccess.Models;
using WebApplication1.ViewModel;


namespace WebApplication1.Mappings
{
    public class ModelMapping : IAutoMap
    {
        public void Initialize()
        {
            Mapper.CreateMap<EmployeeVM, Employee>();
            // Mapper.CreateMap<EmployeeVM, Employee>();
            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap(EmployeeVM, Employee);
            //    cfg.AddProfile(EmployeeVM);
            //});
            //var mapper = config.CreateMapper();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeVM>();
            });
        }
    }
}