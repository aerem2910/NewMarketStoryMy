using LessonThree.Abstractions;
using LessonThree.Contracts.Responses;
using StoreMarket.Abstractions;
using StoreMarket.Contracts.Responses;
using System.Collections.Generic;

namespace LessonThree.GraphQL
{
    public class Query
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public Query(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public IEnumerable<CategoryResponse> GetCategories() => _categoryService.GetCategories();
        public IEnumerable<ProductResponse> GetProducts() => _productService.GetProducts();
        public ProductResponse GetProductById(int id) => _productService.GetProductById(id);
    }
}
