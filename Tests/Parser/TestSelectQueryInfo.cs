using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using NUnit.Framework;
using OctopusCore.Parser;
using OctopusCore.Parser.Filters;

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
                yield return new TestCaseData(
                    "From Person p\r\n| Where p.id == 2\r\n| Select p(id, age, friend)\r\n", 
                    new SelectQueryInfo()
                    {
                        Entity = "Person",
                        Filters = new List<Filter>()
                        {
                            new EqFilter(new List<string>() {"id"}, "2")
                        },
                        Fields = new List<string>()
                        {
                            "id", "age", "friend"
                        },
                        Includes = new List<Include>(),
                        NestedProperty = new List<string>()
                    });
                
            }
        }
        [Test, TestCaseSource(nameof(TestValidSelectQueryInfoParameters))]
        public void TestValidSelectQueryInfo(string query, SelectQueryInfo expectedSelectQueryInfo)
        {
            var actualSelectQueryInfo = _parser.ParseQuery(query).Result;
            Assert.AreEqual(expectedSelectQueryInfo, actualSelectQueryInfo);
        }
    }
}