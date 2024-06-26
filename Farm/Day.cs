namespace Farm;

public class Day
{
    private int DayCounter { get; set; }

    public Day()
    {
        DayCounter = 0;
    }

    internal void StartNewDay(List <Animal> allAnimals)
    {
        DayCounter++;
        Console.WriteLine($"A new day is upon us! Today is day number {DayCounter}\n");
        foreach (var animal in allAnimals)
        {
            animal.DaysSinceFed++;
        } 
    }
}
