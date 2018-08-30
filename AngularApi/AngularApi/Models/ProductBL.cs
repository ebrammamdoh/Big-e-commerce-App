using AngularApi.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularApi.Models
{
    public class ProductBL
    {
        DataContext context = new DataContext();

        public List<ProductVM> getAllProduct()
        {
            
            return context.Products.Select(p => new ProductVM
            {
                C_id = p.ProductId,
                cat_id = p.category.CategoryId,
                cat_name = p.category.CategoryName,
                code = p.Code,
                imgUrl = p.ImgUrl,
                name = p.Name,
                price = p.Price,
                qty = p.Quentity,
                rate = p.Rate,
            }).ToList();
        }
        public ProductVM getProductById(int id)
        {
            return context.Products.Select(p=>new ProductVM
            {
                C_id = p.ProductId,
                cat_id = p.category.CategoryId,
                cat_name = p.category.CategoryName,
                code = p.Code,
                imgUrl = p.ImgUrl,
                name = p.Name,
                price = p.Price,
                qty = p.Quentity,
                rate = p.Rate,
            }).Where(p => p.C_id == id).FirstOrDefault();
        }
        public bool deleteProduct(int id)
        {
            var product = context.Products.Where(p => p.ProductId == id).FirstOrDefault();
            context.Products.Remove(product);
            int x = context.SaveChanges();
            return x>1 ? true : false;
        }
        public int updateProduct(int id, ProductVM prod)
        {
            var product = context.Products.Where(p => p.ProductId == id).FirstOrDefault();
            product.Name = prod.name;
            product.Code = prod.code;
            product.Quentity = prod.qty;
            prod.price = prod.price;
            product.Rate = prod.rate;
            product.category.CategoryId = prod.cat_id;
            product.category.CategoryName = prod.cat_name;
            return context.SaveChanges();

           // return x >  ? true : false;
        }
        public int addProduct(ProductVM product)
        {
            Product prod = new Product();
            //Category cat = new Category();
            var catego = context.Categories.Where(c => c.CategoryId == product.cat_id).FirstOrDefault();

            prod.category = catego;
            prod.Code = product.code;
            prod.ProductId = product.C_id;
            prod.ImgUrl = product.imgUrl;
            prod.Name = product.name;
            prod.Price = product.price;
            prod.Quentity = product.qty;
            prod.Rate = product.rate;
            context.Products.Add(prod);
            return context.SaveChanges();
        }
    }
}