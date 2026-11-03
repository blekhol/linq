using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    internal class Diak
    {
        private string nev;
        private int eletkor;
        private string osztaly;
        private double atlag;

        public Diak(string nev, int eletkor, string osztaly, double atlag)
        {
            this.Nev = nev;
            this.Eletkor = eletkor;
            this.Osztaly = osztaly;
            this.Atlag = atlag;
        }

        public string Nev { get => nev; set => nev = value; }
        public int Eletkor { get => eletkor; set => eletkor = value; }
        public string Osztaly { get => osztaly; set => osztaly = value; }
        public double Atlag { get => atlag; set => atlag = value; }
    }
}
