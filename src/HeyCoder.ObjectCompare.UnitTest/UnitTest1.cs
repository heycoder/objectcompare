using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HeyCoder.ObjectCompare.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var objA = new { Name = "ken", Age = 18 };
            var objB = new { RealName = "ken", Age = 20 };
            var compareResult = Comparer.Compare(objA, objB, new[] { new CompareParameter { ObjectAPropertyName = "Name", ObjectBPropertyName = "RealName" },
                new CompareParameter { ObjectAPropertyName = "Age", ObjectBPropertyName = "Age" } });
            Assert.AreEqual(compareResult.IsEqual, false);
        }
    }
}
