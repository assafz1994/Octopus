﻿using System;
using System.Collections.Generic;
using System.Linq;
using OctopusCore.Common;

namespace OctopusCore.Configuration.ConfigurationProviders
{
    public class AnalyzerConfigurationProvider : IAnalyzerConfigurationProvider
    {
        private readonly Dictionary<string, Dictionary<string, List<string>>> _entityTypeToFieldNameToDatabaseKeys;
        private readonly Dictionary<string, Dictionary<string, List<string>>> _entityTypeToDatabaseToFields;
        private readonly Dictionary<string, string> _entityTypeToPrimaryKey;
        public AnalyzerConfigurationProvider(Scheme scheme, DbConfigurations dbConfigurations)
        {
            Scheme = scheme;
            DbConfigurations = dbConfigurations;
            _entityTypeToFieldNameToDatabaseKeys = new Dictionary<string, Dictionary<string, List<string>>>();
            _entityTypeToDatabaseToFields = new Dictionary<string, Dictionary<string, List<string>>>();
            _entityTypeToPrimaryKey = new Dictionary<string, string>();
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

            foreach (var entity in Scheme.Entities)
            {
                _entityTypeToPrimaryKey.Add(entity.Name, entity.Fields.First().Name);
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
            if (fieldName == StringConstants.Guid)
            {
                fieldName = GetEntityPrimaryKey(entityType);
            }

            if (_entityTypeToFieldNameToDatabaseKeys.TryGetValue(entityType, out var fieldNameToDatabaseKeys) == false)
                throw new ArgumentException($"no db to handle this entity type:{entityType}");
            if (fieldNameToDatabaseKeys.TryGetValue(fieldName, out var databaseKeys) == false)
                throw new ArgumentException(
                    $"no db to handle this field: {nameof(entityType)}= {entityType}: {nameof(fieldName)} = {fieldName}");
            return databaseKeys.First();
        }

        public string GetEntityPrimaryKey(string entityType)
        {
            return _entityTypeToPrimaryKey[entityType];
        }
    }
}