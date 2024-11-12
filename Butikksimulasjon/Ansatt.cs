using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButikkSimulasjon
{
    internal class Ansatt
    {
        private string _navn;
        internal bool _kjørerKasse { get; set; }
        private int _stengingAvAlkoholSalg;

        public string Navn
        {
            get { return _navn; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Error. Navnet er enten null, tom eller bare mellomrom. Vennligst prøv på nytt");
                }
                _navn = value;
            }
        }

        public Ansatt(string navn, int stengingAvAlkoholSalg)
        {
            Navn = navn;
            StengingAvAlkoholSalg = stengingAvAlkoholSalg;
        }

        public int StengingAvAlkoholSalg
        {
            get { return _stengingAvAlkoholSalg; }
            set
            {
                if (value != 20)
                {
                    throw new ArgumentNullException("Error. Stenging av alkoholsalg må være 20. Vennligst prøv på nytt");
                }
                _stengingAvAlkoholSalg = value;
            }
        }

        internal void AlkoholReglerGjennomgåingAvKunde(Kunde kunde) //metode for å sjekke om en kunde er gammel nok og har gyldig legitimasjon for å kjøpe øl
        {
            if (kunde.GjetningAvAlder < 25 && kunde.AnkomstKasse < StengingAvAlkoholSalg)
            {
                Console.WriteLine("Kunde ser under 25 og en legitimasjonsjekk tas: ");
                if (kunde.Alder < 18)
                {
                    SlettVareMedAldersgrense18(kunde);
                    Console.WriteLine("Kunde er under 18 år. Alkohol ble ikke kjøpt.");
                }
                else if (kunde.Alder > 18 && kunde.legitimasjon == true)
                {
                    Console.WriteLine("Kunde er over 18 år. Alkoholkjøp gjennomføres.");
                }
            }
            else if (kunde.GjetningAvAlder >= 25 && kunde.AnkomstKasse < StengingAvAlkoholSalg)
            {
                Console.WriteLine("Kunde ser over 25 ut. Alkoholkjøp gjennomføres.");
            }
            else if (kunde.AnkomstKasse > StengingAvAlkoholSalg)
            {
                SlettVareMedAldersgrense18(kunde);
                Console.WriteLine("Kjøp ble ikke gjennomført da ankomst skjedde etter butikken sluttet å selge alkohol pga klokkeslettet.");
            }
        }

        private void SlettVareMedAldersgrense18(Kunde kunde) //metode for å slette alle varer med aldersgrense 18 i handlekurv
        {
            foreach (var kategori in kunde._handlekurv)
            {
                if (kunde._handlekurv.TryGetValue(kategori.Key, out List<Vare> varer))
                {
                    varer.RemoveAll(vare => vare is IAldersbegrenset aldersbegrensetVare && aldersbegrensetVare.Aldersgrense == 18); //lambda for å slette alle varer med aldersgrense 18 i varelisten
                }
            }
        }
    }
}
