using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace interest.Controllers
{
    [ApiController]
    [Route("/api/taxajuros")]
    public class InterestController : ControllerBase
    {
        private double _interestRate { get; } = 0.01;

        /// <summary>
        /// Return the interest rate.
        /// </summary>
        [HttpGet]
        public double Get() => this._interestRate;
    }
}
