using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButikkSimulasjon
{
    internal class Butikkasse
    {
        internal void KjørButikkKasse(Kunde kunde, Ansatt ansatt) //metode for å kjøre butikkasse med kunde og ansatt. Vil kjøre fram til ansatt._kjørerKasse = false.
        {
            //lage slik at den gjenkjenner alkohol i handlekurven
            ansatt._kjørerKasse = true; //starter med true da ansatt begynner å kjøre kassen

            while (ansatt._kjørerKasse)
            {
                VareAldersgrenseSjekk(kunde, ansatt); //sjekker for varer med aldersgrense 18 og fjerner hvis kunde er mindreårig
                Console.WriteLine($"Kunde har {kunde.Penger} kr. Beregner sum på handlekurv varer:");
                var sum = BeregnSumPåHandlekurvVarer(kunde);
                Console.WriteLine($"Sum ble {sum} kr. Sjekker om kunde har nok penger:");
                if (kunde.Penger >= sum) //hvis kunde har mer eller lik penger som sum så vil kjøpet gjennomføres
                {
                    kunde.Penger -= sum;
                    ansatt._kjørerKasse = false;
                    Console.WriteLine($"Det var nok penger og {sum} kr ble betalt.");
                    LeggTilHandlekurvVarerTilVareInventar(kunde);
                }
                else
                {
                    Console.WriteLine("Ikke nok penger. Ønsker du å trekke fra varer? Skriv 'ja' eller 'nei'");
                    var svar = Console.ReadLine();
                    if (svar.ToLower() == "ja")
                    {
                        TrekkFraVarerFraHandleliste(kunde, sum); //metode som trekker fra en eller flere varer av samme varetype hvis kunde skriver 'ja'
                    }
                    else
                    {
                        ansatt._kjørerKasse = false; //kjøpet gjennomføres ikke da bruker valgte å ikke fullføre
                        Console.WriteLine("Du valgte å ikke trekke varer og kjøpet ble ikke fullført.");
                    }

                }
            }
        }

        private void LeggTilHandlekurvVarerTilVareInventar(Kunde kunde) //legger til handlekurv varer til kunde vareinventar
        {
            foreach (var kategori in kunde._handlekurv)
            {
                if (kunde._vareInventar.ContainsKey(kategori.Key))
                {
                    foreach (var vare in kategori.Value)
                    {
                        kunde._vareInventar[kategori.Key].Add(vare);

                    }
                }
                else
                {
                    kunde._vareInventar[kategori.Key] = new List<Vare>(kategori.Value); //legger til en ny kategori med varen hvis kategori ikke finnes
                }
            }
        }

        private decimal BeregnSumPåHandlekurvVarer(Kunde kunde) //beregner sum på handlekurven
        {
            decimal sum = 0m;
            foreach (var objekt in kunde._handlekurv)
            {
                foreach (var vare in objekt.Value)
                {
                    var vareantallSum = vare.Pris * vare.Antall;
                    sum += vareantallSum;
                }
            }
            return sum;
        }

        private decimal TrekkFraVarerFraHandleliste(Kunde kunde, decimal sum) //trekker fra en eller flere varer av samme varetype. Kan gjennomføres flere ganger.
        {
            decimal sumEtterTrekning = 0;
            bool ferdigTrekkFraVarer = false;

            while (!ferdigTrekkFraVarer)
            {
                foreach (var objekt in kunde._handlekurv) //skriver ut kategorier for handlekurven
                {
                    Console.WriteLine($"Kategori: {objekt.Key}"); //kategorinavnet skrives ut
                    foreach (var vare in objekt.Value) //skriver ut alle varer i den kategorien
                    {
                        vare.SkrivUtInfo();
                    }
                }

                string kategori = "";
                bool kategoriInputSuksessfull = false;
                while (!kategoriInputSuksessfull) //prøver å finne kategorien fram til en kategori blir funnet i handlekurv
                {
                    Console.WriteLine("Skriv kategorien du ønsker å fjerne varen/varer fra:");
                    kategori = Console.ReadLine();
                    if (kunde._handlekurv.ContainsKey(kategori)) //Sjekk om input matcher en nøkkel i dictionary
                    {
                        Console.WriteLine("Kategorien ble funnet.");
                        kategoriInputSuksessfull = true;
                    }
                }

                int indexDictionaryVerdi = 0;
                bool indexDictionaryVerdiInputSuksesfull = false;
                while (!indexDictionaryVerdiInputSuksesfull) //prøver å finne en gyldig index i varelisten og convertere input til int. -1 på int slik at det blir menyvennlig.
                {
                    Console.WriteLine("Skriv 1 for å trekke fra nr1 i listen, 2 for nr2 osv.");
                    string valg2 = Console.ReadLine();

                    if (int.TryParse(valg2, out indexDictionaryVerdi) //sjekk om input ble konvertert til int, int >= 0 og int < er mindre enn dictionary kategoriantall
                        && indexDictionaryVerdi >= 0
                        && indexDictionaryVerdi <= kunde._handlekurv[kategori].Count)
                    {
                        indexDictionaryVerdi -= 1;
                        Console.WriteLine("Verdien til index matcher og input ble konvertert til int suksessfullt.");
                        indexDictionaryVerdiInputSuksesfull = true;
                    }
                    else
                    {
                        Console.WriteLine("Error. Vennligst skriv inn et tall");
                    }
                }

                Console.WriteLine($"indexdictonnaryverdi : {indexDictionaryVerdi}");
                //Console.WriteLine(kunde._handlekurv[kategori][indexDictionaryVerdi].Antall);
                Console.WriteLine("Skriv 1 for å trekke bare 1 vare av samme type, 2 for å trekke fler av samme type.");
                var valgEnEllerFlerAvSammeType = Console.ReadLine();

                if (valgEnEllerFlerAvSammeType == "1") //fjerner 1 vare av samme varetype
                {
                    kunde._handlekurv[kategori][indexDictionaryVerdi].Antall -= 1;
                    Console.WriteLine($"{kunde._handlekurv[kategori][indexDictionaryVerdi].Navn} ble trukket fra 1 gang");
                }

                else if (valgEnEllerFlerAvSammeType == "2") //fjerner brukerbestemt valg av flere av samme varetype
                {
                    
                    bool taVekkFlerSuksessfull = false;

                    while (!taVekkFlerSuksessfull)
                    {
                        Console.WriteLine("Skriv hvor mange du ønsker å ta vekk:");
                        var svarTallStreng = Console.ReadLine();

                        if (int.TryParse(svarTallStreng, out int svar))
                        {
                            if (kunde._handlekurv[kategori][indexDictionaryVerdi].Antall >= svar)
                            {
                                kunde._handlekurv[kategori][indexDictionaryVerdi].Antall -= svar;
                                Console.WriteLine($"{kunde._handlekurv[kategori][indexDictionaryVerdi].Navn} ble trukket fra {svar} ganger");
                                taVekkFlerSuksessfull = true;
                            }
                            else
                            {
                                Console.WriteLine("Error. Vare antall må være minst like mye av det du prøver å ta vekk.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error. Vennligst skriv inn et tall");
                        }
                    }
                }

                sumEtterTrekning = BeregnSumPåHandlekurvVarer(kunde); //beregner ny sum på handlekurv etter varetrekning
                Console.WriteLine($"Summen er: {sumEtterTrekning}. Skriv 1 for å fortsette å trekke varer, 2 for å avslutte å trekke varer");
                var valgFjerneMer = Console.ReadLine();
                if (valgFjerneMer == "2") //avslutter varetrekning hvis kunde skriver '1'
                {
                    ferdigTrekkFraVarer = true;
                }
            }
            return sumEtterTrekning;
        }

        private void VareAldersgrenseSjekk(Kunde kunde, Ansatt ansatt) //Metode for å sjekke om aldersgrensede varer i handlekurve finnes og vil bli fjernet hvis kunde er mindreårig
        {
            Console.WriteLine($"Starter aldrsgrensesjekk for kunde med alder: {kunde.Alder}");
            bool finnesAldersgrenseVare = false;

            foreach (var vare in kunde._handlekurv) //henter ut hver kategori
            {
                if (kunde._handlekurv.TryGetValue(vare.Key, out List<Vare> varer)) //sjekker om kategorien finnes i handlekurv
                {
                    bool harAldersgrense = varer //blir sann hvis betingelsene under er sanne
                        .OfType<IAldersbegrenset>() //varen må arve AldersGrense
                        .Any(v => v.Aldersgrense > 0); //lambda uttrykk for å sjekke om varelisten inneholder varer med aldersgrense og vil returnere sann hvis treff


                    Console.WriteLine(harAldersgrense
                        ? $"Kategori {vare.Key} inneholder varer med aldersgrense. En metode for å sjekke alder på kunden kjøres."
                        : $"Ingen varer med aldergrense i kategori {vare.Key}");

                    if (harAldersgrense)
                    {
                        finnesAldersgrenseVare = true;
                        ansatt.AlkoholReglerGjennomgåingAvKunde(kunde); //metode for å fjerne alkoholvarer hvis kunden er mindreårig
                    }


                }
                else
                {
                    Console.WriteLine($"Kategori {vare.Key} finnes ikke i handlekurv");
                }

            }

            if (!finnesAldersgrenseVare) // hvis det ikke finnes noen aldersgrensevarer i handlekurven vil denne kjøre
            {
                Console.WriteLine("Ingen aldersbegrensede varer funnet i handlekurven for denne kunden");
            }
        }
    }
}
