using TestProgi.Api.Models;

namespace TestProgi.Api.Services.Strategy.Strategies
{
    public class BasicUserFeeStrategy : ICostCalculationStrategy
    {
        public double CalculateCost(Car car)
        {
            double basicUserFee = car.BasePrice * 0.1;
            double minUserFee = car.VehicleType == VehicleTypeEnum.Common ? 10 : 25;
            double maxUserFee = car.VehicleType == VehicleTypeEnum.Common ? 50 : 200;
            basicUserFee = Math.Max(minUserFee, Math.Min(maxUserFee, basicUserFee));
            return basicUserFee;
        }
    }
}
