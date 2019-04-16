namespace P03_SoftUniParking
{
    using System.Collections.Generic;

    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            this.cars = new List<Car>();
            this.capacity = capacity;
        }

        public int Count => this.cars.Count;

        public string AddCar(Car car)
        {
            int carIndex = this.cars
                .FindIndex(c => c.RegistrationNumber == car.RegistrationNumber);

            if (carIndex != -1)
            {
                return "Car with that registration number, already exists!";
            }

            if (this.cars.Count == this.capacity)
            {
                return "Parking is full!";
            }

            this.cars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber)
        {
            int carIndex = this.cars
                .FindIndex(c => c.RegistrationNumber == registrationNumber);

            if (carIndex == -1)
            {
                return "Car with that registration number, doesn't exist!";
            }

            this.cars.RemoveAt(carIndex);
            return $"Successfully removed {registrationNumber}";
        }

        public Car GetCar(string registrationNumber)
        {
            int carIndex = this.cars
                .FindIndex(c => c.RegistrationNumber == registrationNumber);

            return this.cars[carIndex];
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var registrationNumber in registrationNumbers)
            {
                RemoveCar(registrationNumber);
            }
        }
    }
}

