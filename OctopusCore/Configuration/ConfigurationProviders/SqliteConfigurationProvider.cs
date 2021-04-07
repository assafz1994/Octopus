using System;
using System.Collections.Generic;
using System.Text;

namespace OctopusCore.Configuration.ConfigurationProviders
{
    public class SqliteConfigurationProvider
    {
        public string ConnectionString { get; }
        public DbConfiguration DbConfiguration { get; }

        public SqliteConfigurationProvider(Scheme scheme, DbConfiguration dbConfiguration)
        {
            DbConfiguration = dbConfiguration;
            ConnectionString = DbConfiguration.ConnectionString;
        }

        public string GetTableName(string entityType)
        {
            return entityType + "_table";
        }

        public string GetConnectionTable(string entityType, Field field)
        {
            string entity1, entity2, field1, field2;
            var connectedToFieldValue = field.ConnectedToField ?? string.Empty; 
            var compareResult = string.Compare(entityType, field.EntityName, StringComparison.OrdinalIgnoreCase);
            if (compareResult < 1)
            {
                entity1 = entityType;
                entity2 = field.EntityName;
                field1 = field.Name;
                field2 = connectedToFieldValue;
            }
            else if (compareResult > 1)
            {
                entity1 = field.EntityName;
                entity2 = entityType;
                field1 = connectedToFieldValue;
                field2 = field.Name;
            }
            else
            {
                if (string.Compare(field.Name, field.ConnectedToField, StringComparison.OrdinalIgnoreCase) < 1)
                {
                    field1 = field.Name;
                    field2 = connectedToFieldValue;
                }
                else
                {
                    field1 = connectedToFieldValue;
                    field2 = field.Name;
                }

                entity1 = entity2 = entityType; //they are equals
            }

            return $"{entity1}_{entity2}_{field1}_{field2}";
        }
    }
}