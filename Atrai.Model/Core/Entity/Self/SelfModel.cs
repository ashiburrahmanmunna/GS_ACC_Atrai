using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atrai.Model.Core.Entity.Self
{
    public class SelfModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }



        [JsonIgnore]
        [Column(TypeName = "datetime2")]
        public DateTime CreateDate { get; set; }



        [JsonIgnore]
        [Column(TypeName = "datetime2")]
        public DateTime UpdateDate { get; set; }



        [JsonIgnore]
        public bool IsDelete { get; set; }

    }
}
