using System;
using System.Collections.Generic;
using System.Text;
using NGramy.BL;
using log4net;
using log4net.Config;
using System.IO;
using System.Reflection;

namespace NGramy.App
{
    public class Sterowanie
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        static List<string> ListaNGramow = new List<string>();

        public static void Menu()
        {
            Console.WriteLine("Witaj, użytkowniku"); //Pobieranie tekstu od użytkownika.
            string podanyTekst = NGram.PobierzTekst();

            string tekstWynikowy = NGram.CzystyTekst(podanyTekst); //Oczyszczenie tekstu z niedozwolonych znaków.

            Console.WriteLine("Podaj długość NGramu (Domyślnie = 2)"); //Podanie długości Ngramu (opcjonalne).
            string dlugoscNGramu = string.Empty;
            try
            {

                dlugoscNGramu = Console.ReadLine();

                if (dlugoscNGramu == String.Empty)
                {
                    foreach (string ngram in NGram.GenerujNGramy(tekstWynikowy))  //Przeładowana metoda Generowania i wyświetlania NGramów o domyślnej długości 2 znaków.
                    {
                        ListaNGramow.Add(ngram);
                    }
                }
                else
                {
                    int dlugoscNGramuInt = Convert.ToInt32(dlugoscNGramu);
                    foreach (string ngram in NGram.GenerujNGramy(tekstWynikowy, dlugoscNGramuInt)) //Przeładowana metoda Generowania i wyświetlania NGramów o długości podanej przez użytkownika
                    {
                        ListaNGramow.Add(ngram);
                    }
                }
                if (Convert.ToInt32(dlugoscNGramu) < 0)
                    throw new ArgumentOutOfRangeException();


            }
            catch (ArgumentOutOfRangeException outOfRange)
            {
                Console.WriteLine(outOfRange.Message);
                log.Error("Podano ujemnny argument");
                Sterowanie.Menu();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {

            }
            Console.WriteLine("Czy chcesz wyświetlić także powtórki? (t/n)"); //Sprawdzenie czy użytkownik chce wyświetlić także powtórki NGramów.
            string czyPowtorki = Console.ReadLine();
            Console.Clear();

            if (czyPowtorki == "n") //Wyświetlenie Ngramów bez powtórek
            {
                Console.WriteLine("Lista Ngramów: ");
                foreach (string ngram in NGram.UsunPowtorki(ListaNGramow))
                {
                    Console.Write("-({0}), ", ngram);
                }
            }

            else //Wyświetlenie Ngramów z powtórkami
            {
                Console.WriteLine("Lista Ngramów: ");
                foreach (string ngram in ListaNGramow)
                {
                    Console.Write("-({0}), ", ngram);
                }
            }
        }
    }
}