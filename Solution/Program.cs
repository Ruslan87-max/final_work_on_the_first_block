
using System;
class Program
{
    delegate bool Predicate(string str);
    static string[] GetStringArrayFromConsoleString(string str1)
    {
        string[] str2 = str1.Split(',', StringSplitOptions.TrimEntries);
        return str2;
    }

    static string[] GetSortedArray(string[] str, Predicate predicate)
    {
        string[] str2 = new string[1];
        for (int i = 0; i < str.GetLength(0); i++)
        {
            if (predicate(str[i]))
            {
                str2[str2.Length - 1] = str[i];
                Array.Resize(ref str2, str2.Length + 1);
            }
        }
        Array.Resize(ref str2, str2.Length - 1);

        return str2;
    }
    static void PrintArray(string[] str)
    {
        string str2 = (str.Length == 0) ? "[]" : "[\"" + String.Join("\", \"", str) + "\"]";
        Console.WriteLine(str2);
    }

    static void Main(string[] args)
    {
        Console.InputEncoding = System.Text.Encoding.GetEncoding("utf-16");
        Console.WriteLine("Введите массив строк через запятую, завершите командами <Enter> и <Esc>:");

        string str1 = "";
        ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();

        while (true)
        {
            str1 = Convert.ToString(Console.ReadLine());
            keyInfo = Console.ReadKey();

            if (keyInfo.Key == ConsoleKey.Escape)
            {
                break;
            }
        }
        string[] str = GetStringArrayFromConsoleString(str1);
        Console.Write("\nВы ввели массив строк: ");
        PrintArray(str);
        string[] newArray = GetSortedArray(str, x => x.ToCharArray().Length <= 3);
        Console.Write("Массив из строк, длина которых меньше, либо равна 3 символам: ");
        PrintArray(newArray);
    }
}