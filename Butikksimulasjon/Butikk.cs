using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButikkSimulasjon
{
    internal class Butikk
    {
        internal new Dictionary<string, List<Vare>> butikkVareInventar = new Dictionary<string, List<Vare>>();
        InitialiseringVarer initialiseringVarer { get; } = new InitialiseringVarer();

        public Butikk()
        {
            butikkVareInventar = initialiseringVarer.InitialisereVarerIButikk();
        }

        internal new Butikkasse HentButikkasse()
        {
            return new Butikkasse();
        }
    }
}
