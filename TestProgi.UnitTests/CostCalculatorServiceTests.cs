using TestProgi.Api.Models;
using TestProgi.Api.Services;

namespace TestProgi.UnitTests
{
    public class CostCalculatorServiceTests
    {
        CostCalculatorService _costCalculatorService;
        const double STORAGE_COSTS = 100.00;

        public CostCalculatorServiceTests()
        {
           _costCalculatorService = new CostCalculatorService();
        }

        [Theory]
        [InlineData(398.00, VehicleTypeEnum.Common, 39.80, 7.96, 5.00, STORAGE_COSTS, 550.76)]
        [InlineData(501.00, VehicleTypeEnum.Common, 50.00, 10.02,10.00, STORAGE_COSTS, 671.02 )]
        [InlineData(57.00, VehicleTypeEnum.Common,10.00,1.14,5.00, STORAGE_COSTS, 173.14)]
        [InlineData(1800.00, VehicleTypeEnum.Luxury,180.00,72.00,15.00, STORAGE_COSTS, 2167.00)]
        [InlineData(1100.00, VehicleTypeEnum.Common,50.00,22.00,15.00, STORAGE_COSTS, 1287.00)]
        [InlineData(1000000.00, VehicleTypeEnum.Luxury,200.00,40000.00,20.00, STORAGE_COSTS, 1040320.00)]
        public void CalculateCost_ShouldReturnExpectedTotalCost(double basePrice, VehicleTypeEnum vehicleType, 
            double basicUserFee, double specialUserFee, double associationCosts, double storageCosts, double totalCosts)
        {
            // Act
            FeesDetail result = _costCalculatorService.CalculateTotalCost(basePrice, vehicleType);

            // Assert
            Assert.Equal(basicUserFee, result.BasicUserFee);
            Assert.Equal(specialUserFee, result.SpecialUserFee);
            Assert.Equal(associationCosts, result.AssociationCosts);
            Assert.Equal(storageCosts, result.StorageCosts);
            Assert.Equal(totalCosts, result.TotalCosts);
        }
    }
}