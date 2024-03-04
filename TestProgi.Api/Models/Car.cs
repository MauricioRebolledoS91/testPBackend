using System.ComponentModel.DataAnnotations;

namespace TestProgi.Api.Models
{
    public enum VehicleTypeEnum
    {
        Common,
        Luxury
    }

    public class Car
    {
        [Required(ErrorMessage = "Base price is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "The base price must be a positive value.")]
        [DataType(DataType.Currency, ErrorMessage = "The base price must be a numeric value.")]
        public double BasePrice { get; set; }

        [Required(ErrorMessage = "The vehicle type is required.")]
        [EnumDataType(typeof(VehicleTypeEnum), ErrorMessage = "The vehicle type is not valid.")]
        public VehicleTypeEnum VehicleType { get; set; }

        public Car(double basePrice, VehicleTypeEnum vehicleType)
        {
            BasePrice = basePrice;
            VehicleType = vehicleType;
        }
    }
}
