using TestProgi.Api.Models;

namespace TestProgi.Api.Services.Strategy.Strategies
{
    public class AssociationCostsStrategy : ICostCalculationStrategy
    {
        public double CalculateCost(Car car)
        {
            double associationCosts;
            if (car.BasePrice <= 500)
                associationCosts = 5;
            else if (car.BasePrice <= 1000)
                associationCosts = 10;
            else if (car.BasePrice <= 3000)
                associationCosts = 15;
            else
                associationCosts = 20;
            return associationCosts;
        }
    }
}
