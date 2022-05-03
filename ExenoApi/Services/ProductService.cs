using System.Collections.Generic;
using System.Threading.Tasks;
using ExenoApi.Data;
using ExenoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ExenoApi.Services
{
    public class ProductService : IProductService
    {
        private readonly ExenoContext _context;

        public ProductService(ExenoContext context)
        {
            _context = context;
        }
        public async Task<List<Product>> GetProductList()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product> CreateProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<int> UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
            return await _context.SaveChangesAsync();
        }
    }
}
