using System.Reflection;
using Refit;

namespace PlanGrid.Api.JsonConverters
{
    public abstract class BaseUrlParameterFormatter : IUrlParameterFormatter
    {
        public abstract bool CanFormat(object argument, ParameterInfo parameter);
        public abstract string Format(object value, ParameterInfo parameterInfo);
    }
}
