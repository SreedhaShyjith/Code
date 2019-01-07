using CodingChallenge.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChallenge.Tests
{
    public class CompareListEqualityComparer : IEqualityComparer<KeyValuePairs>
    {
        public bool Equals(KeyValuePairs x, KeyValuePairs y)
        {

            if (Object.ReferenceEquals(x, y)) return true;

            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            return x.Key == y.Key && x.Value == y.Value;
        }

        public int GetHashCode(KeyValuePairs compareList)
        {
            if (Object.ReferenceEquals(compareList, null)) return 0;

            int hashValue = compareList.Value == null ? 0 : compareList.Value.GetHashCode();

            int hashKey = compareList.Key.GetHashCode();

            return hashValue ^ hashKey;
        }
    }
}
