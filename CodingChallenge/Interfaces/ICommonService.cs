using CodingChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingChallenge.IServices
{
    public interface ICommonService
    {
        ListCompareResult GetComparedList(ListsToCompare listsToCompare);
    }
}
