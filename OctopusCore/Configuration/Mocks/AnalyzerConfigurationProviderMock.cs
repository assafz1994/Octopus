﻿using System.Collections.Generic;
using OctopusCore.Configuration.ConfigurationProviders;

namespace OctopusCore.Configuration.Mocks
{
    public class AnalyzerConfigurationProviderMock : IAnalyzerConfigurationProvider
    {
        private readonly Dictionary<string, Dictionary<string, string>> _entityTypeToFieldNameToDatabaseKeyMappings;

        public AnalyzerConfigurationProviderMock(Dictionary<string,Dictionary<string,string>> entityTypeToFieldNameToDatabaseKeyMappings)
        {
            _entityTypeToFieldNameToDatabaseKeyMappings = entityTypeToFieldNameToDatabaseKeyMappings;
        }

        public Dictionary<string, List<string>> GetDbsToFields(string entityType)
        {
            throw new System.NotImplementedException();
        }

        public string GetFieldDatabaseKey(string entityType, string fieldName)
        {
            return _entityTypeToFieldNameToDatabaseKeyMappings[entityType][fieldName];
        }

        public bool IsComplexField(string entityType, string fieldName)
        {
            return false;
        }

        public Field GetField(string entityType, string fieldName)
        {
            throw new System.NotImplementedException();
        }

        public string GetEntityFirstField(string entityType)
        {
            throw new System.NotImplementedException();
        }

        public List<Field> GetEntityFields(string entityType)
        {
            throw new System.NotImplementedException();
        }
    }
}