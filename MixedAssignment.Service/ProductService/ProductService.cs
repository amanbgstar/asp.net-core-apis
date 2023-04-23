using AutoMapper;
using MixedAssignment.Domain.Models;
using MixedAssignment.Repository.ProductRepo;
using MixedAssignment.ViewModel.ProductVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixedAssignment.Service.ProductService
{
    public class ProductService: IProductService
    {
        private readonly IProductRepo _productRepo;
        private readonly IMapper _mapper;
        public ProductService(IProductRepo productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }

        public List<ProductsGetVM> GetAllProducts()
        {
            var ListOfData = new List<ProductsGetVM>();
            var allData = _productRepo.GetAllProducts();
            if (allData == null)
            {
                return null;
            }

            foreach (var product in allData)
            {
                var productsVMdata = _mapper.Map<ProductsGetVM>(product);
                ListOfData.Add(productsVMdata);
            }
            return ListOfData;
        }


        public List<ProductsGetVM> GetProductsbyUserid(int userid)
        {
            var ListOfData = new List<ProductsGetVM>();
            var allData = _productRepo.GetProductsbyuserid(userid);
            if (allData == null)
            {
                return null;
            }

            foreach (var product in allData)
            {
                var productsVMdata = _mapper.Map<ProductsGetVM>(product);
                ListOfData.Add(productsVMdata);
            }
            return ListOfData;
        }
        public List<ProductsGetVM> GetProductsByuserId(int userId)
        {
            var ListOfData = new List<ProductsGetVM>();
            var allData = _productRepo.GetByuserId(userId);
            if (allData == null)
            {
                return null;
            }
            foreach (var product in allData)
            {
                var productsVMdata = _mapper.Map<ProductsGetVM>(product);
                ListOfData.Add(productsVMdata);
            }
            return ListOfData;
        }

        public ProductsGetVM GetProductById(int id)
        {
            var product = _productRepo.GetProductbyId(id);
            if (product != null)
            {
                var updatedproduct = _mapper.Map<ProductsGetVM>(product);
                return updatedproduct;
            }
            return null;
        }

        public ProductsVM AddProduct(ProductsVM product)
        {
            var ConProduct = _mapper.Map<Product>(product);
            var addedProduct = _productRepo.AddProduct(ConProduct);
            return _mapper.Map<ProductsVM>(addedProduct);
        }

        public ProductsVM UpdateProduct(int id, ProductsVM productUp)
        {
            var product = _mapper.Map<Product>(productUp);
            var updatedProduct = _productRepo.UpdateProduct(id, product);
            return _mapper.Map<ProductsVM>(updatedProduct);
        }

        public int DeleteProduct(int id)
        {
            return _productRepo.DeleteProduct(id);
        }
    }
}
