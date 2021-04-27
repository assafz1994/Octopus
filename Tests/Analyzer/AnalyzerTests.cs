using System.Collections.Generic;
using System.Linq;
using Autofac;
using NUnit.Framework;
using OctopusCore.Analyzer;
using OctopusCore.Analyzer.Jobs;
using OctopusCore.Configuration;
using OctopusCore.Configuration.ConfigurationProviders;
using OctopusCore.Configuration.Mocks;
using OctopusCore.DbHandlers;
using OctopusCore.Parser;

namespace Tests
{
    [TestFixture]
    public class AnalyzerTests
    {
        private const string EntityName = "Entity1";
        private const string IdField = "Id";
        private const string NameField = "Name";
        private const string DatabaseKey = "sql1";

        private static IContainer _container;
        private static SelectQueryInfo _selectQueryInfo;


        [OneTimeSetUp]
        public static void SetUp()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Analyzer>().As<IAnalyzer>();

            var analyzerConfigurationProvider = CreateAnalyzerConfigurationProviderMock();
            builder.RegisterInstance(analyzerConfigurationProvider).As<IAnalyzerConfigurationProvider>();

            var dbHandlerResolverMock = CreateDbHandlerResolverMock();
            builder.RegisterInstance(dbHandlerResolverMock).As<IDbHandlersResolver>();

            _container = builder.Build();

            _selectQueryInfo = new SelectQueryInfo
            {
                Entity = EntityName,
                Fields = new List<string>
                {
                    IdField,
                    NameField
                }
            };

            IAnalyzerConfigurationProvider CreateAnalyzerConfigurationProviderMock()
            {
                var entityTypeToFieldNameToDatabaseKeyMappings = new Dictionary<string, Dictionary<string, string>>
                {
                    {
                        EntityName, new Dictionary<string, string>
                        {
                            {IdField, DatabaseKey},
                            {NameField, DatabaseKey}
                        }
                    }
                };
            
                return new AnalyzerConfigurationProviderMock(entityTypeToFieldNameToDatabaseKeyMappings);
            }
        }

        private static IDbHandlersResolver CreateDbHandlerResolverMock()
        {
            var databaseKeyToDbHandlerMappings = new Dictionary<string, IDbHandler>
            {
                {DatabaseKey, new SqliteDbHandler(null,null)}
            };
            return new DbHandlerResolverMock(databaseKeyToDbHandlerMappings);
        }


        [Test]
        public void TestAnalyzeSelectQuery()
        {
            using var scope = _container.BeginLifetimeScope();
            var analyzer = scope.Resolve<IAnalyzer>();
            var actualWorkPlan = analyzer.AnalyzeQuery(_selectQueryInfo);

            Assert.AreEqual(1, actualWorkPlan.Jobs.Count);
            var job = actualWorkPlan.Jobs.Single();
            Assert.IsInstanceOf<SelectQueryJob>(job);
            var queryJob = (SelectQueryJob)job;
            Assert.AreEqual(EntityName, queryJob.EntityType);
            Assert.That(queryJob.FieldsToSelect, Is.EquivalentTo(new[]
            {
                IdField,
                NameField
            }));
        }
    }
}