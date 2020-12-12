using System.Collections.Generic;

namespace OctopusCore.Parser
{
    public abstract class Filter
    {
        public List<string> FieldNames { get; set; }

        public string Expression { get; set; }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            return obj is Filter filter
                   && FieldNames.Equals(filter.FieldNames)
                   && Expression.Equals(filter.Expression);

        }

        protected bool Equals(Filter other)
        {
            return Equals(FieldNames, other.FieldNames) && Expression == other.Expression;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((FieldNames != null ? FieldNames.GetHashCode() : 0) * 397) ^ (Expression != null ? Expression.GetHashCode() : 0);
            }
        }
    }
}