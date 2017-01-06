using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperheroesUniverse.Models
{
    public class Power
    {
        public int Id { get; set; }
        
        [MinLength(3)]
        [MaxLength(35)]
        [Index(IsUnique = true)]
        public string Name { get; set; }
    }
}