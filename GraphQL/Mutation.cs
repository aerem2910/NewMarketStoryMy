using LessonThree.Abstractions;
using LessonThree.Contracts.Requests.Categories;
using LessonThree.Contracts.Requests.Products;
using StoreMarket.Abstractions;

namespace LessonThree.GraphQL
{
    public class Mutation
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public Mutation(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public int AddProduct(ProductCreateRequest input) => _productService.AddProduct(input);
        public bool DeleteProduct(int id) => _productService.DeleteProduct(id);
        public bool UpdatePrice(int id, decimal price) => _productService.UpdatePrice(id, price);
        public bool DeleteCategory(string category) => _productService.DeleteCategory(category);

        public int AddCategory(CreateCategoryRequest createCategoryRequest) => _categoryService.AddCategory(createCategoryRequest);
    }
}
