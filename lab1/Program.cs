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

    static Int32 EnterNumber()
    {
        Int32 num;
        try
        {
            num = Convert.ToInt32(Console.ReadLine());
        }
        catch
        {
            Console.WriteLine("Некорректные входные данные!");
            num = EnterNumber();
        }
        return num;
    }

    static void Run()
    {
        Int32 num = EnterNumber();
        switch (num)
        {
            case 0:
                Console.WriteLine("Пока!");
                return;
            case 1:
                Console.WriteLine("Перевод градусов!");
                break;
            case 2:
                Console.WriteLine("Определение палиндрома!");
                break;
            case 3:
                Console.WriteLine("Задача о размножении кроликов!");
                break;
            case 4:
                Console.WriteLine("Работа с файлами!");
                break;
            default:
                Console.WriteLine("Некорректные входные данные!");
                Run();
                break;
        }
    }
    static void Main()
    {
        PrintMenu();
        Run();
    }
}  