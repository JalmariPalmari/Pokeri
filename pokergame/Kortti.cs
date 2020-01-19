using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KorttiPeli
{
    class Kortti : IComparable<Kortti>
    {
        public string Maa { get; private set; }
        public int Arvo { get; private set; }

        public Kortti(string maa, int arvo)
        {
            this.Maa = maa;
            this.Arvo = arvo;
        }
   

        public override string ToString()
        {
            string s = this.Maa + " ";

            switch (this.Arvo)
            {
                case 1:
                    s += "Ässä";
                    break;
                case 11:
                    s += "Jätkä";
                    break;
                case 12:
                    s += "Rouva";
                    break;
                case 13:
                    s += "Kunkku";
                    break;
                default:
                    s += this.Arvo;
                    break;
            }

            return s;
        }

        public int CompareTo(Kortti other)
        {
            int ret = this.Maa.CompareTo(other.Maa);
            if (ret == 0)
                ret = this.Arvo - other.Arvo;
            return ret;
        }
    }
}
