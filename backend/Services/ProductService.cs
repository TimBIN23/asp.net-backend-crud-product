using backend.DTOs;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class ProductService
    {
        private readonly UsmDb _db;

        public ProductService(UsmDb context)
        {
            _db = context;
        }

        // Get all products
        public async Task<List<Product>> GetAllAsync()
        {
            return await _db.Products.AsNoTracking().ToListAsync();
        }

        // Get product by Id
        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _db.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        // Create product
        public async Task<Product> CreateAsync(Product prod)
        {
            if (prod == null)
                throw new ArgumentNullException(nameof(prod));

            _db.Products.Add(prod);
            await _db.SaveChangesAsync();
            return prod;
        }

        // Update product
        public async Task<Product?> UpdateAsync(int id, ProductDto data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            var product = await _db.Products.FindAsync(id);
            if (product == null) return null;

            product.Name = data.Name;
            product.Price = data.Price;

            _db.Products.Update(product);
            await _db.SaveChangesAsync();
            return product;
        }

        // Delete product
        public async Task<bool> DeleteAsync(int id)
        {
            var prod = await _db.Products.FindAsync(id);
            if (prod == null) return false;

            _db.Products.Remove(prod);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
