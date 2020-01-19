using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KorttiPeli
{
   class KorttiPakka
    {
        private List<Kortti> pakka = new List<Kortti>();
        private int jaettavatkortit = 0;
        private int vaihdakortti = 0;
        private int korttiindeksi = 0;

        public KorttiPakka() // Korttipakka luodaan 
        {
            Alusta(); // Korttipakka alustetaan
        }
        private void Alusta() // Korttipakka 
        {
            string[] maat = {"Hertta", "Ruutu",
                "Risti", "Pata"};

            for (int i = 0; i < maat.Length; i++)
            {
                for (int j = 1; j <= 13; j++)
                {
                    Kortti k = new Kortti(maat[i], j);
                    pakka.Add(k);
                }
            }
        }
        public List<Kortti> Jaa(int n) // Korttipakasta jaetaan haluttu määrä kortteja
        {
            // otetaan kortteja pakan päältä
            List<Kortti> kasi = pakka.GetRange(0, n); // aloittaa indeksistä 0 ja ottaa kortteja halutun määrän
            pakka.RemoveRange(0, n); // samalla poistaa pakasta kyseiset alkiot

            return kasi;
        }
        public List<Kortti> Vaihdakasi(List<Kortti> uusikasi)
        {
            Console.WriteLine("Vaihda haluamasi kortit valitsemalla (1) vaihda tai (0) pidä\n");
            korttiindeksi = 0;
            jaettavatkortit = 0;
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Vaihda kortti:  {uusikasi[korttiindeksi].ToString()}: ");
                vaihdakortti = int.Parse(Console.ReadLine());
                if (vaihdakortti == 1)
                {
                    uusikasi.RemoveRange(korttiindeksi, 1); // valinta poistaa käsiteltävän indeksin alkion
                    jaettavatkortit++;
                }
                else if (vaihdakortti != 1)
                {
                    korttiindeksi++; // Laskee korttipakan indeksiä, jotta tulostetaan oikea kortti kädestä. Valinta ei poista kädestä alkiota
                }
            }
            List<Kortti> uudetkortit = pakka.GetRange(0, jaettavatkortit); // aloittaa indeksistä 0 ja jakaa puuttuvat kortit määrän mukaan
            pakka.RemoveRange(0, jaettavatkortit);
            uusikasi.AddRange(uudetkortit);
            korttiindeksi = 0;
            jaettavatkortit = 0;

            return uudetkortit;

        }

        private void Tulostapakka()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            string s = "";

            foreach (var kortti in pakka)
            {
                s += kortti.ToString() + '\n';
            }

            return s;
        }

        public void Sekoita()
        {
            Random pakansekoitus = new Random();

            int n = pakka.Count;

            while (n > 1)
            {
                n--;
                int k = pakansekoitus.Next(n + 1);
                Kortti value = pakka[k];
                pakka[k] = pakka[n];
                pakka[n] = value;
            }
        }

    
        public List<Kortti> Arvojarjestys(List<Kortti> arvotettukasi)
        {
            arvotettukasi.Sort((x, y) => x.Arvo.CompareTo(y.Arvo)); // Tämä järjestää olemassa olevan listan objectit
                                                                    //  List<Kortti> Arvotettu = kasi.OrderBy(o => o.Arvo).ToList(); Tätä voi käyttää pääohjelmassa, se luo uuden olion.
            return arvotettukasi; 
        }

        public void Jarjesta()
        {
            pakka.Sort();
        }
        public int Korttienmaara()
        {
            return pakka.Count();
        }
        public void Tulostapakka(List<Kortti> kadessa)
        {
            foreach (var kortti in kadessa)
            {
                Console.Write($" {kortti.ToString()} | ");  
            }
            Console.WriteLine("\n ");
        }



        public bool royalFlush(List<Kortti> saatukasi)
        {
            if (saatukasi[0].Arvo == 1 && saatukasi[1].Arvo == 10 && saatukasi[2].Arvo == 11 &&
                    saatukasi[3].Arvo == 12 && saatukasi[4].Arvo == 13)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // checks for a straight flush
        public bool straightFlush(List<Kortti> saatukasi)
        {
            for (int counter = 1; counter < 5; counter++)
            {
                if (saatukasi[0].Arvo != saatukasi[counter].Arvo)
                {
                    return false;
                }
            }
            for (int counter2 = 1; counter2 < 5; counter2++)
            {
                if (saatukasi[counter2 - 1].Arvo != (saatukasi[counter2].Arvo - 1))
                {
                    return false;
                }

            }
            return true;

        }

        // checks for four of a kind
        public bool fourOfaKind(List<Kortti> saatukasi)
        {
            if (saatukasi[0].Arvo != saatukasi[3].Arvo && saatukasi[1].Arvo != saatukasi[4].Arvo)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // checks for full house
        public bool fullHouse(List<Kortti> saatukasi)
        {
            int comparison = 0;
            for (int counter = 1; counter < 5; counter++)
            {
                if (saatukasi[counter - 1].Arvo == saatukasi[counter].Arvo)
                {
                    comparison++;
                }
            }
            if (comparison == 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // checks for flush
        public bool flush(List<Kortti> saatukasi)
        {
            for (int counter = 1; counter < 5; counter++)
            {
                if (saatukasi[0].Maa != saatukasi[counter].Maa)
                {
                    return false;
                }
            }
            return true;
        }

        // check for straight
        public bool straight(List<Kortti> saatukasi)
        {
            for (int counter2 = 1; counter2 < 5; counter2++)
            {
                if (saatukasi[counter2 - 1].Arvo != (saatukasi[counter2].Arvo - 1))
                {
                    return false;
                }

            }
            return true;
        }

        // checks for triple
        public bool triple(List<Kortti> saatukasi)
        {
            if (saatukasi[0].Arvo == saatukasi[2].Arvo || saatukasi[2].Arvo == saatukasi[4].Arvo)
            {
                return true;
            }
            return false;
        }

        // checks for two pairs
        public bool twopairs(List<Kortti> saatukasi)
        {
            int check = 0;
            for (int counter = 1; counter < 5; counter++)
            {
                if (saatukasi[counter - 1].Arvo == saatukasi[counter].Arvo)
                {
                    check++;
                }
            }
            if (check == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // check for pair
        public bool pair(List<Kortti> saatukasi)
        {
            int check = 0;
            for (int counter = 1; counter < 5; counter++)
            {
                if (saatukasi[counter - 1].Arvo == saatukasi[counter].Arvo)
                {
                    check++;
                }
            }
            if (check == 1)
            {
                return true;
            }

            else
            {
                return false;

            }


        }

        // find highest card
        public int highcard(List<Kortti> saatukasi)
        {
            int highCard = 0;
            for (int counter = 0; counter < 5; counter++)
            {
                if (saatukasi[counter].Arvo > highCard)
                {
                    highCard = saatukasi[counter].Arvo;
                }
            }
            return highCard;
        }







    }
    }

