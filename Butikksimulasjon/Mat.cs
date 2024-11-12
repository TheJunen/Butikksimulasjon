using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButikkSimulasjon
{
    internal class Mat : Vare
    {
        public Mat(string navn, decimal pris, int antall) : base(navn, pris, antall)
        {

        }
    }
}
