using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices.ComTypes;
using NUnit.Framework;
using OctopusCore.Common;
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
                        Entity = "person",
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
                yield return new TestCaseData(
                    "From Person p\r\n| Where p.id == 2 \r\n| Select p(*)\r\n",
                    new SelectQueryInfo()
                    {
                        Entity = "person",
                        Filters = new List<Filter>()
                        {
                            new EqFilter(new List<string>() {"id"}, "2")
                        },
                        Fields = new List<string>()
                        {
                            StringConstants.All
                        },
                        Includes = new List<Include>(),
                        NestedProperty = new List<string>()
                    });
                yield return new TestCaseData(
                    "From Person p\r\n| where p.FirstName == \"Yonatan\"\r\n| where p.Age == 35\r\n| Select p(id, age, friend, enemy)\r\n",
                    new SelectQueryInfo()
                    {
                        Entity = "person",
                        Filters = new List<Filter>()
                        {
                            new EqFilter(new List<string>() {"firstname"}, "\"Yonatan\""),
                            new EqFilter(new List<string>() {"age"}, "35"),
                        },
                        Fields = new List<string>()
                        {
                            "id", "age", "friend", "enemy"
                        },
                        Includes = new List<Include>(),
                        NestedProperty = new List<string>()
                    });
                yield return new TestCaseData(
                    "From Person p\r\n| where p.FirstName == \"Noa\"\r\n| Select p(id, FirstName, friend,enemy)  Include (friend(FirstName)) \r\nInclude (enemy(FirstName))\r\n",
                    new SelectQueryInfo()
                    {
                        Entity = "person",
                        Filters = new List<Filter>()
                        {
                            new EqFilter(new List<string>() {"firstname"}, "\"Noa\""),
                        },
                        Fields = new List<string>()
                        {
                            "id", "firstname", "friend", "enemy"
                        },
                        Includes = new List<Include>()
                        {
                            new Include()
                            {
                                Name = "friend",
                                Fields = new List<string>(){"firstname"},
                                Includes = new List<Include>()
                            },
                            new Include()
                            {
                                Name = "enemy",
                                Fields = new List<string>(){"firstname"},
                                Includes = new List<Include>()
                            },
                        },
                        NestedProperty = new List<string>()
                    });
                yield return new TestCaseData(
                    "From Person p\r\n| Where p.FirstName == \"Noa\"\r\n\t| Select p(id, FirstName, friend) Include (friend(FirstName, enemy) \r\nInclude (enemy(FirstName)))",
                    new SelectQueryInfo()
                    {
                        Entity = "person",
                        Filters = new List<Filter>()
                        {
                            new EqFilter(new List<string>() {"firstname"}, "\"Noa\""),
                        },
                        Fields = new List<string>()
                        {
                            "id", "firstname", "friend"
                        },
                        Includes = new List<Include>()
                        {
                            new Include()
                            {
                                Name = "friend",
                                Fields = new List<string>(){"firstname", "enemy"},
                                Includes = new List<Include>()
                                {
                                    new Include()
                                    {
                                        Name = "enemy",
                                        Fields = new List<string>(){"firstname"},
                                        Includes = new List<Include>()
                                    }
                                }
                            },
                            
                        },
                        NestedProperty = new List<string>()
                    });
                yield return new TestCaseData(
                    "From Person p \r\n\t| Where p.name == \"Assaf\"\r\n\t| Select p.friend.enemy(FirstName, Age) \r\n",
                    new SelectQueryInfo()
                    {
                        Entity = "person",
                        Filters = new List<Filter>()
                        {
                            new EqFilter(new List<string>() {"name"}, "\"Assaf\""),
                        },
                        Fields = new List<string>()
                        {
                            "firstname", "age"
                        },
                        Includes = new List<Include>(),
                        NestedProperty = new List<string>() {"friend", "enemy" }
                    });
                yield return new TestCaseData(
                    "From Person p \r\n\t| Where p.friend.enemy.name == \"Assaf\"\r\n\t| Select p(FirstName)\r\n",
                    new SelectQueryInfo()
                    {
                        Entity = "person",
                        Filters = new List<Filter>()
                        {
                            new EqFilter(new List<string>() { "friend","enemy","name" }, "\"Assaf\""),
                        },
                        Fields = new List<string>()
                        {
                            "firstname"
                        },
                        Includes = new List<Include>(),
                        NestedProperty = new List<string>()
                    });
            }
        }
        [Test, TestCaseSource(nameof(TestValidSelectQueryInfoParameters))]
        public void TestValidSelectQueryInfo(string query, SelectQueryInfo expectedSelectQueryInfo)
        {
            var actualQueryInfo = _parser.ParseQuery(query).Result;
            Assert.True(actualQueryInfo is SelectQueryInfo);
            var actualSelectQueryInfo = (SelectQueryInfo) actualQueryInfo;
            Assert.AreEqual(expectedSelectQueryInfo, actualSelectQueryInfo);
        }
    }
}