using CodingChallenge.IServices;
using CodingChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingChallenge.Services
{
    public class CommonService: ICommonService
    {/// <summary>
     /// Takes List of list as input and provide the comparison result as output
     /// </summary>
     /// <param name="listsToCompare"></param>
     /// <returns>SortedCompareList</returns>
        public ListCompareResult GetComparedList(ListsToCompare listsToCompare)
        {
            ListCompareResult comparisonResult = new ListCompareResult();
            if (listsToCompare != null && listsToCompare.Current != null && listsToCompare.Initial != null)
            {
                List<KeyValuePairs> initial = new List<KeyValuePairs>();
                List<KeyValuePairs> current = new List<KeyValuePairs>();

                initial = listsToCompare.Initial.Where(c => c != null).ToList(); // Assign valued to initial
                current = listsToCompare.Current.Where(c => c != null).ToList(); // Assign valued to Current

                List<KeyValuePairs> newList = GetNewList(initial, current); // get the newly added items comparing keys
                List<KeyValuePairs> deleteList = GetDeletedList(initial, current); // get the deleted items comparing keys
                List<KeyValuePairs> updatedList = GetUpdatedList(initial, current); // get the updated items comparing keys

                comparisonResult.NewItems = newList;
                comparisonResult.UpdatedItems = updatedList;
                comparisonResult.DeletedItems = deleteList;
                comparisonResult.Message = "Success";
            }
            else
            {
                comparisonResult.Message = "Please provide valid input.";
            }
            return comparisonResult;
        }

        /// <summary>
        ///  Get a list of values that are both in “current” and “initial” but have a different value
        /// </summary>
        /// <param name="initial">Initial List</param>
        /// <param name="current"> Current List</param>
        /// <returns> List of updated values</returns>
        private List<KeyValuePairs> GetUpdatedList(List<KeyValuePairs> initial, List<KeyValuePairs> current)
        {
            List<KeyValuePairs> updatedList = current.Where(a => initial.Any(o => o.Key == a.Key && o.Value != a.Value)).ToList(); 
            return updatedList;
        }

        /// <summary>
        /// Get the list of keys – and their values --  that are in “current” but not in “initial”
        /// </summary>
        /// <param name="initial">Initial List</param>
        /// <param name="current"> Current List</param>
        /// <returns> List of deleted values</returns>
        private List<KeyValuePairs> GetDeletedList(List<KeyValuePairs> initial, List<KeyValuePairs> current)
        {
            List<KeyValuePairs> deleteList = initial.Where(a => !current.Any(o => o.Key == a.Key)).ToList();
            return deleteList;
        }

        /// <summary>
        /// Get the list of keys – and their values --  that are in “current” but not in “initial”
        /// </summary>
        /// <param name="initial">Initial List</param>
        /// <param name="current"> Current List</param>
        /// <returns> List of newly added values</returns>
        private List<KeyValuePairs> GetNewList(List<KeyValuePairs> initial, List<KeyValuePairs> current)
        {
            List<KeyValuePairs> newList = current.Where(a => !initial.Any(o => o.Key == a.Key)).ToList(); 
            return newList;
        }
    }
}
