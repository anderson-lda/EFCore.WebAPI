

namespace EFCore.Domain
{
    public class HeroiBatalha
    {
        public Heroi Heroi { get; set; }
        public Batalha Batalha { get; set; }
        public int HeroiId { get; set; }
        public int BatalhaId { get; set; }

    }
}
