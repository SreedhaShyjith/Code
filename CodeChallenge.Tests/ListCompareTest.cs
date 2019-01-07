using CodingChallenge.Models;
using CodingChallenge.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeChallenge.Tests
{
    [TestClass]
    public class ListCompareTest
    {
        CommonService commonService;
        public ListCompareTest()
        {
            commonService = new CommonService();
        }

        [TestMethod]
        public void GetSortedCompareListTest()
        {
            ListsToCompare listsToCompareTest = new ListsToCompare();
            listsToCompareTest.Current = new List<KeyValuePairs>();

            listsToCompareTest.Initial = new List<KeyValuePairs>();
            listsToCompareTest.Initial.Add(new KeyValuePairs { Key = 1, Value = "Value1" });
            listsToCompareTest.Initial.Add(new KeyValuePairs { Key = 2, Value = "Value2" });
            listsToCompareTest.Initial.Add(new KeyValuePairs { Key = 3, Value = "Value3" });
            listsToCompareTest.Initial.Add(new KeyValuePairs { Key = 4, Value = "Value4" });
            listsToCompareTest.Initial.Add(new KeyValuePairs { Key = 5, Value = "Value5" });
            listsToCompareTest.Initial.Add(new KeyValuePairs { Key = 6, Value = "Value6" });

            listsToCompareTest.Current.Add(new KeyValuePairs { Key = 1, Value = "Value1" });
            listsToCompareTest.Current.Add(new KeyValuePairs { Key = 2, Value = "Value2.1" });
            listsToCompareTest.Current.Add(new KeyValuePairs { Key = 5, Value = "Value5" });
            listsToCompareTest.Current.Add(new KeyValuePairs { Key = 6, Value = "Value6.1" });
            listsToCompareTest.Current.Add(new KeyValuePairs { Key = 7, Value = "Value7" });
            listsToCompareTest.Current.Add(new KeyValuePairs { Key = 8, Value = "Value8" });
            listsToCompareTest.Current.Add(new KeyValuePairs { Key = 9, Value = "Value9" });
            listsToCompareTest.Current.Add(new KeyValuePairs { Key = 10, Value = "Value10" });

            ListCompareResult listCompareResultExpected = new ListCompareResult();
            listCompareResultExpected.NewItems = new List<KeyValuePairs>();
            listCompareResultExpected.NewItems.Add(new KeyValuePairs { Key = 7, Value = "Value7" });
            listCompareResultExpected.NewItems.Add(new KeyValuePairs { Key = 8, Value = "Value8" });
            listCompareResultExpected.NewItems.Add(new KeyValuePairs { Key = 9, Value = "Value9" });
            listCompareResultExpected.NewItems.Add(new KeyValuePairs { Key = 10, Value = "Value10" });

            listCompareResultExpected.DeletedItems = new List<KeyValuePairs>();
            listCompareResultExpected.DeletedItems.Add(new KeyValuePairs { Key = 3, Value = "Value3" });
            listCompareResultExpected.DeletedItems.Add(new KeyValuePairs { Key = 4, Value = "Value4" });

            listCompareResultExpected.UpdatedItems = new List<KeyValuePairs>();
            listCompareResultExpected.UpdatedItems.Add(new KeyValuePairs { Key = 2, Value = "Value2.1" });
            listCompareResultExpected.UpdatedItems.Add(new KeyValuePairs { Key = 6, Value = "Value6.1" });
            listCompareResultExpected.Message = "Success";

            ListCompareResult listCompareResultActual = new ListCompareResult();
            listCompareResultActual = commonService.GetComparedList(listsToCompareTest);

            Assert.IsTrue(listCompareResultExpected.NewItems.SequenceEqual(listCompareResultActual.NewItems, new CompareListEqualityComparer()));
            Assert.IsTrue(listCompareResultExpected.DeletedItems.SequenceEqual(listCompareResultActual.DeletedItems, new CompareListEqualityComparer()));
            Assert.IsTrue(listCompareResultExpected.UpdatedItems.SequenceEqual(listCompareResultActual.UpdatedItems, new CompareListEqualityComparer()));
            Assert.AreEqual(listCompareResultExpected.Message, listCompareResultActual.Message);
        }

        [TestMethod]
        public void GetSortedCompareListNullTest()
        {
            ListsToCompare listsToCompareTest = new ListsToCompare();

            ListCompareResult listCompareResultActual = new ListCompareResult();
            listCompareResultActual = commonService.GetComparedList(listsToCompareTest);

            Assert.AreEqual(listCompareResultActual.Message, "Please provide valid input.");
        }
    }
}
