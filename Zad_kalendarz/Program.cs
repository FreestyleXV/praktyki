using System;
using System.Collections.Generic;
using System.Linq;

namespace Zad_kalendarz
{
    public enum MiesiaceWRoku
    {
        Placeolder,
        Styczen,
        Luty,
        Marzec,
        Kwiecien,
        Maj,
        Czerwiec,
        Lipiec,
        Sierpien,
        Wrzesien,
        Pazdziernik,
        Listopad,
        Grudzien
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj pierwszy rok z Przedziału 1900-2100");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj drugi rok z przedziału 1900-2100");
            int secondYear = int.Parse(Console.ReadLine());
            operacjeObliczeniowe.petle(year, secondYear);
            Console.ReadKey();
        }
    }
}

