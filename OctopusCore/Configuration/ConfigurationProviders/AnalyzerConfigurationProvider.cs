using System;
using System.Collections.Generic;
using System.Linq;

namespace OctopusCore.Configuration.ConfigurationProviders
{
    public class AnalyzerConfigurationProvider : IAnalyzerConfigurationProvider
    {
        private readonly Dictionary<string, Dictionary<string, List<string>>> _entityTypeToFieldNameToDatabaseKeys;
        private readonly Dictionary<string, HashSet<string>> _entityTypeToComplexFields;

        private readonly Dictionary<string, Dictionary<string, List<string>>> _entityTypeToDatabaseToFields;
        public AnalyzerConfigurationProvider(Scheme scheme, DbConfigurations dbConfigurations)
        {
            Scheme = scheme;
            DbConfigurations = dbConfigurations;
            _entityTypeToFieldNameToDatabaseKeys = new Dictionary<string, Dictionary<string, List<string>>>(StringComparer.OrdinalIgnoreCase);
            _entityTypeToDatabaseToFields = new Dictionary<string, Dictionary<string, List<string>>>(StringComparer.OrdinalIgnoreCase);
            _entityTypeToComplexFields = new Dictionary<string, HashSet<string>>(StringComparer.OrdinalIgnoreCase);
            InitializeDictionaries();
        }

        private void InitializeEntityTypeToComplexFields()
        {
            foreach (var entity in Scheme.Entities)
            {
                foreach (var field in entity.Fields)
                {
                    if (field.Type != DbFieldType.Primitive)
                    {
                        if (!_entityTypeToComplexFields.ContainsKey(entity.Name))
                        {
                            _entityTypeToComplexFields.Add(entity.Name,new HashSet<string>());
                        }
                        _entityTypeToComplexFields[entity.Name].Add(field.Name);
                    }
                }
            }
        }

        public Scheme Scheme { get; }
        public DbConfigurations DbConfigurations { get; }

        private void InitializeDictionaries()
        {
            InitializeEntityTypeToComplexFields();
            foreach (var dbConfiguration in DbConfigurations.Configurations)
            foreach (var entity in dbConfiguration.Entities)
            {
                // InitializeDictionaries
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

                // InitializeEntityTypeToDatabaseToFields
                if (_entityTypeToDatabaseToFields.ContainsKey(entity.Name) == false)
                    _entityTypeToDatabaseToFields.Add(entity.Name, new Dictionary<string, List<string>>());
                _entityTypeToDatabaseToFields[entity.Name][dbConfiguration.Id] = entity.Fields.Select(x => x.Name).ToList();
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

        public bool IsComplexField(string entityType, string fieldName)
        {
            if (_entityTypeToComplexFields.TryGetValue(entityType, out var complexFields))
            {
                return complexFields.Contains(fieldName);
            }

            return false;
        }
    }
}