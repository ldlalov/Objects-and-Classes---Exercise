using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Vehicle_Catalogue
{
    class Vehicle
    {
        public string TypeOfVehicle { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Horsepower { get; set; }
        //public override string ToString()
        //{
        //    return $"Type: {TypeOfVehicle}" +
        //         $" Model: {Model}" +
        //        $"Color: {Color}" +
        //        $" Horsepower: {Horsepower}";
        //}
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] cmd = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string type = cmd[0];
                string model = cmd[1];
                string color = cmd[2];
                int horsepower = int.Parse(cmd[3]);
                Vehicle vehicle = new Vehicle()
                {
                    TypeOfVehicle = type,
                    Model = model,
                    Color = color,
                    Horsepower = horsepower
                };
                vehicles.Add(vehicle);
            }
            string catalog;
            double carsHorsePower = 0;
            double averageCarsHorsePower = 0;
            double trucksHorsePower = 0;
            double averageTrucksHorsePower = 0;
            int carsCount = 0;
            int trucksCount = 0;
            while ((catalog = Console.ReadLine()) != "Close the Catalogue")
            {
                List<Vehicle> currentVehicle = new List<Vehicle>();
                currentVehicle = vehicles.FindAll(vehicle => vehicle.Model == catalog);
                if (currentVehicle.Count > 0)
                {

                    foreach (Vehicle item in currentVehicle)
                    {
                        if (item.TypeOfVehicle == "car")
                        {
                            Console.WriteLine($"Type: Car\n" +
                                $"Model: {item.Model}\n" +
                                $"Color: {item.Color}\n" +
                                $"Horsepower: {item.Horsepower}");
                        }
                        else
                        {
                            Console.WriteLine($"Type: Truck\n" +
                                $"Model: {item.Model}\n" +
                                $"Color: {item.Color}\n" +
                                $"Horsepower: {item.Horsepower}");
                        }
                    }
                }
            }
            foreach (Vehicle item in vehicles)
            {
                if (item.TypeOfVehicle == "car")
                {
                    carsHorsePower += item.Horsepower;
                    carsCount++;
                }
                else
                {
                    trucksHorsePower += item.Horsepower;
                    trucksCount++;
                }
            }
            if (carsCount>0)
            {
            averageCarsHorsePower = carsHorsePower / carsCount;
            }
            else
            {
                averageCarsHorsePower = 0;
            }
            if (trucksCount > 0)
            {
            averageTrucksHorsePower = trucksHorsePower / trucksCount;
            }
            else
            {
                averageTrucksHorsePower = 0;
            }
                Console.WriteLine($"Cars have average horsepower of: {averageCarsHorsePower:f2}.");
                Console.WriteLine($"Trucks have average horsepower of: {averageTrucksHorsePower:f2}.");
        }
    }
}
