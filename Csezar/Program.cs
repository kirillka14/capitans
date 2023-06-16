using System.Text.RegularExpressions;
using static Csezar.AbraKadabra;

Console.WriteLine("Команда HELP - справка о командах");
PrintChoice();
string command;
int check = 1;
do
{

    command = Console.ReadLine();
    command = CheckCommand(command);

    var mas = command.Split(' ');
    string resCommand = "";
    if (mas[0] == "DECRYPT")
    {
        resCommand = mas[0] + " " + mas[1];
    } else
    {
        resCommand = mas[0];
    }
    switch (resCommand)
    {
        case "HELP":
            PrintChoice();
            break;
        case "CEZAR":// mas[1] - key, mas[2] - file
            Console.WriteLine(Cesar.Crypt(int.Parse(mas[1]), mas[2]));

            break;
        case "DECRYPT CEZAR"://mas[2] - key, mas[3] - file
            Console.WriteLine(Cesar.Decrypt(int.Parse(mas[2]), mas[3]));

            break;
        case "SUB"://mas[1] - keyfile, mas[2] - file
            Console.WriteLine($"s");
            break;
        case "DECRYPT SUB"://mas[2] - keyfile, mas[3] - file
            Console.WriteLine($"ds");
            break;
        case "VIGENERE"://mas[1] - file
            Console.WriteLine($"v");
            break;
        case "DECRYPT VIGENERE"://mas[2] - file
            Console.WriteLine($"dv");
            break;
        default:
            Console.WriteLine("Нет такой команды!");
            break;


    }





}
while (check != 0);


string CheckCommand (string command)
{
    if (!string.IsNullOrWhiteSpace(command))
    {
        if (Regex.IsMatch(command, @"CEZAR (1|2|3|4|5|6|7|8|9|10|11|12|13|14|15|16|17|18|19|20|21|22|23|24|25|26|27|28|29|30|31|32|33) ((?:.*\\)?)([\w\s]+\.\w+)$", RegexOptions.IgnoreCase))
        {
            return command;
        } else if (Regex.IsMatch(command, @"DECRYPT CEZAR (1|2|3|4|5|6|7|8|9|10|11|12|13|14|15|16|17|18|19|20|21|22|23|24|25|26|27|28|29|30|31|32|33) ((?:.*\\)?)([\w\s]+\.\w+)$", RegexOptions.IgnoreCase))
        {
            return command;
        } else if (Regex.IsMatch(command, @"SUB ((?:.*\\)?)([\w\s]+\.\w+) ((?:.*\\)?)([\w\s]+\.\w+)$", RegexOptions.IgnoreCase))
        {
            return command;
        } else if (Regex.IsMatch(command, @"DECRYPT SUB ((?:.*\\)?)([\w\s]+\.\w+) ((?:.*\\)?)([\w\s]+\.\w+)$", RegexOptions.IgnoreCase))
        {
            return command;
        } else if (Regex.IsMatch(command, @"VIGENERE ((?:.*\\)?)([\w\s]+\.\w+)$", RegexOptions.IgnoreCase))
        {
            return command;
        } else if (Regex.IsMatch(command, @"DECRYPT VIGENERE ((?:.*\\)?)([\w\s]+\.\w+)$", RegexOptions.IgnoreCase))
        {
            return command;
        } else if (command == "HELP")
        {
            return command;
        }
    } else
    {
        return "Команда не может быть пустой!";
    }

    return "Нет такой команды или она не верна!";
}
void PrintChoice ()
{
    Console.WriteLine("Команды:");
    Console.WriteLine("CEZAR <KEY> <FILE> - выполняет шифровку файла с помощью шифра Цезаря, используя сдвиг KEY;");
    Console.WriteLine("DECRYPT CEZAR<KEY> < FILE > -выполняет рассшифровку файла с помощью шифра Цезаря, используя сдвиг KEY;");
    Console.WriteLine("SUB <KEYFILE> <FILE> - выполняет шифровку файла FILE методом подстановки, используя в качестве словаря KEYFILE;");
    Console.WriteLine("DECRYPT SUB <KEYFILE> <FILE> - выполняет рассшифровку файла FILE методом подстановки, используя в качестве словаря KEYFILE;");
    Console.WriteLine("VIGENERE <FILE> - выполняет шифровку файла с помощью метода Виженера, использовать квадрат Виженера;");
    Console.WriteLine("DECRYPT VIGENERE <FILE> - выполняет рассшифровку файла FILE с помощью метода Виженера, использовать квадрат Виженера;");

}