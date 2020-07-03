using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace calculate.Controllers
{
    [ApiController]
    [Route("api/calculajuros")]
    public class CalculateController : ControllerBase
    {
        private readonly InterestAPI _interestApi;
        public CalculateController(InterestAPI interestAPI)
        {
            this._interestApi = interestAPI;
        }


        [HttpGet]
        public async Task<decimal> Calculate([FromQuery] decimal valorinicial, [FromQuery] int meses)
        {
            var interestRate = await this._interestApi.GetInterestRate();

            var powValue = Math.Pow(1 + interestRate, meses);

            return Math.Round(valorinicial * Convert.ToDecimal(powValue), 2);
        }
    }
}
