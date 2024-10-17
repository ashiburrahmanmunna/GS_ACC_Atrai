using Atrai.Model.Core.Entity.Base;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atrai.Model.Core.Entity
{
    [Table("DyDashBoard")]
    public class DyDashBoardModel : BaseModel
    {
        [StringLength(100)]
        [Display(Name = "Type")]
        public string? Type { get; set; }

        [StringLength(100)]
        [Display(Name = "ChartType")]
        public string? ChartType { get; set; }

        [StringLength(100)]
        [Display(Name = "ChartTitle")]
        public string? ChartTitle { get; set; }
        [StringLength(100)]
        [Display(Name = "Grouptitle")]
        public string? Grouptitle { get; set; }
        [StringLength(100)]
        [Display(Name = "GroupBy")]
        public string? GroupBy { get; set; }

        [StringLength(100)]
        [Display(Name = "GroupFilterValue")]
        public string? GroupFilterValue { get; set; }
        [StringLength(100)]
        [Display(Name = "AdditionalFilterTitle")]
        public string? AdditionalFilterTitle { get; set; }
        [StringLength(100)]
        [Display(Name = "AdditionalFilter")]
        public string? AdditionalFilter { get; set; }

        [StringLength(100)]
        [Display(Name = "AdditionalFilterValue")]
        public string? AdditionalFilterValue { get; set; }
        [StringLength(100)]
        [Display(Name = "TimePriod")]
        public string? TimePriod { get; set; }

        [StringLength(100)]
        [Display(Name = "TimePriodValue")]
        public string? TimePriodValue { get; set; }
        public string? StockCaption { get; set; }
        public int? CaptionValue { get; set; }
        public bool? IsPublic { get; set; }
        public int Oder { get; set; }
        public bool Isvisible { get; set; } = true;
        public bool IsSystem { get; set; } = false;
    }
    public class DashBoardLayoutOrder : BaseModel
    {
        public int DashId { get; set; }
        public int Order { get; set; }

    }
}
