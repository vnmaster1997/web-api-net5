using RestfulAPI.Data;
using RestfulAPI.Models;
using RestfulAPI.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace RestfulAPI.Services
{
    public class CategoryInMemory : ICategoryRepository
    {
        static List<CategoryVM> categories = new List<CategoryVM>{
            new CategoryVM {Id = 1, Name = "Xe Dap"},
            new CategoryVM {Id = 2, Name = "Xe May"},
            new CategoryVM {Id = 3, Name = "O to"},
            new CategoryVM {Id = 4, Name = "May bay"}    
        };
        public CategoryVM Add(Models.Category category)
        {
            CategoryVM _category = new CategoryVM
            {
                Id = categories.Max(c => c.Id) + 1,
                Name = category.Name,
            };
            categories.Add(_category);
            return _category;
        }

        public void Delete(int id)
        {
            var _category = categories.SingleOrDefault(c => c.Id == id);
            categories.Remove(_category);
        }

        public List<CategoryVM> GetAll()
        {
            return categories;
        }

        public CategoryVM GetById(int id)
        {
            return categories.SingleOrDefault(c => c.Id == id);
        }

        public void Update(CategoryVM category)
        {
            var _category = categories.SingleOrDefault(c => c.Id == category.Id);
            if(_category != null)
            {
                _category.Name = category.Name;
            }
        }
    }
}
