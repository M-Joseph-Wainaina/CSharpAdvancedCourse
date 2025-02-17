// See https://aka.ms/new-console-template for more information
Quiz.Uncensor("Wh*r* d*d my v*w*ls g*?", "eeioeo");

Quiz.Uncensor("abcd", "");

Quiz.Uncensor("*PP*RC*S*", "UEAE");
class Quiz
{
    public static string Uncensor(string txt, string vowels)
    {
        string UncensoredString = String.Empty;
        int count = 0;

        for (int i = 0; i < txt.Length; i++)
        {
            
            if (txt[i] != '*')
            {
                UncensoredString += txt[i];
            }
            else
            {
                UncensoredString += vowels[count];
                count++;
            }

        }

        Console.WriteLine(UncensoredString);

        return UncensoredString;


    }
}