using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Internal;
using Newtonsoft.Json;
using SuperheroesUniverse.Data;
using SuperheroesUniverse.Data.Repository;
using SuperheroesUniverse.Models;
using Superhero = SuperheroesUniverse.Client.Models.Superhero;

namespace SuperheroesUniverse.Client
{
    public class Importer
    {
        private Func<SuperHeroesData> unitOfWorkFactory;
        private IGenericRepository<SuperheroesUniverse.Models.Superhero> superheroesRepo;
        private IGenericRepository<SuperheroesUniverse.Models.City> citiesRepo;
        private IGenericRepository<SuperheroesUniverse.Models.Country> countriesRepo;
        private IGenericRepository<SuperheroesUniverse.Models.Planet> planetsRepo;

        //public Importer(/*Func<SuperHeroesData> unitOfWorkFactory*/ IGenericRepository<SuperheroesUniverse.Models.Superhero> superheroesRepo, IGenericRepository<SuperheroesUniverse.Models.City> citiesRepo, IGenericRepository<SuperheroesUniverse.Models.Country> countriesRepo, IGenericRepository<SuperheroesUniverse.Models.Planet> planetsRepo)
        //{
        //    //this.unitOfWorkFactory = unitOfWorkFactory;
        //    this.superheroesRepo = superheroesRepo;
        //    this.citiesRepo = citiesRepo;
        //    this.countriesRepo = countriesRepo;
        //    this.planetsRepo = planetsRepo;
        //}

        public void ImportData()
        {
            //Console.WriteLine(Environment.CurrentDirectory);
            var files = Directory.GetFiles(Environment.CurrentDirectory).Where(fileName => fileName.EndsWith(".json")).ToList();
            var superheroes = new List<Superhero>();

            foreach (var file in files)
            {
                var fileContent = File.ReadAllText(file);
                var fileHeroes = JsonConvert.DeserializeObject<IEnumerable<Superhero>>(fileContent);
                superheroes.AddRange(fileHeroes);
                Console.WriteLine("{0} read.", file);
            }

            var cityNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var countryNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var planetNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var powerNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var fractionNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (var item in superheroes)
            {
                cityNames.Add(item.City.Name);
                countryNames.Add(item.City.Country);
                planetNames.Add(item.City.Planet);
            }

            using (var unitOfWork = this.unitOfWorkFactory())
            {
                foreach (var cityName in cityNames)
                {
                    this.citiesRepo.Add(new City() {Name = cityName});
                }

                unitOfWork.Commit();
            }

            using (var unitOfWork = this.unitOfWorkFactory())
            {
                foreach (var countryName in countryNames)
                {
                    this.countriesRepo.Add(new Country() { Name = countryName});
                }

                unitOfWork.Commit();
            }

            using (var unitOfWork = this.unitOfWorkFactory())
            {
                foreach (var planetName in planetNames)
                {
                    this.planetsRepo.Add(new Planet() { Name = planetName });
                }

                unitOfWork.Commit();
            }


            using (var unitOfWork = this.unitOfWorkFactory())
            {
                for(var i = 0; i < superheroes.Count; i++)
                {
                    var item = superheroes[i];
                    var powers = new List<Power>();
                    var fractions = new List<Fraction>();

                    foreach (var power in item.Powers)
                    {
                        powers.Add(new Power() {Name = power});
                    }

                    foreach (var fraction in item.Fractions)
                    {
                        fractions.Add(new Fraction() {Name = fraction});
                    }

                    this.superheroesRepo.Add(new SuperheroesUniverse.Models.Superhero()
                    {
                        Name = item.Name,
                        Aligment = item.Aligment,
                        SecretIndentity = item.SecretIndentity,
                        City = this.citiesRepo.All.FirstOrDefault(x => x.Name == item.Name),
                        Fractions = fractions,
                        Powers = powers,
                        Story = item.Story
                    });
                }

                unitOfWork.Commit();
            }

            



        }
    }
}
