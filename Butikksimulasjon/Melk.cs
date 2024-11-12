using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButikkSimulasjon
{
    internal class Melk : Drikke
    {
        private bool _laktosefri { get; set; }


        public Melk(string navn, decimal pris, int antall, bool laktosefri) : base(navn, pris, antall)
        {
            _laktosefri = laktosefri;
        }

        internal override void SkrivUtInfo()
        {
            Console.WriteLine($"Navn: {Navn}, pris: {Pris}, antall: {Antall} og laktosefri: {_laktosefri}.");
        }
    }
}
