
using OnlineShopApp.Models;

namespace OnlineShopApp.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }

        //public async Task<List<Product>> GetAllProducts()
        //{
        //    var products = await _context.Products.ToListAsync();
        //    return products;
        //}

        public async Task<Product?> GetSingleProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product is null)
                return null;

            return product;
        }

        public async Task<List<Product>> AddProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return await _context.Products.ToListAsync();
        }

        public async Task<List<Product>?> UpdateProduct(int id, Product request)
        {
            var product = await _context.Products.FindAsync(id);

            if (product is null)
                return null;

            product.Name = request.Name;
            product.Description = request.Description;
            product.Quantity = request.Quantity;

            await _context.SaveChangesAsync();

            return await _context.Products.ToListAsync();
        }

        public async Task<List<Product>?> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product is null)
                return null;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return await _context.Products.ToListAsync();
        }
    }
}
