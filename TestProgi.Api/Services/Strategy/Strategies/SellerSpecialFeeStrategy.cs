using TestProgi.Api.Models;

namespace TestProgi.Api.Services.Strategy.Strategies
{
    public class SellerSpecialFeeStrategy : ICostCalculationStrategy
    {
        public double CalculateCost(Car car)
        {
            double sellerFeeRate = car.VehicleType == VehicleTypeEnum.Common ? 0.02 : 0.04;
            double sellerSpecialFee = car.BasePrice * sellerFeeRate;
            return sellerSpecialFee;
        }
    }
}
