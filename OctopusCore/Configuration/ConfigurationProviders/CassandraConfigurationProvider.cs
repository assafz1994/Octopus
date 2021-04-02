﻿using System.Collections.Generic;
using System.Linq;
using Cassandra;
using OctopusCore.Parser;

namespace OctopusCore.Configuration.ConfigurationProviders
{
    public class CassandraConfigurationProvider
    {
        public string ConnectionString { get; }
        public string KeySpace { get; }
        public List<Entity> Entities { get; set; }
        public CassandraConfigurationProvider(Scheme scheme, DbConfiguration dbConfiguration)
        {
            ConnectionString = dbConfiguration.ConnectionString;
            KeySpace = dbConfiguration.KeySpace;
            Entities = dbConfiguration.Entities;
        }

        public string AssembleQuery(string entityType, string fields, IReadOnlyCollection<Filter> filters, string conditions)
        {
            var entity = Entities.First(x => x.Name == entityType);
            var filterNames = filters.Select(x => x.FieldNames[0]).ToList();
            if (filterNames.Count == 0)
            {
                return $"SELECT {fields} FROM {entityType}_table";
            }
            var table = entity.TablesByFields.FirstOrDefault(x =>
                {
                    var set1 = new HashSet<string>(x);
                    var set2 = new HashSet<string>(filterNames);
                    return set1.SetEquals(set2);
                }
               );
            return table != null
                ? $"SELECT {fields} FROM {entityType}_table_by_{string.Join("_", table)} {conditions}"
                : $"SELECT {fields} FROM {entityType}_table {conditions} ALLOW FILTERING";
        }
    }
}