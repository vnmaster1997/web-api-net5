using Microsoft.EntityFrameworkCore;
using RestfulAPI.Data;

namespace RestfulAPI.Data
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions options): base(options)
        {

        }

        #region DbSet
        public DbSet<Merchandise> Merchandises { get; set; }
        public DbSet<Category> Categories { get; set; }
        #endregion
    }
}
