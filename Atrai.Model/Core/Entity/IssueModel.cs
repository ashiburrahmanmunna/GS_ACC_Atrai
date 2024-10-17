using Atrai.Model.Core.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atrai.Model.Core.Entity
{
    [Table("Issue")]
    public class IssueModel : BaseModel
    {
        [Required]
        [DisplayName("Issue Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "datetime2")]
        public DateTime IssueDate { get; set; }
        [DisplayName("Issue Doc No")]

        [StringLength(40)]
        public string? IssueCode { get; set; }
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


        public ICollection<IssueItemsModel> Items { get; set; }
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


        [Column(TypeName = "decimal(18,4)")]
        public decimal GrandTotal { get; set; }

        public IssueModel()
        {
            Items = new List<IssueItemsModel>();
            CostCalculations = new List<CostCalculatedModel>();

        }



    }


    [Table("IssueItems")]
    public class IssueItemsModel : BaseModel
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
        [StringLength(200)]

        public string? Description { get; set; }


        [DisplayName("Issue")]
        [ForeignKey("IssueModel")]
        public int IssueId { get; set; }
        public IssueModel IssueModel { get; set; }

        [Display(Name = "Store Location")]
        public int? WarehouseId { get; set; }

        [ForeignKey("WarehouseId")]

        public virtual WarehouseModel? vWarehouse { get; set; }


        [NotMapped]
        public string[]? SerialItemArray { get; set; }

        public string? SerialItem { get; set; }
        [NotMapped]
        public bool IsTransaction { get; set; }

        public ICollection<IssueBatchItemsModel> BatchSerialItems { get; set; }


    }



    [Table("IssueBatchItems")]
    public class IssueBatchItemsModel : BaseModel
    {

        [DisplayName("Issue Items")]
        [ForeignKey("IssueItems")]
        public int IssueItemId { get; set; }
        public virtual IssueItemsModel IssueItems { get; set; }


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








    public class AdvanceTrasactionTrackingModel : BaseModel
    {
        public int Duration { get; set; }

        [DisplayName("SalesId")]
        [ForeignKey("Sales")]
        public int? SalesId { get; set; }
        public virtual SalesModel? Sales { get; set; }

        [DisplayName("PurchaseId")]
        [ForeignKey("Purchase")]
        public int? PurchaseId { get; set; }
        public virtual PurchaseModel? Purchase { get; set; }

        [StringLength(10)]
        public string? OccuringDate { get; set; }
        public int Occurence { get; set; }
        public DateTime? StartDate { get; set; }

        [ForeignKey("AccountHead")]
        public int? ExpenseHeadId { get; set; }
        public virtual AccountHeadModel? AccountHead { get; set; }
    }

    public class AdvanceTrasactionTrackingModelVM 
    {
        public int Id { get; set; }
        public int Duration { get; set; }
        public int? SalesId { get; set; }
        public int? PurchaseId { get; set; }
        public int? ExpenseHeadId { get; set; }
        public string? OccuringDate { get; set; }
        public int Occurence { get; set; }
        public DateTime? StartDate { get; set; }
    }



}
