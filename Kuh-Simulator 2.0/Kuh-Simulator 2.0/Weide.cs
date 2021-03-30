using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kuh_Simulator_2._0
{
    class Weide
    {
        private int WeideFlaeche;
        private GPSLocation Ort;
        private List<Kuh> Herde = new List<Kuh>();

        public Weide(GPSLocation Ort, int WeideFlaeche)
        {
            this.Ort = Ort;
            this.WeideFlaeche = WeideFlaeche;
        }

        public void zuHerdeHinzufuegen(Kuh k)
        {
            Herde.Add(k);
        }

        public void ausHerdeEntfernen(Kuh k)
        {
            if(Herde.Contains(k))
            {
                Herde.Remove(k);
            } else
            {
                MessageBox.Show("Kuh nicht in der Herde", "Error", MessageBoxButton.OK);
            }
        }

        public List<Kuh> getHerde()
        {
            return Herde;
        }
    }
}
