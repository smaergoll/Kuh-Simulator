using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuh_Simulator_2._0
{
    class Stall
    {
        private int Grundflaeche;
        private List<Kuh> meineKeuhe = new List<Kuh>();

        public Stall(int Grundflaeche)
        {
            this.Grundflaeche = Grundflaeche;
        }

        public void KuhHinzufuegen(Kuh k)
        {
            meineKeuhe.Add(k);
        }

        public void KuhRausLassen(Weide w, string nameKuh)
        {
            foreach(Kuh k in meineKeuhe)
            {
                if(k.getName().Equals(nameKuh))
                {
                    w.zuHerdeHinzufuegen(k);
                    meineKeuhe.Remove(k);
                    break;
                }
            }
        }

        public void KuhVonWeideHolen(Weide w, string nameKuh)
        {
            foreach(Kuh k in w.getHerde())
            {
                if (k.getName().Equals(nameKuh))
                {
                    meineKeuhe.Add(k);
                    w.ausHerdeEntfernen(k);
                    break;
                }
            }
        }

        public List<Kuh> getMeineKuehe()
        {
            return meineKeuhe;
        }
    }
}
