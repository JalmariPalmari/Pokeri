using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KorttiPeli
{


    class Program
    {
    
        static void Main(string[] args)
        {
           
            bool jatkaohjelmaa = true;
            while (jatkaohjelmaa)
            {
                Käyttöliittymä.Tulostavalikko();
                string komento = Console.ReadLine();
                switch (komento)
                {

                    case "1":
                        Console.Clear();
                        // Uusi korttipakka luodaan olioon
                        KorttiPakka korttipakka = new KorttiPakka();

                        // Korttipakka sekoitetaan
                        korttipakka.Sekoita();

                        // Pelaajalle jaetaan korttipakasta käsi
                        Console.WriteLine("____________________");
                        Console.WriteLine("| 1 Pelaajan käsi  |");
                        Console.WriteLine("====================");
                        List<Kortti> kasi = korttipakka.Jaa(5);

                        // Käsi järjestetään arvojärjestykseen
                        korttipakka.Arvojarjestys(kasi);

                        // Pelaajalle tulostetaan jaetut kortit
                        korttipakka.Tulostapakka(kasi);

                        // Console.Write(korttipakka.Korttienmaara());
                        //  Console.Write(" pakassa jäljellä\n");

                        // Pelaaja valitsee mitkä kortit halutaan vaihtaa ja pelaajalle jaetaan uudet kortit tilalle
                        korttipakka.Vaihdakasi(kasi);

                        // Käsi järjestetään arvo järjestykseen
                        korttipakka.Arvojarjestys(kasi);

                        // Pelaajan vaihdettu käsi tulostetaan
                        korttipakka.Tulostapakka(kasi);

                        // Pelaajan käsi arvioidaan ja käden arvo annetaan pisteillä arvojärjestyksen mukaan.
                        int isoinKortti1 = 0;
                        int rank1 = 0;
                        if (korttipakka.royalFlush(kasi) == true)
                        {
                            Console.WriteLine("You have a royal flush!");
                            rank1 = 9;
                        }
                        else if (korttipakka.straightFlush(kasi) == true)
                        {
                            Console.WriteLine("You have a straight flush!");
                            rank1 = 8;
                        }
                        else if (korttipakka.fourOfaKind(kasi) == true)
                        {
                            Console.WriteLine("You have four of a kind!");
                            rank1 = 7;
                        }
                        else if (korttipakka.fullHouse(kasi) == true)
                        {
                            Console.WriteLine("You have a full house!");
                            rank1 = 6;
                        }
                        else if (korttipakka.flush(kasi) == true)
                        {
                            Console.WriteLine("You have a flush!");
                            rank1 = 5;
                        }
                        else if (korttipakka.straight(kasi) == true)
                        {
                            Console.WriteLine("You have a straight!");
                            rank1 = 4;
                        }
                        else if (korttipakka.triple(kasi) == true)
                        {
                            Console.WriteLine("You have a triple!");
                            rank1 = 3;
                        }
                        else if (korttipakka.twopairs(kasi) == true)
                        {
                            Console.WriteLine("You have two pairs!");
                            rank1 = 2;
                        }
                        else if (korttipakka.pair(kasi) == true)
                        {
                            Console.WriteLine("You have a pair!");
                            rank1 = 1;
                        }
                        else
                        {
                            isoinKortti1 = korttipakka.highcard(kasi);
                            Console.WriteLine("Your highest card is " + isoinKortti1);
                        }
                        Console.WriteLine("\n");

                        // Jaetaan toisen pelaajan pokerikäsi samalla tavalla

                        Console.WriteLine("____________________");
                        Console.WriteLine("| 2 Pelaajan käsi  |");
                        Console.WriteLine("====================");
                        List<Kortti> kasi2 = korttipakka.Jaa(5);
                        korttipakka.Arvojarjestys(kasi2);
                        korttipakka.Tulostapakka(kasi2);
                        korttipakka.Vaihdakasi(kasi2);
                        korttipakka.Arvojarjestys(kasi2);
                        korttipakka.Tulostapakka(kasi2);
                        int isoinKortti2 = 0;
                        int rank2 = 0;
                        if (korttipakka.royalFlush(kasi2) == true)
                        {
                            Console.WriteLine("You have a royal flush!");
                            rank2 = 9;
                        }
                        else if (korttipakka.straightFlush(kasi2) == true)
                        {
                            Console.WriteLine("You have a straight flush!");
                            rank2 = 8;
                        }
                        else if (korttipakka.fourOfaKind(kasi2) == true)
                        {
                            Console.WriteLine("You have four of a kind!");
                            rank2 = 7;
                        }
                        else if (korttipakka.fullHouse(kasi2) == true)
                        {
                            Console.WriteLine("You have a full house!");
                            rank2 = 6;
                        }
                        else if (korttipakka.flush(kasi2) == true)
                        {
                            Console.WriteLine("You have a flush!");
                            rank2 = 5;
                        }
                        else if (korttipakka.straight(kasi2) == true)
                        {
                            Console.WriteLine("You have a straight!");
                            rank2 = 4;
                        }
                        else if (korttipakka.triple(kasi2) == true)
                        {
                            Console.WriteLine("You have a triple!");
                            rank2 = 3;
                        }
                        else if (korttipakka.twopairs(kasi2) == true)
                        {
                            Console.WriteLine("You have two pairs!");
                            rank2 = 2;
                        }
                        else if (korttipakka.pair(kasi2) == true)
                        {
                            Console.WriteLine("You have a pair!");
                            rank2 = 1;
                        }
                        else//
                        {
                            isoinKortti2 = korttipakka.highcard(kasi);
                            Console.WriteLine("Your highest card is " + isoinKortti2);
                        }
                        Console.WriteLine("\n");

                        // Verrataan kahden käden paremmuutta ja ilmoitetaan pelin voittaja
                        if (rank1 > rank2)
                        {
                            Console.WriteLine("Pelaaja 1 voittaa pelin");
                        }
                        else if (rank1 < rank2)
                        {
                            Console.WriteLine("Pelaaja 2 voittaa pelin");
                        }
                        else if (rank1 == rank2)
                        {
                            if (isoinKortti1 > isoinKortti2)
                            {
                                Console.WriteLine("Pelaaja 1 voittaa isommalla korttilla " + isoinKortti1);
                            }
                            else
                            {
                                Console.WriteLine("Pelaaja 2 voittaa isommalla kortilla " + isoinKortti2);
                            }
                        }

                        Console.Write(korttipakka.Korttienmaara());
                        Console.Write(" pakassa jäljellä\n");

                        Console.WriteLine();
                        break;
                    case "0":
                        jatkaohjelmaa = false;
                        break;
                    default:
                        Console.WriteLine("Valitsit väärin!");
                        break;
                }
            }
        }
    }
}
