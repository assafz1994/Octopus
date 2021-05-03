﻿using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Octopus.Client;
using OctopusCore.Configuration;
using OctopusCore.Configuration.ConfigurationProviders;
using OctopusCore.DbHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tests.DbsConfiguration;

namespace Tests.DBHandlers
{
    class SQLiteUnitTest
    {
        private OctopusClient _client;
        private DbsConfigurator _dbsConfigurator;
        private SqliteDbHandler _sqliteDBHandler;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _client = new OctopusClient("http://localhost:5000");
            _dbsConfigurator = new DbsConfigurator();
            var entities = new List<Entity>(){
                new Entity()
                {
                    Name="Student",
                    Fields= new List<Field>()
                    {
                        new Field {
                        Name = "sid",
                        Type = DbFieldType.Primitive,
                        PrimitiveType = PrimitiveType.String
                        },
                        new Field
                        {
                            Name = "age",
                            Type = DbFieldType.Primitive,
                            PrimitiveType = PrimitiveType.Int
                        },
                        new Field
                        {
                            Name = "name",
                            Type = DbFieldType.Primitive,
                            PrimitiveType = PrimitiveType.String
                        },
                        new Field
                        {
                            Name = "address",
                            Type = DbFieldType.Object,
                            EntityName = "Address",
                            ConnectedToField = null
                        },
                        new Field
                        {
                            Name = "taughtBy",
                            Type = DbFieldType.Object,
                            EntityName = "teacher",
                            ConnectedToField = "teach"
                        }
                    }
                },
                new Entity
                {
                    Name="Student",
                    Fields= new List<Field>()
                    {
                        new Field
                        {
                            Name = "tid",
                            Type = DbFieldType.Primitive,
                            PrimitiveType = PrimitiveType.String
                        },
                        new Field
                        {
                            Name = "age",
                            Type = DbFieldType.Primitive,
                            PrimitiveType = PrimitiveType.Int
                        },
                        new Field
                        {
                            Name = "name",
                            Type = DbFieldType.Primitive,
                            PrimitiveType = PrimitiveType.String
                        },
                        new Field
                        {
                            Name = "teach",
                            Type = DbFieldType.Object,
                            EntityName = "student",
                            ConnectedToField = "taughtBy"
                        }
                    }
                }
            };

            var schema = new Scheme()
            {
                Entities = entities,
            };

            DbConfiguration configuration = new DbConfiguration() { Entities = entities, Id = "sql1", ConnectionString = "Data Source=DataBases\\sqlite1_test_db.db" };
            var provider = new SqliteConfigurationProvider(schema, configuration);
            var configurations = new DbConfigurations()
            {
                Configurations = new List<DbConfiguration>(){
                    configuration,
                }
            };
            var analyzerConfigurationProvider = new AnalyzerConfigurationProvider(schema, configurations);
            this._sqliteDBHandler = new SqliteDbHandler(provider, analyzerConfigurationProvider);

        }

        [SetUp]
        public void SetUp()
        {
            _dbsConfigurator.SetUpDbs();
        }

        [TearDown]
        public void TearDown()
        {
            _dbsConfigurator.TearDownDbs();
        }

        [Test]
        public void TestSelectMultipleFieldsWithFilterOfStudentUT()
        {
            _dbsConfigurator.SetUpTestComplexSelect();

            IReadOnlyCollection<string> fieldsToSelect = new List<string> {
                "sid",
                "age",
                "name",
            }.AsReadOnly();

            IReadOnlyCollection<OctopusCore.Parser.Filter> filters = new List<OctopusCore.Parser.Filter>
            {
                new OctopusCore.Parser.Filters.EqFilter(new List<string>() {"age"}, 10)
            };

            var entityType = "student";
            List<(string entityType, OctopusCore.Configuration.Field field, List<string> fieldsToSelect)> joinsTuples = new List<(string entityType, OctopusCore.Configuration.Field field, List<string> fieldsToSelect)>();
            var res = _sqliteDBHandler.ExecuteQueryWithFiltersAsync(fieldsToSelect, filters, entityType, joinsTuples).Result;
            
            var expectedResult = new List<Dictionary<string, dynamic>>()
            {
                new Dictionary<string, dynamic>()
                {
                    { "sid", "1" },
                    { "age", 10 },
                    { "name", "sn1" }
                },
                new Dictionary<string, dynamic>()
                {
                    { "sid", "2" },
                    { "age", 10 },
                    { "name", "sn2" }
                },
            };


            var entityResults = res.EntityResults.Values.ToList();
            List<Dictionary<string, dynamic>> fields = entityResults.Select(x => x.Fields).ToList();

            CollectionAssert.AreEqual(fields, expectedResult);            
        }

        [Test]
        public void TestSelectMultipleFieldsWithFilterAndWithComplexFieldOfStudentUT()
        {
            _dbsConfigurator.SetUpTestComplexSelect();

            IReadOnlyCollection<string> fieldsToSelect = new List<string> {
                "sid",
                "age",
                "name",
            }.AsReadOnly();

            IReadOnlyCollection<OctopusCore.Parser.Filter> filters = new List<OctopusCore.Parser.Filter>
            {
                new OctopusCore.Parser.Filters.EqFilter(new List<string>() {"age"}, 30)
            };

            var entityType = "student";
            List<(string entityType, OctopusCore.Configuration.Field field, List<string> fieldsToSelect)> joinsTuples =
                new List<(string entityType, OctopusCore.Configuration.Field field, List<string> fieldsToSelect)>() {
                (
                    entityType,
                    new Field()
                    {
                        ConnectedToField = "teach",
                        EntityName = "teacher",
                        Name = "taughtBy",
                        PrimitiveType = null,
                        Type = DbFieldType.Object
                    },
                    new List<string>(){}
                )
           };

            var res = _sqliteDBHandler.ExecuteQueryWithFiltersAsync(fieldsToSelect, filters, entityType, joinsTuples).Result;
            var expectedResult = new List<Dictionary<string, dynamic>>()
            {
                new Dictionary<string, dynamic>()
                {
                    { "sid", "3" },
                    { "age", 30 },
                    { "name", "sn3" },
                    {"taughtBy",  new JObject() {{"name", "tn3"}} }
                },
            };

            var entityResults = res.EntityResults.Values.ToList();
            List<Dictionary<string, dynamic>> fields = entityResults.Select(x => x.Fields).ToList();
            CollectionAssert.AreEqual(fields, expectedResult);
        }
    }
}
