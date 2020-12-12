using System;
using System.Collections.Generic;
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

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            return obj is SelectQueryInfo selectQueryInfo
                   && Entity.Equals(selectQueryInfo.Entity)
                   && Fields.Equals(selectQueryInfo.Fields)
                   && Includes.Equals(selectQueryInfo.Includes)
                   && Filters.Equals(selectQueryInfo.Filters)
                   && NestedProperty.Equals(selectQueryInfo.NestedProperty);

        }

        protected bool Equals(SelectQueryInfo other)
        {
            return Entity == other.Entity && Equals(Filters, other.Filters) && Equals(NestedProperty, other.NestedProperty) && Equals(Fields, other.Fields) && Equals(Includes, other.Includes);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Entity != null ? Entity.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Filters != null ? Filters.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (NestedProperty != null ? NestedProperty.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Fields != null ? Fields.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Includes != null ? Includes.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}
