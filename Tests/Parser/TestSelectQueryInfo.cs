using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using NUnit.Framework;
using OctopusCore.Parser;

namespace Tests.Parser
{
    [TestFixture]
    public class TestSelectQueryInfo
    {
        private IParser _parser;
        [OneTimeSetUp]
        public void SetUp()
        {
            _parser = new OctopusCore.Parser.Parser();
        }
        public static IEnumerable<TestCaseData> TestValidSelectQueryInfoParameters
        {
            get
            {
                yield return new TestCaseData(EligibleTest1, new List<int> { 1, 1, 1, 1 }).
                    SetName("Eligible OrComposite Discount - True Pred");
                yield return new TestCaseData(EligibleTest2, new List<int> { 5, 1, 1, 1 }).
                    SetName("Eligible OrComposite Discount - Min Quantity with one true");
                yield return new TestCaseData(EligibleTest3, new List<int> { 5, 10, 15, 20 }).
                    SetName("Eligible OrComposite Discount - multiple products 1");
                yield return new TestCaseData(EligibleTest4, new List<int> { 5, 10, 15, 20 }).
                    SetName("Eligible OrComposite Discount - multiple products 2");
                yield return new TestCaseData(EligibleTest5, new List<int> { 5, 10, 15, 20 }).
                    SetName("Eligible OrComposite Discount - multiple products 3");
                yield return new TestCaseData(EligibleTest6, new List<int> { 5, 10, 15, 20 }).
                    SetName("Eligible OrComposite Discount - multiple products 4");
            }
        }
        [Test, TestCaseSource(nameof(TestValidSelectQueryInfoParameters))]
        public void TestValidSelectQueryInfo(string query, SelectQueryInfo selectQueryInfo)
        {
            Assert.AreEqual(selectQueryInfo, );
        }
    }
}