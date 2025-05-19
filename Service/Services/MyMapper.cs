using AutoMapper;
using Common.Dto;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
namespace Service
{
    public class MyMapper : Profile
    {
        //treatment in cacse
        string path = Path.Combine(Environment.CurrentDirectory, "Images/");
        public MyMapper()
        {
            CreateMap<Customer, CustomerDto>().ForMember("ImagePath", x => x.MapFrom(y => File.ReadAllBytes(path + y.ImageUrl)));
            CreateMap<CustomerDto, Customer>().ForMember("ImageUrl", x => x.MapFrom(y => y.fileImage.FileName));//check this line
            CreateMap<WeeklyTracking, WeeklyTrackingDto>().ReverseMap();


        }
    }
}
