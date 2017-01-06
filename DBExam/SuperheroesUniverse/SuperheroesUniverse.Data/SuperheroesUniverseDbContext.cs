using System.Data.Entity;
using SuperheroesUniverse.Models;

namespace SuperheroesUniverse.Data
{
    public class SuperheroesDbContext : DbContext, ISuperheroesDbContext
    {
        public SuperheroesDbContext() : base("SuperheroesUniverseDb3")
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SuperheroesDbContext>());
        }

        public IDbSet<Superhero> Superheros { get; set; }

        public IDbSet<Power> Powers { get; set; }

        public IDbSet<Country> Countries { get; set; }

        public IDbSet<Planet> Planets { get; set; }

        public IDbSet<Fraction> Fractions { get; set; }

        public IDbSet<City> Cities { get; set; }
        public IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public void SaveChanges()
        {
            base.SaveChanges();
        }

        //public IDbSet<Relationships> Relationships { get; set; }
    }
}
