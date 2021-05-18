using System.Collections.Generic;
using NUnit.Framework;
using OctopusCore.Parser;
using OctopusCore.Parser.Filters;

namespace Tests.Parser
{
    public class TestUpdateQueryInfo
    {
        private IParser _parser;
        [OneTimeSetUp]
        public void SetUp()
        {
            _parser = new OctopusCore.Parser.Parser();
        }
        public static IEnumerable<TestCaseData> TestValidUpdateQueryInfoParameters
        {
            get
            {
                yield return new TestCaseData(
                    "Entity Animal : an1 (From Animal a | where a.aid == \"1\" | select a(aid, food))\r\nUpdate an1.food = \"newfood\"",
                    new UpdateQueryInfo()
                    {
                        Entity = "animal",
                        SubQueries = new Dictionary<string, QueryInfo>()
                        {
                            {
                                "guid", new SelectQueryInfo()
                                {
                                    Entity = "animal",
                                    Filters = new List<Filter>()
                                    {
                                        new EqFilter(new List<string>() {"aid"}, "\"1\"")
                                    },
                                    Fields = new List<string>()
                                    {
                                        "aid", "food"
                                    },
                                    Includes = new List<Include>(),
                                    NestedProperty = new List<string>()
                                }
                            }
                        },
                        EntityRep = "an1",
                        EntityRepToEntityType = new Dictionary<string, string>()
                        {
                            {"an1", "animal"}
                        },
                        EntityToSubQuery = new Dictionary<string, string>()
                        {
                            {"an1", "guid"}
                        },
                        Fields = new List<string>() {"food"},
                        Value = "\"newfood\""
                    });
                yield return new TestCaseData(
                    "Entity Animal : an1 (From Animal a | where a.aid == \"1\" | select a(aid, height))\r\nUpdate an1.height = 4567",
                    new UpdateQueryInfo()
                    {
                        Entity = "animal",
                        SubQueries = new Dictionary<string, QueryInfo>()
                        {
                            {
                                "guid", new SelectQueryInfo()
                                {
                                    Entity = "animal",
                                    Filters = new List<Filter>()
                                    {
                                        new EqFilter(new List<string>() {"aid"}, "\"1\"")
                                    },
                                    Fields = new List<string>()
                                    {
                                        "aid", "height"
                                    },
                                    Includes = new List<Include>(),
                                    NestedProperty = new List<string>()
                                }
                            }
                        },
                        EntityRep = "an1",
                        EntityRepToEntityType = new Dictionary<string, string>()
                        {
                            {"an1", "animal"}
                        },
                        EntityToSubQuery = new Dictionary<string, string>()
                        {
                            {"an1", "guid"}
                        },
                        Fields = new List<string>() { "height" },
                        Value = 4567
                    });
            }
        }
        [Test, TestCaseSource(nameof(TestValidUpdateQueryInfoParameters))]
        public void TestValidUpdateQueryInfo(string query, UpdateQueryInfo expectedUpdateQueryInfo)
        {
            var actualQueryInfo = _parser.ParseQuery(query).Result;
            Assert.True(actualQueryInfo is UpdateQueryInfo);
            var actualUpdateQueryInfo = (UpdateQueryInfo)actualQueryInfo;
            Assert.AreEqual(expectedUpdateQueryInfo, actualUpdateQueryInfo);
        }
    }
}