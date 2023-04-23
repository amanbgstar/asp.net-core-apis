using MixedAssignment.Domain.Context;
using MixedAssignment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixedAssignment.Repository.ProductRepo
{
    public class ProductRepo: IProductRepo
    {
        private readonly UserContext _context;
        public ProductRepo(UserContext context)
        {
            _context = context;
        }


        public List<Product> GetAllProducts()
        {
            var productList = _context.Products.ToList();
            return productList;
        }

        
        public List<Product> GetProductsbyuserid(int userid)
        {
            var productList = _context.Products.Where(x => x.userid == userid).ToList();
            return productList;
        }

        public List<Product> GetByuserId(int userid)
        {
            var products = _context.Products.Where(x => x.userid == userid).ToList();
            return products;
        }

        public Product GetProductbyId(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.ProductId == id);
            if (product != null)
            {
                return product;
            }
            return null;
        }

        public Product AddProduct(Product product)
        {
            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                var AddedProduct = GetProductbyId(product.ProductId);
                return AddedProduct;
            }
            catch
            {

            }
            return null;
        }

        public Product UpdateProduct(int id, Product product)
        {
            var existingProduct = _context.Products.FirstOrDefault(x => x.ProductId == id);
            if (product != null)
            {
                existingProduct.ProductName = product.ProductName;
                existingProduct.ProductCode = product.ProductCode;
                existingProduct.ProductImage = product.ProductImage;
                existingProduct.Category = product.Category;
                existingProduct.Brand = product.Brand;
                existingProduct.SellingPrice = product.SellingPrice;
                existingProduct.PurchasePrice = product.PurchasePrice;
                existingProduct.SellingDate = product.SellingDate;
                existingProduct.Stock = product.Stock;

                _context.SaveChanges();

            }
            return existingProduct;
        }

        public int DeleteProduct(int id)
        {
            var user = _context.Products.FirstOrDefault(X => X.ProductId == id);
            if (user != null)
            {
                _context.Products.Remove(user);
                _context.SaveChanges();
                return id;
            }
            return 0;

        }
    }
}
