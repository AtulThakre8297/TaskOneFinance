using AutoMapper;
using ProductAppAPI.Models;
using TaskOneFinance.Models;

namespace TaskOneFinance.Configuration
{
    public class Mapping:Profile
    {
        public Mapping() 
        {
            CreateMap<User,LoginDTO>().ReverseMap();
            CreateMap<User, RegisterDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
