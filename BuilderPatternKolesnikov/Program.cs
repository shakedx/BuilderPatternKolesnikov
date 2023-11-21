using System;

// Интерфейс строителя оптической системы
interface IOpticalSystemBuilder
{
    void BuildLens();
    void BuildSensor();
    void BuildFilter();
    OpticalSystem GetOpticalSystem();
}

// Класс представляющий оптическую систему
class OpticalSystem
{
    public string Lens { get; set; }
    public string Sensor { get; set; }
    public string Filter { get; set; }

    public void DisplayInfo()
    {
        Console.WriteLine($"Lens: {Lens}");
        Console.WriteLine($"Sensor: {Sensor}");
        Console.WriteLine($"Filter: {Filter}");
    }
}

// Билдер для формата А
class FormatABuilder : IOpticalSystemBuilder
{
    private OpticalSystem opticalSystem = new OpticalSystem();

    public void BuildLens()
    {
        opticalSystem.Lens = "LensA";
    }

    public void BuildSensor()
    {
        opticalSystem.Sensor = "SensorA";
    }

    public void BuildFilter()
    {
        opticalSystem.Filter = "FilterA";
    }

    public OpticalSystem GetOpticalSystem()
    {
        return opticalSystem;
    }
}

// Билдер для формата Б
class FormatBBuilder : IOpticalSystemBuilder
{
    private OpticalSystem opticalSystem = new OpticalSystem();

    public void BuildLens()
    {
        opticalSystem.Lens = "LensB";
    }

    public void BuildSensor()
    {
        opticalSystem.Sensor = "SensorB";
    }

    public void BuildFilter()
    {
        opticalSystem.Filter = "FilterB";
    }

    public OpticalSystem GetOpticalSystem()
    {
        return opticalSystem;
    }
}

// Директор, который управляет процессом построения
class Director
{
    public void Construct(IOpticalSystemBuilder builder)
    {
        builder.BuildLens();
        builder.BuildSensor();
        builder.BuildFilter();
    }
}

class Program
{
    static void Main()
    {
        Director director = new Director();
        IOpticalSystemBuilder builderA = new FormatABuilder();
        IOpticalSystemBuilder builderB = new FormatBBuilder();

        // Строим оптические системы различных форматов
        director.Construct(builderA);
        OpticalSystem opticalSystemA = builderA.GetOpticalSystem();

        director.Construct(builderB);
        OpticalSystem opticalSystemB = builderB.GetOpticalSystem();

        Console.WriteLine("Optical System A:");
        opticalSystemA.DisplayInfo();

        Console.WriteLine("\nOptical System B:");
        opticalSystemB.DisplayInfo();
    }
}
