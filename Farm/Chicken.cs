namespace Farm;

public class Chicken : Animal
{
    protected internal Chicken(string name, string category, string breed, string gender, int age) :
        base(name, category, breed, gender, age)
    {
    }
}