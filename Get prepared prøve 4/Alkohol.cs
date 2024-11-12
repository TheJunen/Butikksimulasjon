using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButikkSimulasjon
{
    abstract class Alkohol : Drikke
    {
        private int _aldersgrense;
        private decimal _alkoholprosent;

        public int Aldersgrense
        {
            get { return _aldersgrense; }
            set
            {
                if (value < 18)
                {
                    throw new ArgumentOutOfRangeException("Pris må være minst 0. Prøv på nytt.");
                }
                _aldersgrense = value;
            }
        }

        public decimal Alkoholprosent
        {
            get { return _alkoholprosent; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Alkoholprosent må være større enn 0. Prøv på nytt.");
                }
                _alkoholprosent = value;
            }
        }

        public Alkohol(string navn, decimal pris, int antall, decimal alkoholprosent, int aldersgrense = 18) : base(navn, pris, antall)
        {
            Aldersgrense = aldersgrense;
            Alkoholprosent = alkoholprosent;
        }

        internal override void SkrivUtInfo()
        {
            Console.WriteLine($"Navn: {Navn}, pris: {Pris}, antall: {Antall}, aldersgrense: {Aldersgrense} og alkoholprosent: {Alkoholprosent}.");
        }

    }
}
