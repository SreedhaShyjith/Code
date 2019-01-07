using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CodingChallenge.Models;
using CodingChallenge.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodingChallenge.Controllers
{
    [Produces("application/json")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        CommonService _commonServiceObj = new CommonService();

        #region List Comparer 
        /// <summary>
        /// Takes two lists as input and provide the comparison result as output
        /// </summary>
        /// <param name="listsToCompare"> consits of Initial and current values list </param>
        /// <returns>comparison result of the array of objects provided</returns>
        [HttpPost]
        [Route("api/[controller]")]
        public ActionResult<ListCompareResult> ListComparer([FromBody]ListsToCompare listsToCompare)
        {
            ListCompareResult ComparisonResult = new ListCompareResult();
            try
            {
                ComparisonResult = _commonServiceObj.GetComparedList(listsToCompare);
            }
            catch (Exception)
            {
                ComparisonResult.Message = "Oops!! Something went wrong.";

            }
            return ComparisonResult;
        }
        #endregion

    }
}
