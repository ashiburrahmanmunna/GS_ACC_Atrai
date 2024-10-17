using Atrai.Model.Core.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atrai.Model.Core.Entity
{

    [Table("DeliveryServiceWeight")]
    public class DeliveryServiceWeightModel : BaseModel
    {
        [Required]
        [StringLength(30)]
        [Display(Name = "Weight")]

        public string? WeightName { get; set; }

        [Display(Name = "Description")]
        [StringLength(50)]
        public string? WeightDescription { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal FigureForCalculation { get; set; }

        public bool isInActive { get; set; }
    }


    [Table("DeliveryServiceDistance")]
    public class DeliveryServiceDistanceModel : BaseModel
    {
        [Required]
        [StringLength(30)]
        [Display(Name = "Distance")]

        public string? DistanceName { get; set; }

        [Display(Name = "Description")]
        [StringLength(50)]
        public string? DistanceDescription { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal FigureForCalculation { get; set; }

        public bool isInActive { get; set; }
    }

    [Table("DeliveryServiceTiming")]
    public class DeliveryServiceTimingModel : BaseModel
    {
        [Required]
        [StringLength(30)]
        [Display(Name = "Timing")]

        public string? TimingName { get; set; }

        [Display(Name = "Description")]
        [StringLength(50)]
        public string? TimingDescription { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal FigureForCalculation { get; set; }

        public bool isInActive { get; set; }
    }


    [Table("DeliveryService")]
    public class DeliveryServiceModel : BaseModel
    {


        [Display(Name = "Invoice / Bill No")]
        [StringLength(20)]
        public string? BillNo { get; set; }


        //[Required]
        [Display(Name = "User Name")]
        [ForeignKey("CustomerList")]
        public int? CustomerId { get; set; }
        [Display(Name = "User Name")]
        public virtual CustomerModel? CustomerList { get; set; }



        [Display(Name = "PhoneNo")]
        [StringLength(20)]
        public string? PhoneNo { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Pickup Point")]
        [StringLength(200)]
        public string? PickupPoint { get; set; }


        [Display(Name = "Product Category")]
        [ForeignKey("CategoryList")]
        public int? CategoryId { get; set; }
        [Display(Name = "Category")]
        public virtual CategoryModel? CategoryList { get; set; }


        [Display(Name = "Weight")]
        [ForeignKey("WeightList")]
        public int? WeightId { get; set; }
        [Display(Name = "Weight")]
        public virtual DeliveryServiceWeightModel WeightList { get; set; }



        [Display(Name = "Distance")]
        [ForeignKey("DistanceList")]
        public int? DistanceId { get; set; }
        [Display(Name = "Distance")]
        public virtual DeliveryServiceDistanceModel DistanceList { get; set; }


        [Display(Name = "Payment Type")]
        [ForeignKey("PaymentTypeList")]
        public int? PaymentTypeId { get; set; }
        [Display(Name = "Payment Type")]
        public virtual PaymentTypeModel? PaymentTypeList { get; set; }


        /// <summary>
        /// ///Delivery Point
        /// </summary>


        [Display(Name = "Delivery Client Phone No")]
        [StringLength(200)]
        public string? DeliveryClientPhoneNo { get; set; }


        [Display(Name = "Delivery Client Name")]
        [StringLength(200)]
        public string? DeliveryClientName { get; set; }


        [Display(Name = "Delivery Client Address")]
        [StringLength(200)]
        [DataType(DataType.MultilineText)]

        public string? DeliveryClientAddress { get; set; }


        [Required]
        [Display(Name = "Preferable Date and Time")]
        [DataType(DataType.DateTime)]
        //[DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        //[DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "datetime2")]
        public DateTime PreferableDateTime { get; set; }



        [Display(Name = "Delivery Period / Time")]
        [ForeignKey("DeliveryTiming")]
        public int? DeliveryTimingId { get; set; }
        [Display(Name = "Delivery Period")]
        public virtual DeliveryServiceTimingModel DeliveryTiming { get; set; }



        [Required]
        [Display(Name = "Billed Date")]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "datetime2")]
        public DateTime BilledDate { get; set; }





        [DataType(DataType.MultilineText)]

        [Display(Name = "Note / Remarks")]
        public string? Note { get; set; }


        [Display(Name = "Bill Amount")]
        public float BillAmount { get; set; }

        [Display(Name = "Received Amount")]
        public float ReceivedAmount { get; set; }


        [Display(Name = "Discount")]
        public float Discount { get; set; }



        [NotMapped]
        [Display(Name = "Balance")]
        public float Balance { get; set; }


        [Display(Name = "Is Post")]
        public bool isPost { get; set; }

        [Display(Name = "Is System")]
        public bool isSystem { get; set; }


        [Display(Name = "In Word")]
        [StringLength(300)]
        public string? InWords { get; set; }


        //[Display(Name = "Received By")]
        //[ForeignKey("AccountReceiveByHead")]
        //public int? AccountReceiveHeadId { get; set; }
        //[Display(Name = "Received Head")]
        //public virtual AccountHeadModel? AccountReceiveByHead { get; set; }


        public virtual ICollection<DeliveryServiceCommentModel> DeliveryServiceComment { get; set; }

    }





    [Table("DeliveryServiceComment")]
    public class DeliveryServiceCommentModel : BaseModel
    {


        [Display(Name = "Comment To User / Assaigned To")]
        [ForeignKey("CommentToUserList")]
        public int? CommentToLuserId { get; set; }
        [Display(Name = "Comment To User / Assaigned To")]
        public virtual UserAccountModel? CommentToUserList { get; set; }


        [DisplayName("Delivery Service")]
        [ForeignKey("DeliveryServiceList")]
        public int DeliveryServiceId { get; set; }
        [DisplayName("Delivery Service")]
        public DeliveryServiceCommentModel DeliveryServiceList { get; set; }




        [StringLength(200)]
        [Display(Name = "Comment")]
        [DataType(DataType.MultilineText)]
        public string? Comment { get; set; }



        //public virtual ICollection<InvoiceBillModel> InvoiceBill { get; set; }
    }

    //[Table("PaymentType")]
    //public class DeliveryServicePaymentTypeModel : BaseModel
    //{
    //    [Required]
    //    [StringLength(30)]
    //    [Display(Name = "Payment Type")]

    //    public string? PaymentTypeName { get; set; }

    //    [Display(Name = "Description")]
    //    [StringLength(50)]
    //    public string? PaymentTypeDescription { get; set; }


    //    public bool isInActive { get; set; }
    //}

}
