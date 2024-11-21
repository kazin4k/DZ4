using System;
using System.Linq;

namespace File
{
    public enum Vorchlivost
    {
        Низкий,
        Средний,
        Высокий
    }

    public struct Ded
    {
        public string Name;
        public Vorchlivost Level;
        public string[] Phrases;
        public int Bruises;

        public Ded(string name, Vorchlivost level, string[] phrases)
        {
            Name = name;
            Level = level;
            Phrases = phrases;
            Bruises = 0;
        }

        public int CheckBadWords(params string[] badWords)
        {
            foreach (var phrase in Phrases)
            {
                foreach (var badWord in badWords)
                {
                    if (phrase.IndexOf(badWord, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        Bruises++;
                    }
                }
            }
            return Bruises;
        }
    }
    internal class Program
    {
        static void DrawDigit(int number)
        {
            switch (number)
            {
                case 0:
                    Console.WriteLine("  ###  ");
                    Console.WriteLine(" #   # ");
                    Console.WriteLine(" #   # ");
                    Console.WriteLine(" #   # ");
                    Console.WriteLine("  ###  ");
                    break;
                case 1:
                    Console.WriteLine("   #   ");
                    Console.WriteLine("  ##   ");
                    Console.WriteLine("   #   ");
                    Console.WriteLine("   #   ");
                    Console.WriteLine("  ###  ");
                    break;
                case 2:
                    Console.WriteLine("  ###  ");
                    Console.WriteLine("     # ");
                    Console.WriteLine("  ###  ");
                    Console.WriteLine(" #     ");
                    Console.WriteLine("  ###  ");
                    break;
                case 3:
                    Console.WriteLine("  ###  ");
                    Console.WriteLine("     # ");
                    Console.WriteLine("  ###  ");
                    Console.WriteLine("     # ");
                    Console.WriteLine("  ###  ");
                    break;
                case 4:
                    Console.WriteLine(" #   # ");
                    Console.WriteLine(" #   # ");
                    Console.WriteLine("  ###  ");
                    Console.WriteLine("     # ");
                    Console.WriteLine("     # ");
                    break;
                case 5:
                    Console.WriteLine("  ###  ");
                    Console.WriteLine(" #     ");
                    Console.WriteLine("  ###  ");
                    Console.WriteLine("     # ");
                    Console.WriteLine("  ###  ");
                    break;
                case 6:
                    Console.WriteLine("  ###  ");
                    Console.WriteLine(" #     ");
                    Console.WriteLine(" ####  ");
                    Console.WriteLine(" #   # ");
                    Console.WriteLine("  ###  ");
                    break;
                case 7:
                    Console.WriteLine("  ###  ");
                    Console.WriteLine("     # ");
                    Console.WriteLine("    #  ");
                    Console.WriteLine("   #   ");
                    Console.WriteLine("   #   ");
                    break;
                case 8:
                    Console.WriteLine("  ###  ");
                    Console.WriteLine(" #   # ");
                    Console.WriteLine("  ###  ");
                    Console.WriteLine(" #   # ");
                    Console.WriteLine("  ###  ");
                    break;
                case 9:
                    Console.WriteLine("  ###  ");
                    Console.WriteLine(" #   # ");
                    Console.WriteLine("  ####  ");
                    Console.WriteLine("     # ");
                    Console.WriteLine("  ###  ");
                    break;
                default:
                    break;
            }
        }
        static int CalculateArray(ref int product, out double average, params int[] array)
        {
            int sum = 0;
            product = 1;

            foreach (int number in array)
            {
                sum += number;
                product *= number;
            }

            average = array.Length > 0 ? (double)sum / array.Length : 0;

            return sum;
        }
        static void PrintArray(int[] array)
        {
            foreach (int number in array)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            //Задание 1
            Console.WriteLine("Задание 1");
            Random random = new Random();
            int[] numbers = new int[20];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(1, 101);
            }

            Console.WriteLine("Исходный массив:");
            PrintArray(numbers);

            int firstNumber, secondNumber;

            Console.WriteLine("Введите первое число для обмена:");
            while (!int.TryParse(Console.ReadLine(), out firstNumber) || !Array.Exists(numbers, element => element == firstNumber))
            {
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите число из массива");
            }

            Console.WriteLine("Введите второе число для обмена:");
            while (!int.TryParse(Console.ReadLine(), out secondNumber) || !Array.Exists(numbers, element => element == secondNumber))
            {
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите число из массива");
            }

            int index1 = Array.IndexOf(numbers, firstNumber);
            int index2 = Array.IndexOf(numbers, secondNumber);

            int temp = numbers[index1];
            numbers[index1] = numbers[index2];
            numbers[index2] = temp;

            Console.WriteLine("Измененный массив:");
            PrintArray(numbers);


            //Задание 2
            Console.WriteLine("Задание 2");
            int[] chisla = { 1, 2, 3, 4, 5 };
            int product = 1;
            double average;

            int sum = CalculateArray(ref product, out average, numbers);

            Console.WriteLine($"Сумма элементов: {sum}");
            Console.WriteLine($"Произведение элементов: {product}");
            Console.WriteLine($"Среднее арифметическое: {average}");


            //Задание 3
            Console.WriteLine("Задание 3");
            bool running = true;
            while (running)
            {
                Console.Write("Введите число (или 'exit' для выхода): ");
                string input = Console.ReadLine();

                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase) || input.Equals("закрыть", StringComparison.OrdinalIgnoreCase))
                {
                    running = false;
                    continue;
                }

                try
                {
                    int number = int.Parse(input);

                    if (number >= 0 && number <= 9)
                    {
                        DrawDigit(number);
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Clear();
                        Console.WriteLine("Ошибка: число должно быть от 0 до 9");
                        System.Threading.Thread.Sleep(3000);
                        Console.ResetColor();
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка: введено не число");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Ошибка: число слишком велико или слишком мало");
                }

                //Задание 4
                Console.WriteLine("Задание 4");
                Ded ded1 = new Ded("Дедушка Кирилл", Vorchlivost.Низкий, new string[] { "Гады!", "Что за ерунда?" });
                Ded ded2 = new Ded("Дедушка Владимир", Vorchlivost.Средний, new string[] { "Проститутки!", "Я вас не понимаю!", "Гады!" });
                Ded ded3 = new Ded("Дедушка Ярослав", Vorchlivost.Высокий, new string[] { "Как же вы меня достали!", "Гады!" });
                Ded ded4 = new Ded("Дедушка Алексей", Vorchlivost.Низкий, new string[] { "Что за безобразие?" });
                Ded ded5 = new Ded("Дедушка Николай", Vorchlivost.Средний, new string[] { "Проститутки!", "Вы не правы!", "Гады!", "Как же это бесит!" });

                string[] badWords = { "проститутки", "гады" };

                Console.WriteLine($"{ded1.Name} получил {ded1.CheckBadWords(badWords)} синяков.");
                Console.WriteLine($"{ded2.Name} получил {ded2.CheckBadWords(badWords)} синяков.");
                Console.WriteLine($"{ded3.Name} получил {ded3.CheckBadWords(badWords)} синяков.");
                Console.WriteLine($"{ded4.Name} получил {ded4.CheckBadWords(badWords)} синяков.");
                Console.WriteLine($"{ded5.Name} получил {ded5.CheckBadWords(badWords)} синяков.");

            }
        }
    }
}
