using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OctopusCore.Parser.Filters
{
    public class EqFilter : Filter
    {
        public EqFilter(List<string> fieldNames, string expression)
        {
            FieldNames = fieldNames;
            Expression = expression;
            IsSubQueried = false;
        }
        public EqFilter(List<string> fieldNames, string expression, bool isQueried)
        {
            FieldNames = fieldNames;
            Expression = expression;
            IsSubQueried = isQueried;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            return obj is EqFilter eqFilter
                   && FieldNames.SequenceEqual(eqFilter.FieldNames)
                   && Expression.Equals(eqFilter.Expression)
                   && IsSubQueried.Equals(eqFilter.IsSubQueried);

        }
    }
}
