﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERSProjekat
{
    class Akcija
    {
        public string VremeAkcije { get; set; }
        public string Opis { get; set; }

        public Akcija(string vreme, string opis)
        {
            this.VremeAkcije = vreme;
            this.Opis = opis;
        }

    }
}
