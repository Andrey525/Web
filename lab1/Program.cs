
class Program
{
    static void PrintMenu()
    {
        Console.WriteLine("Выбери пункт меню:");
        Console.WriteLine("0 - Выйти из программы");
        Console.WriteLine("1 - Перевод граудсов");
        Console.WriteLine("2 - Определение палиндрома");
        Console.WriteLine("3 - Задача о размножении кроликов");
        Console.WriteLine("4 - Работа с файлами");
    }

    static double EnterNumber()
    {
        double result;
        while (!Double.TryParse(Console.ReadLine(), out result))
        {
            Console.WriteLine("Некорректные входные данные!");
        }
        return result;

    }
    static void ConvertTemperature()
    {
        char from, to;
        Console.WriteLine("Введите значение температуры:");
        double num = EnterNumber();
        Console.WriteLine("Введите название шкалы (C, K, F):");

        while (!Char.TryParse(Console.ReadLine(), out from)
                || from != 'C' && from != 'K' && from != 'F')
        {
            Console.WriteLine("Некорректные входные данные!");
        }
        Console.WriteLine("Введите название шкалы, в которую надо перевести (C, K, F):");
        while (!Char.TryParse(Console.ReadLine(), out to)
                || to != 'C' && to != 'K' && to != 'F')
        {
            Console.WriteLine("Некорректные входные данные!");
        }
        if (from == 'C')
        {
            if (to == 'K')
            {
                num += 273.15;
            } else if (to == 'F')
            {
                num = num * 1.8 + 32;
            }
        } else if (from == 'K')
        {
            if (to == 'C')
            {
                num -= 273.15;
            }
            else if (to == 'F')
            {
                num = (num - 273.15) * 1.8 + 32;
            }
        } else
        {
            if (to == 'C')
            {
                num = (num - 32) / 1.8;
            }
            else if (to == 'K')
            {
                num = (num - 32) / 1.8 + 273.15;
            }
        }
        Console.WriteLine($"Результат: {num}");
    }

    static void Palindrom()
    {
        Console.Write("Введите слово: ");
        string? word = Console.ReadLine();
        if (word?.Length == 0)
        {
            Console.WriteLine("Введена пустая строка, нельзя определить палиндром ли это!");
            return;
        }
        for (int i = 0; i < word.Length; i++)
        {
            if (word[i] != word[word.Length - i - 1])
            {
                Console.WriteLine("Это не палиндром!");
                return;
            }
        }
        Console.WriteLine("Это палиндром!");
    } 
    static void Rabbit()
    {
        Console.WriteLine("Введите число месяцев:");
        int countMounths = (int)EnterNumber();
        int count = 2;
        int diff = 2;
        for (int i = 1; i < countMounths; i++)
        {
            count += diff;
            diff = count - diff;
        }
        Console.WriteLine($"Count of rabbits = {count}");
    }

    static void 

    static bool Run()
    {
        switch (EnterNumber())
        {
            case 0:
                Console.WriteLine("Пока!");
                return false;
            case 1:
                ConvertTemperature();
                break;
            case 2:
                Palindrom();
                break;
            case 3:
                Rabbit();
                break;
            case 4:
                Console.WriteLine("Работа с файлами!");
                break;
            default:
                Console.WriteLine("Некорректные входные данные!");
                Run();
                break;
        }
        return true;
    }
    static void Main()
    {
        bool isContinued = true;
        while (isContinued)
        {
            PrintMenu();
            isContinued = Run();
        }

    }
}