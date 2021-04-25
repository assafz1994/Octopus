using System.Collections.Generic;
using System.Linq;

namespace OctopusCore.Parser.Filters
{
    public class InFilter : Filter
    {
        public InFilter(List<string> fieldNames, dynamic expression, bool isQueried)
        {
            FieldNames = fieldNames;
            Expression = expression;
            IsSubQueried = isQueried;
        }

        public override FilterType Type { get; } = FilterType.In;
        public override Filter GetNextFilter()
        {
            var nextFieldsNames = FieldNames.ToList();
            nextFieldsNames.RemoveAt(0);

            return new InFilter(nextFieldsNames, Expression, IsSubQueried)
            {
                CalcValue = CalcValue
            };
        }
    }
}