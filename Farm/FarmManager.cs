namespace Farm;

public class FarmManager
{
    private readonly Day _newDay;

    private readonly List<Animal> _allAnimals =
    [
        new Dog(name:"Buddy", category:"Dog", breed:"Border Collie", gender:"Male", age:2),
        new Cat(name: "Sylvester", category: "Cat", breed: "Ragdoll", gender:"Male", age: 4),
        new Chicken(name:"Pip", category: "Chicken", breed:"Cochin", gender:"Female", age:1),
        new Horse(name: "Stella", category:"Horse", breed:"Frieser", gender:"Female", age:5),
        new Sheep(name:"Muffin", category:"Sheep", breed:"Merino", gender:"Female", age: 4),
    ];

    public FarmManager(Day day)
    {
        _newDay = day;
    }

    internal void MainMenu()
    {
        while (true)
        {
            Console.WriteLine("Welcome to the farm :D Here you can");
            Console.WriteLine("1. See all animals");
            Console.WriteLine("2. Feed an animal");
            Console.WriteLine("3. Start a new day");
            Console.WriteLine("4. Exit farm\n");
            Choose();
        }
    }

    private void Choose()
    {
        var input = Console.ReadKey(true).KeyChar - '0';
        switch (input)
        {
            case 1:
                ShowAllAnimals();
                break;
            case 2:
                CheckIfHungry();
                break;
            case 3:
                _newDay.StartNewDay(_allAnimals);
                break;
            case 4:
                ExitProgram();
                break;
            default:
                Console.WriteLine("Invalid input, please try again.\n");
                break;
        }
    }

    private void ShowAllAnimals()
    {
        Console.WriteLine("On the farm you can find these animals:");
        foreach (var animal in _allAnimals)
        {
            animal.ShowAnimal();
        }

        Console.WriteLine();
        AnimalMenu();
    }
    
    private void CheckIfHungry()
    {
        var animalName = GetAnimalName();
        var foundAnimal = FindAnimal(animalName);

        if (foundAnimal != null)
        {
            int hungerThreshold = 0;
            switch (foundAnimal.Category.ToLower())
            {
                case "dog":
                    hungerThreshold = 1;
                    break;
                case "cat":
                    hungerThreshold = 2;
                    break;
                case "horse":
                    hungerThreshold = 3;
                    break;
                case "chicken":
                    hungerThreshold = 2;
                    break;
                case "sheep":
                    hungerThreshold = 4;
                    break;
                default: 
                    Console.WriteLine("We couldn't find the animal you're looking for, please try again.\n");
                    break;
            }
            
            if (foundAnimal.DaysSinceFed >= hungerThreshold)
            {
                Console.WriteLine($"It has been {foundAnimal.DaysSinceFed} days since {foundAnimal.Name} was fed\n");
                foundAnimal.FeedAnimal();
            }
            else
            {
                Console.WriteLine($"{foundAnimal.Name} is not hungry yet, come back and check another day.\n");
            }
        }
        else
        {
            Console.WriteLine("Sorry, we couldn't find the animal you're looking for, please try again.\n");
        }
    }

    private void AnimalMenu()
    {
        Console.WriteLine("Do you want to ...");
        Console.WriteLine("1. Get more information about an animal");
        Console.WriteLine("2. Go back to main menu\n");
        var input = Console.ReadKey(true).KeyChar - '0';

        switch (input)
        {
            case 1:
                ShowAnimalInfo();
                break;
            case 2:
                MainMenu();
                break;
            default:
                Console.WriteLine("Invalid input, please try again.\n");
                break;
        }
    }

    private void ShowAnimalInfo()
    {
        var animalToShow = PromptUser("Type in the name of the animal you want to know more about");
        var animalExists = _allAnimals.Any(animal => animal.Name == animalToShow);

        if (animalExists)
        {
            var animal = _allAnimals.Where(animal => animal.Name == animalToShow).ToList();
            foreach (var property in animal)
            {
               property.ShowInfo();
            }
        }
        else
        {
            Console.WriteLine("The animal you're looking for doesn't exist, please try again.\n");
        }
    }

    private static string GetAnimalName()
    {
        return PromptUser("Who do you want to feed? Type in the animal's name.");
    }

    private Animal FindAnimal(string animalName)
    {
        return _allAnimals.FirstOrDefault(a => a.Name == animalName);
    }

    private static string PromptUser(string text)
    {
        Console.WriteLine(text);
        return Console.ReadLine();
    }

    private static void ExitProgram()
    {
        Console.WriteLine("You're welcome back to the farm any time :D");
        Environment.Exit(0);
    }
}