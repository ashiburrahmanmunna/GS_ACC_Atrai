using Atrai.Model.Core.Entity.Base;

using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atrai.Model.Core.Entity
{

    [Table("Acc_BudgetMain")]
    public class Acc_BudgetMainModel : BaseModel
    {

        [StringLength(200)]
        public string? Name { get; set; }

        [Display(Name = "Fiscal Year")]
        public int? FiscalYearId { get; set; }
        [ForeignKey("FiscalYearId")]
        public virtual Acc_FiscalYearModel? Acc_FiscalYears { get; set; }

        [Display(Name = "Interval")]
        public string? Interval { get; set; }

        [Display(Name = "Pre Fill")]
        public int? PreFillId { get; set; }
        [ForeignKey("PreFillId")]
        public virtual Acc_FiscalYearModel? PreFills { get; set; }
        public ICollection<BudgetSubModel>? BudgetSubs { get; set; }
    }



    [Table("Acc_BudgetSub")]
    public class BudgetSubModel : BaseModel
    {
        [DisplayName("Budget")]
        [ForeignKey("Acc_BudgetMainModel")]
        public int? BudgetId { get; set; }
        public Acc_BudgetMainModel? Acc_BudgetMainModel { get; set; }
        public int AccId { get; set; }
        [ForeignKey("AccId")]
        public virtual AccountHeadModel? Acc_ChartOfAccount { get; set; }

        [NotMapped]
        public string? AccType { get; set; }
        public decimal Jan { get; set; }
        public decimal Feb { get; set; }
        public decimal Mar { get; set; }
        public decimal April { get; set; }
        public decimal May { get; set; }
        public decimal Jun { get; set; }
        public decimal Jul { get; set; }
        public decimal Aug { get; set; }
        public decimal Sep { get; set; }
        public decimal Oct { get; set; }
        public decimal Nov { get; set; }
        public decimal Dec { get; set; }
        public decimal Total { get; set; }
        public decimal Quarter1 { get; set; }
        public decimal Quarter2 { get; set; }
        public decimal Quarter3 { get; set; }
        public decimal Quarter4 { get; set; }
        public decimal Yearly { get; set; }

    }

}
