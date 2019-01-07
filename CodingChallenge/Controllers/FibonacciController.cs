using System;
using System.Collections.Generic;
using System.Linq;
using CodingChallenge.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using CodingChallenge.Services;

namespace CodingChallenge.Controllers
{
    [Produces("application/json")]
    [ApiController]
    public class FibonacciController : ControllerBase
    {
        FibanocciService _FibinocciServiceObj = new FibanocciService();
        #region Generate Fibonacci Series
        /// <summary>
        /// Get the Fibonacci series with length of the array equvalent to "num"
        /// </summary>
        /// <param name="num">length of the Fibonacci series</param>
        /// <returns>Fibonacci series of specified length </returns>

        [HttpGet]
        [Route("api/fibonacci/{num}")]
        public ActionResult<Fibonacci> Fibonacci(int? num)
        {
            Fibonacci FibonacciResponse = new Fibonacci();
            try
            {
                FibonacciResponse = _FibinocciServiceObj.GenerateFebinocciSeries(num);
            }
            catch (Exception)
            {
                FibonacciResponse.Message = "Oops!! Something went wrong.";
            }
            return FibonacciResponse;
        }


        #endregion


    }
}
