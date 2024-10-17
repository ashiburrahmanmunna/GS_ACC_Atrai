using Atrai.Model.Core.Entity.Base;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atrai.Model.Core.Entity
{

    public class pdfModel
    {
        public string? pdfid { get; set; }
        public byte[] pdffile { get; set; }

    }

    [Table("Market")]
    public class MarketModel : BaseModel
    {
        [Display(Name = "Market Code")]
        [StringLength(50)]
        public string? MarketCode { get; set; }

        [Required]
        [Display(Name = "Market Name English")]
        [StringLength(150)]
        public string? MarketNameEng { get; set; }

        [StringLength(200)]
        [Required]
        [Display(Name = "Market Name Bangla")]
        public string? MarketNameBng { get; set; }

        [StringLength(200)]
        [Display(Name = "President Name")]
        public string? PrName { get; set; }

        [Phone]
        [Display(Name = "President Phone")]
        public string? PrPhoneNo { get; set; }

        [StringLength(200)]

        [Display(Name = "Secretory Name")]
        public string? SecName { get; set; }

        [Phone]

        [Display(Name = "Secretory Phone")]
        public string? SecPhoneNo { get; set; }


        [Display(Name = "Floors")]
        public int? Floors { get; set; }
        [Display(Name = "1st Floor")]
        public int? FirstFloor { get; set; }

        [Display(Name = "2nd Floor")]
        public int? SecoundFloor { get; set; }

        [Display(Name = "3rd Floor")]
        public int? ThirdFloor { get; set; }

        [Display(Name = "4th Floor")]
        public int? FourthFloor { get; set; }

        [Display(Name = "5th Floor")]
        public int? FifthFloor { get; set; }



        [Display(Name = "Total Shop")]
        public int? TotalShop { get; set; }


        [Display(Name = "Closed Shop")]
        public int? ClosedShop { get; set; }

        [Display(Name = "ActiveMember")]
        public int? ActiveMember { get; set; }

        [StringLength(100)]
        [Display(Name = "Web Site")]
        public string? Website { get; set; }

        //[Display(Name = "President Image [DB]")]
        //[ValidateFile(ErrorMessage = "Please select a PNG image smaller than 1MB")]

        //public byte[] PresidentImage { get; set; }

        //[Required]
        //[DataType(DataType.ImageUrl)]
        [StringLength(200)]
        [Display(Name = "President Image [Folder]")]
        public string? PresidentImagePath { get; set; }

        [StringLength(50)]

        [Display(Name = "President Files Extension")]
        public string? PresidentFileExtension { get; set; }


        //[Display(Name = "Secretary Image [DB]")]
        //[ValidateFile(ErrorMessage = "Please select a PNG image smaller than 1MB")]

        //public byte[] SecretaryImage { get; set; }

        //[Required]
        //[DataType(DataType.ImageUrl)]

        [Display(Name = "Secretary Image [Folder]")]
        [StringLength(200)]

        public string? SecretaryImagePath { get; set; }
        [StringLength(50)]

        [Display(Name = "President Files Extension")]
        public string? SecretaryFileExtension { get; set; }


        [Display(Name = "Inactive")]
        public bool IsInActive { get; set; }

        [StringLength(200)]

        [DataType(DataType.MultilineText)]
        [Display(Name = "Remarks / Other Info")]

        public string? Remarks { get; set; }


        [Display(Name = "President Image Upload")]

        [NotMapped]
        //[Required(ErrorMessage = "Please select a Image!")]
        public IFormFile PresidentImageUpload { get; set; }


        [Display(Name = "Secretary Image Upload")]

        [NotMapped]
        //[Required(ErrorMessage = "Please select a Image!")]
        public IFormFile SecretaryImageUpload { get; set; }

    }


    [Table("Shop")]
    public class ShopModel : BaseModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ShopModel()
        {
            this.Member = new HashSet<MemberModel>();
            //this.ProductTypes = new HashSet<ProductType>();
        }

        [StringLength(50)]

        [Display(Name = "Shop Code")]

        public string? ShopCode { get; set; }
        [Display(Name = "Market")]

        public Nullable<int> MarketId { get; set; }
        public virtual MarketModel Market { get; set; }

        [StringLength(200)]

        [Display(Name = "Shop Name English")]
        public string? ShopNameEng { get; set; }


        [StringLength(200)]

        [Display(Name = "Shop Name Bangla")]
        public string? ShopNameBng { get; set; }

        [StringLength(200)]

        [Display(Name = "Holding / Shop No English")]
        public string? HoldingNoEng { get; set; }

        [StringLength(200)]
        [Display(Name = "Holding / Shop No Bangla")]


        public string? HoldingNoBng { get; set; }
        [Display(Name = "Shop Address Bangla")]
        [StringLength(200)]


        public string? ShopBusinessAddressBng { get; set; }

        [Display(Name = "Shop Address English")]
        [StringLength(200)]


        public string? ShopBusinessAddressEng { get; set; }


        [Display(Name = "Shop Website")]
        [StringLength(100)]


        public string? ShopWebSite { get; set; }



        [Display(Name = "Shop Email")]
        [StringLength(100)]

        public string? ShopEmail { get; set; }




        [Display(Name = "Shop Mobile No")]
        [Phone]
        public string? ShopMobile { get; set; }




        [Display(Name = "Shop Owner Eng")]
        [StringLength(200)]


        public string? ShopOwnerEng { get; set; }

        [Display(Name = "Shop Owner Bng")]
        [StringLength(200)]


        public string? ShopOwnerBng { get; set; }



        [Display(Name = "Shop Type / Item / Product")]
        [StringLength(200)]


        public string? ShopTypeItemProduct { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Shop Description")]
        [StringLength(200)]

        public string? ShopDescription { get; set; }



        [Display(Name = "Visiting Card Image [DB]")]

        public byte[] ShopImage { get; set; }
        [Display(Name = "Visiting Card Image [Folder]")]
        [StringLength(200)]

        public string? ShopImagePath { get; set; }

        [Display(Name = "Visiting Card Files Extension")]
        [StringLength(200)]

        public string? ShopFileExtension { get; set; }

        [Display(Name = "Inactive")]
        public bool IsInActive { get; set; }

        public virtual ICollection<MemberModel> Member { get; set; }


    }


    [Table("Member")]
    public class MemberModel : BaseModel
    {

        [Display(Name = "Member Access Id")]
        [Required]

        public int MemberAccessId { get; set; }


        [Display(Name = "Member Barcode Id")]
        [StringLength(50)]

        public string? MemberBarcodeId { get; set; }


        [Required]
        [Display(Name = "Member`s Name English")]
        [StringLength(200)]

        public string? MembersNameEng { get; set; }

        [StringLength(200)]

        [Display(Name = "Members Name Bangla")]
        public string? MembersNameBng { get; set; }

        [StringLength(200)]

        [Display(Name = "Fathers Name [English]")]
        public string? FathersNameEng { get; set; }

        [StringLength(200)]

        [Display(Name = "Fathers Name [Bangla]")]
        public string? FathersNameBng { get; set; }

        [StringLength(200)]

        [Display(Name = "Shop Name [English]")]
        public string? ShopNameEng { get; set; }

        [StringLength(200)]

        [Display(Name = "Shop Name [Bangla]")]
        public string? ShopNameBng { get; set; }

        [StringLength(200)]

        [Display(Name = "Business Address [English]")]
        [DataType(DataType.MultilineText)]

        public string? BusinessAddressEng { get; set; }

        [StringLength(200)]

        [Display(Name = "Business Address [Bangla]")]
        [DataType(DataType.MultilineText)]

        public string? BusinessAddressBng { get; set; }




        [StringLength(200)]

        [Display(Name = "Holding / Shop No [Eng]")]
        public string? HoldingNoEng { get; set; }
        [StringLength(200)]


        [Display(Name = "Holding / Shop No [Bng]")]
        public string? HoldingNoBng { get; set; }


        [StringLength(30)]

        [Display(Name = "NID Card No")]
        public string? NID { get; set; }


        [StringLength(50)]

        [Display(Name = "Membership Card No")]
        public string? CardNo { get; set; }


        [StringLength(200)]

        [Display(Name = "Permanent Address")]
        [DataType(DataType.MultilineText)]

        public string? FixedAddress { get; set; }


        [Display(Name = "Date Of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]

        public DateTime? DOB { get; set; }



        [Phone]
        [Display(Name = "Mobile")]
        public string? Mobile { get; set; }

        [StringLength(200)]

        [Display(Name = "Market Name")]
        public string? MarketName { get; set; }
        [StringLength(200)]

        [Display(Name = "Photo")]
        public string? Photo { get; set; }



        [StringLength(10)]

        [Display(Name = "BloodGroup")]
        public string? BloodGroup { get; set; }


        [Phone]
        [Display(Name = "MemberHomePhone")]
        public string? MemberHomePhone { get; set; }



        [Display(Name = "IsActive")]
        public bool isActive { get; set; }


        //[Display(Name = "Member Image [DB]")]
        ////[ValidateFile(ErrorMessage = "Please select a PNG image smaller than 1MB")]

        //public byte[] MemberImage { get; set; }

        ////[Required]
        ////[DataType(DataType.ImageUrl)]

        //[Display(Name = "Member Image [Folder]")]
        [StringLength(200)]

        public string? MemberImagePath { get; set; }

        //[Display(Name = "Member Files Extension")]
        //public string? MemberFileExtension { get; set; }

        [Display(Name = "IsActive")]
        public bool IsExistImage { get; set; }
        [StringLength(30)]

        public string? MemberType { get; set; }
        [StringLength(30)]


        public string? OwnerShipType { get; set; }
        [StringLength(100)]

        public string? EducationalQualification { get; set; }
        [StringLength(100)]


        public string? Occupation { get; set; }

        [StringLength(100)]

        public string? ProposerName { get; set; }
        [StringLength(50)]

        public string? ProposerMemberNo { get; set; }

        [StringLength(200)]

        public string? SupporterName { get; set; }
        [StringLength(50)]

        public string? SupporterMemberNo { get; set; }




        [Display(Name = "Market")]

        [ForeignKey("Market")]
        public int? MarketId { get; set; }

        public virtual MarketModel Market { get; set; }
        [Display(Name = "Shop")]


        [ForeignKey("Shop")]
        public int? ShopId { get; set; }

        public virtual ShopModel Shop { get; set; }
        [Display(Name = "Member Status")]



        [ForeignKey("MemberStatus")]
        public int? MemberStatusId { get; set; }

        public virtual MemberStatusModel MemberStatus { get; set; }

        [Display(Name = "Is Canceled")]
        public bool isCanceled { get; set; }

        [Display(Name = "Cancel Comment")]
        public string? CanceledRemarks { get; set; }
        [StringLength(200)]




        [Display(Name = "Is Applied")]
        public bool IsApplied { get; set; }

        [Display(Name = "Applied Comment")]
        [StringLength(200)]

        public string? AppliedRemarks { get; set; }



        [Display(Name = "Is Checked")]
        public bool IsChecked { get; set; }

        [Display(Name = "CheckingComment")]
        [StringLength(200)]

        public string? CheckedRemarks { get; set; }


        [Display(Name = "Is Verified")]
        public bool isVerified { get; set; }
        [StringLength(200)]


        [Display(Name = "VerifiedComment")]
        public string? VerifiedRemarks { get; set; }

        [Display(Name = "Is Approved")]
        public bool isApproved { get; set; }
        [StringLength(200)]


        [Display(Name = "ApprovalComment")]
        public string? ApprovalRemarks { get; set; }



    }


    [Table("MemberStatus")]
    public class MemberStatusModel : BaseModel
    {

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        [Display(Name = "Member Status")]
        public string? MemberStatusLong { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Member Status Short")]
        public string? MemberStatusShort { get; set; }

    }














    [Table("Employee")]
    public class EmployeeModel : BaseModel
    {

        [Required]
        [StringLength(50)]
        [Display(Name = "Employee Code")]
        public string? EmployeeCode { get; set; }


        [Required]
        [StringLength(200)]

        [Display(Name = "Employee Name")]
        public string? EmployeeName { get; set; }

        [Display(Name = "Father's Name")]
        [StringLength(100)]

        public string? FathersName { get; set; }


        [Display(Name = "Mobile No")]
        [StringLength(70)]

        public string? MobileNo { get; set; }


        [Display(Name = "NID Card No")]
        [StringLength(100)]

        public string? NID { get; set; }

        [Display(Name = "Present Address")]
        [StringLength(300)]

        [DataType(DataType.MultilineText)]
        public string? PresentAddress { get; set; }


        [Display(Name = "Permanent Address")]
        [StringLength(300)]

        [DataType(DataType.MultilineText)]
        public string? PermanentAddress { get; set; }


        [Display(Name = "Emergency Contact Name")]
        [StringLength(100)]

        public string? EmergencyContactName { get; set; }


        [Display(Name = "Emergency Mobile No")]
        [StringLength(50)]

        public string? EmergencyMobileNo { get; set; }


        [Display(Name = "Emergency Contact Relationship")]
        [StringLength(100)]

        public string? EmergencyContactRelationship { get; set; }

        [Display(Name = "Introducer Name")]
        [StringLength(100)]

        public string? IntroducerName { get; set; }
        [Display(Name = "Introducer Contact No")]
        [StringLength(100)]

        public string? IntroducerContctNo { get; set; }
        [Display(Name = "Introducer Address")]
        [StringLength(100)]

        public string? IntroducerAddress { get; set; }

        [Display(Name = "SLNo for Order")]
        public int SLNo { get; set; }

        [Display(Name = "Position / Title")]
        [StringLength(100)]

        public string? PositionTitle { get; set; }


        //[Display(Name = "Department")]
        //public string? Department { get; set; }

        //[Display(Name = "Designation")]
        //public string? Designation { get; set; }

        [Display(Name = "Department")]

        [ForeignKey("DepartmentList")]
        public int? DepartmentId { get; set; }
        [Display(Name = "Department")]

        public virtual Cat_DepartmentModel? DepartmentList { get; set; }

        [Display(Name = "Designation")]

        [ForeignKey("DesignationList")]
        public int? Designationid { get; set; }
        [Display(Name = "Designation")]

        public virtual Cat_DesignationModel? DesignationList { get; set; }



        [Display(Name = "Gross")]
        public float GrossSalary { get; set; } = 0;

        [Display(Name = "Basic")]
        public float Basic { get; set; } = 0;

        [Display(Name = "House Rent")]
        public float HR { get; set; } = 0;

        [Display(Name = "Medical Allowance")]
        public float MA { get; set; } = 0;

        [Display(Name = "Othes Allowance")]
        public float OthersAllowance { get; set; } = 0;


        [Display(Name = "Production Rate")]
        public float ProductionRate { get; set; } = 0;


        [Display(Name = "Hours Rate")]
        public float HoursRate { get; set; } = 0;



        [Display(Name = "Advance Amount")]
        public float EmpAdvanceBalance { get; set; } = 0;



        [Display(Name = "Loan Amount")]
        public float EmpLoanBalance { get; set; } = 0;
        //[Display(Name = "Employee Type")]
        //public string? EmpType { get; set; } = "F";



        [Display(Name = "Work Location")]
        [StringLength(100)]

        public string? WorkLocation { get; set; }



        [Display(Name = "Photo")]
        public string? Photo { get; set; }



        [Display(Name = "IsActive")]
        public bool isActive { get; set; }


        public string? EmployeeImagePath { get; set; }



        [Display(Name = "IsExistImage")]
        public bool IsExistImage { get; set; }




        // public virtual ICollection<UserAccountModel> LinkedUserAccount { get; set; }




        [Display(Name = "E. Name Bangla")]
        [StringLength(50)]
        public string? EmpNameB { get; set; }

        [Display(Name = "Religion")]
        public int? RelgionId { get; set; }
        [ForeignKey("RelgionId")]
        public virtual Cat_ReligionModel? Cat_Religion { get; set; }


        [Display(Name = "Blood Group")]
        public int? BloodId { get; set; }
        [ForeignKey("BloodId")]
        public virtual Cat_BloodGroupModel? Cat_BloodGroup { get; set; }


        [Display(Name = "Employee Type")]
        public int? EmployeeTypeId { get; set; }
        [ForeignKey("EmployeeTypeId")]
        public virtual Cat_EmployeeTypeModel? EmployeeType { get; set; }



        //[Display(Name = "Salary Type")]
        //public int? SalaryTypeId { get; set; }
        //[ForeignKey("SalaryTypeId")]
        //public virtual Cat_SalaryTypeModel SalaryType { get; set; }


        [Display(Name = "Unit")]
        public int? UnitId { get; set; }
        [ForeignKey("UnitId")]
        public virtual Cat_UnitModel? Cat_Unit { get; set; }

        [Display(Name = "Department")]
        public int? DeptId { get; set; }
        [ForeignKey("DeptId")]
        public virtual Cat_DepartmentModel? Cat_Department { get; set; }

        [Display(Name = "Shift")]
        public int? ShiftId { get; set; }
        [ForeignKey("ShiftId")]
        public virtual Cat_ShiftModel? Cat_Shift { get; set; }

        [Display(Name = "Designation")]
        public int? DesigId { get; set; }
        [ForeignKey("DesigId")]
        public virtual Cat_DesignationModel? Cat_Designation { get; set; }


        [Display(Name = "Section")]
        public int? SectId { get; set; }
        [ForeignKey("SectId")]
        public virtual Cat_SectionModel? Cat_Section { get; set; }


        [Display(Name = "Sub Section")]
        public int? SubSectId { get; set; }
        [ForeignKey("SubSectId")]
        public virtual Cat_SubSectionModel? Cat_SubSection { get; set; }


        //[DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Birth Date")]
        [DisplayFormat(DataFormatString = "{0:yy/MMM/dd}")]
        [DataType(DataType.Date)]
        public DateTime? DtBirth { get; set; }

        ///[DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Join Date")]
        [DisplayFormat(DataFormatString = "{0:yy/MMM/dd}")]
        public DateTime? DtJoin { get; set; }

        //[DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Increment Date")]
        [DisplayFormat(DataFormatString = "{0:yy/MMM/dd}")]
        public DateTime? DtIncrement { get; set; }

        //[DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Promotion Date")]
        [DisplayFormat(DataFormatString = "{0:yy/MMM/dd}")]
        public DateTime? DtPromotion { get; set; }


        //[DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Confirm Date")]
        [DisplayFormat(DataFormatString = "{0:yy/MMM/dd}")]
        public DateTime? DtConfirm { get; set; }




        //[DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "PF Date")]
        [DisplayFormat(DataFormatString = "{0:yy/MMM/dd}")]
        public DateTime? DtPF { get; set; }





        //[DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Released Date")]
        [DisplayFormat(DataFormatString = "{0:yy/MMM/dd}")]
        public DateTime? DtReleased { get; set; }


        // transfer into personal 
        //[DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        //[Display(Name = "PF Date")]
        //public DateTime? DtPf { get; set; } 


        //[Display(Name = "Employee Type")]
        //public int? EmpTypeId { get; set; }
        //[ForeignKey("EmpTypeId")]
        //public virtual Cat_EmployeeTypeModel? Cat_Emp_Type { get; set; }


        [Display(Name = "Gender")]
        public int? GenderId { get; set; }
        [ForeignKey("GenderId")]
        public virtual Cat_GenderModel? Cat_Gender { get; set; }

        //[StringLength(40)]
        //[Display(Name = "National Id")]
        //public string? NID { get; set; }

        [StringLength(40)]
        [Display(Name = "Finger Id")]
        public string? FingerId { get; set; }
        [Display(Name = "Is Casual")]
        public bool IsCasual { get; set; }

        [Display(Name = "Is Confirm")]
        public bool IsConfirm { get; set; }

        [Display(Name = "Skill")]
        public int? SkillId { get; set; }
        [ForeignKey("SkillId")]
        public Cat_SkillModel? Cat_Skill { get; set; }


        [Display(Name = "Phone No 1")]
        [StringLength(20)]
        public string? EmpPhone1 { get; set; }

        [Display(Name = "Phone No 2")]
        [StringLength(20)]
        public string? EmpPhone2 { get; set; }

        public bool IsInactive { get; set; }

        [Display(Name = "Is Incentive Bonus")]
        public bool IsIncentiveBns { get; set; }



        [StringLength(50)]
        public string? EmpPerZip { get; set; }

        [Display(Name = "Email")]
        [StringLength(50)]
        public string? EmpEmail { get; set; }


        [StringLength(120)]
        [DataType(DataType.MultilineText)]
        public string? EmpRemarks { get; set; }

        [Display(Name = "Grade")]
        public int? GradeId { get; set; }
        [ForeignKey("GradeId")]
        public virtual Cat_GradeModel? Cat_Grade { get; set; }

        [Display(Name = "Floor")]
        public int? FloorId { get; set; }
        [ForeignKey("FloorId")]
        public virtual Cat_FloorModel? Cat_Floor { get; set; }

        [Display(Name = "Line")]
        public int? LineId { get; set; }
        [ForeignKey("LineId")]
        public virtual Cat_LineModel? Cat_Line { get; set; }

        [Display(Name = "OT Activate")]
        public bool IsAllowOT { get; set; }



        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "DAP Join")]
        public DateTime? DtLocalJoin { get; set; }


        [Display(Name = "Card No")]
        public int ManageType { get; set; } = 0;



        public virtual HR_Emp_Address? HR_Emp_Address { get; set; }
        public virtual ICollection<HR_Emp_EducationModel>? HR_Emp_Educations { get; set; }
        public virtual ICollection<HR_Emp_ExperienceModel>? HR_Emp_Experiences { get; set; }

        public virtual HR_Emp_FamilyModel? HR_Emp_Family { get; set; }
        public virtual HR_Emp_Image? HR_Emp_Image { get; set; }
        public virtual HR_Emp_NomineeModel? HR_Emp_Nominee { get; set; }
        public virtual HR_Emp_PersonalInfoModel? HR_Emp_PersonalInfo { get; set; }
        public virtual HR_Leave_Avail? HR_Leave_Avail { get; set; }
        public virtual HR_Leave_Balance? HR_Leave_Balance { get; set; }
        public virtual HR_Emp_Increment? HR_Emp_Increment { get; set; }
        public virtual HR_Emp_BankInfo? HR_Emp_BankInfo { get; set; }

        public int? LinkUserId { get; set; }

        public virtual ICollection<Hr_RawData>? Hr_RawData { get; set; }
        public virtual ICollection<HR_RawData_App>? HR_RawData_App { get; set; }

        public virtual ICollection<HR_ProcessedData>? HR_ProcessedData { get; set; }
        public virtual ICollection<HR_AttFixed>? HR_AttFixed { get; set; }


        public virtual HR_Emp_Released? HR_Emp_Released { get; set; }


        public virtual HR_Emp_Salary? HR_Emp_Salary { get; set; }
        public virtual HR_Emp_ShiftInput? HR_Emp_ShiftInput { get; set; }



    }

}
