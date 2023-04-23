using MixedAssignment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixedAssignment.Repository.ProductRepo
{
    public interface IProductRepo
    {
        List<Product> GetAllProducts();
        Product GetProductbyId(int id);
        Product AddProduct(Product product);
        Product UpdateProduct(int id, Product product);
        int DeleteProduct(int id);
        List<Product> GetByuserId(int userid);
        List<Product> GetProductsbyuserid(int userid);
    }
}
