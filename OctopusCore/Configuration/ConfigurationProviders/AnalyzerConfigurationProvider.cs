using System;
using System.Collections.Generic;
using System.Linq;
using OctopusCore.Common;

namespace OctopusCore.Configuration.ConfigurationProviders
{
    public class AnalyzerConfigurationProvider : IAnalyzerConfigurationProvider
    {
        //todo refactor dictionaries. create object for fields and database keys(entity -> fieldName -> object)
        private readonly Dictionary<string, Dictionary<string, List<string>>> _entityTypeToFieldNameToDatabaseKeys;
        private readonly Dictionary<string, Dictionary<string,Field>> _entityTypeToFieldNameToField;

        private readonly Dictionary<string, Dictionary<string, List<string>>> _entityTypeToDatabaseToFields;
        private readonly Dictionary<string, List<string>> _entityTypeToFields;
        public AnalyzerConfigurationProvider(Scheme scheme, DbConfigurations dbConfigurations)
        {
            Scheme = scheme;
            DbConfigurations = dbConfigurations;
            _entityTypeToFieldNameToDatabaseKeys = new Dictionary<string, Dictionary<string, List<string>>>(StringComparer.OrdinalIgnoreCase);
            _entityTypeToDatabaseToFields = new Dictionary<string, Dictionary<string, List<string>>>(StringComparer.OrdinalIgnoreCase);
            _entityTypeToFieldNameToField = new Dictionary<string, Dictionary<string, Field>>(StringComparer.OrdinalIgnoreCase);
            InitializeDictionaries();
        }

        public Scheme Scheme { get; }
        public DbConfigurations DbConfigurations { get; }

        private void InitializeDictionaries()
        {
            foreach (var dbConfiguration in DbConfigurations.Configurations)
            foreach (var entity in dbConfiguration.Entities)
            {
                // InitializeDictionaries
                if (_entityTypeToFieldNameToField.ContainsKey(entity.Name) == false)
                {
                    _entityTypeToFieldNameToField.Add(entity.Name,new Dictionary<string, Field>(StringComparer.OrdinalIgnoreCase));
                }
                if (_entityTypeToFieldNameToDatabaseKeys.ContainsKey(entity.Name) == false)
                    _entityTypeToFieldNameToDatabaseKeys.Add(entity.Name, new Dictionary<string, List<string>>());

                foreach (var field in entity.Fields)
                {

                    if (_entityTypeToFieldNameToField[entity.Name].ContainsKey(field.Name) == false)
                    {
                        _entityTypeToFieldNameToField[entity.Name][field.Name] = field;
                    }
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
            var field = GetField(entityType, fieldName);

            return field.Type != DbFieldType.Primitive;
        }

        public Field GetField(string entityType, string fieldName)
        {
            if (_entityTypeToFieldNameToField.TryGetValue(entityType, out var fieldNameToField) == false)
            {
                throw new ArgumentException($"entity not exist. entity type = {entityType}");
            }

            if (fieldNameToField.TryGetValue(fieldName, out var field) == false)
            {
                throw new ArgumentException($"field not exist. field = {fieldName}");
            }

            return field;
        }


        public string GetEntityFirstField(string entityType)
        {
            var fieldNameToField =  _entityTypeToFieldNameToField[entityType];
            foreach (var field in fieldNameToField)
            {
                if (field.Value.Type.Equals(DbFieldType.Primitive))
                {
                    return field.Key;
                }
            }
            return null;
        }

        public List<string> GetEntityFields(string entityType)
        {
            return _entityTypeToFields[entityType];
        }
    }
}