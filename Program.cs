﻿using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace ChallengeETres
{
    internal class Program
    {
        // Exercise 1
        // MCD "Máximo Común Divisor" (Algoritmo de Euclides)
        public static int MCD(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                return numerator;
            }

            int resultado;

            while (denominator != 0)
            {
                resultado = numerator % denominator;
                numerator = denominator;
                denominator = resultado;
            }

            return numerator;
        }

        public static void Simplificar(string fraction)
        {
            string[] subs = fraction.Split('/');

            int numerator = int.Parse(subs[0]);
            int denominator = int.Parse(subs[1]);

            int dividir = MCD(numerator, denominator);

            numerator /= dividir;
            denominator /= dividir;

            Console.WriteLine("{0}/{1}", numerator, denominator);
        }

        // Exercise 2
        public static bool RulerA(string name)
        {
            string[] subs = name.Split(' ');
            int counterCapitalOriginal = 0;

            foreach (string word in subs)
            {
                TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
                string isCapitalize = ti.ToTitleCase(word);

                if (word.Equals(isCapitalize))
                {
                    counterCapitalOriginal++;
                }
            }

            if (subs.Length == counterCapitalOriginal)
            {
                return true;
            }

            Console.WriteLine("capitalización");

            return false;
        }

        public static bool RulerB(string name)
        {
            string[] subs = name.Split(' ');

            if(subs.Length > 1)
            {
                if (subs[0].Length == 1 || subs[1].Length == 1)
                {
                    Console.WriteLine("falta el punto detrás de la inicial");
                    return false;
                }
                else if ((subs[0].Length > 2) && subs[0].Contains('.'))
                {
                    Console.WriteLine("Las palabras no pueden finalizar con puntos (solo iniciales)");
                    return false;
                }
                else if(subs[1].Length > 2 && subs[1].Contains('.'))
                {
                    Console.WriteLine("Las palabras no pueden finalizar con puntos (solo iniciales)");
                    return false;
                }
                else if (subs[0].Length == 2 || subs[1].Length == 2)
                {
                    if (subs[0].Contains('.') || subs[1].Contains('.'))
                    {
                        return true;
                    }
                }
                else
                {
                    // Si no tiene iniciales es valido el nombre
                    return true;
                }
            }

            // En caso de que sea un solo nombre completo es valido
            return true;
        }

        public static bool RulerC(string name)
        {
            string[] subs = name.Split(' ');

            if (subs.Length > 1)
            {
                return true;
            }

            Console.WriteLine("deben ser 2 o tres palabras");

            return false;
        }

        public static bool RulerD(string name)
        {
            string[] subs = name.Split(' ');

            if(subs.Length <= 3)
            {
                if(name.Contains('.'))
                {
                    if (subs.Length == 3)
                    {
                        if 
                        (
                            (subs[0].Contains('.') && subs[0].Length == 2) &&
                            (subs[0+1].Contains('.') && subs[0+1].Length == 2)
                        )
                        {
                            return true;
                        }
                        else if(
                                (subs[0].Length > 2) &&
                                (subs[0 + 1].Contains('.') && subs[0 + 1].Length == 2)
                            )
                        {
                            return true;
                        }
                        else if(
                                 (subs[0].Contains('.') && subs[0].Length == 2) &&
                                 (subs[0 + 1].Length > 2)
                            )
                        {
                            Console.WriteLine("no es válido: inicial como primer nombre y palabra como segundo");
                            return false;
                        }
                    }
                    else if(subs.Length == 2)
                    {
                        if(subs[0].Contains('.') && subs[0].Length == 2)
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    // En caso de que no tenga iniciales es valido (Ej. "Edgar Allan Poe")
                    return true;
                }
            }
            else
            {
                Console.WriteLine("No es válido ingresar más de 3 palabras");

                return false;
            }

            return true;
        }

        public static bool RulerE(string name)
        {
            string[] subs = name.Split(' ');

            if(subs.Length > 1)
            {
                var surnameLength = subs[subs.Length - 1].Length;

                if (surnameLength > 2)
                {
                    return true;
                }

                if (subs[subs.Length - 1].Contains('.') && surnameLength == 2)
                {
                    Console.WriteLine("Apellido como inicial");
                    return false;
                }
            }

            return true;
        }

        public static bool ValidName(string name)
        {
            bool a = RulerA(name);
            bool b = RulerB(name);
            bool c = RulerC(name);
            bool d = RulerD(name);
            bool e = RulerE(name);

            if (a && b && c && d && e)
            {
                Console.WriteLine("true");
                return true;
            }

            return false;
        }

        static void Main(string[] args)
        {
            // Exercise 1
            Console.WriteLine("Exercise 1:");
            Simplificar("4/6");
            Simplificar("10/11");
            Simplificar("100/400");


            // Exercise 2
            Console.WriteLine("Exercise 2:");
            ValidName("E. Poe"); // true
            ValidName("E. A. Poe"); // true
            ValidName("Edgard A. Poe"); // true
            ValidName("Edgard Allan Poe"); // true
            ValidName("Edgard"); // false
            ValidName("e. Poe"); // false
            ValidName("E Poe"); // false
            ValidName("E. Allan Poe"); // false
            ValidName("E. Allan P."); // false
            ValidName("Edg. Allan Poe"); // false

            ValidName("E. A Poe"); // false
            ValidName("e. a. Poe"); // false
            ValidName("E. A. P."); // false
            ValidName("Edg. A. Poe"); // false
            ValidName("E. poe"); // false
        }
    }
}