using Atrai.Model.Core.Entity.Base;

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atrai.Model.Core.Entity
{
    public class CompanyCurrencyModel:BaseModel
    {
        //public string? CurrencyName { get; set; }
        [Display(Name = "Currency")]
        public virtual CountryModel? Currency { get; set; }
        [Display(Name = "Currency")]
        [ForeignKey("Currency")]
        public int CurrencyId { get; set; }
        public string? CurrencyRate { get; set; } = string.Empty;

        [DisplayName("As Of")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "datetime2")]
        public DateTime? AsOf { get; set; }
    }
}
