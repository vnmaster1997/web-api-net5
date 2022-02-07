using System.Collections.Generic;
using RestfulAPI.Models;
using RestfulAPI.Models.ViewModels;

namespace RestfulAPI.Services
{
    public interface ICategoryRepository
    {
        List<CategoryVM> GetAll();
        CategoryVM GetById(int id);
        CategoryVM Add(Category category);
        void Update(CategoryVM category); 
        void Delete(int id);
    }
}
