using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Visitor
{
    public string Name { get; set; }
    public bool HasReservation { get; set; }

    public Visitor(string name, bool hasReservation)
    {
        Name = name;
        HasReservation = hasReservation;
    }
}

public class Cafe
{
    private Queue<Visitor> queue = new Queue<Visitor>();
    private List<Visitor> tables = new List<Visitor>();
    private int totalTables;

    public Cafe(int totalTables)
    {
        this.totalTables = totalTables;
    }

    public void Arrive(Visitor visitor)
    {
        if (visitor.HasReservation)
        {
            Console.WriteLine($"{visitor.Name} с резервом пришел и занял столик.");
            tables.Add(visitor);
        }
        else
        {
            if (tables.Count < totalTables)
            {
                Console.WriteLine($"{visitor.Name} пришел и занял свободный столик.");
                tables.Add(visitor);
            }
            else
            {
                Console.WriteLine($"{visitor.Name} пришел и встал в очередь.");
                queue.Enqueue(visitor);
            }
        }
    }

    public void TableFreed()
    {
        if (queue.Count > 0)
        {
            Visitor nextVisitor = queue.Dequeue();
            Console.WriteLine($"Столик освободился, {nextVisitor.Name} занял столик.");
            tables.Add(nextVisitor);
        }
        else
        {
            Console.WriteLine("Столик освободился, но очередь пуста.");
        }
    }

    public void ShowStatus()
    {
        Console.WriteLine("Текущие посетители за столиками:");
        foreach (var visitor in tables)
        {
            Console.WriteLine($"- {visitor.Name} (Резерв: {visitor.HasReservation})");
        }

        Console.WriteLine("Очередь:");
        foreach (var visitor in queue)
        {
            Console.WriteLine($"- {visitor.Name}");
        }
    }
}

