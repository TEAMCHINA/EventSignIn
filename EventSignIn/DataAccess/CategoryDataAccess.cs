using System;
using System.Collections.Generic;
using System.Linq;
using EventSignIn.Models;

namespace EventSignIn.DataAccess
{
    public class CategoryDataAccess
    {
        public IList<CategoryModel> GetCategories()
        {
            using (var db = new EventSignInEntities())
            {
                var categories = db.Categories
                                   .Select(category => new CategoryModel
                                       {
                                           Id = category.Id,
                                           Name = category.Name,
                                           Description = category.Description,
                                       });

                return categories.ToList();
            }
        }

        public CategoryModel GetCategoryById(int id)
        {
            return GetCategories().FirstOrDefault(category => category.Id == id);
        }

        public int AddCategory(CategoryModel category)
        {
            using (var db = new EventSignInEntities())
            {
                var newCategory = new Category
                    {
                        Name = category.Name,
                        Description = category.Description
                    };

                db.Categories.Add(newCategory);
                db.SaveChanges();

                return newCategory.Id;
            }
        }

        public void UpdateCategory(CategoryModel category)
        {
            using (var db = new EventSignInEntities())
            {
                var dbCategory = db.Categories.FirstOrDefault(c => c.Id == category.Id);

                if (dbCategory == null)
                {
                    throw new InvalidOperationException(string.Format("Could not find Category with ID: {0}", category.Id));
                }

                dbCategory.Name = category.Name;
                dbCategory.Description = category.Description;
                db.SaveChanges();
            }
        }
    }
}