﻿using System.Collections.Generic;

namespace EFCore.Domain
{
    public class Heroi
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public List<HeroiBatalha> HeroisBatalhas { get; set; }
        public List<Arma> Armas { get; set; }

    }
}