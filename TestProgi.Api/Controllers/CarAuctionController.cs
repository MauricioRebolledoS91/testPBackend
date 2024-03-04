using Microsoft.AspNetCore.Mvc;
using TestProgi.Api.Models;
using TestProgi.Api.Services;

namespace TestProgi.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarAuctionController : ControllerBase
    {
        ICostCalculatorService _costCalculatorService;
        public CarAuctionController(ICostCalculatorService costCalculatorService)
        {
            _costCalculatorService = costCalculatorService;   
        }

        [HttpGet]
        public ActionResult<FeesDetail> CalculateTotalPrice(double basePrice, VehicleTypeEnum vehicleType)
        {
            try
            {                
                return _costCalculatorService.CalculateTotalCost(basePrice, vehicleType);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
