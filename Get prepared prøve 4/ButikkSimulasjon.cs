using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*Regler for alkoholsalg:

Det er ikke lov å kjøpe alkohol etter kl 20, dersom kunden ser eldre ut enn 25 kan de kjøpe uansett. 
Dersom de ser yngre ut enn 25 må de fremvise gyldig legitimasjon som viser at de er over 18 år
butikk, 3 kunder
 */
namespace ButikkSimulasjon
{
    internal class ButikkSimulasjon
    {
        InitialiseringVarer initialiseringVarer { get; } = new InitialiseringVarer();
        Butikkasse butikkasse { get; } = new Butikkasse();

        VisningsHåndtering visningsHåndtering { get; } = new VisningsHåndtering();

        internal void KjørButikkSimulasjon() //hovedapplikasjonen. Inneholder bare cw og simpel logikk
        {
            Console.WriteLine("Velkommen til ButikkSimulasjon. Her skal 3 kunder prøve å kjøpe alkohol," +
                " basert på tidspunkt de kjøper, om de er over 18 år og om legitimasjon trengs hvis der ser yngre ut enn 25.");
            Console.WriteLine("Det er ikke lov å kjøpe alkohol etter kl 20. Nå kjøres simulasjonen:");

            Butikk butikk = new Butikk();

            Ansatt ansatt1 = new Ansatt("Heidi", 20);

            List<Kunde> kundeListe = new List<Kunde>
            {
                new Kunde(15, false, 19, 16),
                new Kunde(26, true, 26, 14),
                new Kunde(18, true, 23, 22)
            };

            Console.WriteLine();

            Console.WriteLine("Her er handlekurven av varer for hver kunde:");

            Console.WriteLine("Initialiserer varer i handlekurv for kunder");

            int kundenr;

            Console.WriteLine();

            kundenr = 1;
            foreach (var kunde in kundeListe) //skriver ut hver kunde sin handlekurv
            {
                Console.WriteLine($"Kunde nr {kundenr} sin handlekurv:");
                initialiseringVarer.InitialisereVarerForKundeHandlekurv(butikk, kunde);
                kundenr++;
            }

            Console.WriteLine();

            kundenr = 1;
            foreach (var kunde in kundeListe) //kjører butikkasse på hver kunde sin handlekurv
            {
                Console.WriteLine($"Kunde nr {kundenr} går til kassen:");
                butikk.HentButikkasse().KjørButikkKasse(kunde, ansatt1);
                kundenr++;
            }

            Console.WriteLine();

            kundenr = 1;
            foreach (var kunde in kundeListe) //skriver ut varelister for hver kategori i hver kunde sin vareInventar etter handleturen
            {
                Console.WriteLine($"Kunde nr {kundenr} sin inventar etter handleturen:");
                visningsHåndtering.SkriveUtDictionaryVarelister(kunde._vareInventar);
                kundenr++;
            }
        }
    }
}
