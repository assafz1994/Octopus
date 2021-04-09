using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OctopusCore.Common;
using OctopusCore.Parser;
using OctopusCore.Parser.Filters;

namespace Tests.Parser
{
    class TestDeleteQueryInfo
    {
        private IParser _parser;
        private const string All = "$ALL$";
        [OneTimeSetUp]
        public void SetUp()
        {
            _parser = new OctopusCore.Parser.Parser();
        }
        public static IEnumerable<TestCaseData> TestValidInsertQueryInfoParameters
        {
            get
            {
                yield return new TestCaseData(
                    "Delete From Person p | Where p.id == \"5\"",
                    new DeleteQueryInfo()
                    {
                        Entity = "person",
                        SubQueries = new Dictionary<string, QueryInfo>()
                        {
                            {
                                "guid", new SelectQueryInfo()
                                {
                                    Entity = "person",
                                    Filters = new List<Filter>()
                                    {
                                        new EqFilter(new List<string>() {"id"}, "\"5\"")
                                    },
                                    Fields = new List<string>()
                                    {
                                        StringConstants.Guid
                                    },
                                    Includes = new List<Include>(),
                                    NestedProperty = new List<string>()
                                }
                            }
                        }
                    });
            }
        }
        [Test, TestCaseSource(nameof(TestValidInsertQueryInfoParameters))]
        public void TestValidDeleteQueryInfo(string query, DeleteQueryInfo expectedDeleteQueryInfo)
        {
            var actualQueryInfo = _parser.ParseQuery(query).Result;
            Assert.True(actualQueryInfo is DeleteQueryInfo);
            var actualDeleteQueryInfo = (DeleteQueryInfo)actualQueryInfo;
            Assert.AreEqual(expectedDeleteQueryInfo, actualDeleteQueryInfo);
        }
    }
}
