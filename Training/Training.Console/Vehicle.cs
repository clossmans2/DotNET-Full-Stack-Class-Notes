using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string? TrimLevel { get; set; }
        public int Mileage { get; set; }
        public string Make { get; set; }
        public int MSRP { get; set; }
        public int ModelYear { get; set; }
        public string? VIN { get; set; }

        public override string ToString()
        {
            return $"{Id} - Body: {Body}, Model: {Model}, Color: {Color}, TrimLevel: {TrimLevel}, Mileage: {Mileage}, Make: {Make}, MSRP: {MSRP}, ModelYear: {ModelYear}, VIN: {VIN}";
        }
    }
}
