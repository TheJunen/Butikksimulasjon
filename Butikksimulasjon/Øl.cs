using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButikkSimulasjon
{
    internal class Øl : Alkohol, IAldersbegrenset
    {
        public Øl(string navn, decimal pris, int antall, decimal alkoholprosent, int aldersgrense = 18) : base(navn, pris, antall, alkoholprosent, aldersgrense)
        {
            
        }
    }
}
