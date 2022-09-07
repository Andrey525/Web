using System;
using System.IO;
class Program
{
    static void PrintMenu()
    {
        Console.WriteLine("Выбери пункт меню:");
        Console.WriteLine("0 - Выйти из программы");
        Console.WriteLine("1 - Перевод градусов");
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
        switch (from)
        {
            case 'C':
                switch (to)
                {
                    case 'K':
                        num += 273.15;
                        break;
                    case 'F':
                        num = num * 1.8 + 32;
                        break;
                    default:
                        break;
                }
                break;
            case 'K':
                switch (to)
                {
                    case 'C':
                        num -= 273.15;
                        break;
                    case 'F':
                        num = (num - 273.15) * 1.8 + 32;;
                        break;
                    default:
                        break;
                }
                break;
            case 'F':
                switch (to)
                {
                    case 'C':
                        num = (num - 32) / 1.8;
                        break;
                    case 'K':
                        num = (num - 32) / 1.8 + 273.15;
                        break;
                    default:
                        break;
                }
                break;
        }
        Console.WriteLine($"Результат: {num}");
    }

    static void Palindrom()
    {
        Console.Write("Введите слово: ");
        string? word = Console.ReadLine();
        if (string.IsNullOrEmpty(word))
        {
            Console.WriteLine("Введена пустая строка, нельзя определить палиндром ли это!");
            return;
        }
        for (int i = 0; i < word.Length / 2; i++)
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
        Console.WriteLine($"Число кроликов = {count}");
    }

    static void CSV()
    {
        var list = new List<int>();
        string path = @"D:\Programs\Web\lab1\lab1\data.csv";
        if (!File.Exists(path))
        {
            Console.WriteLine($"Файл {path} не существует");
            return;
        }
        foreach (string line in File.ReadLines(path))
        {
            if (int.TryParse(line, out var result))
            {
                list.Add(result);
            }
        }
        if (list.Count == 0)
        {
            Console.WriteLine("Список чисел пуст");
            return;
        }

    repeat:
        Console.WriteLine("Что хотите сделать:");
        Console.WriteLine("1 - Найти максимум");
        Console.WriteLine("2 - Найти минимум");
        Console.WriteLine("3 - Посчитать среднее значение");
        Console.WriteLine("4 - Посчитать исправленную выборочную дисперсию");

        switch (EnterNumber())
        {
            case 1:
                Console.WriteLine($"Максимум = {list.Max()}");
                break;
            case 2:
                Console.WriteLine($"Минимум = {list.Max()}");
                break;
            case 3:
                Console.WriteLine($"Среднее значение = {((int)list.Average())}");
                break;
            case 4:
                if (list.Count == 1)
                {
                    Console.WriteLine("Дисперсия = 0");
                    break;
                }
                double sum = 0;
                double average = list.Average();
                foreach (int value in list)
                {
                    sum += Math.Pow(value - average, 2);
                }
                double result = sum / (list.Count - 1);
                Console.WriteLine($"Дисперсия = {result}");
                break;
            default:
                Console.WriteLine("Некорректные входные данные!");
                goto repeat;
        }


    }

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
                CSV();
                break;
            default:
                Console.WriteLine("Некорректные входные данные!");
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