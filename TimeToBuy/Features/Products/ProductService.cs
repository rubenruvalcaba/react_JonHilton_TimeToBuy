using System;
using System.Collections.Generic;
using System.Linq;
using TimeToBuy.Domain;

namespace TimeToBuy.Features
{
    public class ProductService
    {

        readonly StoreContext _dbContext;

        public ProductService(StoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public  ProductListModel GetProductList()
        {
            var model = new ProductListModel();
            var products = _dbContext.Products;
            foreach (var product in products)
            {
                model.Products.Add(new ProductListModel.ProductListItem()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description
                });
            }

            return model;

        }

        public  ProductDetailsModel GetProductDetails(int id)
        {
           
            var product = _dbContext.Products.Find(id);
            if (product != null)
            {
                return new ProductDetailsModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price
                };
            }
            else
            {
                return null;
            }
            
        }
    }
}