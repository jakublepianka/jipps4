public class Program
{
    public static void Main(string[] args)
    {
        string[] colors = { "Czerwony", "Zielony", "Niebieski", "Żolty"};
        
        Console.WriteLine("Mój pierwszy kolor to: " + colors[0]);
        Console.WriteLine("Mój ostatni kolor to: " + colors[3]);

        int[] liczby = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        for (int i = 0; i < liczby.Length ; i++)
        {
            Console.WriteLine("Liczba: " + liczby[i]);
        }
        foreach (int liczba in liczby)
        {
            Console.WriteLine("Liczba: " + liczba);
        }
        int counter = 0;
        while (counter < 10)
        {

            Console.WriteLine("Liczba: " + liczby[counter]);
            counter++;
        }

        List<string> fruits = new List<string>();
        fruits.Add("Jablko");
        fruits.Add("Gruszka");
        fruits.Add("Banan");
        fruits.Add("Pomarancza");
        
        Console.WriteLine(string.Join(", ", fruits));
        fruits.Remove("Jablko");
        fruits.RemoveAt(fruits.Count - 1);
        Console.WriteLine(string.Join(", ", fruits));

    }


}
66666,,,