using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ButikkSimulasjon
{
    internal class Drikke : Vare
    {
        public Drikke(string navn, decimal pris, int antall) : base(navn, pris, antall)
        {

        }
    }
}
