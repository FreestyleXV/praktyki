using System;
using System.Collections.Generic;
using System.Text;

namespace NGramy.BL
{
    public class NGram
    {

        public static string podanyTekst { get; set; }

        public static string PobierzTekst()
        {
            Console.WriteLine("Podaj tekst");
            return (podanyTekst = Console.ReadLine());
        }
        public static string CzystyTekst(string podanyTekst)
        {
            string tekstWynikowy = String.Empty;

            foreach (char znak in podanyTekst)
            {
                if (znak == 32 | (znak >= 48 && znak <= 57) || (znak >= 65 && znak <= 90) | (znak >= 97 && znak <= 122))
                {
                    tekstWynikowy += znak;
                }
            }
            Console.WriteLine(tekstWynikowy);
            return tekstWynikowy;
        }
        public static List<string> GenerujNGramy(string tekstWynikowy, int dlugoscNGramu)
        {
            int dlugoscTekstu = tekstWynikowy.Length;
            int iloscNGramow = 0;
            string nGram = string.Empty;
            List<string> listaNGramow = new List<string>();
            for (int i = 1; i <= dlugoscNGramu; i++)
            {
                iloscNGramow += (dlugoscTekstu - (dlugoscTekstu % dlugoscNGramu)) / dlugoscNGramu;
                dlugoscTekstu -= 1;
            }
            for (int i = 0; i < iloscNGramow; i++)
            {
                nGram = tekstWynikowy.Substring(i, dlugoscNGramu);
                listaNGramow.Add(nGram);
            }
            return listaNGramow;
        }
        public static int LiczbaNGramow(string Tekst,int dlugoscNGramu)
        {
            int iloscNGramow = 0;
            int dlugoscTekstu = Tekst.Length;
            for (int i = 1; i <= dlugoscNGramu; i++)
            {
                iloscNGramow += (dlugoscTekstu - (dlugoscTekstu % dlugoscNGramu)) / dlugoscNGramu;
                dlugoscTekstu -= 1;
            }
            return iloscNGramow;
        }
        public static int LiczbaNGramow(List<string> listaNGramow)
        {
            return listaNGramow.Count;
        }
        public static List<string> GenerujNGramy(string tekstWynikowy)
        {
            int dlugoscNGramu = 2;
            int dlugoscTekstu = tekstWynikowy.Length;
            int iloscNGramow = 0;
            string nGram = string.Empty;
            List<string> listaNGramow = new List<string>();
            for (int i = 1; i <= dlugoscNGramu; i++)
            {
                iloscNGramow += (dlugoscTekstu - (dlugoscTekstu % dlugoscNGramu)) / dlugoscNGramu;
                dlugoscTekstu -= 1;
            }
            for (int i = 0; i < iloscNGramow; i++)
            {
                nGram = tekstWynikowy.Substring(i, dlugoscNGramu);
                listaNGramow.Add(nGram);
            }
            return listaNGramow;
        }
        public static List<string> UsunPowtorki(List<string> listaNGramow)
        {
            List<string> list = new List<string>();
            foreach (string ngram in listaNGramow)
            {
                list.Add(ngram);
            }
            foreach (string ngram in list)
            {
                while (listaNGramow.IndexOf(ngram) != listaNGramow.LastIndexOf(ngram))
                {
                    listaNGramow.Remove(ngram);
                }
            }
            return listaNGramow;
        }
        public static void WyswietlListeBezPowtorek(List<string> listaNgramow)
        {
            foreach (string ngram in listaNgramow)
            {
                Console.WriteLine(ngram);
            }
        }
    }
}