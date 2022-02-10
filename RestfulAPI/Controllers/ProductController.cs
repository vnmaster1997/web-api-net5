using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestfulAPI.Services;
using System;

namespace RestfulAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMerchandiseRepository _merchandiseRepository;

        public ProductController(IMerchandiseRepository merchandiseRepository)
        {
            _merchandiseRepository = merchandiseRepository;
        }

        [HttpGet]
        public IActionResult GetAllProducts(string search, double? from, double? to, string sortBy, int page = 1)
        {
            try
            {
                var listProducts = _merchandiseRepository.GetAll(search, from, to, sortBy, page);
                return Ok(listProducts);
            } catch (Exception ex)
            {
                return BadRequest("We can't get all products!");
            }
        }
    }
}
