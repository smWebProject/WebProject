using AutoMapper;
using DTO;
using Entities;

namespace MyWeb
{
    public class Mapper: Profile
    {
        public Mapper()
        {
            CreateMap<Product,ProductDto>().ForMember(dest=>dest.CategoryName, src=>src.MapFrom(p=>p.Category.Name)).ReverseMap();
            CreateMap<Category, CategoryDto>().ForMember(dest => dest.ProductsAmount, src => src.MapFrom(c => c.Products.Count())).ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserDTOwithoutPassword>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
        }
    }
}
