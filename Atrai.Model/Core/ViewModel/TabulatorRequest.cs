using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atrai.Model.Core.ViewModel
{
    public class TabulatorRequest
    {
        public List<Filter> Filter { get; set; }= new();
        public int Page { get; set; }
        public int Size { get; set; }

        public string GetCombinedFilterExpression()
        {
            if (Filter == null || Filter.Count == 0)
            {                
                return string.Empty;
            }           
            var filterExpressions = Filter.Select(GetFilterExpression);
            return string.Join(" && ", filterExpressions);
        }

        private string GetFilterExpression(Filter filter)
        {
            switch (filter.Type)
            {
                case "like":                    
                    return $"{filter.Field}.ToLower().Contains(\"{filter.Value}\".ToLower())";                
                default:
                    throw new NotSupportedException($"Filter type '{filter.Type}' is not supported.");
            }
        }
    }

    public class Filter
    {
        public string Field { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
    }

}