using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButikkSimulasjon
{
    internal class InitialiseringVarer
    {
        private static Random rand = new Random();

        public InitialiseringVarer()
        {
            InitialisereVarerIButikk();
        }
        internal Dictionary<string, List<Vare>> InitialisereVarerIButikk() //returnerer butikkInventar 
        {
            return new Dictionary<string, List<Vare>>()
            {
                { "Drikke", new List<Vare> { new Saft("Sukkerfri saft", 29.99m, GenererTallForTilfeldigVareAntall(), true), new Saft("saft", 25.99m, GenererTallForTilfeldigVareAntall(), false), new Øl("Øl 1 6-pakning", 119.00m, GenererTallForTilfeldigVareAntall(), 0.50m), new Melk("Melk", 19.99m, GenererTallForTilfeldigVareAntall(), false) } },
                { "Mat", new List<Vare> { new Hamburgerkjøtt("Hamburgerkjøtt 6-pakning", 79.99m, GenererTallForTilfeldigVareAntall()), new Blomkålsuppe("Blomkålsuppe posepulver", 19.99m, GenererTallForTilfeldigVareAntall()) } }
            };
        }

        private string HentTilfeldigNøkkelFraButikkVareInventar(Butikk butikk) //returnerer tilfeldig kategori
        {
            var keys = butikk.butikkVareInventar.Keys.ToList(); //henter alle kategorier i butikkVareInventar og gjør om til liste
            var tilfeldigNøkkel = keys[rand.Next(0, keys.Count)]; //tilfeldig kategori fra keys

            //return new KeyValuePair<string, List<Vare>>(tilfeldigNøkkel, butikkVareInventar[tilfeldigNøkkel]);
            return tilfeldigNøkkel;
        }

        private Vare HentTilfeldigVaretype(Butikk butikk, string kategori) //returnerer tilfeldig vare
        {
            // sjekker om kategorien finnes i ordboken
            if (butikk.butikkVareInventar.ContainsKey(kategori))
            {
                List<Vare> varer = butikk.butikkVareInventar[kategori]; //hent listen av varer

                if (varer.Count > 0) // sjekk om listen er tom
                {
                    int tilfeldigIndex = rand.Next(varer.Count); //tilfeldig index fra random
                    return varer[tilfeldigIndex]; //returnerer tilfeldig varetype
                }
                else
                {
                    throw new InvalidOperationException("Ingen varer tilgjengelig i denne kategorien");
                }

            }
            else
            {
                throw new KeyNotFoundException("Kategorien finnes ikke i inventaret");
            }
        }
        private int GenererTallForTilfeldigVareAntall() //returnerer tilfeldig vare antall fra 1-10 for butikk og kunde
        {
            return rand.Next(1, 11);
        }

        internal void InitialisereVarerForKundeHandlekurv(Butikk butikk, Kunde kunde) //legger til tilfeldig varetyperantall fra 1-6 i handlekurv
        {
            int tallForTilfeldigVareTyperAntall = GenererTallForTilfeldigVareTyperAntall();

            switch (tallForTilfeldigVareTyperAntall)
            {
                case 1:
                    GenererAntallTilfeldigNøkkelOgTilfeldigVareOgLeggTilTilfeldigVareIHandlekurv(butikk, kunde, 1);
                    Console.WriteLine("1 tilfeldig varetype ble lagt til");
                    break;
                case 2:
                    GenererAntallTilfeldigNøkkelOgTilfeldigVareOgLeggTilTilfeldigVareIHandlekurv(butikk, kunde, 2);
                    Console.WriteLine("2 tilfeldig varetype ble lagt til");
                    break;
                case 3:
                    GenererAntallTilfeldigNøkkelOgTilfeldigVareOgLeggTilTilfeldigVareIHandlekurv(butikk, kunde, 3);
                    Console.WriteLine("3 tilfeldig varetype ble lagt til");
                    break;
                case 4:
                    GenererAntallTilfeldigNøkkelOgTilfeldigVareOgLeggTilTilfeldigVareIHandlekurv(butikk, kunde, 4);
                    Console.WriteLine("4 tilfeldig varetype ble lagt til");
                    break;
                case 5:
                    GenererAntallTilfeldigNøkkelOgTilfeldigVareOgLeggTilTilfeldigVareIHandlekurv(butikk, kunde, 5);
                    Console.WriteLine("5 tilfeldig varetype ble lagt til");
                    break;
                case 6:
                    GenererAntallTilfeldigNøkkelOgTilfeldigVareOgLeggTilTilfeldigVareIHandlekurv(butikk, kunde, 6);
                    Console.WriteLine("6 tilfeldig varetype ble lagt til");
                    break;
                default:
                    Console.WriteLine("Ugyldig tall. Sjekk i koden om random er satt fra 1-6.");
                    break;
            }
        }

        private int GenererTallForTilfeldigVareTyperAntall() //returnerer tilfeldig varetype antall fra 1-6
        {
            return rand.Next(1, 7);
        }

        private void LeggTilTilfeldigVareIHandleKurv(Kunde kunde, string kategori, Vare vare) //legger til tilfeldig vare i handlekurv
        {
            if (kunde._handlekurv.ContainsKey(kategori))
            {
                kunde._handlekurv[kategori].Add(vare);
            }
            else
            {
                kunde._handlekurv[kategori] = new List<Vare> { vare }; //legger til en ny kategori med varen hvis kategori ikke finnes
            }
        }

        private void GenererAntallTilfeldigNøkkelOgTilfeldigVareOgLeggTilTilfeldigVareIHandlekurv(Butikk butikk, Kunde kunde, int antall) //hoveddel som legger til antall tilfeldig varetype basert på GenererTallForTilfeldigVareTyperAntall() i handlekurv
        {
            for (int i = 0; i < antall; i++)
            {
                var tilfeldigNøkkel = HentTilfeldigNøkkelFraButikkVareInventar(butikk);
                var tilfeldigVare = HentTilfeldigVaretype(butikk, tilfeldigNøkkel);
                LeggTilTilfeldigVareIHandleKurv(kunde, tilfeldigNøkkel, tilfeldigVare);
            }
        }


    }
}
