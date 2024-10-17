using Atrai.Model.Core.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atrai.Model.Core.Entity
{

    [Table("ProductLedger")]
    public class ProductLedgerModel : BaseModel
    {

        [NotMapped]
        [DataType(DataType.Text)]
        [Display(Name = "UserId")]
        public string? UserId { get; set; }

        [Required]
        [NotMapped]
        [DataType(DataType.Text)]
        [Display(Name = "UserName")]
        public string? UserName { get; set; }


        [Display(Name = "User Name")]
        [ForeignKey("InternetUserList")]
        public int? InternetUserId { get; set; }
        [Display(Name = "Internet User")]
        public virtual InternetUserModel? InternetUserList { get; set; }






        //[Required]
        [NotMapped]
        [DataType(DataType.Text)]
        [Display(Name = "Product Name")]
        public string? ProductName { get; set; }




        [Display(Name = "Product Id")]
        [ForeignKey("ProductList")]
        public int? ProductId { get; set; }
        [Display(Name = "Product Id")]
        public virtual ProductModel? ProductList { get; set; }

        [StringLength(200)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string? PrdDescription { get; set; }



        [Required]
        [Display(Name = "Entry Date")]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "datetime2")]
        public DateTime EntryDate { get; set; }


        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Ticket Id")]
        public string? TicketId { get; set; }


        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "TeamType")]
        public string? TeamType { get; set; }



        [Display(Name = "Quantity")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Quantity { get; set; }


        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 0)]
        [DataType(DataType.Text)]
        [Display(Name = "Subject")]
        public string? Subject { get; set; }



        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 0)]
        [DataType(DataType.Text)]
        [Display(Name = "Referance")]
        public string? Referance { get; set; }



        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 0)]
        [DataType(DataType.Text)]
        [Display(Name = "Received By")]
        public string? ReceivedBy { get; set; }



        //[Required]
        [StringLength(200, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 0)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Comment")]
        public string? Comment { get; set; }

    }



    [Table("ToDo")]
    public class ToDoModel : BaseModel
    {


        [Required]
        [Display(Name = "Entry Date")]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "datetime2")]
        public DateTime EntryDate { get; set; }


        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 0)]
        [DataType(DataType.Text)]
        [Display(Name = "Subject")]
        public string? Subject { get; set; }


        [StringLength(200)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string? Description { get; set; }




        [NotMapped]
        [DataType(DataType.Text)]
        [Display(Name = "UserId")]
        public string? UserId { get; set; }

        [Required]
        [NotMapped]
        [DataType(DataType.Text)]
        [Display(Name = "UserName")]
        public string? UserName { get; set; }


        [Display(Name = "User Name")]
        [ForeignKey("InternetUserList")]
        public int? InternetUserId { get; set; }
        [Display(Name = "Internet User")]
        public virtual InternetUserModel? InternetUserList { get; set; }



        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Ticket Id")]
        public string? TicketId { get; set; }




        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Staff Comment")]
        public string? StaffComment { get; set; }





        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 0)]
        [DataType(DataType.Text)]
        [Display(Name = "Assaign Fusion Team")]
        public string? AssaignFusionTeam { get; set; }



        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 0)]
        [DataType(DataType.Text)]
        [Display(Name = "Status")]
        public string? Status { get; set; }



        //[Required]
        [StringLength(200, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 0)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Comment (Mgr.)")]
        public string? Comment { get; set; }

    }



    [Table("TestRouterOnuTracking")]
    public class TestRouterOnuTrackingModel : BaseModel
    {

        [Required]
        [Display(Name = "Entry Date")]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "datetime2")]
        public DateTime EntryDate { get; set; }





        //[Required]
        [NotMapped]
        [DataType(DataType.Text)]
        [Display(Name = "Product Name")]
        public string? ProductName { get; set; }




        [Display(Name = "Product Id")]
        [ForeignKey("ProductList")]
        public int? ProductId { get; set; }
        [Display(Name = "Product Id")]
        public virtual ProductModel? ProductList { get; set; }

        [StringLength(200)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string? PrdDescription { get; set; }


        [StringLength(200)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "MAC Serial")]
        public string? MacSerial { get; set; }


        [NotMapped]
        [DataType(DataType.Text)]
        [Display(Name = "User Id")]
        public string? UserId { get; set; }

        [Required]
        [NotMapped]
        [DataType(DataType.Text)]
        [Display(Name = "User Name")]
        public string? UserName { get; set; }


        [Display(Name = "User Name")]
        [ForeignKey("InternetUserList")]
        public int? InternetUserId { get; set; }
        [Display(Name = "Internet User")]
        public virtual InternetUserModel? InternetUserList { get; set; }




        [Required]
        [Display(Name = "Withdrawn Date")]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "datetime2")]
        public DateTime WithdrawnDate { get; set; }


        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Status")]
        public string? Status { get; set; }



        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 0)]
        [DataType(DataType.Text)]
        [Display(Name = "Given By")]
        public string? GivenBy { get; set; }



        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 0)]
        [DataType(DataType.Text)]
        [Display(Name = "Withdrawn By")]
        public string? WithdrawnBy { get; set; }



        //[Required]
        [StringLength(200, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 0)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Note")]
        public string? Note { get; set; }

    }


    [Table("InvoiceBill")]
    public class InvoiceBillModel : BaseModel
    {
        [Display(Name = "Invoice / Bill No")]
        [StringLength(20)]
        public string? BillNo { get; set; }
        [Required]

        [Display(Name = "User Id")]
        [StringLength(50)]
        public string? UserId { get; set; }
        [Required]

        [Display(Name = "User Name")]
        [StringLength(50)]
        public string? UserName { get; set; }


        [Required]
        [Display(Name = "Billed Date")]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "datetime2")]
        public DateTime BilledDate { get; set; }

        [Display(Name = "Next Follow Date")]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "datetime2")]
        public DateTime? NextFollowDate { get; set; }


        [Required]
        [Display(Name = "Expiration Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]

        [Column(TypeName = "datetime2")]
        public DateTime? ExpiredDate { get; set; }


        [Display(Name = "Received Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]

        [Column(TypeName = "datetime2")]
        public DateTime? ReceivedDate { get; set; }


        [Display(Name = "Description")]
        public string? Description { get; set; }


        [Display(Name = "Bill Amount")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal BillAmount { get; set; }

        [Display(Name = "Received Amount")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal ReceivedAmount { get; set; }


        [Display(Name = "Discount")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Discount { get; set; }


        [Display(Name = "BadDebt")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal BadDebt { get; set; }


        [NotMapped]
        [Display(Name = "Balance")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Balance { get; set; }


        [Display(Name = "Is Post")]
        public bool isPost { get; set; }

        [Display(Name = "Is System")]
        public bool isSystem { get; set; }


        [Display(Name = "In Word")]
        [StringLength(300)]
        public string? InWords { get; set; }


        [Display(Name = "Received By")]
        [ForeignKey("AccountReceiveByHead")]
        public int? AccountReceiveHeadId { get; set; }
        [Display(Name = "Received Head")]
        public virtual AccountHeadModel? AccountReceiveByHead { get; set; }



        //[Required]
        [Display(Name = "Apps User Id")]
        [ForeignKey("InternetUserList")]
        public int? InternetUserId { get; set; }
        [Display(Name = "Internet User")]
        public virtual InternetUserModel? InternetUserList { get; set; }

    }


    [Table("InternetUser")]
    public class InternetUserModel : BaseModel
    {
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        //[Required]

        [Display(Name = "USERID (PPOE)")]
        [StringLength(50)]
        public string? UserId { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [StringLength(20)]
        public string? Password { get; set; }


        [Display(Name = "User Name")]
        [StringLength(100)]
        public string? UserName { get; set; }

        [Display(Name = "User Type")]
        [StringLength(20)]
        public string? UserType { get; set; }


        [Required]
        [Display(Name = "LastBilled Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "datetime2")]
        public DateTime LastBilledDate { get; set; }


        //[Required]
        [Display(Name = "Expiration Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "datetime2")]
        public DateTime? LastExpiredDate { get; set; }


        [Display(Name = "Last Received Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "datetime2")]
        public DateTime? LastReceivedDate { get; set; }


        [StringLength(50)]

        [DataType(DataType.PhoneNumber)]

        [Display(Name = "MobileNo")]
        public string? MobileNo { get; set; }

        [StringLength(150)]


        [DataType(DataType.MultilineText)]
        [Display(Name = "Address")]
        public string? Address { get; set; }
        [Column(TypeName = "decimal(18,4)")]

        [Display(Name = "Amount")]
        public decimal Amount { get; set; }

        [StringLength(50)]

        [Display(Name = "ONU Mac")]
        public string? ONUMac { get; set; }

        [Display(Name = "IP Address")]
        [StringLength(120)]

        public string? IPAddress { get; set; }

        [StringLength(120)]

        [Display(Name = "Connection Point Address")]
        public string? ConnectionPointAddress { get; set; }

        [StringLength(200)]

        [Display(Name = "Description")]
        public string? Description { get; set; }


        [Column(TypeName = "decimal(18,4)")]
        [Display(Name = "TotalDue")]
        public decimal TotalDue { get; set; }


        [Display(Name = "Paid Status")]
        public string? PaidStatus { get; set; }



        [Required]
        [Display(Name = "Created On")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "datetime2")]
        public DateTime CreatedOn { get; set; }


        [Display(Name = "Created By")]
        public string? CreatedBy { get; set; }


        [StringLength(30)]
        [Display(Name = "National ID Card")]
        public string? NationalIdCard { get; set; }

        [Display(Name = "User Status")]
        [ForeignKey("UserStatus")]
        public int? UserStatusId { get; set; }
        [Display(Name = "User Status")]

        public virtual InternetUserStatusModel UserStatus { get; set; }


        //[Display(Name = "PackageId")]
        //public string? PackageId { get; set; }


        [Display(Name = "Package Name")]
        [ForeignKey("InternetPackageList")]
        public int? PackageId { get; set; }
        [Display(Name = "Internet Package")]
        public virtual InternetPackageModel InternetPackageList { get; set; }


        [Display(Name = "Image [Folder]")]
        [StringLength(200)]

        public string? ImagePath { get; set; }

        [Display(Name = "Files Extension")]
        [StringLength(20)]

        public string? FileExtension { get; set; }


        public virtual ICollection<InvoiceBillModel> InvoiceBill { get; set; }
    }



    [Table("InternetUserStatus")]
    public class InternetUserStatusModel : BaseModel
    {

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        [Display(Name = "Member Status")]
        public string? UserStatusLong { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Member Status Short")]
        public string? UserStatusShort { get; set; }

    }




    [Table("InternetPackage")]
    public class InternetPackageModel : BaseModel
    {

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        [Display(Name = "PackageName")]
        public string? PackageName { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Speed")]
        public string? Speed { get; set; }


        [Required]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        //[DataType(DataType.Text)]
        [Display(Name = "Package Active Day")]
        public int PackageActiveDay { get; set; }

        [Required]
        //[DataType(DataType.Text)]
        [Display(Name = "Package Price")]
        public float PackageAmount { get; set; }


        //[Required]
        [StringLength(200, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Package Description")]
        public string? PackageDescription { get; set; }


        public bool IsActive { get; set; }
    }




    [Table("ExpireDateExtend")]
    public class ExpireDateExtendModel : BaseModel
    {
        [Required]
        [NotMapped]
        [DataType(DataType.Text)]
        [Display(Name = "UserId")]
        public string? UserId { get; set; }

        [Required]
        [NotMapped]
        [DataType(DataType.Text)]
        [Display(Name = "UserName")]
        public string? UserName { get; set; }

        [Required]
        [Display(Name = "User Name")]
        [ForeignKey("InternetUserList")]
        public int InternetUserId { get; set; }
        [Display(Name = "Internet User")]
        public virtual InternetUserModel? InternetUserList { get; set; }


        [Required]
        [Display(Name = "Old Expire Date")]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        //[DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "datetime2")]
        public DateTime OldExpireDate { get; set; }


        [Required]
        [Display(Name = "New Expire Date")]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]

        [Column(TypeName = "datetime2")]
        public DateTime NewExpiredDate { get; set; }



        //[Required]
        [StringLength(200, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Note / Description")]
        public string? Note { get; set; }


        public int TotalDays { get; set; }
    }




    [Table("UserTerminate")]
    public class UserTerminateModel : BaseModel
    {
        [Required]
        [NotMapped]
        [DataType(DataType.Text)]
        [Display(Name = "UserId")]
        public string? UserId { get; set; }

        [Required]
        [NotMapped]
        [DataType(DataType.Text)]
        [Display(Name = "UserName")]
        public string? UserName { get; set; }

        [Required]
        [Display(Name = "User Name")]
        [ForeignKey("InternetUserList")]
        public int InternetUserId { get; set; }
        [Display(Name = "Internet User")]
        public virtual InternetUserModel? InternetUserList { get; set; }



        [Required]
        [Display(Name = "Terminate Date")]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "datetime2")]
        public DateTime TerminateDate { get; set; }


        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Mobile No")]
        public string? MobileNoIfNecessary { get; set; }


        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Device Update")]
        public string? DeviceUpdate { get; set; }



        [Required]
        [Display(Name = "Next Follow Date")]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "datetime2")]
        public DateTime NextFollowDate { get; set; }


        //[Required]
        [StringLength(200, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Note / Description")]
        public string? Note { get; set; }


    }


    [Table("InternetComplain")]
    public class InternetComplainModel : BaseModel
    {
        [Required]
        [StringLength(30)]
        [Display(Name = "Complain")]

        public string? ComplainName { get; set; }
        [Display(Name = "Description")]
        [StringLength(50)]
        public string? Description { get; set; }

        public bool isInActive { get; set; }
    }


    [Table("DiagnosisReport")]
    public class DiagnosisReportModel : BaseModel
    {
        [Required]
        [StringLength(30)]
        [Display(Name = "Diagonosis Report")]

        public string? Name { get; set; }

        [Display(Name = "Description")]
        [StringLength(50)]
        public string? Description { get; set; }

        public bool isInActive { get; set; }
    }



    [Table("ActivationTicket")]
    public class ActivationTicketModel : BaseModel
    {


        [Display(Name = "Ticket No")]
        [StringLength(50)]
        public string? TicketNo { get; set; }

        [Display(Name = "Contact Name")]
        [StringLength(50)]
        public string? ContactName { get; set; }

        [Display(Name = "Contact Number")]
        [StringLength(50)]
        [DataType(DataType.PhoneNumber)]
        public string? ContactNumber { get; set; }

        [Display(Name = "Address")]
        [StringLength(200)]
        [DataType(DataType.MultilineText)]
        public string? Address { get; set; }

        [Display(Name = "Area / Zone")]
        [StringLength(100)]
        public string? AreaZone { get; set; }


        [Required]
        [Display(Name = "Promise Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "datetime2")]
        public DateTime PromiseDate { get; set; }


        [StringLength(150)]
        [Display(Name = "OTC")]
        public string? OTC { get; set; }

        [StringLength(150)]
        [Display(Name = "MRC")]
        public string? MRC { get; set; }







        [Display(Name = "Package Name / Bandwith")]
        [ForeignKey("InternetPackageList")]
        public int? PackageId { get; set; }
        [Display(Name = "Internet Package")]
        public virtual InternetPackageModel InternetPackageList { get; set; }


        [Display(Name = "User Type")]
        [StringLength(20)]
        public string? UserType { get; set; }


        [Display(Name = "Priority")]
        [StringLength(20)]
        public string? Priority { get; set; }




        [Display(Name = "ONU From")]
        [StringLength(120)]
        public string? ONUFrom { get; set; }

        [Display(Name = "Router From")]
        [StringLength(120)]
        public string? ROUTERFrom { get; set; }




        [StringLength(120)]
        [Display(Name = "Referance By")]
        public string? ReferanceBy { get; set; }


        [StringLength(200)]
        [Display(Name = "Note")]
        public string? Note { get; set; }



        [Display(Name = "Fusion Team Member Id")]
        [ForeignKey("FusionTeamAssaign")]
        public int? FusionTeamLUserId { get; set; }
        [Display(Name = "Fusion Team Member Id")]
        public virtual UserAccountModel? FusionTeamAssaign { get; set; }



        [Display(Name = "Activated by User")]
        [ForeignKey("ActivatedbyUser")]
        public int? ActivatedbyLUserId { get; set; }
        [Display(Name = "Activated by User")]
        public virtual UserAccountModel? ActivatedbyUser { get; set; }

        //[StringLength(100)]
        //[Display(Name = "Fusion Team Assaign:")]
        //public string? FusionTeamAssaign { get; set; }

        //[StringLength(100)]
        //[Display(Name = "Activated by:")]
        //public string? Activatedby { get; set; }


        //public virtual ICollection<InvoiceBillModel> InvoiceBill { get; set; }
    }



    [Table("TroubleTicket")]
    public class TroubleTicketModel : BaseModel
    {
        [Display(Name = "Ticket No")]
        [StringLength(50)]
        public string? TicketNo { get; set; }

        [Display(Name = "User Id")]
        [ForeignKey("InternetUser")]
        public int? InternetUserId { get; set; }
        [Display(Name = "User Id")]
        public virtual InternetUserModel? InternetUser { get; set; }


        //[NotMapped]
        //[Display(Name = "User Name")]
        //[StringLength(100)]
        //public string? UserName { get; set; }


        [NotMapped]
        [DataType(DataType.Text)]
        [Display(Name = "UserId")]
        public string? UserId { get; set; }

        [Required]
        [NotMapped]
        [DataType(DataType.Text)]
        [Display(Name = "UserName")]
        public string? UserName { get; set; }



        [Display(Name = "Complaint")]
        [ForeignKey("InternetComplain")]
        public int? InternetComplainId { get; set; }
        [Display(Name = "Complaint")]
        public virtual InternetComplainModel InternetComplain { get; set; }


        [Display(Name = "Diagonosis by User")]
        [ForeignKey("DiagonosisByUser")]
        public int? DiagonosisByLUserId { get; set; }
        [Display(Name = "Diagonosis by User")]
        public virtual UserAccountModel? DiagonosisByUser { get; set; }



        //[StringLength(120)]
        //[Display(Name = "Diagonosis By")]
        //public string? DiagonosisBy { get; set; }




        [Display(Name = "Diagnosis Report")]
        [ForeignKey("DiagnosisReport")]
        public int? DiagnosisReportId { get; set; }
        [Display(Name = "Diagnosis Report")]
        public virtual DiagnosisReportModel DiagnosisReport { get; set; }



        [Display(Name = "Support by User")]
        [ForeignKey("SupportByUser")]
        public int? SupportByLUserId { get; set; }
        [Display(Name = "Support by User")]
        public virtual UserAccountModel? SupportByUser { get; set; }


        //[StringLength(100)]
        //[Display(Name = "Support By:")]
        //public string? SupportBy { get; set; }





        [StringLength(200)]
        [Display(Name = "Recommendation")]
        public string? Recommendation { get; set; }


        [Display(Name = "Priority")]
        [StringLength(20)]
        public string? Priority { get; set; }


        [StringLength(200)]
        [Display(Name = "Note")]
        public string? Note { get; set; }

        public virtual ICollection<TroubleTicketCommentModel> TroubleTicketComment { get; set; }
    }


    [Table("TroubleTicketComment")]
    public class TroubleTicketCommentModel : BaseModel
    {


        [Display(Name = "Comment To User / Assaigned To")]
        [ForeignKey("CommentToUserList")]
        public int? CommentToLuserId { get; set; }
        [Display(Name = "Comment To User / Assaigned To")]
        public virtual UserAccountModel? CommentToUserList { get; set; }


        [DisplayName("Trouble Ticket Id")]
        [ForeignKey("TroubleTicket")]
        public int TroubleTicketId { get; set; }
        [DisplayName("Trouble Ticket")]
        public TroubleTicketModel TroubleTicket { get; set; }




        [StringLength(200)]
        [Display(Name = "Comment")]
        [DataType(DataType.MultilineText)]
        public string? Comment { get; set; }



        //public virtual ICollection<InvoiceBillModel> InvoiceBill { get; set; }
    }

}
