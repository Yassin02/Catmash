using CatMash.Business.Model;
using System.Data.Entity;

namespace CatMash.Business.Context
{

    public class RatingContext : DbContext
    {

        public RatingContext()
            : base("name=RatingContext")
        {
            Database.SetInitializer<RatingContext>(new RatingDBInitializer());
            Database.CommandTimeout = 300;
        }

        public DbSet<Cat> Cats { get; set; }

    }
}