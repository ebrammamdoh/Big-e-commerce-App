using AngularApi.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularApi.Models
{
    public class CategoryBL
    {
        DataContext context = new DataContext();
        public List<CategoryVM> getAllCategories()
        {
            return context.Categories.Select(c => new CategoryVM
            {
                C_id = c.CategoryId,
                C_name = c.CategoryName,
                C_products = c.products.Count,
            }).ToList();
        }
        public int Add(CategoryVM cat)
        {
            Category category = new Category();
            category.CategoryName = cat.C_name;
            context.Categories.Add(category);
            return context.SaveChanges();
        }
        public int updateCategory(CategoryVM cat)
        {
            var catego = context.Categories.Where(c => c.CategoryId == cat.C_id).FirstOrDefault();
            catego.CategoryName = cat.C_name;
            return context.SaveChanges();
        }
        public int deleteCategory(int id)
        {
            var catego = context.Categories.Where(c => c.CategoryId == id).FirstOrDefault();
            context.Categories.Remove(catego);
            return context.SaveChanges();
        }
    }
}