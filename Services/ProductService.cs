using AutoMapper;
using LessonThree.Contracts.Requests.Products;
using Microsoft.Extensions.Caching.Memory;
using StoreMarket.Abstractions;
using StoreMarket.Context;
using StoreMarket.Contracts.Responses;
using StoreMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreMarket.Services
{
    public class ProductService : IProductService
    {
        private readonly StoreContext _storeContext;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;


        public ProductService(StoreContext context, IMapper mapper, IMemoryCache memoryCache)
        {
            _storeContext = context;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        public int AddProduct(ProductCreateRequest product)
        {
            var mappedProduct = _mapper.Map<Product>(product);
            _storeContext.Products.Add(mappedProduct);
            _storeContext.SaveChanges();
            _memoryCache.Remove("products");
            return mappedProduct.Id;
        }

        public IEnumerable<ProductResponse> GetProducts()
        {
            if (_memoryCache.TryGetValue("products", out List<ProductResponse> cachedProducts))
            {
                return cachedProducts;
            }

            var products = _storeContext.Products.Select(p => _mapper.Map<ProductResponse>(p)).ToList();
            _memoryCache.Set("products", products, TimeSpan.FromMinutes(30));

            return products;
        }

        public ProductResponse GetProductById(int id)
        {
            var product = _storeContext.Products.FirstOrDefault(p => p.Id == id);
            return product != null ? _mapper.Map<ProductResponse>(product) : null;
        }

        public bool DeleteProduct(int id)
        {
            var product = _storeContext.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _storeContext.Products.Remove(product);
                _storeContext.SaveChanges();
                _memoryCache.Remove("products");
                return true;
            }
            return false;
        }
        /*
        public bool UpdatePrice(int id, decimal price)
        {
            var product = _storeContext.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                product.Price = price;
                _storeContext.SaveChanges();
                _memoryCache.Remove("products");
                return true;
            }
            return false;
        }
        */
        public bool UpdatePrice(int idProduct, decimal price)
        {
            var product = _storeContext.Products.FirstOrDefault(p => p.Id == idProduct);
            if (product != null)
            {
                product.Price = price;
                _storeContext.SaveChanges();
                _memoryCache.Remove("products");
                return true;
            }
            return false;
        }

        public bool DeleteCategory(string category)
        {
            var products = _storeContext.Products.Where(p => p.Category != null && p.Category.Name == category);
            ;
            foreach (var product in products)
            {
                product.Category = null;
            }
            _storeContext.SaveChanges();
            _memoryCache.Remove("products");
            return true;
        }
    }
}

