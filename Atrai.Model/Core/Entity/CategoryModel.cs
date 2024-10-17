using Atrai.Model.Core.Entity.Base;
using Atrai.Model.Core.Entity.Self;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atrai.Model.Core.Entity
{
    [Table("Category")]
    public class CategoryModel : BaseModel
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "Category Name")]

        public string? Name { get; set; }
        [Display(Name = "Description")]
        [StringLength(100)]
        public string? Description { get; set; }


        [ForeignKey("Categories")]
        [Display(Name = "Parent Category")]

        public int? CategoryParentId { get; set; }
        [Display(Name = "Parent Category")]
        public virtual CategoryModel? Categories { get; set; }



        [Display(Name = "Tax Percentage % [If Applicable]")]
        [Column(TypeName = "decimal(18,4)")]
        public double TaxPer { get; set; } = 0;

        [Display(Name = "Tax Excluded")]
        public bool isTaxExcluded { get; set; }


        [NotMapped]
        public string? CategoryImageString { get; set; }



        [Display(Name = "Image [Folder]")]

        public string? ImagePath { get; set; }

        [Display(Name = "Files Extension")]
        public string? FileExtension { get; set; }



        [NotMapped]
        public int IsPartialView { get; set; }

        [NotMapped]
        public string? ProductPicturePreview1 { get; set; }

        
        public virtual ICollection<CategoryModel>? ChildCategoryList { get; set; }
        public virtual ICollection<ProductModel>? ProductCount { get; set; }

    }


    [Table("Brand")]
    public class BrandModel : BaseModel
    {
        [Required]
        [StringLength(30)]
        [Display(Name = "Brand Name")]

        public string? BrandName { get; set; }
        [Display(Name = "Description")]
        [StringLength(100)]
        public string? Description { get; set; }


        [NotMapped]
        public string? BrandImageString { get; set; }



        [Display(Name = "Image [Folder]")]

        public string? ImagePath { get; set; }

        [Display(Name = "Files Extension")]
        public string? FileExtension { get; set; }

        [NotMapped]
        public int IsPartialView { get; set; }

    }

    [Table("DocApprovalSetting")]
    public class DocApprovalSettingModel : BaseModel
    {
        [ForeignKey("DocType")]
        [Display(Name = "Doc Type")]
        public int? DocTypeId { get; set; }
        
        [Display(Name = "Doc Type")]
        public virtual DocTypeModel? DocType { get; set; }


        [ForeignKey("ApprovalType")]
        [Display(Name = "Approval Type")]
        public int? ApprovalTypeId { get; set; }

        [Display(Name = "Approval Type")]
        public virtual ApprovalTypeModel ApprovalType { get; set; }


        [ForeignKey("EntryUserList")]
        public int LuserIdEntry { get; set; }
        //[JsonIgnore]
        [Display(Name = "Entry User")]
        public virtual UserAccountModel? EntryUserList { get; set; }



        [ForeignKey("CheckUserList")]
        public int? LuserIdCheck { get; set; }
        //[JsonIgnore]
        [Display(Name = "Check User")]
        public virtual UserAccountModel? CheckUserList { get; set; }



        [ForeignKey("VerifyUserList")]
        public int? LuserIdVerify { get; set; }
        //[JsonIgnore]
        [Display(Name = "Verify User")]
        public virtual UserAccountModel? VerifyUserList { get; set; }



        [ForeignKey("ApproveUserList")]
        public int? LuserIdApprove { get; set; }
        //[JsonIgnore]
        [Display(Name = "Approve User")]
        public virtual UserAccountModel? ApproveUserList { get; set; }


        public bool isInactive { get; set; }

    }




    [Table("Warrenty")]
    public class WarrentyModel : SelfModel
    {
        [Required]
        [StringLength(80)]
        [Display(Name = "Warrenty Type")]
        public string? Name { get; set; }


        //[StringLength(30)]
        //[Display(Name = "Day / Month / Year")]
        //public string? DayMonthYear { get; set; }


        [ForeignKey("DurationTime")]
        public int? DurationTimeId { get; set; }
        [Display(Name = "DurationTime")]
        public virtual DurationTimeModel DurationTime { get; set; }



        [Display(Name = "Days")]
        public int Day { get; set; }

        [StringLength(100)]
        [Display(Name = "Description")]
        public string? Description { get; set; }

        public bool isInactive { get; set; }
    }






    [Table("TimeZoneSettings")]
    public class TimeZoneSettingsModel : SelfModel
    {
        [Required]
        [StringLength(200)]
        [Display(Name = "TimeZone Name")]
        public string? TimeZoneName { get; set; }


        [StringLength(200)]
        [Display(Name = "TimeZone Name")]
        [Required]

        public string? TimeZoneNameJquery { get; set; }

        [StringLength(200)]
        public string? UTCTime { get; set; }

        public bool isInactive { get; set; }

        public int? CountryId { get; set; }
    }



    [Table("TradeTerms")]
    public class TradeTermsModel : BaseModel
    {
        [Required]
        [StringLength(30)]
        [Display(Name = "Trade Terms")]
        public string? TradeTermCaption { get; set; }

        [Display(Name = "Days")]
        public int Day { get; set; }

        [StringLength(100)]
        [Display(Name = "Description")]
        public string? Description { get; set; }

        public bool isInactive { get; set; }
    }


    [Table("DurationTime")]
    public class DurationTimeModel : SelfModel
    {
        [Required]
        [StringLength(30)]
        [Display(Name = "Duration Type")]
        public string? DurationName { get; set; }


        //[StringLength(30)]
        //[Display(Name = "Day / Month / Year")]
        //public string? DayMonthYear { get; set; }

        [Display(Name = "Days")]
        public int Day { get; set; }

        [StringLength(100)]
        [Display(Name = "Description")]
        public string? Description { get; set; }

        public bool isInactive { get; set; }
    }

    //[Table("Color")]
    //public class ColorModel : SelfModel
    //{
    //    [Required]
    //    [StringLength(30)]
    //    [Display(Name = "Color Name")]
    //    public string? ColorName { get; set; }

    //    [StringLength(4)]
    //    [Display(Name = "Short Name")]
    //    public string? ColorShortName { get; set; }

    //    [Required]
    //    [StringLength(30)]
    //    [Display(Name = "Color Code")]
    //    public string? ColorCode { get; set; }

    //    public bool isInactive { get; set; }


    //    [ForeignKey("CompanyList")]
    //    public int? ComId { get; set; }
    //    [Display(Name = "Company")]
    //    public virtual CompanyModel CompanyList { get; set; }
    //}


    //[Table("Size")]
    //public class SizeModel : SelfModel
    //{
    //    [Required]
    //    [StringLength(30)]
    //    [Display(Name = "Size Name")]
    //    public string? SizeName { get; set; }

    //    [StringLength(4)]
    //    [Display(Name = "Short Name")]
    //    public string? SizeShortName { get; set; }

    //    public int SLNo { get; set; }


    //    public bool isInactive { get; set; }

    //    [ForeignKey("CompanyList")]
    //    public int? ComId { get; set; }
    //    [Display(Name = "Company")]
    //    public virtual CompanyModel CompanyList { get; set; }
    //}


    [Table("DocType")]
    public class DocTypeModel : SelfModel
    {
        [Required]
        [StringLength(30)]
        [Display(Name = "Doc Type")]
        public string? DocType { get; set; }

        public int SLNo { get; set; }
        public string? DocFor { get; set; }
        public string? DocTypeValue { get; set; }

    }


    [Table("DocPrefix")]

    public class DocPrefixModel : BaseModel
    {
        [Display(Name = "Doc Type")]
        //[Key, Column(Order = 0)]
        public int DocTypeId { get; set; }
        [ForeignKey("DocTypeId")]
        public virtual DocTypeModel? vDocTypes { get; set; }
        [Display(Name = "Doc Prefix")]

        public string? DocPrefix { get; set; }

        //[Display(Name = "No Length")]
        //public int Length { get; set; } = 0;

        //[Display(Name = "Visible For Entry")]
        //public bool isVisible { get; set; }

        public int LastDocNo { get; set; }
        public int FirstDocNo { get; set; }

        public bool YearSuffix { get; set; }
        public bool MonthSuffix { get; set; }
        public bool DateSuffix { get; set; }

        public string? LastGeneratedCode { get; set; }
        public string? Format { get; set; }


    }

    [Table("UnitConversion")]
    public class UnitConversionModel : BaseModel
    {
        
        public int PrimaryUnitId { get; set; }
        [ForeignKey("PrimaryUnitId")]
        public virtual UnitModel PrimaryUnitModel { get; set; }

        public int SecondaryUnitId { get; set; }
        [ForeignKey("SecondaryUnitId")]
        public virtual UnitModel SecondaryUnitModel { get; set; }

        public double? ConversionRate { get; set; } = 0;

    }

    [Table("Status")]
    public class StatusModel : SelfModel
    {
        public int SLNo { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name = "Status")]
        public string? Status { get; set; }

        [StringLength(10)]
        public string? StatusShort { get; set; }
        [Display(Name = "Doc Type")]
        public int? DocTypeId { get; set; }
        [ForeignKey("DocTypeId")]
        public virtual DocTypeModel? DocTypes { get; set; }

    }

    [Table("DocStatus")]
    public class DocStatusModel : SelfModel
    {
        public int SLNo { get; set; }

        [Display(Name = "Doc Type")]
        public int? DocTypeId { get; set; }
        [ForeignKey("DocTypeId")]
        public virtual DocTypeModel? DocTypes { get; set; }


        public int? StatusId { get; set; }
        [ForeignKey("StatusId")]
        public virtual StatusModel? StatusInfo { get; set; }
    }

    [Table("DiscountType")]
    public class DiscountTypeModel : BaseModel
    {
        public int SLNo { get; set; }
        public int IsDefault { get; set; }


        [Required]
        [Display(Name = "Dis Per")]
        public double DisPer { get; set; }
        public string? DiscountFor { get; set; }
       


    }

    [Table("ApprovalType")]
    public class ApprovalTypeModel : SelfModel
    {
        [Required]
        [StringLength(200)]
        [Display(Name = "Approval Type")]
        public string? ApprovalType { get; set; }

        public int ApprovalStage { get; set; }

    }

    [Table("ApprovalStatus")]
    public class ApprovalStatusModel : SelfModel
    {
        [Required]
        [StringLength(200)]
        [Display(Name = "Approval Status")]
        public string? ApprovalStatus { get; set; }


    }


    [Table("Notification")]
    public class NotificationModel : BaseModel
    {
        [Required]
        [StringLength(300)]
        [Display(Name = "Text Message")]

        public string? TextMessage { get; set; }

        public string? Type { get; set; }

        public int? Value { get; set; }

        public bool IsSeen { get; set; }

        public DateTime NotifyDate { get; set; }

        public virtual ICollection<NotificationSeenModel> NotificationSeenList { get; set; }

    }


    [Table("NotificationSeen")]
    public class NotificationSeenModel : BaseModel
    {

        [ForeignKey("Notificaioninfo")]
        public int NotificationId { get; set; }
        [Display(Name = "Notification Info")]
        public virtual NotificationModel Notificaioninfo { get; set; }
    }


    [Table("EmployeeAttendance")]
    public class EmployeeAttendanceModel : BaseModel
    {
        [StringLength(128)]

        public string? Latitude { get; set; }
        [StringLength(128)]

        public string? Longitude { get; set; }

        public DateTime PunchDateTime { get; set; }

        public DateTime PunchDate { get; set; }

        public DateTime InTime { get; set; }

        public DateTime OutTime { get; set; }

        //[ForeignKey("EmployeeList")]
        public int EmployeeLuerId { get; set; }
        //[Display(Name = "Employee Data")]
        //public virtual UserAccountModel? EmployeeList { get; set; }

        //public int EmployeeLuerId { get; set; }

        [StringLength(400)]
        public string? LocationName { get; set; }

        [StringLength(10)]
        public string? Status { get; set; }


        [NotMapped]
        public string? EmpFrontImageString { get; set; }

        [NotMapped]
        public string? EmpBackImageString { get; set; }


        [Display(Name = "Image Front")]

        public string? ImagePathFront { get; set; }

        [Display(Name = "Image Back")]

        public string? ImagePathBack { get; set; }

        public bool isPosted { get; set; }

    }


    [Table("HR_ProcessLock")]
    public partial class HR_ProcessLockModel : BaseModel
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int ProcessId { get; set; }


        [Display(Name = "Lock Type")]
        [StringLength(50)]
        public string? LockType { get; set; }

        [Display(Name = "Lock Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DtDate { get; set; }

        [Display(Name = "To Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DtToDate { get; set; }

        [Display(Name = "Fiscal Year")]
        public int? FiscalYearId { get; set; }
        [ForeignKey("FiscalYearId")]
        public virtual Acc_FiscalYearModel? Acc_FiscalYears { get; set; }


        [Display(Name = "Fiscal Month")]
        public int? FiscalMonthId { get; set; }
        [ForeignKey("FiscalMonthId")]
        public virtual Acc_FiscalMonthModel Acc_FiscalMonths { get; set; }



        [Display(Name = "Is Lock")]
        public bool IsLock { get; set; }

    }


    [Table("MobileTextAnimation")]
    public class MobileTextAnimationModel : BaseModel
    {
        [Required]
        [StringLength(300)]
        [Display(Name = "Text Message One")]

        public string? TextMessageOne { get; set; }

        [StringLength(300)]
        [Display(Name = "Text Message One")]
        public string? TextMessageTwo { get; set; }

        [StringLength(300)]
        [Display(Name = "Text Message One")]
        public string? TextMessageThree { get; set; }
        [StringLength(100)]
        public string? Type { get; set; }
        public bool IsSeen { get; set; }
        public DateTime AnimationDate { get; set; }


        [StringLength(30)]
        public string? TypeColor { get; set; }

        [StringLength(30)]
        public string? TextMessageOneColor { get; set; }

        [StringLength(30)]
        public string? TextMessageTwoColor { get; set; }

        [StringLength(30)]
        public string? TextMessageThreeColor { get; set; }



        [StringLength(10)]
        public string? TypeSize { get; set; }

        [StringLength(10)]
        public string? TextMessageOneSize { get; set; }

        [StringLength(10)]
        public string? TextMessageTwoSize { get; set; }

        [StringLength(10)]
        public string? TextMessageThreeSize { get; set; }

    }


    [Table("TaskToDo")]
    public class TaskToDoModel : BaseModel
    {
        [StringLength(100)]
        public string? TaskTitle { get; set; } ///Official // Personal

        [Required]
        [StringLength(300)]
        [Display(Name = "Details")]
        public string? TaskDetails { get; set; }
        [StringLength(300)]
        [Display(Name = "Remakrs")]
        public string? TaskRemarks { get; set; }

        [Display(Name = "Colour")]

        [StringLength(30)]
        public string? TaskColour { get; set; }

        public DateTime InputDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime? CompleteDate { get; set; }
        public bool IsComplete { get; set; }
        public int TaskPercentage { get; set; }


        [Display(Name = "Amount")]

        public int? Amount { get; set; }

        [StringLength(100)]
        [Display(Name = "Assaign To")]
        public string? AssaignToPerson { get; set; }


        [ForeignKey("ParentTaskToDo")]
        public int? TaskToDoParentId { get; set; }
        [Display(Name = "Task Under")]
        public virtual TaskToDoModel ParentTaskToDo { get; set; }



        public virtual ICollection<TaskToDoModel> SubTaskList { get; set; }




    }


}
