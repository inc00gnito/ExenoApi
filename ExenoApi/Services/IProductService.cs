using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExenoApi.Models;

namespace ExenoApi.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProductList();
        Task<Product> GetProductById(int id);
        Task<Product> CreateProduct(Product product);
        Task<int> UpdateProduct(Product product);
        Task<int> DeleteProduct(Product product);


    }
}
