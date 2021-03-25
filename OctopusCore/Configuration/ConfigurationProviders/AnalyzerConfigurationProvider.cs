using System;
using System.Collections.Generic;
using System.Linq;

namespace OctopusCore.Configuration.ConfigurationProviders
{
    public class AnalyzerConfigurationProvider : IAnalyzerConfigurationProvider
    {
        private readonly Dictionary<string, Dictionary<string, List<string>>> _entityTypeToFieldNameToDatabaseKeys;
        private readonly Dictionary<string, HashSet<string>> _entityTypeToComplexFields;

        public AnalyzerConfigurationProvider(Scheme scheme, DbConfigurations dbConfigurations)
        {
            Scheme = scheme;
            DbConfigurations = dbConfigurations;
            _entityTypeToFieldNameToDatabaseKeys = new Dictionary<string, Dictionary<string, List<string>>>();
            _entityTypeToComplexFields = new Dictionary<string, HashSet<string>>();
            InitializeEntityTypeToFieldNameToDatabaseKeys();
            InitializeEntityTypeToComplexFields();
        }

        private void InitializeEntityTypeToComplexFields()
        {
            foreach (var entity in Scheme.Entities)
            {
                foreach (var field in entity.Fields)
                {
                    if(field.Type)
                }
            }

            Scheme.Entities
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

        }
    }
}