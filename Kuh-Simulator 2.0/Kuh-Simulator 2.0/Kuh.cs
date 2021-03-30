using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuh_Simulator_2._0
{
    public class Kuh
    {
        private string Name;
        private double Gewicht = 0;
        private double EuterInhalt = 0;
        private int Alter = 0;
        private double AbgegebeneMilchMenge = 0;

        public Kuh(string Name, double Gewicht, int Alter)
        {
            this.Name = Name;
            this.Alter = Alter;
            this.Gewicht = Gewicht;
        }
        public void setName(string Name)
        {
            this.Name = Name;
        }
        public string getName()
        {
            return Name;
        }
        public void setGewicht(double Gewicht)
        {
            this.Gewicht = Gewicht;
        }
        public double getGewicht()
        {
            return Gewicht;
        }
        public void setEuterInhalt(double EuterInhalt)
        {
            this.EuterInhalt = EuterInhalt;
        }
        public double getEuterInhalt()
        {
            return EuterInhalt;
        }
        public void setAlter(int Alter)
        {
            this.Alter = Alter;
        }
        public int getAlter()
        {
            return Alter;
        }

        public void abgegebeneMilchMengeErhoehen(double MilchMenge)
        {
            AbgegebeneMilchMenge += MilchMenge;
        }

        public double getAbgegebeneMilchMenge()
        {
            return AbgegebeneMilchMenge;
        }
        public void fressen(double Heumenge)
        {
            this.EuterInhalt += Heumenge / 3;
            this.Gewicht += Heumenge / 10 + Heumenge / 3;
        }
        public void melken()
        {
            abgegebeneMilchMengeErhoehen(EuterInhalt);
            this.Gewicht -= this.EuterInhalt;
            this.EuterInhalt = 0;
        }
    }
}
