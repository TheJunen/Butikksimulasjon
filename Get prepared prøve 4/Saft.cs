using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButikkSimulasjon
{
    internal class Saft : Drikke
    {
        private bool _sukkerfri {  get; set; }
        public Saft(string navn, decimal pris, int antall, bool sukkerfri) : base(navn, pris, antall)
        {
            _sukkerfri = sukkerfri;
        }

        internal override void SkrivUtInfo()
        {
            Console.WriteLine($"Navn: {Navn}, pris: {Pris}, antall: {Antall} og sukkerfri: {_sukkerfri}.");
        }
    }
}
