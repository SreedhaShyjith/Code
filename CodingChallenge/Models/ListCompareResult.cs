using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CodingChallenge.Models
{
    public class ListCompareResult
    {
        public List<KeyValuePairs> NewItems { get; set; }
        public List<KeyValuePairs> UpdatedItems { get; set; }
        public List<KeyValuePairs> DeletedItems { get; set; }
        public string Message { get; set; }
    }
   
}
