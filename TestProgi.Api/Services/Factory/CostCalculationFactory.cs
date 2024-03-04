using TestProgi.Api.Services.Strategy;

namespace TestProgi.Api.Services.Factory
{
    public enum CostCalculationStrategyType
    {
        BasicUserFee,
        SellerSpecialFee,
        AssociationCosts
    }

    public class CostCalculationFactory
    {
        public static ICostCalculationStrategy Create(CostCalculationStrategyType strategyType)
        {
            switch (strategyType)
            {
                case CostCalculationStrategyType.BasicUserFee:
                    return new BasicUserFeeStrategy();
                case CostCalculationStrategyType.SellerSpecialFee:
                    return new SellerSpecialFeeStrategy();
                case CostCalculationStrategyType.AssociationCosts:
                    return new AssociationCostsStrategy();
                default:
                    throw new ArgumentException("Invalid strategy type");
            }
        }
    }
}
