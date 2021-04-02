using System;
using System.Collections.Generic;
using System.Linq;
using OctopusCore.Common;

namespace OctopusCore.Configuration.ConfigurationProviders
{
    public class AnalyzerConfigurationProvider : IAnalyzerConfigurationProvider
    {
        private readonly Dictionary<string, Dictionary<string, List<string>>> _entityTypeToFieldNameToDatabaseKeys;
        private readonly Dictionary<string, Dictionary<string, List<string>>> _entityTypeToDatabaseToFields;
        public AnalyzerConfigurationProvider(Scheme scheme, DbConfigurations dbConfigurations)
        {
            Scheme = scheme;
            DbConfigurations = dbConfigurations;
            _entityTypeToFieldNameToDatabaseKeys = new Dictionary<string, Dictionary<string, List<string>>>();
            _entityTypeToDatabaseToFields = new Dictionary<string, Dictionary<string, List<string>>>();
            InitializeEntityTypeToFieldNameToDatabaseKeys();
            InitializeEntityTypeToDatabaseToFields();
        }

        private void InitializeEntityTypeToDatabaseToFields()
        {
            foreach (var dbConfiguration in DbConfigurations.Configurations)
            foreach (var entity in dbConfiguration.Entities)
            {
                if (_entityTypeToDatabaseToFields.ContainsKey(entity.Name) == false)
                    _entityTypeToDatabaseToFields.Add(entity.Name, new Dictionary<string, List<string>>());
                var fields = entity.Fields.Select(x => x.Name).ToList();
                fields.Add(StringConstants.Guid);
                _entityTypeToDatabaseToFields[entity.Name][dbConfiguration.Id] = fields;
            }
        }

        public Scheme Scheme { get; }
        public DbConfigurations DbConfigurations { get; }

        private void InitializeEntityTypeToFieldNameToDatabaseKeys()
        {
            foreach (var dbConfiguration in DbConfigurations.Configurations)
            foreach (var entity in dbConfiguration.Entities)
            {
                if (_entityTypeToFieldNameToDatabaseKeys.ContainsKey(entity.Name) == false)
                    _entityTypeToFieldNameToDatabaseKeys.Add(entity.Name, new Dictionary<string, List<string>>());

                foreach (var field in entity.Fields)
                {
                    var fieldNameToDatabaseKey = _entityTypeToFieldNameToDatabaseKeys[entity.Name];
                    if (fieldNameToDatabaseKey.ContainsKey(field.Name) == false)
                        fieldNameToDatabaseKey.Add(field.Name, new List<string> {dbConfiguration.Id});
                    else
                        fieldNameToDatabaseKey[field.Name].Add(dbConfiguration.Id);
                }
            }
        }
        public Dictionary<string, List<string>> GetDbsToFields(string entityType)
        {
            if (_entityTypeToDatabaseToFields.TryGetValue(entityType, out var dbsToFieldsDictionary) == false)
                throw new ArgumentException($"no db to handle this entity type:{entityType}");
            return dbsToFieldsDictionary;
        }

        public string GetFieldDatabaseKey(string entityType, string fieldName)
        {
            if (_entityTypeToFieldNameToDatabaseKeys.TryGetValue(entityType, out var fieldNameToDatabaseKeys) == false)
                throw new ArgumentException($"no db to handle this entity type:{entityType}");
            if (fieldNameToDatabaseKeys.TryGetValue(fieldName, out var databaseKeys) == false)
                throw new ArgumentException(
                    $"no db to handle this field: {nameof(entityType)}= {entityType}: {nameof(fieldName)} = {fieldName}");
            return databaseKeys.First();
        }
    }
}