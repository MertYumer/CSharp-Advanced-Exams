namespace P03_SoftUniParking
{
    using System.Text;

    public class Car
    {
        public Car(string make, string model, int horsePower, string registrationNumber)
        {
            this.Make = make;
            this.Model = model;
            this.HorsePower = horsePower;
            this.RegistrationNumber = registrationNumber;
        }

        public string Make { get; set; }

        public string Model { get; set; }

        public int HorsePower { get; set; }

        public string RegistrationNumber { get; set; }

        public override string ToString()
        {
            var carInformation = new StringBuilder();
            carInformation.AppendLine($"Make: {this.Make}");
            carInformation.AppendLine($"Model: {this.Model}");
            carInformation.AppendLine($"HorsePower: {this.HorsePower}");
            carInformation.Append($"RegistrationNumber: {this.RegistrationNumber}");
            return carInformation.ToString();
        }
    }
}
