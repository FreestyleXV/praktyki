using System;
using System.Collections.Generic;
using System.Text;

namespace Zad_kalendarz
{
    public class operacjeObliczeniowe
    {
        public static void petle(int year, int secondYear)
        {
            for (int i = year; i <= secondYear; i++)
            {
                Console.WriteLine("Miesiące 5 weekendowe w roku" + i);
                int licznik4Wk = 1;
                int licznik5Wk = 0;

                for (int j = 1; j <= 12; j++)
                {
                    DateTime dt = new DateTime(i, j, 1);

                    if (j == 1 || j == 3 || j == 5 || j == 7 || j == 8 || j == 10 || j == 12)
                    {
                        if (dt.DayOfWeek == DayOfWeek.Friday || dt.DayOfWeek == DayOfWeek.Saturday)
                        {
                            licznik5Wk++;
                            Console.WriteLine((MiesiaceWRoku)j);
                        }
                        else
                        {
                            licznik4Wk++;
                        }
                    }
                    else if (j == 4 || j == 6 || j == 9 || j == 11)
                    {
                        if (dt.DayOfWeek == DayOfWeek.Saturday)
                        {

                            licznik5Wk++;
                            Console.WriteLine((MiesiaceWRoku)j);
                        }
                        else
                        {
                            licznik4Wk++;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                Console.WriteLine("W roku {0} jest {1} miesięcy 4 weekendowych i {2} miesięcy 5 weekendowych", i, licznik4Wk, licznik5Wk);
            }
        }
    }
}
