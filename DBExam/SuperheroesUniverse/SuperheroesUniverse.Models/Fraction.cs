using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperheroesUniverse.Models
{
    public class Fraction
    {
        private ICollection<Superhero> members;
        private ICollection<Planet> planets;

        public Fraction()
        {
            this.members = new HashSet<Superhero>();
            this.planets = new HashSet<Planet>();
        }

        public int Id { get; set; }

        [MinLength(3)]
        [MaxLength(35)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public string Aligment { get; set; }

        public virtual ICollection<Planet> Planets
        {
            get { return this.planets; }
            set { this.planets = value; }
        }

        public virtual ICollection<Superhero> Members
        {
            get { return this.members; }
            set { this.members = value; }
        }

    }
}