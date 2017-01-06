using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Planning.Bindings;
using SuperheroesUniverse.Data;
using SuperheroesUniverse.Data.Repository;
using SuperheroesUniverse.Models;

namespace SuperheroesUniverse.Client
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            //var importer = new Importer();
            ISuperheroesDbContext context = new SuperheroesDbContext();
            //importer.ImportData();
            //Func<SuperHeroesData> unitOfWorkFactory = ;
            IGenericRepository<SuperheroesUniverse.Models.Superhero> superheroesRepo = new GenericRepository<Superhero>(context);
            IGenericRepository<SuperheroesUniverse.Models.City> citiesRepo = new GenericRepository<City>(context);
            IGenericRepository<SuperheroesUniverse.Models.Country> countriesRepo = new GenericRepository<Country>(context);
            IGenericRepository<SuperheroesUniverse.Models.Planet> planetsRepo = new GenericRepository<Planet>(context);
            //fail with ninject
            //var kernel = new StandardKernel();

            //kernel.Bind<Func<SuperHeroesData>>().ToMethod( ctx => () => new )

            //var importer = new Importer(superheroesRepo, citiesRepo, countriesRepo, planetsRepo);
            //importer.ImportData();
            var dbContext = new SuperheroesDbContext();
            dbContext.Superheros.Count();
        }
    }

    
}
