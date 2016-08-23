using System.Collections;
using System.Reflection;
using Refit;

namespace PlanGrid.Api.JsonConverters
{
    public class CommaSeparatedListUrlParameterFormatter : BaseUrlParameterFormatter
    {
        public override bool CanFormat(object argument, ParameterInfo parameter)
        {
            return typeof(IList).IsAssignableFrom(parameter.ParameterType);
        }

        public override string Format(object value, ParameterInfo parameterInfo)
        {
            return string.Join(",", (IEnumerable)value);
        }
    }
}
