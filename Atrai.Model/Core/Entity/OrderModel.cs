using Atrai.Model.Core.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atrai.Model.Core.Entity
{
    [Table("Orders")]
    public class OrdersModel : BaseModel
    {

        [Required]
        [DisplayName("Orders Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "datetime2")]
        public DateTime OrdersDate { get; set; }
        [DisplayName("Orders Doc No")]


        //[Column(TypeName = "varchar(50)")]
        [StringLength(40)]
        public string? OrderCode { get; set; }
        [StringLength(200)]

        public string? Notes { get; set; }

        [StringLength(20)]
        public string? Status { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal GrandTotal { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public double DisPer { get; set; }
        [Display(Name = "Dis. Amount")]

        [Column(TypeName = "decimal(18,4)")]
        public decimal DisAmt { get; set; }

        [Display(Name = "Service Charge")]
        [DisplayFormat(DataFormatString = "{0:#,#.00}")]

        [Column(TypeName = "decimal(18,4)")]
        public decimal ServiceCharge { get; set; }

        [Display(Name = "Shipping")]

        [Column(TypeName = "decimal(18,4)")]
        public decimal Shipping { get; set; }

        [Display(Name = "Total Vat ")]

        [Column(TypeName = "decimal(18,4)")]
        public decimal TotalVat { get; set; }


        [Display(Name = "Net Amount")]

        [Column(TypeName = "decimal(18,4)")]
        public decimal NetAmount { get; set; }
        //[Display(Name = "Paid Amount")]


        //[Column(TypeName = "decimal(18,2)")]
        //public decimal PaidAmt { get; set; }
        //[Display(Name = "Due Amount")]


        //[Column(TypeName = "decimal(18,2)")]
        //public decimal DueAmt { get; set; }


        [DisplayName("CustomerId")]
        [ForeignKey("CustomerModel")]
        public int? CustomerId { get; set; }
        public CustomerModel? CustomerModel { get; set; }
        [StringLength(100)]

        [Display(Name = "Customer Name")]
        public string? CustomerName { get; set; }
        [StringLength(200)]

        //[Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Primary Address")]
        public string? PrimaryAddress { get; set; }

        [StringLength(200)]

        //[Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Secoundary Address")]
        public string? SecoundaryAddress { get; set; }

        [Phone]
        [DisplayName("Phone No")]
        [StringLength(30)]

        public string? PhoneNo { get; set; }

        [StringLength(20)]

        [DisplayName("Postal Code")]
        public string? PostalCode { get; set; }


        [StringLength(50)]

        [DisplayName("Email")]
        public string? EmailId { get; set; }


        public bool isPosted { get; set; }

        public ICollection<OrdersItemsModel> Items { get; set; }
        public ICollection<OrdersPaymentModel> OrdersPayments { get; set; }


        public OrdersModel()
        {
            Items = new List<OrdersItemsModel>();
            OrdersPayments = new List<OrdersPaymentModel>();
        }

    }


    [Table("OrdersItems")]
    public class OrdersItemsModel : BaseModel
    {
        [DisplayName("ProductId")]
        [ForeignKey("ProductModel")]
        public int ProductId { get; set; }
        public virtual ProductModel? Product { get; set; }

        [Column(TypeName = "decimal(18,4)")]

        public decimal Price { get; set; }
        [Column(TypeName = "decimal(18,4)")]

        public decimal Quantity { get; set; }
        [Column(TypeName = "decimal(18,4)")]

        public decimal Amount { get; set; }

        [DisplayName("Order")]
        [ForeignKey("OrdersModel")]
        public int OrdersId { get; set; }
        public OrdersModel OrdersModel { get; set; }
    }


    [Table("OrdersPayment")]
    public class OrdersPaymentModel : BaseModel
    {
        public int OrdersId { get; set; }

        [StringLength(100)]
        public string? PaymentCardNo { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Amount { get; set; }

        public int? RowNo { get; set; }

        [ForeignKey("OrdersId")]
        public virtual OrdersModel OrdersMain { get; set; }
    }

}
