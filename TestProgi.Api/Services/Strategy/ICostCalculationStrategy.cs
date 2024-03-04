using TestProgi.Api.Models;

namespace TestProgi.Api.Services.Strategy
{
    public interface ICostCalculationStrategy
    {
        double CalculateCost(Car car);
    }

    public class BasicUserFeeStrategy : ICostCalculationStrategy
    {
        public double CalculateCost(Car car)
        {
            double basicUserFee = car.BasePrice * 0.1;
            double minUserFee = car.VehicleType == VehicleTypeEnum.Common ? 10 : 25;
            double maxUserFee = car.VehicleType == VehicleTypeEnum.Common ? 50 : 200;
            basicUserFee = Math.Round(Math.Max(minUserFee, Math.Min(maxUserFee, basicUserFee)), 2);

            return basicUserFee;
        }
    }

    public class SellerSpecialFeeStrategy : ICostCalculationStrategy
    {
        public double CalculateCost(Car car)
        {
            double sellerFeeRate = car.VehicleType == VehicleTypeEnum.Common ? 0.02 : 0.04;
            double sellerSpecialFee = Math.Round(car.BasePrice * sellerFeeRate, 2);
            return sellerSpecialFee;
        }
    }

    public class AssociationCostsStrategy : ICostCalculationStrategy
    {
        public double CalculateCost(Car car)
        {
            double associationCosts = 0;
            if (car.BasePrice <= 500)
                associationCosts = 5;
            else if (car.BasePrice <= 1000)
                associationCosts = 10;
            else if (car.BasePrice <= 3000)
                associationCosts = 15;
            else
                associationCosts = 20;
            return Math.Round(associationCosts, 2);
        }
    }
}
