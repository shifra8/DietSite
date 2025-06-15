using AutoMapper;
using Common.Dto;
using Common.Dto.Common.Dto;
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
            CreateMap<DietType, DietDto>().ReverseMap();
            CreateMap<WeeklyTracking, WeeklyTrackingDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();

            CreateMap<DietType, DietDto>()
                  .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.ImageUrl));

            // מיפוי מ-DietDto ל-DietType
            CreateMap<DietDto, DietType>()
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImagePath));
            CreateMap<CustomerFoodPreference, FoodPreferencesDto>().ReverseMap();
           
        }
    }
}
