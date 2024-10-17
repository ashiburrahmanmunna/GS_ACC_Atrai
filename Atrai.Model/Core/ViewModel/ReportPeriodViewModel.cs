using System;
using System.ComponentModel.DataAnnotations;

namespace Atrai.Model.Core.ViewModel
{
    public class ReportPeriodViewModel
    {
        [Required]
        public DateTime From { get; set; }
        [Required]
        public DateTime To { get; set; }
    }


    public class JobCardVM
    {
        public string? Criteria { get; set; }
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
        public string? DeptId { get; set; }
        public string? DesigId { get; set; }
        public string? SectId { get; set; }
        public string? SubSectionId { get; set; }
        public string? EmpId { get; set; }
        public string? EmpTypeId { get; set; }
        public string? EmpName { get; set; }
        public string? UnitId { get; set; }
        public string? ShiftId { get; set; }
        public string? FloorId { get; set; }
        public string? LineId { get; set; }
        public string? LId { get; set; }
        public string? ReportName { get; set; }
        public string? ReportType { get; set; }
        public string? ReportFormat { get; set; }
        public string? Format { get; set; }

        public JobCardGrid JobCardGrid { get; set; }

    }
    public class JobCardGrid
    {
        public string? Criteria { get; set; }
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
        public string? DeptId { get; set; }
        public string? DesigId { get; set; }
        public string? SectId { get; set; }
        public string? SubSectionId { get; set; }
        public string? EmpId { get; set; }
        public string? EmpTypeId { get; set; }
        public string? EmpName { get; set; }
        public string? UnitId { get; set; }
        public string? ShiftId { get; set; }
        public string? FloorId { get; set; }
        public string? LineId { get; set; }
        public string? LId { get; set; }
        public string? ReportName { get; set; }
        public string? ReportType { get; set; }
        public string? ReportFormat { get; set; }
        public string? Format { get; set; }
    }
}
