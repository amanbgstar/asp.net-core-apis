using MixedAssignment.ViewModel.ProductVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixedAssignment.Service.ProductService
{
    public interface IProductService
    {
        List<ProductsGetVM> GetAllProducts();
        ProductsGetVM GetProductById(int id);
        ProductsVM AddProduct(ProductsVM product);
        ProductsVM UpdateProduct(int id, ProductsVM productUp);
        int DeleteProduct(int id);
        List<ProductsGetVM> GetProductsByuserId(int userId);
        List<ProductsGetVM> GetProductsbyUserid(int userid);
    }
}
