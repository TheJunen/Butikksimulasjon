using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButikkSimulasjon
{
    internal class Vare
    {
        private string _navn;
        private decimal _pris;
        private int _antall;

        public string Navn
        {
            get { return _navn; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Navnet er null, tom eller bare mellomrom. Prøv på nytt.");
                }
                _navn = value;
            }
        }

        public decimal Pris
        {
            get { return _pris; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Pris må være minst 0. Prøv på nytt.");
                }
                _pris = value;
            }
        }

        public int Antall
        {
            get { return _antall; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Antall må være minst 0. Prøv på nytt.");
                }
                _antall = value;
            }
        }

        public Vare(string navn, decimal pris, int antall)
        {
            Navn = navn;
            Pris = pris;
            Antall = antall;
        }

        public Vare()
        {
            
        }

        internal virtual void SkrivUtInfo()
        {
            Console.WriteLine($"Navn: {Navn}, pris: {Pris}, antall: {Antall}.");
        }
    }
}
