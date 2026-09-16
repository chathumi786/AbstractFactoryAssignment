using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Abstract Factory Vehicle Demo ===\n");

            Console.Write("Choose engine type (gasoline/electric): ");
            string engineChoice = Console.ReadLine().ToLower();

            Console.Write("Choose vehicle type (car/truck): ");
            string vehicleChoice = Console.ReadLine().ToLower();

            IVehicleFactory factory;

            if (engineChoice == "gasoline")
                factory = new GasolineVehicleFactory(vehicleChoice);
            else
                factory = new ElectricVehicleFactory(vehicleChoice);

            IVehicle vehicle = factory.CreateVehicle();
            IEngine engine = factory.CreateEngine();

            Console.WriteLine();
            vehicle.ShowDetails();
            engine.Start();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();

        }
    }
}


public interface IEngine
{
    void Start();
}


public interface IVehicle
{
    void ShowDetails();
}


public interface IVehicleFactory
{
    IVehicle CreateVehicle();
    IEngine CreateEngine();
}


public class GasolineEngine : IEngine
{
    public void Start()
    {
        Console.WriteLine("Gasoline engine starting... VROOM!");
    }
}


public class ElectricEngine : IEngine
{
    public void Start()
    {
        Console.WriteLine("Electric engine starting... silent hum.");
    }
}

public class GasolineCar : IVehicle
{
    public void ShowDetails()
    {
        Console.WriteLine("I am a Gasoline Car.");
    }
}

public class GasolineTruck : IVehicle
{
    public void ShowDetails()
    {
        Console.WriteLine("I am a Gasoline Truck.");
    }
}

public class ElectricCar : IVehicle
{
    public void ShowDetails()
    {
        Console.WriteLine("I am an Electric Car.");
    }
}

public class ElectricTruck : IVehicle
{
    public void ShowDetails()
    {
        Console.WriteLine("I am an Electric Truck.");
    }
}


public class GasolineVehicleFactory : IVehicleFactory
{
    private string vehicleType;

    public GasolineVehicleFactory(string type)
    {
        vehicleType = type;   // "car" or "truck"
    }

    public IVehicle CreateVehicle()
    {
        if (vehicleType.ToLower() == "car")
            return new GasolineCar();
        else
            return new GasolineTruck();
    }

    public IEngine CreateEngine()
    {
        return new GasolineEngine();
    }
}


public class ElectricVehicleFactory : IVehicleFactory
{
    private string vehicleType;

    public ElectricVehicleFactory(string type)
    {
        vehicleType = type;   // "car" or "truck"
    }

    public IVehicle CreateVehicle()
    {
        if (vehicleType.ToLower() == "car")
            return new ElectricCar();
        else
            return new ElectricTruck();
    }

    public IEngine CreateEngine()
    {
        return new ElectricEngine();
    }
}

