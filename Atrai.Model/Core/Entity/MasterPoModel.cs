using Atrai.Model.Core.Entity.Base;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atrai.Model.Core.Entity
{
    [Table("MasterPO_Master")]
    public class MasterPOModel : BaseModel
    {
        [DisplayName("Master Po No")]

        [StringLength(100)]
        public string? MasterPONo { get; set; }

        public ICollection<MasterPODetailsModel> MasterPODetails { get; set; }

        public double TotalQty { get; set; }

        public DateTime? MasterPODate { get; set; }

    }
    [Table("MasterPO_Details")]
    public class MasterPODetailsModel : BaseModel
    {
        [DisplayName("Master PO")]
        [ForeignKey("MasterPO")]
        public int MasterPOId { get; set; }
        public virtual MasterPOModel? MasterPO { get; set; }


        [DisplayName("Buyer PO Id")]
        [ForeignKey("BuyerPO_Master")]
        public int BuyerPOId { get; set; }
        public virtual BuyerPO_MasterModel? BuyerPO_Master { get; set; }

        public double Qty { get; set; }

    }
}
