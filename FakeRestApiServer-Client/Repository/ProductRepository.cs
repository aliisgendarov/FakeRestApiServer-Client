using FakeRestApiServer_Client.DataAccess;
using FakeRestApiServer_Client.Entities;
using Microsoft.EntityFrameworkCore;

namespace FakeRestApiServer_Client.Repository
{
    public class ProductRepository
    {
        private readonly FakeApiDbContext _context;

        public ProductRepository(FakeApiDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllProduct()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetProduct(int id)
        {
            return await _context.Products.SingleOrDefaultAsync(p => p.Id == id);
        }

        public bool Add(Product product)
        {
            _context.Products.Add(product);
            var result = _context.SaveChanges();
            return result > 0;
        }
        public bool Update(Product product)
        {
            _context.Products.Update(product);
            var result = _context.SaveChanges();
            return result > 0;
        }
        public async Task<bool> Delete(int id)
        {
            var product = await _context.Products.SingleOrDefaultAsync(p => p.Id == id);
            if (product is null)
            {
                return false;
            }

            _context.Products.Remove(product);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
