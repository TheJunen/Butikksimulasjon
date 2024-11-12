using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButikkSimulasjon
{
    internal class VisningsHåndtering
    {
        internal void SkriveUtDictionaryVarelister(Dictionary<String, List<Vare>> ordbok) //metode for å skrive ut handlekurv eller vareInventar
        {
            foreach (var kategori in ordbok)
            {
                Console.WriteLine($"Kategori {kategori.Key}");
                if (ordbok.TryGetValue(kategori.Key, out List<Vare> varer))
                {
                    foreach (var vare in varer)
                    {
                        vare.SkrivUtInfo();
                    }
                }
            }
        }
    }
}
