using Atrai.Model.Core.Entity.Base;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atrai.Model.Core.Entity
{
    [Table("Sizes")]
    public class SizesModel : BaseModel
    {
        [StringLength(100)]
        public string? SizeName { get; set; }
        [StringLength(100)]
        public string? SizeCode { get; set; }
        [StringLength(300)]
        public string? SizeDesc { get; set; }

    }
}
