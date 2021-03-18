using System;
using System.Collections.Generic;
using System.Linq;

namespace OctopusCore.Parser.Filters
{
    public class EqFilter : Filter
    {
        public EqFilter(List<string> fieldNames, dynamic expression)
        {
            FieldNames = fieldNames;
            Expression = expression;
            IsSubQueried = false;
            Type = FilterType.Eq;
        }
        
        public EqFilter(List<string> fieldNames, dynamic expression, bool isQueried)
        {
            FieldNames = fieldNames;
            Expression = expression;
            IsSubQueried = isQueried;
            Type = FilterType.Eq;
        }

        public override FilterType Type { get; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            var eqFilter = (EqFilter) obj;
            return FieldNames.SequenceEqual(eqFilter.FieldNames)
                   && Expression.Equals(eqFilter.Expression)
                   && IsSubQueried.Equals(eqFilter.IsSubQueried)
                   && Type.Equals(eqFilter.Type);
        }

        protected bool Equals(EqFilter other)
        {
            return Equals(FieldNames, other.FieldNames) && Expression == other.Expression;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FieldNames, Expression, Type);
        }
    }
}