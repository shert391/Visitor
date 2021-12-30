/*Реализация паттерна визитор*/
using System;
using System.Collections.Generic;

internal enum CarModel
{
    Reno,
    Audi,
    Peugeot,
}

internal enum FuelType
{
    Diesel,
    Petrol,
}

internal interface IVisitor
{
    void Visit(PassengerСar passengerСar);
    void Visit(ReightCar reightСar);
}

internal class StartVisitor : IVisitor
{
    public void Visit(PassengerСar passengerСar)
    {
        Console.WriteLine($"Легковой автомобиль модели <{passengerСar.CarModel}> с номерами <{passengerСar.Number}> и топливом <{passengerСar.FuelType}> - заведен!\n");
    }

    public void Visit(ReightCar reightСar)
    {
        Console.WriteLine($"Грузовой автомобиль модели <{reightСar.CarModel}> с номерами <{reightСar.Number}> и топливом <{reightСar.FuelType}> - заведен!\n");
    }
}

internal class MoveVisitor : IVisitor
{
    public void Visit(PassengerСar passengerСar)
    {
        Console.WriteLine($"Я...! Легковой автомобиль модели <{passengerСar.CarModel}> с номерами <{passengerСar.Number}> и топливом <{passengerСar.FuelType}> - поехал!\n");
    }

    public void Visit(ReightCar reightСar)
    {
        Console.WriteLine($"Я...! Грузовой автомобиль модели <{reightСar.CarModel}> с номерами <{reightСar.Number}> и топливом <{reightСar.FuelType}> - заведен!\n");
    }
}

internal abstract class Car
{
    public CarModel CarModel { get; }
    public FuelType FuelType { get; }
    public int Number { get; }

    protected Car(CarModel model, FuelType fuelType, int number)
    {
        CarModel = model;
        FuelType = fuelType;
        Number = number;
    }
    
    public abstract void Accept(IVisitor visitor);
}

internal class PassengerСar : Car
{
    public PassengerСar(CarModel model, FuelType fuelType, int number) : base(model, fuelType, number) { }
    
    public override void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}

internal class ReightCar : Car
{
    public ReightCar(CarModel model, FuelType fuelType, int number) : base(model, fuelType, number) { }
    
    public override void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}

internal class Program
{
    private static void Main()
    {
        var cars = new List<Car>()
        {
            new PassengerСar(CarModel.Audi, FuelType.Petrol, 100),
            new ReightCar(CarModel.Reno, FuelType.Diesel, 201),
            new PassengerСar(CarModel.Peugeot, FuelType.Petrol, 110),
        };

        var moveVisitor = new MoveVisitor();
        var startVisitor = new StartVisitor();

        foreach (var car in cars)
        {
            car.Accept(startVisitor);
            car.Accept(moveVisitor);
        }
    }
}