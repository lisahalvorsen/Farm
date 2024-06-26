namespace Farm;

public class Animal
{
    public string Name { get; internal set; }
    public string Category { get; internal set; }
    private string Breed { get; set; }
    private string Gender { get; set; }
    private int Age { get; set; }
    public bool IsHungry { get; internal set; }
    public int DaysSinceFed { get; internal set; }

    protected Animal(string name, string category, string breed, string gender, int age)
    {
        Name = name;
        Category = category;
        Breed = breed;
        Gender = gender;
        Age = age;
        IsHungry = true;
    }

    internal void ShowInfo()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Kind of animal: {Category}");
        Console.WriteLine($"Breed: {Breed}");
        Console.WriteLine($"Gender: {Gender}");
        Console.WriteLine($"Age: {Age}\n");
    }

    internal void ShowAnimal()
    {
        Console.WriteLine($"{Name} ({Category})");
    }

    internal void FeedAnimal()
    {
        IsHungry = false;
        Console.WriteLine($"You fed {Name}, and it is looking happy :D\n");
        DaysSinceFed = 0;
    }
}