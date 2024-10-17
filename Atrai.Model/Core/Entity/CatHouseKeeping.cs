using Atrai.Model.Core.Entity.Base;
using Atrai.Model.Core.Entity.Self;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atrai.Model.Core.Entity
{

    //[Table("Cat_Department")]
    //public class Cat_DepartmentModel : BaseModel
    //{
    //    //public Cat_Department()
    //    //{

    //    //    Cat_Section = new HashSet<Cat_Section>();
    //    //    Cat_SubSection = new HashSet<Cat_SubSection>();
    //    //}


    //    //[Key]
    //    //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    //public int DeptId { get; set; }

    //    [Display(Name = "Department Code")]

    //    public string? DeptCode { get; set; }

    //    [Display(Name = "Department Name")]
    //    [Required(ErrorMessage = "Please Provide Department Name")]
    //    [StringLength(25)]
    //    [DataType("NVARCHAR(25)")]

    //    public string? DeptName { get; set; }

    //    [Display(Name = "Department Name Bangla")]
    //    [StringLength(25)]
    //    [DataType("NVARCHAR(25)")]
    //    public string? DeptBangla { get; set; }

    //    [Display(Name = "SL No")]
    //    public short? Slno { get; set; }

    //    [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
    //    public DateTime DtInput { get; set; }

    //    public virtual ICollection<Cat_Section> Cat_Section { get; set; }
    //    public virtual ICollection<Cat_SubSection> Cat_SubSection { get; set; }
    //}

    //[Table("Cat_Designation")]
    //public class Cat_DesignationModel : BaseModel
    //{
    //    [Display(Name = "Designation Name")]
    //    [Required(ErrorMessage = "Please Provide Designation Name")]
    //    [StringLength(25)]
    //    [DataType("NVARCHAR(25)")]
    //    public string? DesigName { get; set; }

    //    [Display(Name = "Designation Bangla")]
    //    [StringLength(25)]
    //    [DataType("NVARCHAR(25)")]
    //    public string? DesigNameB { get; set; }

    //    //[Display(Name = "Salary Range")]
    //    //[StringLength(40)]
    //    //public string? SalaryRange { get; set; }

    //    //[Display(Name = "Sl No")]
    //    //public int? SlNo { get; set; }
    //    //[Display(Name = "Minimum GS")]
    //    //[Column(TypeName = "decimal(18,2)")]
    //    //public decimal? Gsmin { get; set; }

    //    //[Display(Name = "Grade")]
    //    //public int? GradeId { get; set; }
    //    //public virtual Cat_Grade Grade { get; set; }

    //    //[Column(TypeName = "decimal(18,2)")]
    //    //public decimal AttBonus { get; set; }

    //    //[Display(Name = "Total Manpower")]
    //    //public int? TtlManpower { get; set; }

    //    //[Display(Name = "Total Manpower")]
    //    //public int? ProposedManPower { get; set; }
    //}


    [Table("Cat_Department")]

    public partial class Cat_DepartmentModel : BaseModel
    {
        public Cat_DepartmentModel()
        {
            //HrTempAttend = new HashSet<HrTempAttend>();
            //HrTempAttendMonth = new HashSet<HrTempAttendMonth>();
            //Cat_SectionModel = new HashSet<Cat_SectionModel>();
            //Cat_SubSectionModel = new HashSet<Cat_SubSectionModel>();
        }


        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int DeptId { get; set; }

        //public int ComId { get; set; }

        [Display(Name = "Department Code")]
        //[StringLength()]
        public string? DeptCode { get; set; }

        [Display(Name = "Department Name")]
        [Required(ErrorMessage = "Please Provide Department Name")]
        [StringLength(100)]
        [DataType("NVARCHAR(100)")]
        //[Remote(action: "IsExist", controller: "Department")]
        public string? DeptName { get; set; }

        [Display(Name = "Department Name Bangla")]
        [StringLength(100)]
        [DataType("NVARCHAR(100)")]
        public string? DeptBangla { get; set; }

        [Display(Name = "SL No")]
        public short? Slno { get; set; }

        public string? PcName { get; set; }
        //[StringLength(128)]
        //public string? UserId { get; set; }
        //public Nullable<System.DateTime> DateAdded { get; set; }
        //public string? UpdateByUserId { get; set; }
        //public Nullable<System.DateTime> DateUpdated { get; set; }
        //[DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DtInput { get; set; }


        //public virtual Cat_Company Com { get; set; }
        //public virtual ICollection<HrTempAttend> HrTempAttend { get; set; }
        //public virtual ICollection<HrTempAttendMonth> HrTempAttendMonth { get; set; }

        public virtual ICollection<Cat_SectionModel>? Cat_Section { get; set; }
        public virtual ICollection<Cat_SubSectionModel>? Cat_SubSection { get; set; }
    }


    [Table("Cat_Section")]
    public partial class Cat_SectionModel : BaseModel
    {
        public Cat_SectionModel()
        {
            //Cat_SubSectionModel = new HashSet<Cat_SectionModel>();
        }

        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int SectId { get; set; }

        //public int ComId { get; set; }
        [Display(Name = "Section Name")]
        [Required(ErrorMessage = "Please Provide Section Name")]
        [StringLength(100)]
        [DataType("NVARCHAR(100)")]
        public string? SectName { get; set; }

        [Display(Name = "Section Bangla")]
        [StringLength(100)]
        [DataType("NVARCHAR(100)")]
        public string? SectNameB { get; set; }

        [Display(Name = "Department")]
        public int? DeptId { get; set; }
        public virtual Cat_DepartmentModel? Dept { get; set; }

        [Display(Name = "SL NO")]
        public int Slno { get; set; }
        public DateTime DtInput { get; set; }

        public virtual ICollection<Cat_SubSectionModel>? Cat_SubSection { get; set; }
    }

    public partial class Cat_SubSectionModel : BaseModel
    {
        public Cat_SubSectionModel()
        {
            //HrTempAttend = new HashSet<HrTempAttend>();
            //HrTempAttendMonth = new HashSet<HrTempAttendMonth>();
        }
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int SubSectId { get; set; }

        //public int ComId { get; set; }
        [Display(Name = "Sub Section Name")]
        [Required(ErrorMessage = "Please Provide Sub Section Name")]
        [StringLength(100)]
        [DataType("NVARCHAR(100)")]
        public string? SubSectName { get; set; }
        [Display(Name = "Sub Section Bangla")]
        [StringLength(100)]
        [DataType("NVARCHAR(100)")]
        public string? SubSectNameB { get; set; }

        [Display(Name = "Section Name")]
        public int SectId { get; set; }
        [Display(Name = "Department Name")]
        public int DeptId { get; set; }

        [Display(Name = "SL NO")]
        public short Slno { get; set; }


        public string? PcName { get; set; }
        //[DataType("NVARCHAR(128)")]
        //public string? UserId { get; set; }
        //public Nullable<System.DateTime> DateAdded { get; set; }
        //public string? UpdateByUserId { get; set; }
        //public Nullable<System.DateTime> DateUpdated { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DtInput { get; set; }

        //public virtual Cat_Company Com { get; set; }
        [ForeignKey("DeptId")]
        public virtual Cat_DepartmentModel? Dept { get; set; }
        [ForeignKey("SectId")]

        public virtual Cat_SectionModel? Sect { get; set; }
        //public virtual ICollection<HrTempAttend> HrTempAttend { get; set; }
        //public virtual ICollection<HrTempAttendMonth> HrTempAttendMonth { get; set; }
    }


    [Table("Cat_Designation")]

    public partial class Cat_DesignationModel : BaseModel
    {
        public Cat_DesignationModel()
        {
            //HrTempAttendMonth = new HashSet<HrTempAttendMonth>();
        }
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int DesigId { get; set; }
        //public int ComId { get; set; }

        [Display(Name = "Designation Name")]
        [Required(ErrorMessage = "Please Provide Desingation Name")]
        [StringLength(100)]
        [DataType("NVARCHAR(100)")]
        public string? DesigName { get; set; }

        [Display(Name = "Designation Bangla")]
        [StringLength(100)]
        [DataType("NVARCHAR(100)")]
        public string? DesigNameB { get; set; }

        [Display(Name = "Salary Range")]
        [StringLength(100)]
        public string? SalaryRange { get; set; }

        [Display(Name = "Sl No")]
        public int? SlNo { get; set; }
        [Display(Name = "Minimum GS")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal? Gsmin { get; set; }

        [Display(Name = "Grade")]
        public int? GradeId { get; set; }
        public virtual Cat_GradeModel? Grade { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal AttBonus { get; set; }

        [Display(Name = "Total Manpower")]
        public int? TtlManpower { get; set; }

        [Display(Name = "Total Manpower")]
        public int? ProposedManPower { get; set; }


        public string? PcName { get; set; }

        //[DataType("NVARCHAR(128)")]
        //public string? UserId { get; set; }
        //public Nullable<System.DateTime> DateAdded { get; set; }
        //public string? UpdateByUserId { get; set; }
        //public Nullable<System.DateTime> DateUpdated { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DtInput { get; set; }


        //public virtual Cat_Company Com { get; set; }
        //public virtual ICollection<HrTempAttendMonth> HrTempAttendMonth { get; set; }
    }
    [Table("Cat_Grade")]

    public partial class Cat_GradeModel : BaseModel
    {

        [Display(Name = "Grade Name")]
        [Required(ErrorMessage = "Please Input Grade Name.")]
        [StringLength(25)]
        [DataType("NVARCHAR(25)")]
        public string? GradeName { get; set; }

        [Display(Name = "Grade Bangla")]
        [StringLength(25)]
        [DataType("NVARCHAR(25)")]
        public string? GradeNameB { get; set; }

        [Display(Name = "Minimum GS")]
        public double? MinGS { get; set; }

        [Display(Name = "Total Manpower")]
        public int? TtlManpower { get; set; }

        [Display(Name = "Salary Range")]
        [StringLength(30)]
        public string? SalaryRange { get; set; }

        [Display(Name = "Total Man Power Worker")]
        public int? TtlManPowerWorker { get; set; }

        [Display(Name = "SL No")]
        public int? SlNo { get; set; }

    }
    [Table("Cat_Religion")]

    public partial class Cat_ReligionModel : SelfModel
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int RelgionId { get; set; }

        [Display(Name = "Religion Name")]
        [Required(ErrorMessage = "Please Provide Religion Name")]
        [StringLength(20)]
        [DataType("NVARCHAR(20)")]
        public string? ReligionName { get; set; }

        [Display(Name = "Religion Bangla")]
        [Required(ErrorMessage = "Please Provide Religion Name Bangla")]
        [StringLength(20)]
        [DataType("NVARCHAR(20)")]
        public string? ReligionNameB { get; set; }


    }


    [Table("Cat_BloodGroup")]
    public partial class Cat_BloodGroupModel : SelfModel
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int BloodId { get; set; }

        [Display(Name = "Blood Group")]
        [Required(ErrorMessage = "Plz input Blood Group Name")]
        [StringLength(30)]
        [DataType("nvarchar(40)")]
        public string? BloodName { get; set; }

        [Display(Name = "Blood Group Bangla")]
        [Required(ErrorMessage = "Plz input Blood Group Name Bangla")]
        [StringLength(30)]
        [DataType("nvarchar(40)")]
        public string? BloodNameB { get; set; }
        //public int ComId { get; set; }


    }


    [Table("Cat_Line")]
    public partial class Cat_LineModel : BaseModel
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int LineId { get; set; }

        [Display(Name = "Line Name")]
        [Required(ErrorMessage = "Plz input Line Name")]
        [StringLength(100)]
        [DataType("nvarchar(100)")]
        public string? LineName { get; set; }

        [Display(Name = "Line Bangla")]
        [StringLength(100)]
        [DataType("nvarchar(100)")]
        public string? LineNameB { get; set; }

    }
    [Table("Cat_Shift")]
    public partial class Cat_ShiftModel : BaseModel
    {
        public Cat_ShiftModel()
        {
            //HrTempAttend = new HashSet<HrTempAttend>();
        }

        [Display(Name = "Shift Name")]
        [Required(ErrorMessage = "Please Provide Shift Name")]
        [StringLength(25)]
        [DataType("NVARCHAR(25)")]
        public string? ShiftName { get; set; }

        [Display(Name = "Shift Code")]
        [StringLength(25)]
        [DataType("NVARCHAR(25)")]
        public string? ShiftCode { get; set; }

        [Display(Name = "Shift Description")]
        [StringLength(200)]
        public string? ShiftDesc { get; set; }

        [Display(Name = "Shift In")]

        [DataType(DataType.Time), DisplayFormat(DataFormatString = @"{0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime ShiftIn { get; set; }
        [Display(Name = "Shift Out")]
        [DataType(DataType.Time), DisplayFormat(DataFormatString = @"{0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime ShiftOut { get; set; }

        [Display(Name = "Shift Late")]
        [DataType(DataType.Time), DisplayFormat(DataFormatString = @"{0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime ShiftLate { get; set; }

        [Display(Name = "Lunch Time")]
        [DataType(DataType.Time), DisplayFormat(DataFormatString = @"{0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime LunchTime { get; set; }

        [Display(Name = "Lunch In")]
        [DataType(DataType.Time), DisplayFormat(DataFormatString = @"{0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime LunchIn { get; set; }

        [Display(Name = "Lunch Out")]
        [DataType(DataType.Time), DisplayFormat(DataFormatString = @"{0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime LunchOut { get; set; }

        [Display(Name = "Tiffin Time")]
        [DataType(DataType.Time), DisplayFormat(DataFormatString = @"{0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime TiffinTime { get; set; }

        [Display(Name = "Tiffin In")]
        [DataType(DataType.Time), DisplayFormat(DataFormatString = @"{0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime TiffinIn { get; set; }


        [Display(Name = "Tiffin Out")]
        [DataType(DataType.Time), DisplayFormat(DataFormatString = @"{0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime TiffinOut { get; set; }


        [Display(Name = "Regular Hour")]
        [DataType(DataType.Time), DisplayFormat(DataFormatString = @"{0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime RegHour { get; set; }

        [Display(Name = "Shift Type")]
        public string? ShiftType { get; set; }

        [Display(Name = "Shift Cat")]
        public string? ShiftCat { get; set; }

        [Display(Name = "Is Inactive")]
        public bool IsInactive { get; set; }

        [Display(Name = "Tiffin Time 1")]
        [DataType(DataType.Time), DisplayFormat(DataFormatString = @"{0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime? TiffinTime1 { get; set; }

        [Display(Name = "Tiffin Time In 1")]
        [DataType(DataType.Time), DisplayFormat(DataFormatString = @"{0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime? TiffinTimeIn1 { get; set; }

        [Display(Name = "Tiffin Time 2")]
        [DataType(DataType.Time), DisplayFormat(DataFormatString = @"{0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime? TiffinTime2 { get; set; }

        [Display(Name = "Tiffin Time In 2")]
        [DataType(DataType.Time), DisplayFormat(DataFormatString = @"{0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime? TiffinTimeIn2 { get; set; }


        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DtInput { get; set; }

    }


    [Table("HR_Cat_Shift_SP")]
    public partial class HR_Cat_Shift_SP_Model : BaseModel
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int SP_ShiftId { get; set; }

        [Display(Name = "Shift In")]
        [DataType(DataType.Time), DisplayFormat(DataFormatString = @"{0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime ShiftIn { get; set; }

        [Display(Name = "Shift Out")]
        [DataType(DataType.Time), DisplayFormat(DataFormatString = @"{0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime ShiftOut { get; set; }

        [Display(Name = "Shift Late")]
        [DataType(DataType.Time), DisplayFormat(DataFormatString = @"{0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime ShiftLate { get; set; }

        [Display(Name = "Regular Hour")]
        [DataType(DataType.Time), DisplayFormat(DataFormatString = @"{0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime RegHour { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ShiftDate { get; set; }

        //Foreing key
        [ForeignKey("Cat_Shift")]
        public int ShiftId { get; set; }

        public virtual Cat_ShiftModel? Cat_Shift { get; set; }

    }

    [Table("Cat_Floor")]
    public partial class Cat_FloorModel : BaseModel
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int FloorId { get; set; }

        [Display(Name = "Floor Name")]
        [Required(ErrorMessage = "Plz input Floor Name")]
        [StringLength(100)]
        [DataType("nvarchar(100)")]
        public string? FloorName { get; set; }

        [Display(Name = "Floor Bangla")]
        [StringLength(100)]
        [DataType("nvarchar(100)")]
        public string? FloorNameB { get; set; }


    }
    [Table("Cat_Unit")]
    public partial class Cat_UnitModel : BaseModel
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int UnitId { get; set; }

        [Display(Name = "Unit Name")]
        [Required(ErrorMessage = "Plz input Unit Name")]
        [StringLength(100)]
        [DataType("nvarchar(100)")]
        public string? UnitName { get; set; }

        [Display(Name = "Short Name")]
        [StringLength(100)]
        [DataType("nvarchar(100)")]
        public string? UnitShortName { get; set; }

        [Display(Name = "Unit Bangla")]
        [StringLength(100)]
        [DataType("nvarchar(100)")]
        public string? UnitNameB { get; set; }

    }


    [Table("Cat_District")]
    public partial class Cat_DistrictModel : BaseModel
    {

        [Display(Name = "District Name")]
        [Required(ErrorMessage = "Please Provide District Name")]
        [StringLength(25)]
        [DataType("NVARCHAR(25)")]
        public string? DistName { get; set; }

        [Display(Name = "District Bangla")]
        [Required(ErrorMessage = "Please Provide District Name Bangla")]
        [StringLength(25)]
        [DataType("NVARCHAR(25)")]
        public string? DistNameB { get; set; }

        [Display(Name = "Short Name")]
        [StringLength(15)]
        [DataType("NVARCHAR(15)")]
        public string? DistNameShort { get; set; }

        [Display(Name = "SL No")]
        public int? SL { get; set; }


        //public int? CountryId { get; set; }
        //public virtual Cat_Country Country { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DtInput { get; set; }
        //public virtual ICollection<DistictBuffer> DistictBufferList { get; set; }

        //public virtual ICollection<Cat_PoliceStation> Cat_PoliceStations { get; set; }
        //public virtual ICollection<Cat_Employee> Cat_Employee { get; set; }
    }

    [Table("Cat_PoliceStation")]
    public partial class Cat_PoliceStationModel : SelfModel
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int PStationId { get; set; }

        [Display(Name = "Police Station Name")]
        [Required(ErrorMessage = "Plz input Police Station Name")]
        [StringLength(30)]
        [DataType("nvarchar(30)")]
        public string? PStationName { get; set; }

        [Display(Name = "Police Station Bangla")]
        [StringLength(30)]
        [DataType("nvarchar(25)")]
        public string? PStationNameB { get; set; }

        [Display(Name = "District")]
        public int DistId { get; set; }
        [ForeignKey("DistId")]
        public virtual Cat_DistrictModel Cat_District { get; set; }


    }


    [Table("Cat_BusStop")]
    public partial class Cat_BusStopModel : BaseModel
    {

        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int BusStopId { get; set; }

        [Display(Name = "Bus Stop Name")]
        [Required(ErrorMessage = "Please Provide Bus Stop Name")]
        [StringLength(25)]
        [DataType("NVARCHAR(25)")]
        public string? BusStopName { get; set; }

        public float Rate { get; set; }

        [StringLength(150)]
        [DataType(DataType.MultilineText)]
        public string? Remarks { get; set; }

        public bool IsInactive { get; set; }


    }

    public partial class Cat_ExchangeRateModel : BaseModel
    {

        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int ExChangeId { get; set; }

        [Display(Name = "Exchange Rate")]
        [Required(ErrorMessage = "Please provide Exchange Rate")]
        //[StringLength(25)]
        //[DataType("NVARCHAR(25)")]
        public float ExchangeRate { get; set; }



        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date")]
        public DateTime? DtInput { get; set; }

    }

    public partial class Cat_IncenBandModel : BaseModel
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int InBId { get; set; }

        [Display(Name = "IncenBand Name")]
        [Required(ErrorMessage = "Please Input Grade Name.")]
        [StringLength(25)]
        [DataType("NVARCHAR(25)")]
        public string? IncenBandName { get; set; }

        [Display(Name = "Remarks")]
        [StringLength(25)]
        [DataType(DataType.MultilineText)]
        public string? Remarks { get; set; }

        [Display(Name = "SLNO")]
        public int SlNo { get; set; }

        [Display(Name = "IsInactive")]
        public bool IsInactive { get; set; }

    }

    public partial class Cat_CatagoryModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CatId { get; set; }

        [Display(Name = "Catagory Name")]
        [Required(ErrorMessage = "Please Input Category Name.")]
        [StringLength(25)]
        [DataType("NVARCHAR(25)")]
        public string? CatName { get; set; }

        [Display(Name = "Remarks")]
        [StringLength(25)]
        [DataType(DataType.MultilineText)]
        public string? Remarks { get; set; }

        [Display(Name = "SLNO")]
        public int SlNo { get; set; }

        [Display(Name = "IsInactive")]
        public bool IsInactive { get; set; }

        //public int ComId { get; set; }

        [StringLength(25)]
        public string? PcName { get; set; }
        [DataType("NVARCHAR(128)")]
        public string? UserId { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public string? UpdateByUserId { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }

    }

    public partial class Cat_InsurGradeModel : BaseModel
    {

        [Display(Name = "InSurance Grade Name")]
        [Required(ErrorMessage = "Please Input Grade Name.")]
        [StringLength(25)]
        [DataType("NVARCHAR(25)")]
        public string? InSurGrade { get; set; }

        [Display(Name = "Amount")]
        public int Amount { get; set; }

        [Display(Name = "Remarks")]
        [StringLength(25)]
        [DataType(DataType.MultilineText)]
        public string? Remarks { get; set; }

        [Display(Name = "SLNO")]
        public int SlNo { get; set; }

        [Display(Name = "IsInactive")]
        public bool IsInactive { get; set; }

    }



    public partial class Cat_AreaModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short AreaId { get; set; }
        public string? AreaName { get; set; }
        public string? AreaNameShort { get; set; }
        public string? AreaCode { get; set; }

        //public short? CountryId { get; set; }

        public string? Pcname { get; set; }
        public string? UserId { get; set; }
        public int ComId { get; set; }

        //public virtual Cat_Country Country { get; set; }
    }

    //public partial class Cat_Article
    //{
    //    public Cat_Article()
    //    {
    //        //TblStrBomArticle = new HashSet<TblStrBomArticle>();
    //        //TblStrChemicalBatchMain = new HashSet<TblStrChemicalBatchMain>();
    //        //TblStrPuArticle = new HashSet<TblStrPuArticle>();
    //    }

    //    public int ComId { get; set; }
    //    [Key]
    //    public int ArticleId { get; set; }
    //    public string? ArticleNo { get; set; }
    //    public string? ArticleName { get; set; }
    //    public short BuyerId { get; set; }
    //    public short ColorId { get; set; }
    //    public string? Iman { get; set; }
    //    public string? StandSize { get; set; }
    //    public string? SizeRange { get; set; }
    //    public float MatOrdExess { get; set; }
    //    public string? UserId { get; set; }
    //    public string? Pcname { get; set; }



    //    public string? MouldName { get; set; }
    //    public string? PackingAssort { get; set; }
    //    public string? MouldCode { get; set; }
    //    public string? ArtImageName { get; set; }
    //    public string? Remarks { get; set; }

    //    public virtual Cat_Buyer Buyer { get; set; }
    //    public virtual Cat_Color Color { get; set; }
    //    public virtual Cat_Company Com { get; set; }
    //    //public virtual ICollection<TblStrBomArticle> TblStrBomArticle { get; set; }
    //    //public virtual ICollection<TblStrChemicalBatchMain> TblStrChemicalBatchMain { get; set; }
    //    //public virtual ICollection<TblStrPuArticle> TblStrPuArticle { get; set; }
    //}
    [Table("Cat_Bank")]
    public partial class Cat_BankModel : BaseModel
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int BankId { get; set; }

        [Display(Name = "Bank Name")]
        [Required(ErrorMessage = "Please input Bank Name")]
        [StringLength(60)]
        [DataType("nvarchar(60)")]
        public string? BankName { get; set; }

        [Display(Name = "Short Name")]
        [StringLength(40)]
        [DataType("nvarchar(40)")]
        public string? BankShortName { get; set; }

        [Display(Name = "Bank Address")]
        [StringLength(250)]
        [DataType("nvarchar(250)")]
        public string? BankAddress { get; set; }

    }

    [Table("Cat_BankBranch")]
    public partial class Cat_BankBranchModel : BaseModel
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int BranchId { get; set; }

        [Display(Name = "Branch Name")]
        [Required(ErrorMessage = "Please input Branch Name")]
        [StringLength(70)]
        [DataType("nvarchar(70)")]
        public string? BranchName { get; set; }

        [Display(Name = "Branch Address")]
        [StringLength(250)]
        [DataType("nvarchar(250)")]
        public string? BranchAddress { get; set; }

    }

    [Table("Cat_PayMode")]
    public partial class Cat_PayModeModel : SelfModel
    {

        [Display(Name = "Pay Mode")]
        [StringLength(25)]
        public string? PayModeName { get; set; }
    }
    [Table("Cat_AccountType")]
    public partial class Cat_AccountTypeModel : SelfModel
    {
        [Display(Name = "Account Type")]
        [StringLength(25)]
        public string? AccTypeName { get; set; }
    }

    //public partial class Cat_Bomtype
    //{
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public short BomtypeId { get; set; }
    //    public string? BomtypeName { get; set; }
    //    public string? Pcname { get; set; }
    //    public string? UserId { get; set; }

    //    public short Slno { get; set; }

    //    public int ComId { get; set; }

    //    public virtual Cat_Company Com { get; set; }
    //}

    //public partial class Cat_Business
    //{
    //    public int ComId { get; set; }

    //    public short Buid { get; set; }
    //    public string? Buname { get; set; }
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public int AId { get; set; }
    //    public short Cpid { get; set; }
    //    public string? Cpname { get; set; }
    //    public string? Pcname { get; set; }
    //    public string? UserId { get; set; }

    //    public virtual Cat_Company Com { get; set; }
    //}


    //public partial class Cat_Buyer
    //{
    //    public Cat_Buyer()
    //    {
    //        Cat_Article = new HashSet<Cat_Article>();
    //        //TblOrderMain = new HashSet<TblOrderMain>();
    //        //TblStrReplaceSub1 = new HashSet<TblStrReplaceSub1>();
    //    }

    //    public short BuyerId { get; set; }
    //    public string? BuyerCode { get; set; }
    //    public string? BuyerName { get; set; }
    //    public string? BuyerNameShort { get; set; }
    //    public string? AddBiz { get; set; }
    //    public string? AddShip { get; set; }
    //    public string? Phone { get; set; }
    //    public string? Mobile { get; set; }
    //    public string? Fax { get; set; }
    //    public string? Email { get; set; }
    //    public string? Web { get; set; }
    //    public short CountryId { get; set; }
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]


    //    public string? Pcname { get; set; }
    //    public string? UserId { get; set; }
    //    public int ComId { get; set; }
    //    public byte IsInactive { get; set; }
    //    public string? BuyerGroup { get; set; }

    //    public virtual Cat_Company Com { get; set; }
    //    public virtual ICollection<Cat_Article> Cat_Article { get; set; }
    //    //public virtual ICollection<TblOrderMain> TblOrderMain { get; set; }
    //    //public virtual ICollection<TblStrReplaceSub1> TblStrReplaceSub1 { get; set; }
    //}

    //public partial class Cat_BuyerCont
    //{
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public int? AId { get; set; }
    //    public int? BuyerId { get; set; }
    //    public string? Contperson { get; set; }
    //    public string? Cat_Designation { get; set; }
    //    public string? ContNo { get; set; }
    //    public string? EMail { get; set; }
    //    public byte? Contid { get; set; }
    //    public Guid? Wid { get; set; }
    //    public int ComId { get; set; }
    //    public byte? RowNo { get; set; }

    //    public virtual Cat_Company Com { get; set; }
    //}

    //public partial class Cat_Cadre
    //{
    //    public int ComId { get; set; }
    //    public int Cdid { get; set; }
    //    public string? Position { get; set; }
    //    public string? IdealSet { get; set; }
    //    public short? Mcdid { get; set; }
    //    public string? Mposition { get; set; }
    //    public string? Remarks { get; set; }
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public int AId { get; set; }
    //    public string? Pcname { get; set; }
    //    public string? UserId { get; set; }

    //    public virtual Cat_Company Com { get; set; }
    //}

    //public partial class Cat_CadreHeader
    //{
    //    public int ComId { get; set; }
    //    public int Mcdid { get; set; }
    //    public string? Mposition { get; set; }
    //    public string? Remarks { get; set; }
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public int AId { get; set; }
    //    public string? Pcname { get; set; }
    //    public string? UserId { get; set; }

    //    public virtual Cat_Company Com { get; set; }
    //}

    //public partial class Cat_CadreUnit
    //{
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public int AId { get; set; }
    //    public int ComId { get; set; }
    //    public int Cdid { get; set; }
    //    public string? Position { get; set; }
    //    public string? IdealSet { get; set; }
    //    public short? Mcdid { get; set; }
    //    public string? Mposition { get; set; }
    //    public string? Remarks { get; set; }
    //    public int Ideal { get; set; }

    //    public string? Pcname { get; set; }
    //    public string? UserId { get; set; }

    //    public virtual Cat_Company Com { get; set; }
    //}

    public partial class Cat_ColorModel : BaseModel
    {
        public Cat_ColorModel()
        {

            Cat_Sizes = new HashSet<Cat_SizeModel>();
        }
        public string? ColorName { get; set; }
        public string? ColorCode { get; set; }
        [ForeignKey("Cat_Style")]
        public int? StyleId { get; set; }

        //navigation
        public virtual ICollection<Cat_SizeModel> Cat_Sizes { get; set; }
        public virtual Cat_StyleModel Cat_Style { get; set; }

    }

    //public partial class Cat_Company
    //{


    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public int ComId { get; set; }
    //    public string? ComCode { get; set; }
    //    public string? ComName { get; set; }
    //    public string? ComNameB { get; set; }
    //    public string? ComNameAvro { get; set; }
    //    public string? ComAddress { get; set; }
    //    public string? ComAddressB { get; set; }
    //    public string? ComAddress2 { get; set; }
    //    public string? ComAddress2B { get; set; }
    //    public string? ComPhone { get; set; }
    //    public string? ComPhone2 { get; set; }
    //    public string? ComFax { get; set; }
    //    public string? ComEmail { get; set; }
    //    public string? ComWeb { get; set; }
    //    public string? ComType { get; set; }
    //    public string? ComAlias { get; set; }
    //    public string? ComFinYear { get; set; }
    //    public string? Description { get; set; }
    //    public string? ContPerson { get; set; }
    //    public string? ContDesig { get; set; }
    //    public byte IsGroup { get; set; }
    //    public byte IsShowCurrencySymbol { get; set; }
    //    public byte IsShowZeroBalance { get; set; }
    //    public byte IsInactive { get; set; }
    //    public string? ImgName { get; set; }
    //    public string? ImgName2 { get; set; }

    //    public string? ComMain { get; set; }
    //    public byte? ComMainId { get; set; }
    //    public byte? IsVoucherChange { get; set; }
    //    public byte? IsCat_SubSection { get; set; }
    //    public byte? IsMultiCurrency { get; set; }
    //    public byte? IsChequeNo { get; set; }
    //    public string? ComShortName { get; set; }
    //    public int? Processforproductid { get; set; }

    //    public virtual ICollection<HrAttFixed> HrAttFixed { get; set; }
    //    public virtual ICollection<HrEarnLeave> HrEarnLeave { get; set; }
    //    public virtual ICollection<HrEmpIncr> HrEmpIncr { get; set; }
    //    public virtual ICollection<EmployeeModel> HR_Emp_Info { get; set; }
    //    public virtual ICollection<HrEmpInfoBangla> HR_Emp_InfoBangla { get; set; }
    //    public virtual ICollection<HR_Emp_Released> HrEmpReleased { get; set; }
    //    public virtual ICollection<HR_Emp_Salary> HrEmpSalary { get; set; }
    //    public virtual ICollection<HrEmpShift> HrEmpShift { get; set; }
    //    public virtual ICollection<HrLeaveAvail> HrLeaveAvail { get; set; }

    //    public virtual ICollection<HrTemp> HrTemp { get; set; }
    //    public virtual ICollection<HrTempAttend> HrTempAttend { get; set; }
    //    public virtual ICollection<HrTempAttendMonth> HrTempAttendMonth { get; set; }
    //    public virtual ICollection<HrTempElBalance> HrTempElBalance { get; set; }
    //    public virtual ICollection<HrTempEmp> HrTempEmp { get; set; }
    //    public virtual ICollection<HrWeekday> HrWeekday { get; set; }
    //    public virtual ICollection<Cat_Article> Cat_Article { get; set; }
    //    public virtual ICollection<Cat_Bomtype> Cat_Bomtype { get; set; }
    //    public virtual ICollection<Cat_BusStop> Cat_BusStop { get; set; }
    //    public virtual ICollection<Cat_Business> Cat_Business { get; set; }
    //    public virtual ICollection<Cat_Buyer> Cat_Buyer { get; set; }
    //    public virtual ICollection<Cat_BuyerCont> Cat_BuyerCont { get; set; }
    //    public virtual ICollection<Cat_Cadre> Cat_Cadre { get; set; }
    //    public virtual ICollection<Cat_CadreHeader> Cat_CadreHeader { get; set; }
    //    public virtual ICollection<Cat_CadreUnit> Cat_CadreUnit { get; set; }


    //    public virtual ICollection<Cat_Currency> Cat_Currency { get; set; }
    //    public virtual ICollection<Cat_DepartmentModel> Cat_Department { get; set; }
    //    public virtual ICollection<Cat_DesignationModel> Desig { get; set; }
    //    public virtual ICollection<Cat_Employee> Cat_Employee { get; set; }
    //    public virtual ICollection<Cat_ExchangeRate> Cat_ExchangeRate { get; set; }
    //    public virtual ICollection<Cat_Shift> Cat_Shift { get; set; }
    //    public virtual ICollection<Cat_SubSectionModel>? Cat_SubSection { get; set; }
    //    //public virtual ICollection<TblExtraOtofficer> TblExtraOtofficer { get; set; }
    //    //public virtual ICollection<TblOtpermission> TblOtpermission { get; set; }
    //    //public virtual ICollection<TblProcessedDataSal> TblProcessedDataSal { get; set; }
    //    //public virtual ICollection<TblProcessedDataTemp> TblProcessedDataTemp { get; set; }
    //    //public virtual ICollection<TblSalArrear> TblSalArrear { get; set; }
    //    //public virtual ICollection<TblSalDue> TblSalDue { get; set; }
    //    //public virtual ICollection<TblSalIncomeTax> TblSalIncomeTax { get; set; }
    //    //public virtual ICollection<TblUserCompany> TblUserCompany { get; set; }
    //}


    public partial class Cat_Country : SelfModel
    {
        public Cat_Country()
        {
            Cat_Area = new HashSet<Cat_AreaModel>();
            Cat_District = new HashSet<Cat_DistrictModel>();
        }

        public string? CountryCode { get; set; }
        public string? CountryName { get; set; }
        public string? CountrySname { get; set; }
        public string? TimeDifference { get; set; }
        public string? CurrName { get; set; }
        public string? CurrSname { get; set; }
        public byte IsLocal { get; set; }

        public string? Pcname { get; set; }
        public string? UserId { get; set; }
        public virtual ICollection<Cat_AreaModel> Cat_Area { get; set; }
        public virtual ICollection<Cat_DistrictModel> Cat_District { get; set; }
    }

    //public partial class Cat_Currency
    //{
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public byte CurrencyId { get; set; }
    //    public string? CurrencyName { get; set; }
    //    public Guid? Wid { get; set; }
    //    public int ComId { get; set; }
    //    public string? UserId { get; set; }

    //    public virtual Cat_Company Com { get; set; }
    //}

    public partial class Cat_Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CustId { get; set; }
        public int AreaId { get; set; }
        public int ZoneId { get; set; }
        public string? CustCode { get; set; }
        public string? CustName { get; set; }
        public int CtypeId { get; set; }
        public string? SrtName { get; set; }
        public string? ContPerson { get; set; }
        public string? Cat_Designation { get; set; }
        public string? OrgName { get; set; }
        public string? OrgType { get; set; }
        public string? OrgAddress { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        public double OpAmount { get; set; }
        public byte IsAllowCredit { get; set; }
        public int SalesRefId { get; set; }
        public double FreeBagBalance { get; set; }
        public int? AccId { get; set; }
        public int ComId { get; set; }
        public DateTime? DtOpen { get; set; }
        public long SalAccId { get; set; }
        public byte? IsAllowComission { get; set; }
        public int? AreaInchargeId { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal? CreditLimit { get; set; }
        public int? Loctionid { get; set; }
        public int? Locationid { get; set; }
        public string? Bdapprvdno { get; set; }
        public string? UsFdaregNo { get; set; }

        public virtual Cat_CustomerType Ctype { get; set; }
    }

    public partial class Cat_CustomerInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Custid { get; set; }
        public string? Custcode { get; set; }
        public string? Custname { get; set; }
        public string? Srtname { get; set; }
        public int AreaId { get; set; }
        public string? BussAdd { get; set; }
        public string? Billto { get; set; }
        public string? Shipto { get; set; }
        public string? Warehouse { get; set; }
        public string? Home { get; set; }
        public string? Legal { get; set; }
        public string? Postal { get; set; }
        public string? Other { get; set; }
        public int? Isinactive { get; set; }
        public DateTime? CustSince { get; set; }
        public string? Currency { get; set; }
        public string? Balance { get; set; }
        public DateTime? BalanceAsOf { get; set; }
        public string? BusPhone { get; set; }
        public string? Mobile { get; set; }
        public string? AssistantPhone { get; set; }
        public string? OtherPhone { get; set; }
        public string? BusinessFax { get; set; }
        public string? OtherFax { get; set; }
        public string? Email1 { get; set; }
        public string? Email2 { get; set; }
        public string? WebPageAddress { get; set; }
        public string? SalesPerson { get; set; }
        public string? SalesBalance { get; set; }
        public string? FinCreditLimit { get; set; }
        public string? FinPriceLevel { get; set; }
        public string? FinCreditRating { get; set; }
        public string? PreShipMet { get; set; }
        public string? PrePayMet { get; set; }
        public string? PaymentTerms { get; set; }
        public string? CustGroup { get; set; }
        public string? Logo { get; set; }
        public string? TaxGroup { get; set; }
        public string? CustStatus { get; set; }
        public string? Zone { get; set; }


        public string? BussType { get; set; }
        public DateTime DtStatusUpdate { get; set; }
        public byte IsHideInClist { get; set; }
        public byte UnderComId { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal? AdjAmount { get; set; }
        public DateTime? DtQrcodeGen { get; set; }
        public byte IsQrcodeGen { get; set; }
    }

    public partial class Cat_CustomerType
    {
        public Cat_CustomerType()
        {
            Cat_Customer = new HashSet<Cat_Customer>();
        }


        public string? CtypeName { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CtypeId { get; set; }

        public DateTime? DtOrder { get; set; }
        public int? Priority { get; set; }

        public virtual ICollection<Cat_Customer> Cat_Customer { get; set; }
    }

    public partial class Cat_DeliverySite
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DsiteId { get; set; }
        public string? DsiteName { get; set; }

        public string? Pcname { get; set; }
        public string? UserId { get; set; }
        public byte? Comid { get; set; }
    }



    public partial class Cat_DepartmentOhid
    {
        public int ComId { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeptId { get; set; }
        public string? DeptCode { get; set; }
        public string? DeptName { get; set; }

        public string? Pcname { get; set; }
        public string? UserId { get; set; }
        public string? DeptBangla { get; set; }
        public short? Slno { get; set; }
        public int? ParentId { get; set; }
        public short? Buid { get; set; }
        public string? Buname { get; set; }
        public string? DptSrtName { get; set; }
        public byte? IsStrDpt { get; set; }
    }



    public partial class DesigCapacity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short DesigId { get; set; }
        public int ComId { get; set; }
        public short DeptId { get; set; }
        public short SectId { get; set; }

        public string? DesigName { get; set; }
        public string? Band { get; set; }
        public short? Capacity { get; set; }
        public byte? IsInactive { get; set; }

        public string? Pcname { get; set; }
        public string? UserId { get; set; }

    }

    public partial class Cat_Directory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AId { get; set; }
        public string? DirApp { get; set; }
        public string? DirGtr { get; set; }
        public string? DirReport { get; set; }
        public string? DirTemp { get; set; }
        public string? DirPic { get; set; }
        public string? Flag { get; set; }
    }



    public partial class Cat_Doctor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DrId { get; set; }
        public string? Name { get; set; }
        public string? Degree { get; set; }
        public string? RegNo { get; set; }
        public string? MobileNo { get; set; }
        public string? Pcname { get; set; }
        public string? UserId { get; set; }
    }



    [Table("Cat_Leave_Type")]
    public partial class Cat_Leave_TypeModel : SelfModel
    {

        [Display(Name = "Leave Type")]
        [Required(ErrorMessage = "Please Provide Leave Type.")]

        [StringLength(25)]
        public string? LTypeName { get; set; }

        [Display(Name = "Short Name")]
        [StringLength(5)]
        public string? LTypeNameShort { get; set; }

        [Display(Name = "Leave Days")]
        public float? LDays { get; set; }
    }




    //public partial class Cat_Machine
    //{
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public int MachineId { get; set; }
    //    public string? MachineName { get; set; }
    //    public int DeptId { get; set; }
    //    public string? Remarks { get; set; }
    //    public int ComId { get; set; }
    //    public string? UserId { get; set; }
    //    public string? Pcname { get; set; }


    //    public string? MachineCode { get; set; }
    //    public string? MachineSpec { get; set; }
    //    public int? SubSectId { get; set; }
    //    public double? PrdCapacity { get; set; }
    //    public int? PrdCapacityUnitId { get; set; }
    //}

    public partial class Cat_MonthName
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short MonthId { get; set; }
        public string? MonthName { get; set; }
        public string? MonthNameB { get; set; }
        public int YearName { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public byte TotalDays { get; set; }
        public byte MonthSl { get; set; }
        public byte LockAttend { get; set; }
        public byte LockSalary { get; set; }
        public byte LockOt { get; set; }
        public byte LockBonus { get; set; }
        public byte LockIncrement { get; set; }

    }

    public partial class Cat_Operation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AId { get; set; }
        public string? Operation { get; set; }
        public string? Pcname { get; set; }
        public string? UserId { get; set; }
    }


    [Table("Cat_PostOffice")]
    public partial class Cat_PostOfficeModel : SelfModel
    {

        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int POId { get; set; }

        [Display(Name = "Post Office Name")]
        [Required(ErrorMessage = "Plz input Post Office Name")]
        [StringLength(40)]
        [DataType("nvarchar(40)")]
        public string? POName { get; set; }

        [Display(Name = "Post Office Code")]
        [StringLength(40)]
        [DataType("nvarchar(40)")]
        public string? POCode { get; set; }

        [Display(Name = "Post Office Bangla")]
        [StringLength(40)]
        [DataType("nvarchar(40)")]
        public string? PONameB { get; set; }

        [Display(Name = "District")]
        public int DistId { get; set; }
        [ForeignKey("DistId")]
        public virtual Cat_DistrictModel Cat_District { get; set; }

        [Display(Name = "Police Station")]
        public int? PStationId { get; set; }
        [ForeignKey("PStationId")]
        public virtual Cat_PoliceStationModel Cat_PoliceStation { get; set; }



    }


    [Table("Cat_Skill")]
    public partial class Cat_SkillModel : BaseModel
    {

        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int SkillId { get; set; }

        [Display(Name = "Skill Name")]
        [StringLength(40)]
        [Required]
        public string? SkillName { get; set; }

        [Display(Name = "Sikill Name Bangla")]
        [StringLength(40)]
        [DataType("nvarchar(40)")]
        public string? SkillNameB { get; set; }

    }

    public partial class Cat_ProdCategory
    {
        public Cat_ProdCategory()
        {
            Cat_ProdSubCategory = new HashSet<Cat_ProdSubCategory>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short ProdCatId { get; set; }
        public string? ProdCatName { get; set; }
        public string? Pcname { get; set; }
        public string? UserId { get; set; }


        public int ComId { get; set; }

        public virtual ICollection<Cat_ProdSubCategory> Cat_ProdSubCategory { get; set; }
        //public virtual ICollection<TblStrProduct> TblStrProduct { get; set; }
    }

    public partial class Cat_ProdSubCategory
    {
        public Cat_ProdSubCategory()
        {
            //TblStrProduct = new HashSet<TblStrProduct>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProdScatId { get; set; }
        public string? ProdScatName { get; set; }
        public short ProdCatId { get; set; }
        public string? UserId { get; set; }
        public string? Pcname { get; set; }


        public string? PurchaseType { get; set; }
        public int ComId { get; set; }
        public int? Scslno { get; set; }

        public virtual Cat_ProdCategory ProdCat { get; set; }
        //public virtual ICollection<TblStrProduct> TblStrProduct { get; set; }
    }

    public partial class Cat_RowColour
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short RowColourId { get; set; }
        public string? RowColourName { get; set; }
        public string? Pcname { get; set; }
        public string? UserId { get; set; }

        public short Slno { get; set; }

        public int ComId { get; set; }
    }

    public partial class Cat_SalaryPerType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public byte SalId { get; set; }
        public string? SalPerType { get; set; }
        public string? Pcname { get; set; }
        public string? UserId { get; set; }
    }

    public partial class Cat_ScratchCard
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? ScratchCardId { get; set; }
        public string? ScratchCardname { get; set; }

        public int ComId { get; set; }
        public Guid? WId { get; set; }
        public string? Pcname { get; set; }
        public string? UserId { get; set; }
        public string? ScratchCardCode { get; set; }
    }






    [Table("Cat_ShiftNight")]
    public partial class Cat_ShiftNightModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short ShiftId { get; set; }
        public string? ShiftCode { get; set; }
        public string? ShiftName { get; set; }
        public string? ShiftDesc { get; set; }
        public DateTime ShiftIn { get; set; }
        public DateTime ShiftOut { get; set; }
        public DateTime ShiftLate { get; set; }
        public DateTime LunchTime { get; set; }
        public DateTime LunchIn { get; set; }
        public DateTime LunchOut { get; set; }
        public DateTime TiffinTime { get; set; }
        public DateTime TiffinIn { get; set; }
        public DateTime TiffinOut { get; set; }
        public DateTime RegHour { get; set; }
        public string? ShiftType { get; set; }
        public string? ShiftCat { get; set; }
        public byte IsInactive { get; set; }


        public string? Pcname { get; set; }
        public string? UserId { get; set; }
        public byte? ComId { get; set; }
    }

    [Table("Cat_ShiftRamadanModel")]
    public partial class Cat_ShiftRamadanModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short ShiftId { get; set; }
        public string? ShiftCode { get; set; }
        public string? ShiftName { get; set; }
        public string? ShiftDesc { get; set; }
        public DateTime ShiftIn { get; set; }
        public DateTime ShiftOut { get; set; }
        public DateTime ShiftLate { get; set; }
        public DateTime LunchTime { get; set; }
        public DateTime LunchIn { get; set; }
        public DateTime LunchOut { get; set; }
        public DateTime TiffinTime { get; set; }
        public DateTime TiffinIn { get; set; }
        public DateTime TiffinOut { get; set; }
        public DateTime RegHour { get; set; }
        public string? ShiftType { get; set; }
        public string? ShiftCat { get; set; }
        public byte IsInactive { get; set; }


        public string? Pcname { get; set; }
        public string? UserId { get; set; }
        public byte? ComId { get; set; }
        public DateTime? TiffinTime1 { get; set; }
        public DateTime? TiffinTimeIn1 { get; set; }
        public DateTime? TiffinTime2 { get; set; }
        public DateTime? TiffinTimeIn2 { get; set; }
    }

    public partial class Cat_SizeModel : BaseModel
    {

        public string? SizeName { get; set; }

        // FK
        [ForeignKey("Cat_Color")]
        public int? ColorId { get; set; }


        // navigation
        public virtual Cat_ColorModel Cat_Color { get; set; }
        //public virtual ICollection<TblStrArticleSizeSub> TblStrArticleSizeSub { get; set; }
        //public virtual ICollection<TblStrExtraOrderSub> TblStrExtraOrderSub { get; set; }
        //public virtual ICollection<TblStrOrderSub> TblStrOrderSub { get; set; }
    }

    public partial class Cat_SpecTypeModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short SpecTypeId { get; set; }
        public string? SpecTypeName { get; set; }
        public string? Pcname { get; set; }
        public string? UserId { get; set; }
        public int ComId { get; set; }
    }

    public partial class Cat_StyleModel : BaseModel
    {

        [Display(Name = "Style Name")]
        [Required(ErrorMessage = "Please Input Style Name.")]
        [StringLength(50)]
        [DataType("NVARCHAR(50)")]
        public string? StyleName { get; set; }

        [Display(Name = "Style Name Bangla")]
        [StringLength(50)]
        [DataType("NVARCHAR(50)")]
        public string? StyleNameB { get; set; }

        [Display(Name = "Amount")]
        [Required(ErrorMessage = "Please Input Amount.")]
        public float Rate { get; set; }

        [Display(Name = "Style Type")]
        public string? StyleType { get; set; }

        [Display(Name = "DSL")]
        public int? DSLNo { get; set; }

        [Display(Name = "GS Min")]
        public float? GSMin { get; set; }
        //public int ComId { get; set; }


        public string? Color { get; set; }
        public string? Size { get; set; }
        [DataType(DataType.Date)]
        public DateTime StyleDate { get; set; }
        public bool IsFixedRate { get; set; }

    }



    public partial class Cat_Supplier
    {
        public Cat_Supplier()
        {
            //TblStrProductDistribution = new HashSet<TblStrProductDistribution>();
            //TblStrProductSupplier = new HashSet<TblStrProductSupplier>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SupplierId { get; set; }
        public string? SupplierCode { get; set; }
        public string? SupplierName { get; set; }
        public string? SupplierNameShort { get; set; }
        public string? AddBiz { get; set; }
        public string? AddShip { get; set; }
        public string? Phone { get; set; }
        public string? Mobile { get; set; }
        public string? Fax { get; set; }
        public string? Email { get; set; }
        public string? Web { get; set; }
        public short CountryId { get; set; }


        public string? Pcname { get; set; }
        public string? UserId { get; set; }
        public byte? Comid { get; set; }
        public byte? IsInactive { get; set; }
        public int? AccId { get; set; }

        //public virtual ICollection<TblStrProductDistribution> TblStrProductDistribution { get; set; }
        //public virtual ICollection<TblStrProductSupplier> TblStrProductSupplier { get; set; }
    }

    public partial class Cat_SupplierCont
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int? SupplierId { get; set; }
        public string? Contperson { get; set; }
        public string? Cat_Designation { get; set; }
        public string? ContNo { get; set; }
        public string? EMail { get; set; }
        public byte? Contid { get; set; }
        public Guid? Wid { get; set; }
        public byte? Comid { get; set; }
        public byte? RowNo { get; set; }
    }

    public partial class Cat_Terms
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TermsId { get; set; }
        public string? TermsType { get; set; }
        public string? TermsData { get; set; }
        public string? UserId { get; set; }
        public string? Pcname { get; set; }


    }

    public partial class Cat_TermsMain
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TermsId { get; set; }
        public string? TermsType { get; set; }
        public string? UserId { get; set; }
        public string? Pcname { get; set; }

        public byte? ComId { get; set; }
    }

    public partial class Cat_TermsSub
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TermsId { get; set; }
        public string? TermsData { get; set; }
        public int? RowNo { get; set; }


    }

    public partial class Cat_Tiffin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CatTiffinId { get; set; }
        public string? DesigName { get; set; }
        public byte PaidBothShift { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal ShiftAmount { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal GenAmount { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal ShiftAllow { get; set; }
        public string? Pcname { get; set; }
        public string? UserId { get; set; }
    }

    public partial class Cat_Truck
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Truckid { get; set; }
        public string? TruckNo { get; set; }
        public int? TruckTypeId { get; set; }
        public Guid? Wid { get; set; }
        public byte? Comid { get; set; }
        public int? Userid { get; set; }
        public string? TruckTypeNoNeed { get; set; }
    }

    public partial class Cat_TruckChallanBillVoucher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long TruckChallanBillId { get; set; }
        public long Doid { get; set; }
        public string? Dono { get; set; }
        public long CustId { get; set; }
        public DateTime DtDate { get; set; }
        public double Qty { get; set; }
        public double Aramount { get; set; }
        public double SalesVatamt { get; set; }
        public double CompRate { get; set; }
        public double SalesRate { get; set; }
        public double Vat { get; set; }
        public double Carrying { get; set; }
        public double Unloading { get; set; }
        public double Commission { get; set; }
        public int? Vataccid { get; set; }
        public int? Custaccid { get; set; }
        public int? Salaccid { get; set; }
        public int? Truckaccid { get; set; }
        public string? Description { get; set; }
        public long? TruckChallanid { get; set; }
        public long? VatChallanId { get; set; }
        public byte? Comid { get; set; }
        public string? UserId { get; set; }
    }

    public partial class Cat_TruckType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TruckTypeid { get; set; }
        public string? TruckType { get; set; }
        public long? TruckAccId { get; set; }
        public byte? Comid { get; set; }
        public int? Userid { get; set; }
    }

    public partial class Cat_Type
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short TypeId { get; set; }
        public string? TypeName { get; set; }
        public string? Pcname { get; set; }
        public string? UserId { get; set; }


        public int ComId { get; set; }
        public int? TypeSlno { get; set; }
    }



    //public partial class Cat_UnitConversion
    //{
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public short FromUnitId { get; set; }
    //    public short ToUnitId { get; set; }
    //    public double FromUnitRate { get; set; }
    //    public double ToUnitRate { get; set; }

    //    public string? Pcname { get; set; }
    //    public string? UserId { get; set; }
    //}


    [Table("Cat_Gender")]
    public partial class Cat_GenderModel : SelfModel
    {

        [StringLength(30)]
        public string? GenderName { get; set; }
        [StringLength(30)]
        public string? GenderNameB { get; set; }


    }



    [Table("Cat_Emp_Type")]
    public partial class Cat_Emp_TypeModel : SelfModel
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int EmpTypeId { get; set; }

        [StringLength(30)]
        public string? EmpTypeName { get; set; }
        [StringLength(30)]
        public string? EmpTypeNameB { get; set; }

        [Display(Name = "Total Manpower")]
        public int? TtlManpower { get; set; }

    }

    //public partial class Cat_VatParticulars
    //{
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public int VatId { get; set; }
    //    public string? VatParticulars { get; set; }
    //    public string? VatQtyType { get; set; }
    //    public double VatPrincipalValue { get; set; }
    //    public double BeforeTaka { get; set; }
    //    public double DiffTaka { get; set; }
    //    public int CountryId { get; set; }
    //    public int? Userid { get; set; }
    //    public int ComId { get; set; }
    //    public Guid? Wid { get; set; }
    //    public long? VatAcciD { get; set; }
    //    public int? Prdid { get; set; }
    //    public byte? IsExport { get; set; }
    //    public byte? IsVat { get; set; }
    //    public byte? IsOther { get; set; }
    //    public double? ExportValue { get; set; }
    //}

    //public partial class Cat_VisitorCompany
    //{
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public int VcomId { get; set; }
    //    public string? VcomName { get; set; }
    //    public string? VcomAddress { get; set; }
    //}

    //public partial class Cat_VoucherType
    //{
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public int VoucherTypeId { get; set; }
    //    public string? VtypeName { get; set; }
    //    public string? VtypeNameShort { get; set; }
    //    public byte ModuleId { get; set; }
    //    public byte IsAll { get; set; }
    //    public byte SortNo { get; set; }

    //}

    //public partial class Cat_Warehouse
    //{
    //    public Cat_Warehouse()
    //    {
    //        Cat_WarehouseBin = new HashSet<Cat_WarehouseBin>();
    //        //TblStrProductDistributionBin = new HashSet<TblStrProductDistributionBin>();
    //    }
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public int WarehouseId { get; set; }
    //    public int ComId { get; set; }
    //    public short Whid { get; set; }
    //    public string? Whcode { get; set; }
    //    public string? Whname { get; set; }
    //    public string? WhnameShort { get; set; }
    //    public int ParentId { get; set; }
    //    public string? ParentCode { get; set; }
    //    public string? Whtype { get; set; }


    //    public virtual ICollection<Cat_WarehouseBin> Cat_WarehouseBin { get; set; }
    //    //public virtual ICollection<TblStrProductDistributionBin> TblStrProductDistributionBin { get; set; }
    //}

    public partial class Cat_WarehouseBin
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public byte WarehouseBinId { get; set; }
        public int ComId { get; set; }
        public short BinId { get; set; }
        public string? BinNo { get; set; }
        public string? FloorNo { get; set; }
        public string? RoomNo { get; set; }
        public string? RackNo { get; set; }
        public string? CellNo { get; set; }
        public string? BinDetails { get; set; }
        public short Whid { get; set; }

        public string? Pcname { get; set; }
        public string? UserId { get; set; }

        public virtual WarehouseModel? Wh { get; set; }
    }

    public partial class Cat_Zone
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int ZoneId { get; set; }
        public string? Zonename { get; set; }
        public int? AreaId { get; set; }
        public int ComId { get; set; }
        public Guid? WId { get; set; }
        public string? Pcname { get; set; }
        public string? UserId { get; set; }
        public string? ZoneCode { get; set; }
    }

    [Table("Cat_BuildingType")]
    public partial class Cat_BuildingTypeModel : BaseModel
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int BId { get; set; }

        [Display(Name = "Building Name")]
        [Required(ErrorMessage = "Plz input Building Name")]
        [StringLength(30)]
        [DataType("nvarchar(30)")]
        public string? BuildingName { get; set; }

        [Display(Name = "Building Short Name")]
        [StringLength(30)]
        [DataType("nvarchar(30)")]
        public string? BuildingShortName { get; set; }

        [Display(Name = "Building Bangla")]
        [StringLength(30)]
        [DataType("nvarchar(25)")]
        public string? BuildingNameB { get; set; }

    }

    public partial class Cat_Location : BaseModel
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int LId { get; set; }

        [Display(Name = "House Location Name")]
        [Required(ErrorMessage = "Plz input House Location Name")]
        [StringLength(30)]
        public string? LocationName { get; set; }

        [Display(Name = "House Location Bangla")]
        [StringLength(30)]
        public string? LocationNameB { get; set; }

        [Display(Name = "Location Name Short")]
        [StringLength(30)]
        public string? LocationNameShort { get; set; }

        [Display(Name = "Location Name Short Bangla")]
        [StringLength(30)]
        public string? LocationNameShortB { get; set; }

        //[StringLength(80)]
        //public int ComId { get; set; }

        [StringLength(60)]
        public string? PcName { get; set; }

        //[StringLength(80)]
        //public string? UserId { get; set; }
        //public DateTime? DateAdded { get; set; }
        //[StringLength(80)]
        //public string? UpdateByUserId { get; set; }
        //public DateTime? DateUpdated { get; set; }
    }

    public partial class Cat_AttStatus : BaseModel
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int StatusId { get; set; }

        [Display(Name = "Attend. Status")]
        [Required(ErrorMessage = "Please Provide Attendance Type.")]
        [StringLength(5)]
        public string? AttStatus { get; set; }

        [Display(Name = "Attend. Status Details")]
        [StringLength(25)]
        public string? AttStatusDetails { get; set; }

    }

    public partial class Cat_Variable : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VarId { get; set; }

        //[StringLength(80)]
        //public int ComId { get; set; }

        [StringLength(30)]
        [Display(Name = "Name")]
        public string? VarName { get; set; }

        [StringLength(20)]
        [Display(Name = "Type")]
        public string? VarType { get; set; }

        [Display(Name = "Serial No")]
        public int SLNo { get; set; }


    }

    public partial class Cat_MedicalDiagnosis : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DiagId { get; set; }

        [Display(Name = "Diagnosis Name")]
        [StringLength(50)]
        public string? DiagName { get; set; }

    }


    [Table("Cat_HRSetting")]
    public partial class Cat_HRSettingModel : BaseModel
    {


        [Display(Name = "Employee Type")]
        public int EmpTypeId { get; set; }
        [ForeignKey("EmpTypeId")]
        public virtual Cat_Emp_TypeModel Cat_Emp_Type { get; set; }

        [Display(Name = "House Location")]
        public int LId { get; set; }
        [ForeignKey("LId")]
        public virtual Cat_Location Cat_Location { get; set; }

        [Display(Name = "House Category")]
        public int? BId { get; set; }
        [ForeignKey("BId")]
        public virtual Cat_BuildingTypeModel Cat_BuildingType { get; set; }

        public string? CompanyCode { get; set; }

        [Display(Name = "Basic")]
        public float BS { get; set; }
        [Display(Name = "Is BS Persentage")]
        public bool IsBSPersentage { get; set; }

        [Display(Name = "House Rent")]
        [Required]
        public float HR { get; set; }
        [Display(Name = "Is HR Persentage")]
        public bool IsHRPersentage { get; set; }

        //[Display(Name = "Minimum HR")]
        //public float? MinHR { get; set; }

        [Display(Name = "Medical Allownce")]
        public float MA { get; set; }

        [Display(Name = "Is MA Persentage")]
        public bool IsMAPersentage { get; set; }

        [Display(Name = "Conveyance Allowance")]
        public float CA { get; set; }

        [Display(Name = "Is CA Persentage")]
        public bool IsCAPersentage { get; set; }

        [Display(Name = "Food Allowance")]
        public float FA { get; set; }

        [Display(Name = "Is FA Persentage")]
        public bool IsFAPersentage { get; set; }

        public bool IsCADifference { get; set; }
        public bool IsFADifference { get; set; }
        public bool IsLateDedcution { get; set; }
        public string? DeductionType { get; set; }
    }
    //public partial class Cat_HRExpSetting : BaseModel
    //{
    //    //Id, EmpType, HouseLocation, HouseCatagory, BS, HR, HRExp, MA, GasAllowance, GasCharge, ElectricCharge

    //    //[Key]
    //    //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    //public int Id { get; set; }

    //    [Display(Name = "Employee Type")]
    //    public int EmpTypeId { get; set; }
    //    [ForeignKey("EmpTypeId")]
    //    public virtual Cat_Emp_Type Cat_Emp_Type { get; set; }

    //    [Display(Name = "House Location")]
    //    public int LId { get; set; }
    //    [ForeignKey("LId")]
    //    public virtual Cat_Location Cat_Location { get; set; }

    //    [Display(Name = "House Category")]
    //    public int BId { get; set; }
    //    [ForeignKey("BId")]
    //    public virtual Cat_BuildingType Cat_BuildingType { get; set; }

    //    [Display(Name = "Basic")]
    //    public float BS { get; set; }

    //    [Display(Name = "H.R. Exp")]
    //    [Required]
    //    public float HRExp { get; set; }

    //    [Display(Name = "Is Persentage")]
    //    public bool IsPersentage { get; set; }


    //    //[StringLength(80)]
    //    //public int ComId { get; set; }

    //    //[StringLength(80)]
    //    //public string? UserId { get; set; }

    //    //public DateTime? DateAdded { get; set; }
    //    //[StringLength(80)]
    //    //public string? UpdateByUserId { get; set; }

    //    //public DateTime? DateUpdated { get; set; }
    //}

    //public partial class Cat_GasChargeSetting : BaseModel
    //{
    //    //Id, EmpType, HouseLocation, HouseCatagory, BS, HR, HRExp, MA, GasAllowance, GasCharge, ElectricCharge

    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public int Id { get; set; }

    //    //[Display(Name = "Employee Type")]
    //    //public int EmpTypeId { get; set; }
    //    //[ForeignKey("EmpTypeId")]
    //    //public virtual Cat_Emp_Type Cat_Emp_Type { get; set; }

    //    [Display(Name = "House Location")]
    //    public int LId { get; set; }
    //    [ForeignKey("LId")]
    //    public virtual Cat_Location Cat_Location { get; set; }

    //    [Display(Name = "House Category")]
    //    public int BId { get; set; }
    //    [ForeignKey("BId")]
    //    public virtual Cat_BuildingType Cat_BuildingType { get; set; }

    //    //[Display(Name = "Basic")]
    //    //[NotMapped]
    //    //public float BS { get; set; }

    //    [Display(Name = "Gas Charge")]
    //    [Required]
    //    public float GasCharge { get; set; }

    //    [Display(Name = "Is Persentage")]
    //    public bool IsPersentage { get; set; }

    //    //[StringLength(80)]
    //    //public int ComId { get; set; }

    //    //[StringLength(80)]
    //    //public string? UserId { get; set; }

    //    //public DateTime? DateAdded { get; set; }
    //    //[StringLength(80)]
    //    //public string? UpdateByUserId { get; set; }

    //    //public DateTime? DateUpdated { get; set; }
    //}

    //public partial class Cat_ElectricChargeSetting : BaseModel
    //{
    //    //Id, EmpType, HouseLocation, HouseCatagory, BS, HR, HRExp, MA, GasAllowance, GasCharge, ElectricCharge

    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public int Id { get; set; }

    //    //[Display(Name = "Employee Type")]
    //    //public int EmpTypeId { get; set; }
    //    //[ForeignKey("EmpTypeId")]
    //    //public virtual Cat_Emp_Type Cat_Emp_Type { get; set; }

    //    [Display(Name = "House Location")]
    //    public int LId { get; set; }
    //    [ForeignKey("LId")]
    //    public virtual Cat_Location Cat_Location { get; set; }

    //    [Display(Name = "House Category")]
    //    public int BId { get; set; }
    //    [ForeignKey("BId")]
    //    public virtual Cat_BuildingType Cat_BuildingType { get; set; }


    //    //[Display(Name = "Basic")]
    //    //[NotMapped]
    //    //public float BS { get; set; }

    //    [Display(Name = "Electric Charge")]
    //    [Required]
    //    public float ElectricCharge { get; set; }

    //    [Display(Name = "Is Persentage")]
    //    public bool IsPersentage { get; set; }

    //    //[StringLength(80)]
    //    //public int ComId { get; set; }

    //    //[StringLength(80)]
    //    //public string? UserId { get; set; }

    //    //public DateTime? DateAdded { get; set; }
    //    //[StringLength(80)]
    //    //public string? UpdateByUserId { get; set; }

    //    //public DateTime? DateUpdated { get; set; }
    //}

    public class Cat_SummerWinterAllowanceSetting : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SWAllowanceId { get; set; }
        public string? ProssType { get; set; }
        public float SummerAllow { get; set; }
        public float WinterAllow { get; set; }
        public float RainCoatAndGumbootAllow { get; set; }
        public float VatDiduction { get; set; }
        public float TaxDiduction { get; set; }

        [StringLength(40)]
        [Display(Name = "Reference No")]
        public string? ReferenceNo { get; set; }

        //[StringLength(80)]
        //public int ComId { get; set; }

        //[StringLength(80)]
        //public string? UserId { get; set; }

        //public DateTime? DateAdded { get; set; }
        //[StringLength(80)]
        //public string? UpdateByUserId { get; set; }

        //public DateTime? DateUpdated { get; set; }
    }

    public class Cat_IncomeTaxChk
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "Pross Type")]
        [StringLength(12)]
        public string? ProssType { get; set; }
        [Display(Name = "Is Stop Tax")]
        public bool IsStopTax { get; set; }
        [StringLength(80)]
        public int ComId { get; set; }
        [StringLength(80)]
        public string? UserId { get; set; }
        public DateTime? DateAdded { get; set; }
        [StringLength(80)]
        public string? UpdateByUserId { get; set; }
        public DateTime? DateUpdated { get; set; }
    }

    public class Cat_ITComputationSetting : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "Tax Computation")]
        public float TaxComputation { get; set; }
        public float Amount { get; set; }
        public float Rate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime dtFrom { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? dtTo { get; set; }
        [Display(Name = "Fiscal Year")]
        [StringLength(20)]
        public string? FiscalYear { get; set; }
        //[StringLength(80)]
        //public int ComId { get; set; }
        //[StringLength(80)]
        //public string? UserId { get; set; }
        //public DateTime? DateAdded { get; set; }
        //[StringLength(80)]
        //public string? UpdateByUserId { get; set; }
        //public DateTime? DateUpdated { get; set; }
    }


    [Table("Cat_ITaxBank")]
    public class Cat_ITaxBankModel : BaseModel
    {


        [Display(Name = "Bank")]
        public int BankId { get; set; }
        [ForeignKey("BankId")]
        public Cat_BankModel Cat_Bank { get; set; }


        [Display(Name = "Branch")]
        public int BranchId { get; set; }
        [ForeignKey("BranchId")]
        public Cat_BankBranchModel Cat_BankBranch { get; set; }


        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Moth Date")]
        public DateTime MonthDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Chq Date")]
        public DateTime ChqDate { get; set; }

        [StringLength(50)]
        [Display(Name = "Chq No")]
        public string? ChqNo { get; set; }

    }


    [Table("Cat_ReportSignatory")]
    public partial class Cat_ReportSignatoryModel : BaseModel
    {

        [Display(Name = "Module")]
        [StringLength(30)]
        public string? Module { get; set; }

        [Display(Name = "Report")]
        [StringLength(30)]
        public string? ReportName { get; set; }


        [Display(Name = "Signatory1")]
        [Required]
        [StringLength(30)]
        public string? Signatory1 { get; set; }

        [StringLength(30)]
        [Display(Name = "Signatory1 Bangla")]
        public string? Signatory1B { get; set; }

        [Display(Name = "Signatory Desig1")]
        [Required]
        [StringLength(30)]
        public string? SignatoryDesig1 { get; set; }

        [StringLength(30)]
        [Display(Name = "Signatory Desig1 Bangla")]
        public string? SignatoryDesig1B { get; set; }

        [Display(Name = "Signatory2")]
        [StringLength(30)]
        public string? Signatory2 { get; set; }

        [StringLength(30)]
        [Display(Name = "Signatory2 Bangla")]
        public string? Signatory2B { get; set; }

        [Display(Name = "Signatory Desig2")]
        [Required]
        [StringLength(30)]
        public string? SignatoryDesig2 { get; set; }

        [StringLength(30)]
        [Display(Name = "Signatory Desig2 Bangla")]
        public string? SignatoryDesig2B { get; set; }

        [Display(Name = "Signatory3")]
        [StringLength(30)]
        public string? Signatory3 { get; set; }

        [StringLength(30)]
        [Display(Name = "Signatory3 Bangla")]
        public string? Signatory3B { get; set; }

        [Display(Name = "Signatory Desig3")]
        [Required]
        [StringLength(30)]
        public string? SignatoryDesig3 { get; set; }

        [StringLength(30)]
        [Display(Name = "Signatory Desig3 Bangla")]
        public string? SignatoryDesig3B { get; set; }


        [Display(Name = "Signatory4")]
        [StringLength(30)]
        public string? Signatory4 { get; set; }

        [StringLength(30)]
        [Display(Name = "Signatory4 Bangla")]
        public string? Signatory4B { get; set; }

        [Display(Name = "Signatory Desig4")]
        [Required]
        [StringLength(30)]
        public string? SignatoryDesig4 { get; set; }

        [StringLength(30)]
        [Display(Name = "Signatory Desig4 Bangla")]
        public string? SignatoryDesig4B { get; set; }


        [Display(Name = "Signatory5")]
        [StringLength(30)]
        public string? Signatory5 { get; set; }

        [StringLength(30)]
        [Display(Name = "Signatory5 Bangla")]
        public string? Signatory5B { get; set; }

        [Display(Name = "Signatory Desig5")]
        [Required]
        [StringLength(30)]
        public string? SignatoryDesig5 { get; set; }

        [StringLength(30)]
        [Display(Name = "Signatory Desig5 Bangla")]
        public string? SignatoryDesig5B { get; set; }

        [Display(Name = "Signatory6")]
        [StringLength(30)]
        public string? Signatory6 { get; set; }

        [StringLength(30)]
        [Display(Name = "Signatory6 Bangla")]
        public string? Signatory6B { get; set; }

        [Display(Name = "Signatory Desig6")]
        [Required]
        [StringLength(30)]
        public string? SignatoryDesig6 { get; set; }

        [StringLength(30)]
        [Display(Name = "Signatory Desig6 Bangla")]
        public string? SignatoryDesig6B { get; set; }


        [Display(Name = "From Date")]
        public DateTime FromDate { get; set; }

        [Display(Name = "To Date")]
        public DateTime ToDate { get; set; }

    }

    public class Payroll_InComeTaxAmountSetting : BaseModel
    {
        public int Id { get; set; }
        public float GSLimitFrom { get; set; }
        public float GSLimitTo { get; set; }
        public float IncomeTax { get; set; }
        public bool IsInComeTax { get; set; }
    }








    public partial class HrTemp
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HrTempId { get; set; }
        public int ComId { get; set; }
        public string? ComName { get; set; }
        public string? ComAddress { get; set; }
        public string? ComAddress2 { get; set; }
        public string? ComImagePath { get; set; }
        public string? ComPhone { get; set; }
        public string? ComPhone2 { get; set; }
        public string? ComWeb { get; set; }
        public string? LuserId { get; set; }
        public string? EmpName { get; set; }
        public string? EmpDesig { get; set; }
        public string? EmpDept { get; set; }
        public string? EmpMobile { get; set; }
        public string? EmpEmail { get; set; }
        public string? EmpCode { get; set; }
        public int? MasterId { get; set; }
        public string? VarCaption1 { get; set; }
        public string? VarCaption2 { get; set; }
        public string? VarMaster1 { get; set; }
        public string? VarMaster2 { get; set; }
        public string? VarMaster3 { get; set; }
        public string? VarMaster4 { get; set; }
        public string? VarMaster5 { get; set; }
        public string? VarStr1 { get; set; }
        public string? VarStr2 { get; set; }
        public string? VarStr3 { get; set; }
        public DateTime? VarDate1 { get; set; }
        public DateTime? VarDate2 { get; set; }
        public DateTime? VarDate3 { get; set; }
        public int? VarInt1 { get; set; }
        public int? VarInt2 { get; set; }
        public int? VarInt3 { get; set; }
        public int? VarInt4 { get; set; }
        public int? VarInt5 { get; set; }

    }

    //public partial class HrTempAttend
    //{
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    //    public int ComId { get; set; }
    //    public string? ComName { get; set; }
    //    public string? ComAdd1 { get; set; }
    //    public string? ComAdd2 { get; set; }
    //    public string? Caption { get; set; }
    //    public int SectId { get; set; }
    //    public string? SectName { get; set; }
    //    public long EmpId { get; set; }
    //    public string? EmpCode { get; set; }
    //    public string? EmpName { get; set; }
    //    public string? CardNo { get; set; }
    //    public int DesigId { get; set; }
    //    public string? DesigName { get; set; }
    //    public int ShiftId { get; set; }
    //    public string? ShiftName { get; set; }
    //    public DateTime? DtPunchDate { get; set; }
    //    public string? Status { get; set; }
    //    public DateTime? TimeIn { get; set; }
    //    public DateTime? TimeOut { get; set; }
    //    public DateTime? Late { get; set; }
    //    public DateTime? RegHour { get; set; }
    //    public DateTime? Othour { get; set; }
    //    public float? Othr { get; set; }
    //    public string? Remarks { get; set; }
    //    public int Sl { get; set; }
    //    public int? SslNo { get; set; }
    //    public int? DslNo { get; set; }
    //    //public int? Slno { get; set; }
    //    public string? Pstatus { get; set; }
    //    public DateTime? PtimeIn { get; set; }
    //    public DateTime? PtimeOut { get; set; }
    //    public int? AbTn { get; set; }
    //    public DateTime? DtFromDate { get; set; }
    //    public string? EmpType { get; set; }
    //    public short DeptId { get; set; }
    //    public string? DeptName { get; set; }
    //    public string? Band { get; set; }
    //    public DateTime? DtJoin { get; set; }
    //    public string? Operation { get; set; }
    //    public short? CscomId { get; set; }
    //    public int SubSectId { get; set; }

    //    public virtual Cat_Company Com { get; set; }
    //    public virtual Cat_DepartmentModel? ComNavigation { get; set; }
    //    public virtual EmployeeModel? HR_Emp_Info { get; set; }
    //    public virtual Cat_SectionModel? Sect { get; set; }
    //    public virtual Cat_Shift Shift { get; set; }
    //    public virtual Cat_SubSectionModel? SubSect { get; set; }
    //}

    //public partial class HrTempAttendMonth
    //{
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    //    public int ComId { get; set; }
    //    public string? ComName { get; set; }
    //    public string? ComAdd1 { get; set; }
    //    public string? ComAdd2 { get; set; }
    //    public string? Caption { get; set; }
    //    public long EmpId { get; set; }
    //    public string? EmpCode { get; set; }
    //    public string? EmpName { get; set; }
    //    public string? DtJoin { get; set; }
    //    public int? DesigId { get; set; }
    //    public string? DesigName { get; set; }
    //    public string? Grade { get; set; }
    //    public int SectId { get; set; }
    //    public string? SectName { get; set; }
    //    public int? DeptId { get; set; }
    //    public string? DeptName { get; set; }
    //    public string? Band { get; set; }
    //    public string? Floor { get; set; }
    //    public string? Line { get; set; }
    //    public byte DayMonth { get; set; }
    //    public float DayTtl { get; set; }
    //    public float Present { get; set; }
    //    public float Absent { get; set; }
    //    public float LateDay { get; set; }
    //    public float Leave { get; set; }
    //    public float Hday { get; set; }
    //    public float Wday { get; set; }
    //    public float Cl { get; set; }
    //    public float El { get; set; }
    //    public float Sl { get; set; }
    //    public float Ml { get; set; }
    //    public float AccL { get; set; }
    //    public float Lwp { get; set; }
    //    public float LateHrs { get; set; }
    //    public float EarlyLvHrs { get; set; }
    //    public float ShortLvHrs { get; set; }
    //    public string? OthrsTtl { get; set; }
    //    public byte Lunch { get; set; }
    //    public byte Night { get; set; }
    //    public float Othr { get; set; }
    //    public string? LateHrTtl { get; set; }
    //    public float OthrDed { get; set; }
    //    public float? Rot { get; set; }
    //    public float? Eot { get; set; }
    //    public int? Sslno { get; set; }
    //    public int? Dslno { get; set; }
    //    public int? ShiftId { get; set; }
    //    public decimal? Gs { get; set; }
    //    public decimal? Bs { get; set; }
    //    public float? Otrate { get; set; }
    //    public decimal? Ot { get; set; }
    //    public string? SubSectName { get; set; }
    //    public string? DaysCnt { get; set; }
    //    public int SubSectId { get; set; }
    //    public float? NewJoinAbs { get; set; }

    //    public virtual Cat_Company Com { get; set; }
    //    public virtual Cat_DepartmentModel? Dept { get; set; }
    //    public virtual Cat_DesignationModel? Desig { get; set; }
    //    public virtual EmployeeModel? HR_Emp_Info { get; set; }
    //    public virtual Cat_SectionModel? Sect { get; set; }
    //    public virtual Cat_SubSectionModel? SubSect { get; set; }
    //}

    public partial class HrTempCount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public long? EmpId { get; set; }
        public double? Cnt { get; set; }
        public double? Cnt1 { get; set; }
        public string? Code { get; set; }
        public string? Code1 { get; set; }
        public DateTime? DateTime { get; set; }
        public DateTime? DateTime1 { get; set; }
        public DateTime? DateTime2 { get; set; }
        public string? Vchr { get; set; }
        public string? Vchr1 { get; set; }
        public string? Vchr2 { get; set; }
    }

    public partial class HrTempCount1
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public long? EmpId { get; set; }
        public double? Cnt { get; set; }
        public double? Cnt1 { get; set; }
        public string? Code { get; set; }
        public string? Code1 { get; set; }
        public DateTime? DateTime { get; set; }
        public DateTime? DateTime1 { get; set; }
        public DateTime? DateTime2 { get; set; }
        public string? Vchr { get; set; }
        public string? Vchr1 { get; set; }
        public DateTime? DateTime3 { get; set; }
        public string? Vchr2 { get; set; }
        public int? Cnt2 { get; set; }
        public DateTime? TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }
        public int? ShiftId { get; set; }
        public string? ShiftType { get; set; }
    }

    public partial class HrTempCount2
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public long? EmpId { get; set; }
        public double? Cnt { get; set; }
        public double? Cnt1 { get; set; }
        public string? Code { get; set; }
        public string? Code1 { get; set; }
        public DateTime? DateTime { get; set; }
        public DateTime? DateTime1 { get; set; }
        public DateTime? DateTime2 { get; set; }
        public string? Vchr { get; set; }
        public string? Vchr1 { get; set; }
        public int? ComId { get; set; }
        public int? Cnt3 { get; set; }
        public int? Cnt4 { get; set; }
        public float? Cnt5 { get; set; }
        public string? DocType { get; set; }
        public double? CntFloat { get; set; }
        public double? BinId { get; set; }
        public double? WhId { get; set; }
    }

    public partial class HrTempCount3
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public long? EmpId { get; set; }
        public double? Cnt { get; set; }
        public double? Cnt1 { get; set; }
        public string? Code { get; set; }
        public string? Code1 { get; set; }
        public DateTime? DateTime { get; set; }
        public DateTime? DateTime1 { get; set; }
        public DateTime? DateTime2 { get; set; }
        public string? Vchr { get; set; }
        public string? Vchr1 { get; set; }
        public int? ComId { get; set; }
        public int? Cnt3 { get; set; }
        public int? Cnt4 { get; set; }
        public float? Cnt5 { get; set; }
        //public long AId { get; set; }
    }

    public partial class HrTempCountGtr
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public string? IpAddress { get; set; }
        public double? Cnt { get; set; }
        public int? Cnt1 { get; set; }
        public DateTime? DtDate { get; set; }
        public DateTime? DtTime { get; set; }
        public int ComId { get; set; }
    }

    public partial class HrTempDailySum
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ComId { get; set; }
        public string? ComName { get; set; }
        public string? ComAdd { get; set; }
        public string? ComAdd2 { get; set; }
        public string? Caption { get; set; }
        public DateTime DtDate { get; set; }
        public int SectId { get; set; }
        public string? SectName { get; set; }
        public int? DesigId { get; set; }
        public string? DesigName { get; set; }
        public float Male { get; set; }
        public float Female { get; set; }
        public float TtlEmp { get; set; }
        public float Present { get; set; }
        public float PresentPer { get; set; }
        public float Late { get; set; }
        public float LatePer { get; set; }
        public float TtlPresent { get; set; }
        public float TtlPresentPer { get; set; }
        public float Absent { get; set; }
        public float AbsentPer { get; set; }
        public float Leave { get; set; }
        public float LeavePer { get; set; }
        public float Total { get; set; }
        public int? Sslno { get; set; }
        public int? Dslno { get; set; }
        public float? OffDay { get; set; }
        public float? NewJoin { get; set; }
    }

    //public partial class HrTempElBalance
    //{
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]


    //    public int ComId { get; set; }
    //    public long EmpId { get; set; }
    //    public DateTime? DtStart { get; set; }
    //    public DateTime? DtEnd { get; set; }
    //    public DateTime? DtOpbal { get; set; }
    //    public int TtlPresent { get; set; }
    //    public int PrevEl { get; set; }
    //    public int Ael { get; set; }
    //    public int El { get; set; }
    //    public int CashedEl { get; set; }
    //    public int CurrBel { get; set; }
    //    public byte BalType { get; set; }

    //    public virtual Cat_Company Com { get; set; }
    //    public virtual EmployeeModel? HR_Emp_Info { get; set; }
    //}

    //public partial class HrTempEmp
    //{
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    //    public int ComId { get; set; }
    //    public long EmpId { get; set; }

    //    public virtual Cat_Company Com { get; set; }
    //    public virtual EmployeeModel? HR_Emp_Info { get; set; }
    //}

    //public partial class HrTempJob
    //{
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    //    public int ComId { get; set; }
    //    public string? ComName { get; set; }
    //    public string? ComAdd1 { get; set; }
    //    public string? ComAdd2 { get; set; }
    //    public string? Caption { get; set; }
    //    public long? EmpId { get; set; }
    //    public string? EmpCode { get; set; }
    //    public string? EmpName { get; set; }
    //    public string? BloodGroup { get; set; }
    //    public decimal Gs { get; set; }
    //    public short DesigId { get; set; }
    //    public string? DesigName { get; set; }
    //    public string? Grade { get; set; }
    //    public short SectId { get; set; }
    //    public string? SectName { get; set; }
    //    public short? DeptId { get; set; }
    //    public string? DeptName { get; set; }
    //    public string? Band { get; set; }
    //    public string? Floor { get; set; }
    //    public string? Line { get; set; }
    //    public string? DtJoin { get; set; }
    //    public string? DtReleased { get; set; }
    //    public string? CardNo { get; set; }
    //    public float Present { get; set; }
    //    public float Absent { get; set; }
    //    public float LateDay { get; set; }
    //    public float Leave { get; set; }
    //    public float Hday { get; set; }
    //    public float Wday { get; set; }
    //    public float LateHrTtl { get; set; }
    //    public float Othr { get; set; }
    //    public float OthrDed { get; set; }
    //    public float OthrsTtl { get; set; }
    //    public float? Rot { get; set; }
    //    public float? Eot { get; set; }
    //    //public int Slno { get; set; }
    //    public float Night { get; set; }
    //    public float Lunch { get; set; }
    //}

    public partial class HrTempProssCount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public byte ComId { get; set; }
        public long EmpId { get; set; }
        public DateTime DtPunchDate { get; set; }
        public string? EmpCode { get; set; }
        public short? ShiftId { get; set; }
        public short? SectId { get; set; }
        public short? DesigId { get; set; }
        public string? Band { get; set; }
        public short? DeptId { get; set; }
        public string? Grade { get; set; }
        public decimal? Gs { get; set; }
        public DateTime? TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }
        public DateTime? Late { get; set; }
        public DateTime? LunchIn { get; set; }
        public DateTime? LunchOut { get; set; }
        public DateTime? LunchLate { get; set; }
        public string? Status { get; set; }
        public DateTime? Othour { get; set; }
        public DateTime? RegHour { get; set; }
        public DateTime? TotalHour { get; set; }
        public float OthourMin { get; set; }
        public float? Ot { get; set; }
        public float RegMin { get; set; }
        public DateTime? ShiftInTime { get; set; }
        public float? RegHr { get; set; }
        public float? LunchTime { get; set; }
        public DateTime? TiffinTime1 { get; set; }
        public float? TiffinD1 { get; set; }
        public DateTime? TiffinTime2 { get; set; }
        public float? TiffinD2 { get; set; }
        public DateTime? TiffinTime3 { get; set; }
        public float? TiffinD3 { get; set; }
        public float? TotalMin { get; set; }
        public float? WeeklyMin { get; set; }
        public float? RegOt { get; set; }
        public float? WeeklyOt { get; set; }
        public float? Cnt { get; set; }
        public float? Cnt1 { get; set; }
        public string? Code { get; set; }
        public string? Code1 { get; set; }
        public DateTime? DateTime2 { get; set; }
        public string? Vchr { get; set; }
        public string? Vchr1 { get; set; }
        public string? Vchr2 { get; set; }
        public string? Remarks { get; set; }
        public byte IsNightShift { get; set; }
    }

    public partial class HrTempProssCount2
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public byte ComId { get; set; }
        public long EmpId { get; set; }
        public DateTime DtPunchDate { get; set; }
        public string? EmpCode { get; set; }
        public short? ShiftId { get; set; }
        public short? SectId { get; set; }
        public short? DesigId { get; set; }
        public string? Band { get; set; }
        public short? DeptId { get; set; }
        public string? Grade { get; set; }
        public decimal? Gs { get; set; }
        public DateTime? TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }
        public DateTime? Late { get; set; }
        public DateTime? LunchIn { get; set; }
        public DateTime? LunchOut { get; set; }
        public DateTime? LunchLate { get; set; }
        public string? Status { get; set; }
        public DateTime? Othour { get; set; }
        public DateTime? RegHour { get; set; }
        public DateTime? TotalHour { get; set; }
        public float OthourMin { get; set; }
        public float? Ot { get; set; }
        public float RegMin { get; set; }
        public DateTime? ShiftInTime { get; set; }
        public float? RegHr { get; set; }
        public float? LunchTime { get; set; }
        public DateTime? TiffinTime1 { get; set; }
        public float? TiffinD1 { get; set; }
        public DateTime? TiffinTime2 { get; set; }
        public float? TiffinD2 { get; set; }
        public DateTime? TiffinTime3 { get; set; }
        public float? TiffinD3 { get; set; }
        public float? TotalMin { get; set; }
        public float? WeeklyMin { get; set; }
        public float? RegOt { get; set; }
        public float? WeeklyOt { get; set; }
        public float? Cnt { get; set; }
        public float? Cnt1 { get; set; }
        public string? Code { get; set; }
        public string? Code1 { get; set; }
        public DateTime? DateTime2 { get; set; }
        public string? Vchr { get; set; }
        public string? Vchr1 { get; set; }
        public string? Vchr2 { get; set; }
        public string? Remarks { get; set; }
    }

    public partial class HrTempProssCount3
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public byte ComId { get; set; }
        public long EmpId { get; set; }
        public DateTime DtPunchDate { get; set; }
        public string? EmpCode { get; set; }
        public short? ShiftId { get; set; }
        public short? SectId { get; set; }
        public short? DesigId { get; set; }
        public string? Band { get; set; }
        public short? DeptId { get; set; }
        public string? Grade { get; set; }
        public decimal? Gs { get; set; }
        public DateTime? TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }
        public DateTime? Late { get; set; }
        public DateTime? LunchIn { get; set; }
        public DateTime? LunchOut { get; set; }
        public DateTime? LunchLate { get; set; }
        public string? Status { get; set; }
        public DateTime? Othour { get; set; }
        public DateTime? RegHour { get; set; }
        public DateTime? TotalHour { get; set; }
        public float OthourMin { get; set; }
        public float? Ot { get; set; }
        public float RegMin { get; set; }
        public DateTime? ShiftInTime { get; set; }
        public float? RegHr { get; set; }
        public float? LunchTime { get; set; }
        public DateTime? TiffinTime1 { get; set; }
        public float? TiffinD1 { get; set; }
        public DateTime? TiffinTime2 { get; set; }
        public float? TiffinD2 { get; set; }
        public DateTime? TiffinTime3 { get; set; }
        public float? TiffinD3 { get; set; }
        public float? TotalMin { get; set; }
        public float? WeeklyMin { get; set; }
        public float? RegOt { get; set; }
        public float? WeeklyOt { get; set; }
        public float? Cnt { get; set; }
        public float? Cnt1 { get; set; }
        public string? Code { get; set; }
        public string? Code1 { get; set; }
        public DateTime? DateTime2 { get; set; }
        public string? Vchr { get; set; }
        public string? Vchr1 { get; set; }
        public string? Vchr2 { get; set; }
        public string? Remarks { get; set; }
    }

    public partial class HrTempProssData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public byte ComId { get; set; }
        public long EmpId { get; set; }
        public DateTime DtPunchDate { get; set; }
        public string? EmpCode { get; set; }
        public short? ShiftId { get; set; }
        public short? SectId { get; set; }
        public short? DesigId { get; set; }
        public string? Band { get; set; }
        public short? DeptId { get; set; }
        public string? Grade { get; set; }
        public decimal? Gs { get; set; }
        public DateTime? TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }
        public DateTime? Late { get; set; }
        public DateTime? LunchIn { get; set; }
        public DateTime? LunchOut { get; set; }
        public DateTime? LunchLate { get; set; }
        public string? Status { get; set; }
        public DateTime Othour { get; set; }
        public float OthourMin { get; set; }
        public float? Ot { get; set; }
        public float RegMin { get; set; }
        public DateTime? ShiftInTime { get; set; }
        public DateTime? RegHour { get; set; }
        public float? RegHr { get; set; }
        public float? LunchTime { get; set; }
        public DateTime? TiffinTime1 { get; set; }
        public float? TiffinD1 { get; set; }
        public DateTime? TiffinTime2 { get; set; }
        public float? TiffinD2 { get; set; }
        public DateTime? TiffinTime3 { get; set; }
        public float? TiffinD3 { get; set; }
        public float? TotalMin { get; set; }
        public string? Remarks { get; set; }
        public byte IsNightShift { get; set; }
        public float WeeklyMin { get; set; }
    }

    public partial class HrTempRawData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public string? Empid { get; set; }
        public DateTime? Punchdate { get; set; }
        public TimeSpan? Punchtime { get; set; }
        public int? RowNo { get; set; }
    }

    public partial class HrTempSalCal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public string? EmpId { get; set; }
        public DateTime? Date { get; set; }
        public double? Number { get; set; }
        public double? Number1 { get; set; }
    }

    public partial class HrWeekday : BaseModel
    {

        public long EmpId { get; set; }
        public DateTime DtPunchDate { get; set; }
        public string? Remarks { get; set; }
        public virtual EmployeeModel? HR_Emp_Info { get; set; }
    }

}
