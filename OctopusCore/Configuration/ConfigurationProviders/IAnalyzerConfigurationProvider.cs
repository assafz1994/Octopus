﻿using System.Collections.Generic;

namespace OctopusCore.Configuration.ConfigurationProviders
{
    public interface IAnalyzerConfigurationProvider
    {
        public Dictionary<string, List<string>> GetDbAndFields(string entityType);
        string GetFieldDatabaseKey(string entityType, string fieldName);
    }
}