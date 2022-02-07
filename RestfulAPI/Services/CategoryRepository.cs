using RestfulAPI.Data;
using RestfulAPI.Models;
using RestfulAPI.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace RestfulAPI.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MyDbContext _context;

        public CategoryRepository(MyDbContext context)
        {
            _context = context;
        }
        public CategoryVM Add(Models.Category category)
        {
            var _category = new Data.Category()
            {
                Name = category.Name,
            };

            _context.Add(_category);
            _context.SaveChanges();
            return new CategoryVM { 
                Id = _category.Id,
                Name = category.Name,
            };
        }

        public void Delete(int id)
        {
            var _category = _context.Categories.SingleOrDefault(cate => cate.Id == id);
            if(_category != null)
            {
                _context.Remove(_category);
                _context.SaveChanges();
            }
        }

        public List<CategoryVM> GetAll()
        {
            var Categories = _context.Categories.Select(cate => new CategoryVM {
                Id = cate.Id,
                Name = cate.Name,
            });
            return Categories.ToList();
        }

        public CategoryVM GetById(int id)
        {
            var category = _context.Categories.SingleOrDefault(cate => cate.Id == id);
            if(category != null)
            {
                return new CategoryVM
                {
                    Id = category.Id,
                    Name = category.Name,
                };
            }
            return null;
        }

        public void Update(CategoryVM category)
        {
            var _category = _context.Categories.SingleOrDefault(cate => cate.Id == category.Id);
            if(category != null)
            {
                _category.Name = category.Name;
                _context.SaveChanges();
            }
        }
    }
}
