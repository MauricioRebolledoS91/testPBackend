using TestProgi.Api.Models;
using TestProgi.Api.Services.Factory;

namespace TestProgi.Api.Services
{
    public class CostCalculatorService : ICostCalculatorService
    {
        const int FIXED_STORAGE_COST = 100;
        public FeesDetail CalculateTotalCost(double basePrice, VehicleTypeEnum vehicleType)
        {
            Car car = new Car(basePrice, vehicleType);

            var basicUserFeeStrategy = CostCalculationFactory
                .Create(CostCalculationStrategyType.BasicUserFee);
            var sellerSpecialFeeStrategy = CostCalculationFactory
                .Create(CostCalculationStrategyType.SellerSpecialFee);
            var associationCostsStrategy = CostCalculationFactory
                .Create(CostCalculationStrategyType.AssociationCosts);

            double basicUserFee = basicUserFeeStrategy.CalculateCost(car);
            double sellerSpecialFee = sellerSpecialFeeStrategy.CalculateCost(car);
            double associationCosts = associationCostsStrategy.CalculateCost(car);

            double totalCost = car.BasePrice + basicUserFee + sellerSpecialFee 
                + associationCosts + FIXED_STORAGE_COST;

            FeesDetail totalFees = new FeesDetail()
            {
                BasicUserFee = basicUserFee,
                SpecialUserFee = sellerSpecialFee,
                AssociationCosts = associationCosts,
                StorageCosts = FIXED_STORAGE_COST,
                TotalCosts = totalCost
            };

            return totalFees;
        }
    }

    public interface ICostCalculatorService
    {
        FeesDetail CalculateTotalCost(double basePrice, VehicleTypeEnum vehicleType);
    }
}
