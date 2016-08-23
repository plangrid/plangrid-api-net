using System.Collections.Generic;
using System.Reflection;
using Refit;

namespace PlanGrid.Api.JsonConverters
{
    public class PlanGridUrlParameterFormatter : IUrlParameterFormatter
    {
        private DefaultUrlParameterFormatter defaultFormatter = new DefaultUrlParameterFormatter();
        private List<BaseUrlParameterFormatter> formatters = new List<BaseUrlParameterFormatter>();

        public PlanGridUrlParameterFormatter()
        {
            formatters.Add(new DateUrlParameterFormatter());
            formatters.Add(new CommaSeparatedListUrlParameterFormatter());
        }

        public string Format(object value, ParameterInfo parameterInfo)
        {
            foreach (BaseUrlParameterFormatter formatter in formatters)
            {
                if (formatter.CanFormat(value, parameterInfo))
                {
                    return formatter.Format(value, parameterInfo);
                }
            }
            return defaultFormatter.Format(value, parameterInfo);
        }
    }
}
