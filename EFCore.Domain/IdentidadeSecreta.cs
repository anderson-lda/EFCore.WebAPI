namespace EFCore.Domain
{
    public class IdentidadeSecreta
    {
        public string NomeReal { get; set; }
        public int Id { get; set; }
        public int HeroiId { get; set; }
        public Heroi Heroi { get; set; }

    }
}