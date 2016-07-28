using System;
using System.Reflection;
using Refit;

namespace PlanGrid.Api.JsonConverters
{
    public class DateUrlParameterFormatter : DefaultUrlParameterFormatter
    {
        public override string Format(object value, ParameterInfo parameterInfo)
        {
            if (value is DateTime)
            {
                return ((DateTime)value).ToString("yyyy-MM-ddTHH\\:mm\\:ss");
            }
            else
            {
                return base.Format(value, parameterInfo);
            }
        }
    }
}
