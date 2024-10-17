namespace Atrai.Model.Core.ViewModel
{
    public class ChartDataRequest
    {
        public string? Type { get; set; }
        public string? selectColums { get; set; }
        public string? groupfilterid { get; set; }
        public string? additionalfilter { get; set; }
        public string? additionalfilterdata { get; set; }
        public string? Timepreriod { get; set; }
    }
    public class ChartConfiguration
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public object Data { get; set; }
        public object Options { get; set; }
        public bool isSystem = false;
    }
    public class Chartdata
    {
        public string? Labels { get; set; }
        public string? Data { get; set; }

    }
    public class AccledgerHead
    {
        public string? id { get; set; }
        public string? accname { get; set; }

    }
    public class CustomView
    {
        public string? Title { get; set; }
        public int Id { get; set; }
        public string? Data { get; set; }
        public string? Type { get; set; }
        public string? Timepreriod { get; set; }
        public string? selectColums { get; set; }
        public string? Groupby { get; set; }
        public string? StockCaption { get; set; }
        public int? CaptionValue { get; set; }       
        public int? LuserId { get; set; }       
        public bool? IsPublic { get; set; }       
    }
}
