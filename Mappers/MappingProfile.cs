using AutoMapper;
using LessonThree.Contracts.Requests.Categories;
using LessonThree.Contracts.Requests.Products;
using LessonThree.Contracts.Responses;
using StoreMarket.Contracts.Responses;
using StoreMarket.Models;

namespace StoreMarket.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductResponse>().ReverseMap();
            CreateMap<Product, ProductCreateRequest>().ReverseMap();
            CreateMap<Product, ProductUpdateRequest>().ReverseMap();
            CreateMap<Product, ProductDeleteRequest>().ReverseMap();

            CreateMap<Category, CreateCategoryRequest>().ReverseMap();
            CreateMap<Category, CategoryResponse>().ReverseMap();
        }
    }
}
