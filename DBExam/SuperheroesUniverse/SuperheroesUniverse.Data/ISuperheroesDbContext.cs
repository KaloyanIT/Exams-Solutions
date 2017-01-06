using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperheroesUniverse.Models;

namespace SuperheroesUniverse.Data
{
    public interface ISuperheroesDbContext
    {
        IDbSet<Superhero> Superheros { get; set; }
        
        IDbSet<Power> Powers { get; set; }
        
        IDbSet<Country> Countries { get; set; }
        
        IDbSet<Planet> Planets { get; set; }
        
        IDbSet<Fraction> Fractions { get; set; }
        
        IDbSet<City> Cities { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        void SaveChanges();
    }
}
