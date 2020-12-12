using System;
using System.Collections.Generic;
using System.Text;

namespace OctopusCore.Parser.Filters
{
    public class EqFilter : Filter
    {
        public EqFilter(List<string> fieldNames, string expression)
        {
            FieldNames = fieldNames;
            Expression = expression;
        }

        public EqFilter GetEqFilter(List<string> fieldNames, string expression)
        {
            return new EqFilter(fieldNames, expression);
        }
    }
}
