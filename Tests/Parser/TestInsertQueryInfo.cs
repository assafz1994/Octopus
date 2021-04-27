using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices.ComTypes;
using NUnit.Framework;
using OctopusCore.Parser;
using OctopusCore.Parser.Filters;

namespace Tests.Parser
{
    [TestFixture]
    public class TestInsertQueryInfo
    {
        private IParser _parser;
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
                    "Entity Person : p (Id = \"6\", firstname = \"Guest\", Age = 120)\r\n" +
                    "insert p",
                    new InsertQueryInfo()
                    {
                        ParserEntities = new List<ParserEntity>()
                        {
                            new ParserEntity(
                                "person", 
                                "p", 
                                new Dictionary<string, dynamic>()
                                {
                                    {"id", "\"6\""},
                                    {"firstname", "\"Guest\""},
                                    {"age", 120},
                                })
                        },
                        EntityReps = new List<string>()
                        {
                            "p"
                        }
                    });
                yield return new TestCaseData(
                    "Entity Person : p2 (Id = \"6\", firstname = \"Guest\", Age = 1)\r\n" +
                    "Entity Person : p3 (Id = \"7\", firstname = \"Guest\", Age = 2) \r\n" +
                    "insert p2, p3",
                    new InsertQueryInfo()
                    {
                        ParserEntities = new List<ParserEntity>()
                        {
                            new ParserEntity(
                                "person",
                                "p2",
                                new Dictionary<string, dynamic>()
                                {
                                    {"id", "\"6\""},
                                    {"firstname", "\"Guest\""},
                                    {"age", 1},
                                }),
                            new ParserEntity(
                                "person",
                                "p3",
                                new Dictionary<string, dynamic>()
                                {
                                    {"id", "\"7\""},
                                    {"firstname", "\"Guest\""},
                                    {"age", 2},
                                })
                        },
                        EntityReps = new List<string>()
                        {
                            "p2", "p3"
                        }
                    });
                yield return new TestCaseData(
                    "Entity Person : p2 (Id = \"6\", firstname = \"Guest\", Age = 1)\r\n" +
                    "Entity Car : c1 (Id = \"345\", Company = \"Best Cars\", Year = 2021) \r\n" +
                    "insert p2, c1",
                    new InsertQueryInfo()
                    {
                        ParserEntities = new List<ParserEntity>()
                        {
                            new ParserEntity(
                                "person",
                                "p2",
                                new Dictionary<string, dynamic>()
                                {
                                    {"id", "\"6\""},
                                    {"firstname", "\"Guest\""},
                                    {"age", 1},
                                }),
                            new ParserEntity(
                                "car",
                                "c1",
                                new Dictionary<string, dynamic>()
                                {
                                    {"id", "\"345\""},
                                    {"company", "\"Best Cars\""},
                                    {"year", 2021},
                                })
                        },
                        EntityReps = new List<string>()
                        {
                            "p2", "c1"
                        }
                    });
            }
        }
        [Test, TestCaseSource(nameof(TestValidInsertQueryInfoParameters))]
        public void TestValidInsertQueryInfo(string query, InsertQueryInfo expectedInsertQueryInfo)
        {
            var actualQueryInfo = _parser.ParseQuery(query).Result;
            Assert.True(actualQueryInfo is InsertQueryInfo);
            var actualInsertQueryInfo = (InsertQueryInfo) actualQueryInfo;
            Assert.AreEqual(expectedInsertQueryInfo, actualInsertQueryInfo);
        }
    }
}