using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExenoApi.Models;
using ExenoApi.Services;

namespace ApiTests
{
    internal class ProductServiceFake : IProductService
    {
        private readonly List<Product> _productList;
        private int index = 4;
        public ProductServiceFake()
        {
            _productList = new List<Product>()
            {
                new Product()
                {
                    Id = 1, Name = "Product One", Description = "This a short description for the first product",
                    Price = 20, CreateDate = DateTime.Today
                },
                new Product()
                {
                    Id = 2, Name = "Product Two", Description = "This a short description for the second product",
                    Price = 50, CreateDate = DateTime.Today
                },
                new Product()
                {
                    Id = 3, Name = "Product Three", Description = "This a short description for the third product",
                    Price = 10.99, CreateDate = DateTime.Today
                },
            };
        }
        public async Task<IEnumerable<Product>> GetProductList()
        {
            return _productList;
        }

        public async Task<Product> GetProductById(int id)
        {
            return _productList.FirstOrDefault(p => p.Id == id);
        }

        public async Task<Product> CreateProduct(Product product)
        {
            product.Id = index;
            index++;
            _productList.Add(product);
            return product;
        }

        public Task<int> UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }


        public async Task<int> DeleteProduct(Product product)
        {
            _productList.Remove(product);
            return product.Id;
        }
    }
}
