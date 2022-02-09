using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestfulAPI.Data;
using RestfulAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestfulAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchandiseController : ControllerBase
    {
        public static List<Models.Merchandise> merchandises = new List<Models.Merchandise>();
        private readonly MyDbContext _context;

        public MerchandiseController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(merchandises);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                // LINQ [Object] Query
                var merchandise = merchandises.SingleOrDefault(mer => mer.code == Guid.Parse(id));
                if(merchandise == null)
                {
                    return NotFound();
                }
                return Ok(merchandise);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create(MerchandiseVM merchandiseVM)
        {
            var merchandise = new Data.Merchandise()
            {
                code = Guid.NewGuid(),
                name = merchandiseVM.name,
                price = merchandiseVM.price
            };
            _context.Add(merchandise);
            _context.SaveChanges();

            return Ok(new
            {
                Success = true,
                Data = merchandise
            });
        }

        [HttpPut("{id}")]
        public IActionResult Edit(string id, Models.Merchandise merchandiseUpdate)
        {
            try {
                // LINE [Object] Query

                var mer = merchandises.SingleOrDefault(m => m.code == Guid.Parse(id));
                if(mer == null)
                {
                    return NotFound();
                }

                mer.price = merchandiseUpdate.price;
                mer.name = merchandiseUpdate.name;

                return Ok(mer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(string id)
        {
            try
            {
                var mer = merchandises.SingleOrDefault(m => m.code == Guid.Parse(id));
                if (mer == null)
                {
                    return NotFound();
                }
                merchandises.Remove(mer);
                return Ok("Removed " + id);
            } catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }
    }
}
