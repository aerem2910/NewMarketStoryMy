using LessonThree.Contracts.Requests.Products;
using StoreMarket.Contracts.Responses;

namespace StoreMarket.Abstractions
{
    public interface IProductService
    {
        public int AddProduct(ProductCreateRequest product);
        public IEnumerable<ProductResponse> GetProducts();

        public ProductResponse GetProductById(int id);
        public bool DeleteProduct(int id);
        public bool DeleteCategory(string category);
        bool UpdatePrice(int idProduct, decimal price);

    }
}
