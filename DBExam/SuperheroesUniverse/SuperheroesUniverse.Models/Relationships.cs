namespace SuperheroesUniverse.Models
{
    public class Relationships 
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int FirstHeroId { get; set; }

        public Superhero FirstHero { get; set; }

        public int SecondHeroId { get; set; }

        public Superhero SecondHero { get; set; }
    }
}
