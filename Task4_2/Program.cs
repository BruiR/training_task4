using System;

namespace Task4_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var rn1 = new RationalNumber(2, 6);
            Console.WriteLine($"rn1 ={rn1}");
            var rn2 = new RationalNumber(5, 25);
            Console.WriteLine($"rn2 ={rn2}");
            var rn3 = new RationalNumber(5, 26);
            Console.WriteLine($"rn3 ={rn3}");
            var rn4 = new RationalNumber(3, 9);
            Console.WriteLine($"rn4 ={rn4}");
            Console.WriteLine($"rn1.Equals(rn4) = {rn1.Equals(rn4)}");
            Console.WriteLine($"rn1.CompareTo(rn4) = {rn1.CompareTo(rn4)}");

            Console.WriteLine($"rn1.Equals(rn2) = {rn1.Equals(rn2)}");
            Console.WriteLine($"rn1.CompareTo(rn2) = {rn1.CompareTo(rn2)}");
            Console.WriteLine($"rn2.CompareTo(rn1) = {rn2.CompareTo(rn1)}");

            Console.WriteLine($"rn1+rn2 = {rn1+rn2}");
            Console.WriteLine($"rn1+3 = {rn1 + 3}");

            Console.WriteLine($"rn1-rn2 = {rn1 - rn2}");
            Console.WriteLine($"rn1-3 = {rn1 - 3}");

            Console.WriteLine($"rn1*rn2 = {rn1 * rn2}");
            Console.WriteLine($"rn1*3 = {rn1 * 3}");

            Console.WriteLine($"rn1/rn2 = {rn1 / rn2}");
            Console.WriteLine($"rn1/3 = {rn1 / 3}");

            Console.WriteLine($"явное приведение к double = {(double)rn1}");
            Console.WriteLine($"(неявное приведение int к RationalNumber) 3+rn1= { 3+rn1 }");
        }
    }
}
