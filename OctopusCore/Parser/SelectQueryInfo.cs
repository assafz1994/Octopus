﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OctopusCore.Parser
{
    public class SelectQueryInfo : QueryInfo
    {
        public string Entity { get; set; }
        public List<Filter> Filters { get; set; }
        public List<string> NestedProperty { get; set; }
        public List<string> Fields { get; set; }
        public List<Include> Includes { get; set; }

        public SelectQueryInfo()
        {
            SubQueries = new Dictionary<string, QueryInfo>();
            Filters = new List<Filter>();
            NestedProperty = new List<string>();
            Fields = new List<string>();
            Includes = new List<Include>();
        }
        
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            if (!(obj is SelectQueryInfo selectQueryInfo)) return false;
            return 
                    Entity.Equals(selectQueryInfo.Entity)
                   && Fields.SequenceEqual(selectQueryInfo.Fields)
                   && Includes.SequenceEqual(selectQueryInfo.Includes)
                   && Filters.SequenceEqual(selectQueryInfo.Filters)
                   && NestedProperty.SequenceEqual(selectQueryInfo.NestedProperty) 
                   && SubQueries.Values.SequenceEqual(selectQueryInfo.SubQueries.Values);

        }
    }
}
