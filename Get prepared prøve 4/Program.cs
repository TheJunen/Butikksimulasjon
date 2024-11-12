/*Regler for alkoholsalg:

Det er ikke lov å kjøpe alkohol etter kl 20, dersom kunden ser eldre ut enn 25 kan de kjøpe uansett. 
Dersom de ser yngre ut enn 25 må de fremvise gyldig legitimasjon som viser at de er over 18 år
butikk, 3 kunder
 */


namespace ButikkSimulasjon
{
    class Program
    {
        static void Main(string[] args)
        {
            ButikkSimulasjon butikkSimulasjon = new ButikkSimulasjon();
            butikkSimulasjon.KjørButikkSimulasjon();
        }
    }
}
