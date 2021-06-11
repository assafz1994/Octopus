using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using OctopusCore.Configuration.ConfigurationProviders;
using OctopusCore.DbHandlers;

namespace OctopusCore.Configuration
{
    public class DbHandlersResolver : IDbHandlersResolver
    {
        private readonly ConcurrentDictionary<string, IDbHandler> _databaseKeyToDbHandlerMapping;
        private AnalyzerConfigurationProvider _analyzerConfigurationProvider; 


        public DbHandlersResolver(Scheme scheme, DbConfigurations dbConfigurations)
        {
            _analyzerConfigurationProvider = new AnalyzerConfigurationProvider(scheme, dbConfigurations);
            _databaseKeyToDbHandlerMapping = new ConcurrentDictionary<string, IDbHandler>();
            foreach (var dbConfiguration in dbConfigurations.Configurations)
            {
                var dbHandler = CreateDbHandler(dbConfiguration, scheme);
                _databaseKeyToDbHandlerMapping.TryAdd(dbConfiguration.Id, dbHandler);
            }
        }

        public IDbHandler ResolveDbHandler(string databaseKey)
        {
            if (_databaseKeyToDbHandlerMapping.TryGetValue(databaseKey, out var result) == false)
                throw new ArgumentException("invalid dataBaseKey", nameof(databaseKey));

            return result;
        }

        

        private IDbHandler CreateDbHandler(DbConfiguration dbConfiguration, Scheme scheme)
        {
            switch (dbConfiguration.DbType)
            {
                case DbType.Sqlite:
                    var sqliteProvider = new SqliteConfigurationProvider(scheme, dbConfiguration);
                    return new SqliteDbHandler(sqliteProvider, _analyzerConfigurationProvider);
                case DbType.MongoDB:
                    var mongoDbProvider = new MongoDBConfigurationProvider(scheme, dbConfiguration);
                    return new MongoDBHandler(mongoDbProvider);
                case DbType.Neo4j:
                    return new Neo4JDbHandler(new Neo4jConfigurationProvider(scheme, dbConfiguration));
                case DbType.Cassandra:
                    var cassandraConfigurationProvider = new CassandraConfigurationProvider(scheme, dbConfiguration);
                    return new CassandraDbHandler(cassandraConfigurationProvider);
                default:
                    throw new NotSupportedException($"unsupported dataBaseType : {dbConfiguration.DbType}");
            }
        }
    }
}