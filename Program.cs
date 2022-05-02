using System.Text;
using System.IO;

public class PasswordGenerator
{
    public static String GeneratePassword(String[] characters, int number)
    {
        int counter = 0;
        StringBuilder password = new StringBuilder();

        Random random = new Random();

        int latestPercentagePrinted = -1;
        while (counter < number)
        {
            int percentageProgress = (int)(((double)counter / (double)number) * 100.0 + 1.0);
            if (counter > 0 && percentageProgress - latestPercentagePrinted > 1)
            {
                Console.WriteLine("Whoops");
            }
            if (percentageProgress != latestPercentagePrinted)
            {
                Console.WriteLine($"{percentageProgress}% complete.");
                latestPercentagePrinted = percentageProgress;
            }
            password.Append(characters[random.Next(characters.Length)]);
            counter++;
        }

        return password.ToString();
    }

    public static void Main()
    {
        Console.WriteLine("Enter number of characters: ");
        int numberOfCharacters = int.Parse(Console.ReadLine());

        string[] characters = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "!", "\"", "£", "$", "%", "^", "&", "*", "(", ")", "-", "_", "=", "+", "[", "{", "]", "}", ";", ":", "'", "@", "#", "~", ",", "<", ".", ">", "/", "?" };

        Console.WriteLine("Generating random password...");
        string password = GeneratePassword(characters, numberOfCharacters);

        Console.WriteLine("Saving password to file...");

        try
        {
            File.WriteAllText("password.txt", password);
            Console.WriteLine("Password has been saved to file.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}