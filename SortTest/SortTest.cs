using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortTest
{
    [TestClass]
    public class SortTest
    {
        [TestMethod]
        public void Test_Sorting_Proper_Format_Order_1()
        {            
            IEnumerable<string> contents = new List<string> { "PALMER, TERESSA, 88", "SMITH, ALLAN, 70", "SMITH, FRANCIS, 85", "BUNDY, MADISON, 88" };                                                            
            Assert.IsTrue(DemSort.Program.Sort(contents));
            var sortedContents = DemSort.Program.SortedContents.ToList();
            Assert.AreEqual(sortedContents[0], "BUNDY, MADISON, 88");
            Assert.AreEqual(sortedContents[1], "PALMER, TERESSA, 88");
            Assert.AreEqual(sortedContents[2], "SMITH, FRANCIS, 85");
            Assert.AreEqual(sortedContents[3], "SMITH, ALLAN, 70");            
        }

        [TestMethod]
        public void Test_Sorting_Proper_Format_Order_2()
        {
            IEnumerable<string> contents = new List<string> { "SMITH, ALLAN, 70", "SMITH, FRANCIS, 85", "BUNDY, TERESSA, 88", "BUNDY, MADISON, 88" };
            Assert.IsTrue(DemSort.Program.Sort(contents));
            var sortedContents = DemSort.Program.SortedContents.ToList();
            Assert.AreEqual(sortedContents[0], "BUNDY, MADISON, 88");
            Assert.AreEqual(sortedContents[1], "BUNDY, TERESSA, 88");
            Assert.AreEqual(sortedContents[2], "SMITH, FRANCIS, 85");
            Assert.AreEqual(sortedContents[3], "SMITH, ALLAN, 70");
        }

        [TestMethod]
        public void Test_Sorting_Incorrect_Format_Order_1()
        {
            IEnumerable<string> contents = new List<string> { "TERESSA, 88", "SMITH, ALLAN, 70", "SMITH, FRANCIS", "BUNDY, MADISON, 88" };
            Assert.IsFalse(DemSort.Program.Sort(contents));                                                        
        }
    }
}
