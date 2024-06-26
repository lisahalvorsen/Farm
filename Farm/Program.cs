namespace Farm;

class Program
{
    static void Main(string[] args)
    {
        var farm = new FarmManager(new Day());
        farm.MainMenu();
    }
}