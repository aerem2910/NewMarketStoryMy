using AutoMapper;
using LessonThree.Abstractions;
using LessonThree.Contracts.Requests.Categories;
using LessonThree.Contracts.Responses;
using StoreMarket.Abstractions;
using StoreMarket.Context;
using StoreMarket.Models;
using System.Collections.Generic;
using System.Linq;

namespace LessonThree.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly StoreContext _storeContext;

        public CategoryService(StoreContext storeContext, IMapper mapper)
        {
            _storeContext = storeContext;
            _mapper = mapper;
        }

        public int AddCategory(CreateCategoryRequest createCategoryRequest)
        {
            var mappedCategory = _mapper.Map<Category>(createCategoryRequest);
            _storeContext.Categories.Add(mappedCategory);
            _storeContext.SaveChanges();
            return mappedCategory.Id;
        }

        public IEnumerable<CategoryResponse> GetCategories()
        {
            return _storeContext.Categories.Select(c => _mapper.Map<CategoryResponse>(c));
        }
    }
}
