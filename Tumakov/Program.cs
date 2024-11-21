using System;

namespace Tumakov
{
    internal class Program
    {
        public double Sravnenie(double x, double y)
        {
            return Math.Max(x, y);
        }

        public static void Zamena(ref double x, ref double y)
        {
            double z;
            z = x; x = y; y = z;
        }

        public long Factorial(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException("Факториал не определен для отрицательных чисел.");
            }
            else if (n == 0 || n == 1)
            {
                return 1;
            }
            else
            {
                return n * Factorial(n - 1);
            }
        }
        public bool Fact(int n, out long fact)
        {
            fact = 1;
            if (n < 0)
            {
                Console.WriteLine("Факториал не определен для отрицательного числа\r\n");
            }
            try
            {
                for (int i = 1; i <= n; i++)
                {
                    checked
                    {
                        fact *= i;
                    }
                }
                return true;
            }
            catch (OverflowException)
            {
                return false;
            }
        }

        public static int NOD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public static int NOD(int a, int b,int c)
        {
            return NOD(NOD(a, b), c);
        }
        static int Fibonacci(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Индекс должен быть положительным числом.");
            }
            else if (n == 1 || n == 2)
            {
                return 1;
            }
            else
            {
                return Fibonacci(n - 1) + Fibonacci(n - 2);
            }
        }

        static void Main(string[] args)
        {
            //Задание 5.1
            Program program = new Program();
            Console.WriteLine("Задание 5.1");
            Console.WriteLine("Введите 2 числа(в столбик)");
            string a = Console.ReadLine();
            string b = Console.ReadLine();
            if (double.TryParse(a, out double a1) && double.TryParse(b, out double b1))
            {
            Console.WriteLine($"Наибольшее число из {a} и {b}: {program.Sravnenie(a1,b1)}");
            }
            else
            {
                Console.WriteLine("Ошибка: Введите числа");
            }
            Console.ReadKey();

            //Задание 5.2
            Console.WriteLine("Задание 5.2");
            Console.WriteLine("Введите значения 2 параметров(в столбик)");
            string x = Console.ReadLine();
            string y = Console.ReadLine();
            Console.WriteLine($"Заначения до замены: {x}, {y}");
            if (double.TryParse(x, out double x1) && double.TryParse(y, out double y1))
            {
                Zamena(ref x1, ref y1);
                Console.WriteLine($"Значения параметров после замены: {x1}, {y1}");
            }
            else
            {
                Console.WriteLine("Ошибка: Введите число");
            }

            //5.3
            Console.WriteLine("Задание 5.3");
            Console.WriteLine("Введите число: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int n))
            {
                if (program.Fact(n, out long fact))
                {
                    Console.WriteLine($"Факториал и числа {n} это {fact}\r\n");
                }
                else
                {
                    Console.WriteLine("Переполнение при вычислении факториала\r\n");
                }
            }


            //Задание 5.4
            try
            {
                Console.WriteLine("Задание 5.4");
                Console.WriteLine("Введите число: ");
                string fact = Console.ReadLine();
                if (int.TryParse(fact, out int factorial))
                {
                    long result = program.Factorial(factorial);
                    Console.WriteLine($"Факториал числа {fact}: {result}");
                }
                else
                {
                    Console.WriteLine("Ошибка: Введите число корректно\r\n");
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("Ошибка: факториал слишком большой\r\n");
            }

            //Домашнее задание
            //Задание 5.1
            Console.WriteLine("Задание 5.1");
            Console.WriteLine("Введите три числа(в столбик): ");
            string aa = Console.ReadLine();
            string bb = Console.ReadLine();
            string cc = Console.ReadLine();
            if (int.TryParse(aa, out int aa1) && int.TryParse(bb, out int bb1) && int.TryParse(cc, out int cc1))
            {
                int maxi1 = NOD(aa1, bb1);
                int maxi2 = NOD(aa1,bb1,cc1);
                Console.WriteLine($"НОД для 2 чисел {aa1} и {bb1}: {maxi1}");
                Console.WriteLine($"НОД для 3 чисел {aa1} и {bb1} и {cc1}: {maxi2}");
            }
            else
            {
                Console.WriteLine("Ошибка: введите целые числа");
            }
            
            //Задание 5.2
            Console.WriteLine("Задание 5.2");
            Console.WriteLine("Введите индекс члена последовательности Фибоначчи");
            string nn = Console.ReadLine();
            int resultat;
            if (int.TryParse(nn, out int nn1))
            {
                resultat = Fibonacci(nn1);
                Console.WriteLine($"N-й член последовательности Фибоначчи равен: {resultat}");
            }

            Console.ReadKey();



        }
    }
}
