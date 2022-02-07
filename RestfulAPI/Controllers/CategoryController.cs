using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestfulAPI.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly Data.MyDbContext _dbContext;

        public CategoryController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var listCategories = _dbContext.Categories.ToList();
            return Ok(listCategories);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var category = _dbContext.Categories.SingleOrDefault(cate => cate.Id == id);
                if(category == null)
                {
                    return NotFound();
                }
                return Ok(category);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateNew([FromForm] Models.Category category)
        {
            try
            {
                var newCate = new Data.Category
                {
                    Name = category.Name
                };
                _dbContext.Add(newCate);
                _dbContext.SaveChanges();
                return Ok(newCate);
            } catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateById(int id,[FromForm] Models.Category category)
        {
            try
            {
                var categoryFound = _dbContext.Categories.SingleOrDefault(cat => cat.Id == id);
                if(categoryFound != null)
                {
                    categoryFound.Name = category.Name;
                    _dbContext.SaveChanges();
                    return Ok(categoryFound);
                } else
                {
                    return NotFound();
                }
            } catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
