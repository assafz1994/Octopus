using System;
using System.Collections.Generic;
using System.Text;

namespace OctopusCore.Configuration.Scheme
{
    public class Scheme
    {
        public List<Entity> Entities { get; set; }
    }

    public class Entity
    {
        public string Name { get; set; }
        public List<Field> Fields { get; set; }
    }

    public class Field
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public Connection ConnectedTo { get; set; }
    }

    public class Connection
    {
        public string EntityName { get; set; }
        public string FieldName { get; set; }
    }
}