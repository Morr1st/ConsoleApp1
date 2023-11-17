using System.Runtime.CompilerServices;
using System.Security.Cryptography;

class program
{
    static void Main(string[] args)
    {
        int n = 0;
        Console.WriteLine("Какое задание Вы хотите просмотреть? 1,2,3:");
        int choose = Convert.ToInt32(Console.ReadLine());
        Plusik pls = new Plusik(n);
        bool sw1 = true;
        switch (choose)
        {
            case 1:
                Console.WriteLine("Введите a,b,c");
                int a = Convert.ToInt32(Console.ReadLine());
                int b = Convert.ToInt32(Console.ReadLine());
                int c = Convert.ToInt32(Console.ReadLine());
                ReshitOnline gdz = new ReshitOnline();
                ReshitOnline.Znaki(a, b, c, 0);
                break;
            case 2:
                while (sw1)
                {
                    Console.WriteLine("Выйти = -1 Введите число: ");
                    n = Convert.ToInt32(Console.ReadLine());
                    if (n == -1) { sw1 = false; }
                    else { pls.SetNumber(n); }
                }
                break;
            case 3:
                int shift;
                Console.Write("Введите текст: ");
                string UserStringToConvert = Console.ReadLine();
                Console.Write("Введите сдвиг: ");
                while (true)
                {
                    shift = Convert.ToInt32(Console.ReadLine());
                    if (shift <= 0)
                    {
                        Console.Write("Так нельзя: ");
                    }
                    else break;
                }

                Cezar cz = new Cezar(UserStringToConvert, shift);
                Console.WriteLine("Расшифровать - 1, зашифровать - 2");
                while (true)
                {
                    int option = Convert.ToInt32(Console.ReadLine());
                    if (option == 2)
                    {
                        Console.Write("Зашифрованное слово: ");
                        cz.ConvertedString();
                        break;
                    }
                    if (option == 1)
                    {

                        Console.Write("Расшифровонное слово: ");
                        cz.UnConvertedString();
                        break;
                    }
                    else
                    {
                        Console.Write("Неверное действие: ");
                    }
                }
                break;
        }
    }
    class ReshitOnline // Задание 1
    {
        public static void Znaki(int a, int b, int c, float d)
        {
            Discrim(a, b, c, d);
        }
        private static void Discrim(int a, int b, int c, float d)
        {
            d = (b * b) - (4 * a * c);
            Proverka(a, b, c, d);
        }
        private static void Proverka(int a, int b, int c, float d)
        {
            if (d > 0)
            {
                CalculateRoots(a, b, c, d);
            }
            if (d <= 0)
            {
                Console.WriteLine("Корней нет");
            }
        }
        static void CalculateRoots(int a, int b, int c, float d)
        {
            float x = (-b + (d / d)) / 2 * a;
            Console.WriteLine(x);
        }
    }
    class Plusik //Задание 2
    {
        private int n;
        private int number;
        public Plusik(int number)
        {
            this.number = number;
        }
        public bool SetNumber(int number)
        {
            if (number == n + 1)
            {
                n = number;
                Console.WriteLine("Верно");
                return true;
            }
            else
            {
                Console.WriteLine("Не верно");
                n = 0;
                return false;
            };
        }
    }
    class Cezar
    {
        private string ConvertIn;
        private int ShiftTo;
        private char[] alphabet = { 'а', 'б', 'в', 'г', 'д',
                                    'е', 'ё', 'ж', 'з', 'и',
                                    'й', 'к', 'л', 'м', 'н',
                                    'о', 'п', 'р', 'с', 'т',
                                    'у', 'ф', 'х', 'ц', 'ч',
                                    'ш', 'щ', 'ъ', 'ы', 'ь',
                                    'э', 'ю', 'я'};
        public Cezar(string convertIn, int shiftTo)
        {
            this.ConvertIn = convertIn;
            this.ShiftTo = shiftTo;
        }

        private string ConvertingString(string Convert, int shift)
        {
            string result = "";
            foreach (char symbol in Convert)
            {
                for (int i = 0; i < alphabet.Length; i++)
                {
                    if (symbol == alphabet[i])
                    {
                        int newIndex = (i + shift) % alphabet.Length;
                        result += alphabet[newIndex];
                    }
                }
            }
            return result;
        }
        private string UnConvert(string Convert, int shift)
        {
            string result = "";
            foreach (char symbol in Convert)
            {
                for (int i = 0; i < alphabet.Length; i++)
                {
                    if (symbol == alphabet[i])
                    {
                        int newIndex = (i - shift + alphabet.Length) % alphabet.Length;
                        result += alphabet[newIndex];
                    }
                }
            }
            return result;
        }
        public void UnConvertedString()
        {
            Console.WriteLine(UnConvert(ConvertIn, ShiftTo));
        }
        public void ConvertedString()
        {
            Console.WriteLine(ConvertingString(ConvertIn, ShiftTo));
        }
    }
}