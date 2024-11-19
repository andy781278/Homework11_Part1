
using System.Numerics;

internal class Program
{
    private static void Main(string[] args)
    {
        Dictionary<string, Pair> boyNames = new Dictionary<string, Pair>();
        Dictionary<string, Pair> girlNames = new Dictionary<string, Pair>();

        using (StreamReader s = new StreamReader("boynames.txt"))
        {
            string? line = null;
            int i = 0;
            while ((line = s.ReadLine()) != null)
            {
                string[] splited = line.Split(' ');
                Pair pair = new Pair(i, Convert.ToInt32(splited[1]));
                boyNames.Add(splited[0].Trim(), pair);
                i++;
            }
        }

        using (StreamReader s = new StreamReader("girlnames.txt"))
        {
            string? line = null;
            int i = 0;
            while ((line = s.ReadLine()) != null)
            {
                string[] splited = line.Split(' ');
                Pair pair = new Pair(i, Convert.ToInt32(splited[1]));
                girlNames.Add(splited[0].Trim(), pair);
                i++;
            }
        }

        while (true)
        {
            Console.WriteLine("Please input name: ");
            string? name = Console.ReadLine();
            if (boyNames.ContainsKey(name))
            {
                Console.WriteLine($"Boy Named {name}, rank {boyNames[name].getRank()}, count {boyNames[name].getCount()}");
            }
            else if (girlNames.ContainsKey(name))
            {
                Console.WriteLine($"Girl Named {name}, rank {girlNames[name].getRank()}, count {girlNames[name].getCount()}");
            }
            else {
                Console.WriteLine("Name not found!");
            }
            Console.WriteLine("Would you like to try again? (y/n)");
            string? exit = Console.ReadLine();
            if (exit.Trim()=="n") {
                return;
            }
        }
    }
}

class Pair {
    private int rank;
    private int count;
    public Pair(int rank, int count) { this.rank = rank; this.count = count; }
    public int getCount() { return count; }
    public int getRank() { return rank; }
}