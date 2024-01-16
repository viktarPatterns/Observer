// Интерфейс для наблюдателя
public interface ISubscriber
{
    void Update(string newspaper);
}

// Подписчик на газету
public class Subscriber : ISubscriber
{
    private string _name;

    public string Name => _name;

    public Subscriber(string name)
    {
        _name = name;
    }

    public void Update(string newspaper)
    {
        Console.WriteLine($"{_name} received new newspaper: {newspaper}!");
    }
}

// Интерфейс наблюдаемого объекта
public interface IPublisher
{
    void Subscribe(Subscriber subscriber);
    void Unsubscribe(Subscriber subscriber);
    void Notify(string message);
}

// Издатель газеты
public class NewspaperPublisher : IPublisher
{
    private List<Subscriber> _subscribers = new List<Subscriber>();

    public void Subscribe(Subscriber subscriber)
    {
        Console.WriteLine($"{subscriber.Name} has subscribed!");
        _subscribers.Add(subscriber);
    }

    public void Unsubscribe(Subscriber subscriber)
    {
        Console.WriteLine($"{subscriber.Name} has unsubscribed!");
        _subscribers.Remove(subscriber);
    }

    public void Notify(string newspaper)
    {
        foreach (var subscriber in _subscribers)
        {
            subscriber.Update(newspaper);
        }
    }
}

class Program
{
    static void Main()
    {
        var publisher = new NewspaperPublisher();

        var subscriber1 = new Subscriber("Ivan");
        var subscriber2 = new Subscriber("Andrew");

        publisher.Subscribe(subscriber1);
        publisher.Subscribe(subscriber2);

        publisher.Notify("The times");

        publisher.Unsubscribe(subscriber1);

        Console.WriteLine("******************************************");

        publisher.Notify("The sun");
    }
}