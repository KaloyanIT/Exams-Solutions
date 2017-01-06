using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperheroesUniverse.Models
{
    public class Superhero
    {
        private ICollection<Fraction> fractions;
        private ICollection<Power> powers;

        public Superhero()
        {
            this.fractions = new HashSet<Fraction>();
            this.powers = new HashSet<Power>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(60)]
        public string Name { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        [Index(IsUnique = true)]
        public string SecretIndentity { get; set; }

        [Required]
        public int CityId { get; set; }

        public virtual City City { get; set; }

        [Required]
        public string Aligment { get; set; }

        [Required]
        [MinLength(4)]
        public string Story { get; set; }


        [Required]
        public virtual ICollection<Fraction> Fractions
        {
            get { return this.fractions; }
            set { this.fractions = value; }
        }

        [Required]
        public virtual ICollection<Power> Powers
        {
            get { return this.powers; }
            set { this.powers = value; }
        }
    }
}
