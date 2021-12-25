using System;

namespace Task4_2
{
    public sealed class RationalNumber : IComparable<RationalNumber>
    {
        public int Numerator { get; }
        public int Denumerator { get; }
        public RationalNumber(int numerator, int denumerator)
        {
            if (denumerator == 0) throw new ArgumentNullException(nameof(denumerator));
            //приведение к несократимой дроби
            int d = Nod(numerator, denumerator);
            Numerator = numerator / d; 
            Denumerator = denumerator / d;

        }

        public int CompareTo(RationalNumber otherNumber)
        {
            int thisNumerator = Numerator * otherNumber.Denumerator;
            int otherNumerator = otherNumber.Numerator * Denumerator;
            return thisNumerator - otherNumerator;
        }

        public override bool Equals(object obj)
        {
            if (obj is RationalNumber rationalNumber)
            {
                return (Numerator == rationalNumber.Numerator) && (Denumerator == rationalNumber.Denumerator);
            }
            else
            {
                throw new ArgumentException("object is not RationalNumber", nameof(obj));
            }
        }

        public override int GetHashCode()
        {
            return Numerator * Denumerator;
        }

        public override string ToString()
        {
            return ($"{Numerator}/{Denumerator}");
        }

        public static RationalNumber operator +(RationalNumber rationalNumber, int number)
        {
            if (rationalNumber == null)
            {
                throw new ArgumentNullException(nameof(rationalNumber));
            }
            int numerator = rationalNumber.Numerator + rationalNumber.Denumerator * number;
            int d = Nod(numerator, rationalNumber.Denumerator);
            numerator /= d;
            int denumerator = rationalNumber.Denumerator  / d;
            return new RationalNumber(numerator, denumerator);
        }

        public static RationalNumber operator +(RationalNumber firstNumber, RationalNumber secondNumber)
        {
            if (firstNumber == null)
            {
                throw new ArgumentNullException(nameof(firstNumber));
            }
            if (secondNumber == null)
            {
                throw new ArgumentNullException(nameof(secondNumber));
            }        
            int numerator = firstNumber.Numerator * secondNumber.Denumerator  + secondNumber.Numerator * firstNumber.Denumerator;
            int denumerator = firstNumber.Denumerator * secondNumber.Denumerator;
            int d = Nod(numerator, denumerator);
            numerator /= d;
            denumerator /= d;
            return new RationalNumber(numerator, denumerator);
        }

        public static RationalNumber operator -(RationalNumber rationalNumber, int number)
        {
            if (rationalNumber == null)
            {
                throw new ArgumentNullException(nameof(rationalNumber));
            }
            int numerator = rationalNumber.Numerator - rationalNumber.Denumerator * number;
            int d = Nod(numerator, rationalNumber.Denumerator);
            numerator /= d;
            int denumerator = rationalNumber.Denumerator / d;
            return new RationalNumber(numerator, denumerator);
        }

        public static RationalNumber operator -(RationalNumber firstNumber, RationalNumber secondNumber)
        {
            if (firstNumber == null)
            {
                throw new ArgumentNullException(nameof(firstNumber));
            }
            if (secondNumber == null)
            {
                throw new ArgumentNullException(nameof(secondNumber));
            }
            int numerator = firstNumber.Numerator * secondNumber.Denumerator - secondNumber.Numerator * firstNumber.Denumerator;
            int denumerator = firstNumber.Denumerator * secondNumber.Denumerator;
            int d = Nod(numerator, denumerator);
            numerator /= d;
            denumerator /= d;
            return new RationalNumber(numerator, denumerator);
        }

        public static RationalNumber operator *(RationalNumber rationalNumber, int number)
        {
            if (rationalNumber == null)
            {
                throw new ArgumentNullException(nameof(rationalNumber));
            }
            int numerator = rationalNumber.Numerator * number;
            int d = Nod(numerator, rationalNumber.Denumerator);
            numerator /= d;
            int denumerator = rationalNumber.Denumerator / d;
            return new RationalNumber(numerator, denumerator);
        }

        public static RationalNumber operator *(RationalNumber firstNumber, RationalNumber secondNumber)
        {
            if (firstNumber == null)
            {
                throw new ArgumentNullException(nameof(firstNumber));
            }
            if (secondNumber == null)
            {
                throw new ArgumentNullException(nameof(secondNumber));
            }
            int numerator = firstNumber.Numerator * secondNumber.Numerator;
            int denumerator = firstNumber.Denumerator * secondNumber.Denumerator;
            int d = Nod(numerator, denumerator);
            numerator /= d;
            denumerator /= d;
            return new RationalNumber(numerator, denumerator);
        }

        public static RationalNumber operator /(RationalNumber rationalNumber, int number)
        {
            if (rationalNumber == null)
            {
                throw new ArgumentNullException(nameof(rationalNumber));
            }
            int denumerator = rationalNumber.Denumerator * number;
            int d = Nod(rationalNumber.Numerator, denumerator);
            denumerator /= d;
            int numerator = rationalNumber.Numerator / d;
            return new RationalNumber(numerator, denumerator);
        }

        public static RationalNumber operator /(RationalNumber firstNumber, RationalNumber secondNumber)
        {
            if (firstNumber == null)
            {
                throw new ArgumentNullException(nameof(firstNumber));
            }

                if (secondNumber == null)
            {
                throw new ArgumentNullException(nameof(secondNumber));
            }
            int numerator = firstNumber.Numerator * secondNumber.Denumerator;
            int denumerator = firstNumber.Denumerator * secondNumber.Numerator;
            int d = Nod(numerator, denumerator);
            numerator /= d;
            denumerator /= d;
            return new RationalNumber(numerator, denumerator);
        }

        public static explicit operator double(RationalNumber rationalNumber)
        {
            return (double)rationalNumber.Numerator / rationalNumber.Denumerator; 
        }

        public static implicit operator RationalNumber(int number)
        {
            return new RationalNumber(number, 1); 
        }

        private static int Nod(int a, int b)
        {
            int tmp;
            a = Math.Abs(a);
            b = Math.Abs(b);
            if (b > a)
            {
                tmp = a;
                a = b;
                b = tmp;
            }
            do
            {
                tmp = a % b;
                a = b;
                b = tmp;
            } while (b != 0);
            return (a);
        }
    }
}
