

namespace EFCore.WebAPI.Models
{
    public class HeroiBatalha
    {
        public Heroi Heroi { get; set; }
        public Batalha Batalha { get; set; }
        public int HeroiId { get; set; }
        public int BatalhaId { get; set; }

    }
}
