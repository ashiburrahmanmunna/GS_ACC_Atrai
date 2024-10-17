namespace Atrai.Model.Core.ViewModel
{
    public class ReportrequestDto
    {
        public string? ReportName { get; set; }
        public string? Type { get; set; }
        public string? Value { get; set; }
        public int Id { get; set; }
        public int ParentId { get; set; }
    }
}
