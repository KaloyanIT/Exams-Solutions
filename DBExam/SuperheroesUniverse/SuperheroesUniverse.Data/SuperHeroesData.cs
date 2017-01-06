using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperheroesUniverse.Data
{
    public class SuperHeroesData : ISuperheroesData, IDisposable
    {
        private ISuperheroesDbContext context;
        public SuperHeroesData(ISuperheroesDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException();
            }

            this.context = context;
        }

        public void Commit()
        {
            this.context.SaveChanges();
        }

        public void Dispose()
        {
        }
    }
}
