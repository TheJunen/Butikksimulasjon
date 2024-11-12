using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButikkSimulasjon
{
    internal class Kunde
    {
        private int _alder;
        internal bool legitimasjon {  get; set; }
        private int _gjetningAvAlder;
        private int _ankomstKasse;
        internal Dictionary<string, List<Vare>> _vareInventar = new Dictionary<string, List<Vare>>(); //Valg av dictionary var pga. istedenfor å ha alle varer i en liste, kunne jeg kategorisere dem og finne dem via index
        internal Dictionary<string, List<Vare>> _handlekurv = new Dictionary<string, List<Vare>>();
        private decimal _penger;
        Random rand { get; } = new Random();


        public int Alder
        {
            get { return _alder; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Alder må være minst 0. Prøv på nytt.");
                }
                _alder = value;
            }
        }

        public int GjetningAvAlder
        {
            get { return _gjetningAvAlder; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Gjetning av alder må være minst 0. Prøv på nytt.");
                }
                _gjetningAvAlder = value;
            }
        }

        public int AnkomstKasse
        {
            get { return _ankomstKasse; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Kl må være minst 0. Prøv på nytt.");
                }
                _ankomstKasse = value;
            }
        }

        public decimal Penger
        {
            get { return _penger; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Penger må være minst 0. Prøv på nytt.");
                }
                _penger = value;
            }
        }

        public Kunde(int alder, bool legitimasjon, int gjetningAvAlder, int ankomstAvKasse)
        {
            Alder = alder;
            this.legitimasjon = legitimasjon;
            GjetningAvAlder = gjetningAvAlder;
            AnkomstKasse = ankomstAvKasse;
            Penger = GenererPengetallForKunde();
        }
        
        private decimal GenererPengetallForKunde()
        {
            var pengetall = (decimal)rand.NextDouble() * (2001.00m - 100.00m) + 100.00m;
            return Math.Floor(pengetall);
        }
    }
}
