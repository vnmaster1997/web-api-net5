using Microsoft.EntityFrameworkCore;
using RestfulAPI.Data;
using RestfulAPI.Models;
using RestfulAPI.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace RestfulAPI.Services
{
    public class MerchandiseRepository : IMerchandiseRepository
    {
        private readonly MyDbContext _context;
        public static int PAGE_SIZE { get; set; } = 3;
        public MerchandiseRepository(MyDbContext context)
        {
            _context = context;
        }
        public List<MerchandiseModel> GetAll(string search, double? from, double? to, string sortBy, int page = 1)
        {
            var allMerchandises = _context.Merchandises.Include(hh => hh.Category).AsQueryable();

            #region Filtering
            if (!string.IsNullOrEmpty(search))
            {
                allMerchandises = allMerchandises.Where(hh => hh.name.Contains(search));
            }

            if (from.HasValue)
            {
                allMerchandises = allMerchandises.Where(hh => hh.price >= from);
            }

            if (to.HasValue)
            {
                allMerchandises = allMerchandises.Where(hh => hh.price <= to);
            }
            #endregion

            #region Sorting
            // Default sort by name merchandise
            allMerchandises = allMerchandises.OrderBy(hh => hh.name);

            if(!string.IsNullOrEmpty(sortBy))
            {
                switch(sortBy)
                {
                    case "name_desc": allMerchandises = allMerchandises.OrderByDescending(hh => hh.name); break;
                    case "price_asc": allMerchandises = allMerchandises.OrderBy(hh => hh.price); break;
                    case "price_desc": allMerchandises = allMerchandises.OrderByDescending(hh => hh.price); break;
                }
            }
            #endregion

            //#region Paging
            //allMerchandises = allMerchandises.Skip((page - 1) * PAGE_SIZE).Take(PAGE_SIZE);
            //#endregion

            //var results = allMerchandises.Select(hh => new MerchandiseModel
            //{
            //    code = hh.code,
            //    name = hh.name,
            //    price = hh.price,
            //    category_name = hh.Category.Name
            //});

            //return results.ToList();

            var result = PaginatedList<Data.Merchandise>.Create(allMerchandises, page, PAGE_SIZE);
            return result.Select(hh => new MerchandiseModel
            {
                code = hh.code,
                name = hh.name,
                price = hh.price,
                category_name = hh.Category?.Name
            }).ToList();
        }
    }
}
