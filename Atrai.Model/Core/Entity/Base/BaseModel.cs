using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atrai.Model.Core.Entity.Base
{
    public class BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }



        [Column(TypeName = "datetime2")]
        //[JsonIgnore]
        public DateTime CreateDate { get; set; }




        [Column(TypeName = "datetime2")]
        //[JsonIgnore]
        public DateTime UpdateDate { get; set; }


        //[JsonIgnore]
        public bool IsDelete { get; set; }



        //[JsonIgnore]
        [ForeignKey("CompanyList")]

        public int ComId { get; set; }



        //[JsonIgnore]
        [Display(Name = "Company")]
        public virtual CompanyModel? CompanyList { get; set; }

        //[JsonIgnore]
        [ForeignKey("UserAccountList")]
        public int LuserId { get; set; }


        //[JsonIgnore]
        [Display(Name = "User Account")]
        public virtual UserAccountModel? UserAccountList { get; set; }



        //[JsonIgnore]
        public int? LuserIdUpdate { get; set; }


        //[ForeignKey("CompanyList")]

        //public int ComId { get; set; }
        //[Display(Name = "User Company")]
        //public virtual CompanyModel CompanyList { get; set; }
    }

    //public abstract class RecursiveModel<TEntity> : BaseModel//, IRecursiveEntity<TEntity>
    //where TEntity : RecursiveModel<TEntity>
    //{
    //    public virtual TEntity Parent { get; set; }
    //    public ICollection<TEntity> Children { get; set; }
    //}
}
