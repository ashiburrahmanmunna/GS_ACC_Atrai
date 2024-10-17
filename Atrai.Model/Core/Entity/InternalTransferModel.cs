using Atrai.Model.Core.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atrai.Model.Core.Entity
{
    [Table("InternalTransfer")]
    public class InternalTransferModel : BaseModel
    {
        [Required]
        [DisplayName("InternalTransfer Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "datetime2")]
        public DateTime InternalTransferDate { get; set; }
        [DisplayName("InternalTransfer Doc No")]

        [StringLength(40)]
        public string? InternalTransferCode { get; set; }
        [StringLength(200)]

        public string? Notes { get; set; }


        [StringLength(200)]

        [DataType(DataType.MultilineText)]
        public string? Remarks { get; set; }


        [StringLength(100)]

        [Display(Name = "Referance One")]
        public string? ReferanceOne { get; set; }
        [StringLength(200)]

        //[Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Referance Two")]
        public string? ReferanceTwo { get; set; }

        public bool isPosted { get; set; }


        [Display(Name = "Store Location")]
        public int? WarehouseIdMain { get; set; }
        [ForeignKey("WarehouseIdMain")]
        public virtual WarehouseModel? Warehouses { get; set; }


        public ICollection<InternalTransferItemsModel> Items { get; set; }
        public virtual ICollection<CostCalculatedModel> CostCalculations { get; set; }

        [NotMapped]
        [DataType(DataType.Text)]
        [Display(Name = "UserId")]
        public string? UserId { get; set; }



        [Display(Name = "User Name")]
        [ForeignKey("InternetUserList")]
        public int? InternetUserId { get; set; }
        [Display(Name = "Internet User")]
        public virtual InternetUserModel? InternetUserList { get; set; }


        public InternalTransferModel()
        {
            Items = new List<InternalTransferItemsModel>();
            CostCalculations = new List<CostCalculatedModel>();

        }



    }


    [Table("InternalTransferItems")]
    public class InternalTransferItemsModel : BaseModel
    {
        [DisplayName("ProductId")]
        [ForeignKey("ProductModel")]
        public int ProductId { get; set; }
        public virtual ProductModel? Product { get; set; }
        [StringLength(200)]

        public string? Name { get; set; }

        [Required]
        public double Price { get; set; }


        public double AvgCostPrice { get; set; }


        [Required]
        public double Quantity { get; set; }
        [Required]
        public double Amount { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(300)]

        public string? Description { get; set; }


        [DisplayName("InternalTransfer")]
        [ForeignKey("InternalTransferModel")]
        public int InternalTransferId { get; set; }
        public InternalTransferModel InternalTransferModel { get; set; }

        [Display(Name = "From Store Location")]
        public int? FromWarehouseId { get; set; }
        [ForeignKey("FromWarehouseId")]
        public virtual WarehouseModel? FromWarehouse { get; set; }


        [Display(Name = "To Store Location")]
        public int? ToWarehouseId { get; set; }
        [ForeignKey("ToWarehouseId")]
        public virtual WarehouseModel? ToWarehouse { get; set; }



        [NotMapped]
        public string[]? SerialItemArray { get; set; }

        public string? SerialItem { get; set; }
        [NotMapped]
        public bool IsTransaction { get; set; }

        public ICollection<InternalTransferBatchItemsModel> BatchSerialItems { get; set; }


    }



    [Table("InternalTransferBatchItems")]
    public class InternalTransferBatchItemsModel : BaseModel
    {

        [DisplayName("InternalTransfer Items")]
        [ForeignKey("InternalTransferItems")]
        public int InternalTransferItemId { get; set; }
        public virtual InternalTransferItemsModel InternalTransferItems { get; set; }


        [DisplayName("Product Name")]
        [ForeignKey("Products")]
        public int ProductId { get; set; }
        public virtual ProductModel? Products { get; set; }



        [DisplayName("Batch Serial No")]
        [ForeignKey("PurchaseBatchItems")]
        public int PurchaseBatchId { get; set; }
        public virtual PurchaseBatchItemsModel? PurchaseBatchItems { get; set; }

        [Required]
        [StringLength(20)]
        public string? BatchSerialNo { get; set; }

        public bool IsUsed { get; set; }
        [NotMapped]
        public bool IsTransaction { get; set; }




    }


}
