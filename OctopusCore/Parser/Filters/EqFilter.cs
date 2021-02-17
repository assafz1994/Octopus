using System;
using System.Collections.Generic;
using System.Linq;

namespace OctopusCore.Parser.Filters
{
    public class EqFilter : Filter
    {
        public EqFilter(List<string> fieldNames, string expression)
        {
            FieldNames = fieldNames;
            Expression = expression;
            Type = FilterType.Eq;
        }

        public override FilterType Type { get; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            return obj is EqFilter eqFilter
                   && FieldNames.SequenceEqual(eqFilter.FieldNames)
                   && Expression.Equals(eqFilter.Expression)
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