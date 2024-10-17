using Atrai.Model.Core.Entity.Base;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atrai.Model.Core.Entity
{
    [Table("Colors")]
    public class ColorsModel:BaseModel
    {
        [StringLength(100)]
        public string? ColorName { get; set; }
        [StringLength(80)]
        public string? ColorCode { get; set; }
        [StringLength(300)]
        public string? ColorDesc { get; set; }

        [Display(Name = "Image [Folder]")]
        public string? FilePath { get; set; }
        public string? ColorsFilePath { get; set; }

    }
}
