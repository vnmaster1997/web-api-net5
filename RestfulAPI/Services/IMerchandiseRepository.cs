using System.Collections.Generic;
using RestfulAPI.Models;
using RestfulAPI.Models.ViewModels;

namespace RestfulAPI.Services
{
    public interface IMerchandiseRepository
    {
        List<MerchandiseModel> GetAll(string search, double? from, double? to, string sortBy, int page = 1);
    }
}
