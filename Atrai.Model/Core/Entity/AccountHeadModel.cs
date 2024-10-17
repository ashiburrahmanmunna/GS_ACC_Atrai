using Atrai.Model.Core.Entity.Base;
using Atrai.Model.Core.Entity.Self;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atrai.Model.Core.Entity
{
    [Table("AccountHead")]
    public class AccountHeadModel : BaseModel // RecursiveModel<AccountHeadModel>
    {
        [Required]
        [StringLength(1)]
        [Display(Name = "Type")]
        public string? AccType { get; set; }
        [Required]
        [StringLength(60)]
        [Display(Name = "Account Head")]
        [Remote("CheckExistingAccountName", "Values", HttpMethod = "POST", AdditionalFields = "Id", ErrorMessage = "Account Head Already exists. Try with a different Name.")]
        public string? AccName { get; set; }

        [Display(Name = "SL No")]
        public int? NumericNumber { get; set; }
        [Display(Name = "Account Code")]
        [Remote("CheckExistingAccountCode", "Values", HttpMethod = "POST", AdditionalFields = "Id", ErrorMessage = "Code Already exists. Try with a different Code.")]
        [StringLength(50)]
        public string? AccCode { get; set; }
        [Display(Name = "System Head")]
        public bool isSystem { get; set; }
        [Display(Name = "Base / Parent Head")]
        public virtual AccountHeadModel? vAccountGroupHead { get; set; }
        [Display(Name = "Base / Parent Head")]
        [ForeignKey("vAccountGroupHead")]
        public int? ParentId { get; set; }
        //[Required]
        [NotMapped]
        [StringLength(30)]
        [Display(Name = "Account Category / Type")]
        public string? AccountCategory { get; set; }

        [Display(Name = "Account Category")]
        public virtual AccountCategoryModel? AccountCategorys { get; set; }
        [Display(Name = "Account Category")]
        [ForeignKey("AccountCategorys")]
        public int? AccountCategoryId { get; set; }

        //[NotMapped]
        [Column(TypeName = "decimal(18,4)")]
        public decimal AccountBalance { get; set; }


        //[NotMapped]
        [Column(TypeName = "decimal(18,4)")]
        public decimal AccountBalanceLive { get; set; }


        [Display(Name = "Currency")]
        public virtual CountryModel? Currency { get; set; }
        [Display(Name = "Currency")]
        [ForeignKey("Currency")]
        public int? CountryId { get; set; }


        //public virtual ICollection<TransactionModel>? Account { get; set; }

        //public AccountHeadModel()
        //{
        //    Account = new List<TransactionModel>();
        //}



        [Display(Name = "Opening Debit")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal OpDebit { get; set; } = 0;

        [Display(Name = "Opening Credit")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal OpCredit { get; set; } = 0;


        [Display(Name = "Rate")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Rate { get; set; } = 0;


        [Display(Name = "Opening Debit Local")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal OpDebitLocal { get; set; } = 0;

        [Display(Name = "Opening Credit Local")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal OpCreditLocal { get; set; } = 0;


        [Display(Name = "Is Cash Item")]


        public bool IsCashItem { get; set; }
        [Display(Name = "Is Bank Item")]


        public bool IsBankItem { get; set; }


        [Display(Name = "Inactive")]
        public bool isInactive { get; set; }



        [Display(Name = "Is Item Consumed")]
        public bool isItemConsumed { get; set; }// = false;
        [Display(Name = "Is Item Inventory")]

        public bool isItemInventory { get; set; }// = false;


        public bool IsChkRef { get; set; }

        [Display(Name = "Is Item Depreciation Exp.")]
        public bool IsItemDepExp { get; set; }

        [Display(Name = "Is Item Accumulated Depreciation")]
        public bool IsItemAccmulateddDep { get; set; }




        [Display(Name = "Is Item BS")]
        public bool IsItemBS { get; set; }
        [Display(Name = "Is Item PL")]
        public bool IsItemPL { get; set; }
        [Display(Name = "Is Item TA")]
        public bool IsItemTA { get; set; }
        [Display(Name = "Is Item CS")]
        public bool IsItemCS { get; set; }




        [Display(Name = "Opening Date")]
        [DisplayFormat(DataFormatString = "{0:yy/MM/dd}")]
        [DataType(DataType.Date)]
        public DateTime OpDate { get; set; }


        [ForeignKey("AccumulatedDepChartOfAccount")]
        [Display(Name = "Accumulated Depreciation Head - Only for Asset Item.")]
        //public int? ParentAccId { get; set; }
        public int? AccumulatedDepId { get; set; }



        //[ForeignKey("DepExpenseChartOfAccount")]
        [Display(Name = "Depreciation Head - Only for Asset Item.")]
        //public int? ParentAccId { get; set; }
        public int? DepExpenseId { get; set; }


        [StringLength(20)]
        [DataType(DataType.Text)]
        [Display(Name = "Depreciation Rate :")]
        public string? DepreciationRate { get; set; }

        [StringLength(200)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description :")]
        public string? Description { get; set; }


        [Display(Name = "Level")]
        //public int? ParentAccId { get; set; }
        public int? LevelId { get; set; }


        [Display(Name = "Level")]
        //public int? ParentAccId { get; set; }
        public string? Level { get; set; }

        [NotMapped]
        public string? ParentName { get; set; }

        [Display(Name = "Location")]
        public virtual WarehouseModel? Location { get; set; }
        [Display(Name = "Location")]
        [ForeignKey("Location")]
        public int? WarehouseId { get; set; }
        public virtual ICollection<AccountHeadModel>? ChildrenAccountList { get; set; }

    }


    [Table("AccountHead_System")]
    public class AccountHeadSystemModel : SelfModel
    {


        [Display(Name = "Business Type")]
        public virtual BusinessTypeModel? BusinessType { get; set; }
        [Display(Name = "Business Type")]
        [ForeignKey("BusinessType")]
        public int? BusinessTypeId { get; set; }


        [Required]
        [StringLength(1)]
        [Display(Name = "Type")]
        public string? AccType { get; set; }
        [Required]
        [StringLength(60)]
        [Display(Name = "Account Head")]
        [Remote("CheckExistingAccountNameSystem", "Values", HttpMethod = "POST", AdditionalFields = "Id", ErrorMessage = "Account Head Already exists. Try with a different Name.")]
        public string? AccName { get; set; }

        [Display(Name = "SL No")]
        public int? NumericNumber { get; set; }
        [Display(Name = "Account Code")]
        [Remote("CheckExistingAccountCodeSystem", "Values", HttpMethod = "POST", AdditionalFields = "Id", ErrorMessage = "Code Already exists. Try with a different Code.")]
        [StringLength(50)]
        public string? AccCode { get; set; }
        [Display(Name = "System Head")]
        public bool isSystem { get; set; }
        [Display(Name = "Base / Parent Head")]
        public virtual AccountHeadSystemModel? vAccountGroupHead { get; set; }
        [Display(Name = "Base / Parent Head")]
        [ForeignKey("vAccountGroupHead")]
        public int? ParentId { get; set; }
        //[Required]
        //[StringLength(30)]
        //[Display(Name = "Account Category / Type")]
        [NotMapped]
        public string? AccountCategory { get; set; }

        [Display(Name = "Account Category")]
        public virtual AccountCategoryModel? AccountCategorys { get; set; }
        [Display(Name = "Account Category")]
        [ForeignKey("AccountCategorys")]
        public int? AccountCategoryId { get; set; }

        //[NotMapped]
        //[Column(TypeName = "decimal(18,2)")]
        //public decimal AccountBalance { get; set; }



        //[Display(Name = "Currency")]
        //public virtual CountryModel? Currency { get; set; }
        //[Display(Name = "Currency")]
        //[ForeignKey("Currency")]
        //public int? CountryId { get; set; }


        //public virtual ICollection<TransactionModel>? Account { get; set; }

        //public AccountHeadModel()
        //{
        //    Account = new List<TransactionModel>();
        //}



        //[Display(Name = "Opening Debit")]
        //[Column(TypeName = "decimal(18,2)")]
        //public decimal OpDebit { get; set; } = 0;

        //[Display(Name = "Opening Credit")]
        //[Column(TypeName = "decimal(18,2)")]
        //public decimal OpCredit { get; set; } = 0;


        //[Display(Name = "Rate")]
        //[Column(TypeName = "decimal(18,2)")]
        //public decimal Rate { get; set; } = 0;


        //[Display(Name = "Opening Debit Local")]
        //[Column(TypeName = "decimal(18,2)")]
        //public decimal OpDebitLocal { get; set; } = 0;

        //[Display(Name = "Opening Credit Local")]
        //[Column(TypeName = "decimal(18,2)")]
        //public decimal OpCreditLocal { get; set; } = 0;


        //[Display(Name = "Is Cash Item")]


        //public bool IsCashItem { get; set; }
        //[Display(Name = "Is Bank Item")]


        //public bool IsBankItem { get; set; }


        [Display(Name = "Inactive")]
        public bool isInactive { get; set; }



        //[Display(Name = "Is Item Consumed")]
        //public bool isItemConsumed { get; set; }// = false;
        //[Display(Name = "Is Item Inventory")]

        //public bool isItemInventory { get; set; }// = false;


        //public bool IsChkRef { get; set; }

        [Display(Name = "Is Item Depreciation Exp.")]
        public bool IsItemDepExp { get; set; }

        [Display(Name = "Is Item Accumulated Depreciation")]
        public bool IsItemAccmulateddDep { get; set; }




        //[Display(Name = "Is Item BS")]
        //public bool IsItemBS { get; set; }
        //[Display(Name = "Is Item PL")]
        //public bool IsItemPL { get; set; }
        //[Display(Name = "Is Item TA")]
        //public bool IsItemTA { get; set; }
        //[Display(Name = "Is Item CS")]
        //public bool IsItemCS { get; set; }




        [Display(Name = "Opening Date")]
        [DisplayFormat(DataFormatString = "{0:yy/MM/dd}")]
        [DataType(DataType.Date)]
        public DateTime OpDate { get; set; }


        [ForeignKey("AccumulatedDepChartOfAccount")]
        [Display(Name = "Accumulated Depreciation Head - Only for Asset Item.")]
        //public int? ParentAccId { get; set; }
        public int? AccumulatedDepId { get; set; }



        //[ForeignKey("DepExpenseChartOfAccount")]
        [Display(Name = "Depreciation Head - Only for Asset Item.")]
        //public int? ParentAccId { get; set; }
        public int? DepExpenseId { get; set; }


        [StringLength(20)]
        [DataType(DataType.Text)]
        [Display(Name = "Depreciation Rate :")]
        public string? DepreciationRate { get; set; }


        [Display(Name = "Level")]
        //public int? ParentAccId { get; set; }
        public int? LevelId { get; set; }


        [Display(Name = "Level")]
        //public int? ParentAccId { get; set; }
        public string? Level { get; set; }




    }


    [Table("DailyCurrencyRate")]

    public partial class DailyCurrencyRate : BaseModel
    {

        [Required]
        [Display(Name = "Input Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? tranDate { get; set; }
        [Display(Name = "Foreign Currency")]

        public int CountryIdForeign { get; set; }
        [Display(Name = "Foreign Amount")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal AmountForeign { get; set; }
        [Display(Name = "Local Currency")]

        public int CountryIdLocal { get; set; }
        [Display(Name = "Buying Price")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal AmountLocalBuy { get; set; }
        [Display(Name = "Selling Price")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal AmountLocalSale { get; set; }
        [Display(Name = "Is Auto Entry")]

        public Boolean isAutoEntry { get; set; }

    }


    [Table("Acc_VoucherMain")]

    public partial class Acc_VoucherMainModel : BaseModel
    {

        [NotMapped]
        public int? AccountMainId { get; set; }
        public int VoucherSerialId { get; set; }
        public int? YearlyVoucherTypeWiseSerial { get; set; }

        [NotMapped]
        [Display(Name = "Last No")]
        public string? LastVoucherNo { get; set; }

        [Display(Name = "Voucher No"), StringLength(25, ErrorMessage = "Max length 25 char.")]
        [Column(TypeName = "varchar(25)")]
        public string? VoucherNo { get; set; }
        [Display(Name = "Voucher Date")]
        [DisplayFormat(DataFormatString = "{0:yy/MM/dd}")]
        [DataType(DataType.Date)]
        public DateTime VoucherDate { get; set; }

        [Display(Name = "Voucher Input Date")]
        public DateTime VoucherInputDate { get; set; }

        [Display(Name = "Image [Folder]")]

        public string? FilePath { get; set; }


        public double MasterCurrencyRate { get; set; }


        [Display(Name = "Unit")]
        public virtual PrdUnit? PrdUnits { get; set; }
        [Display(Name = "Unit")]
        [ForeignKey("PrdUnits")]
        public int? PrdUnitId { get; set; }


        [Display(Name = "Location")]
        public virtual WarehouseModel? Location { get; set; }
        [Display(Name = "Location")]
        [ForeignKey("Location")]
        public int? WarehouseId { get; set; }

        public string? ApprovalStage { get; set; }

        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string? VoucherDesc { get; set; }
        public int? LuserIdCheck { get; set; }
        public int? LuserIdApprove { get; set; }
        public bool isAutoEntry { get; set; }
        public bool isPosted { get; set; }



        [Display(Name = "Amount")]

        public double VAmount { get; set; }
        [Display(Name = "In Words")]
        public string? vAmountInWords { get; set; }


        public string? Source { get; set; }
        public int SourceId { get; set; }
        [Display(Name = "Convert Rate"), Range(0, double.MaxValue, ErrorMessage = "Conversion rate must grater than zero.")]
        public double ConvRate { get; set; }

        [Display(Name = "Amount [Local]")]

        public double vAmountLocal { get; set; }

        [Display(Name = "Ref. One")]

        public string? Referance { get; set; }
        [Display(Name = "Ref. Two")]

        public string? ReferanceTwo { get; set; }

        [Display(Name = "Amount / Ref. Three")]

        public string? ReferanceThree { get; set; }
        public bool IsCash { get; set; }





        [Display(Name = "Voucher Type")]
        public virtual Acc_VoucherTypeModel? Acc_VoucherTypes { get; set; }
        [Display(Name = "Voucher Type")]
        [ForeignKey("Acc_VoucherTypes")]
        public int VoucherTypeId { get; set; }


        [Display(Name = "Currency"), Range(1, int.MaxValue, ErrorMessage = "Select Currency.")]
        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        public virtual CountryModel? Acc_Currency { get; set; }



        [Display(Name = "Currency"), Range(1, int.MaxValue, ErrorMessage = "Select Currency.")]
        public int CountryIdLocal { get; set; }
        [ForeignKey("CountryIdLocal")]
        public virtual CountryModel? Acc_CurrencyLocal { get; set; }

        [Display(Name = "Fiscal Year")]
        public int? FiscalYearId { get; set; }
        [ForeignKey("FiscalYearId")]
        public virtual Acc_FiscalYearModel? Acc_FiscalYears { get; set; }


        [Display(Name = "Fiscal Month")]
        public int? FiscalMonthId { get; set; }
        [ForeignKey("FiscalMonthId")]
        public virtual Acc_FiscalMonthModel? Acc_FiscalMonths { get; set; }



        [NotMapped]
        public string[]? VoucherTranGroupArray { get; set; }

        public string? VoucherTranGroupList { get; set; }

        //[Display(Name = "Single Entry Input")]
        //public byte IsSingleEntry { get; set; }

        [Display(Name = "Tran Group")]
        [ForeignKey("VoucherTranGroups")]
        public int? VoucherTranGroupId { get; set; }
        public virtual VoucherTranGroupModel? VoucherTranGroups { get; set; }

        public virtual ICollection<Acc_VoucherSubModel>? VoucherSubs { get; set; }

        public virtual ICollection<Acc_VoucherSubChecknoModel>? VoucherCheckNos { get; set; }

        public virtual ICollection<Acc_VoucherTranGroupModel>? Acc_VoucherTranGroups { get; set; }

        public virtual ICollection<Acc_VoucherTagsModel>? VoucherTagsList { get; set; }

        [NotMapped]
        public string[]? VoucherTags { get; set; }

        public string? VoucherFilePath { get; set; }


    }

    [Table("Acc_VoucherSub")]

    public class Acc_VoucherSubModel : BaseModel
    {

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Key]
        //public int VoucherSubId { get; set; }


        public int AccId { get; set; }
        [ForeignKey("AccId")]
        public virtual AccountHeadModel? Acc_ChartOfAccount { get; set; }

        public int SRowNo { get; set; }
        public int ccId { get; set; }
        public int CurrencyId { get; set; }
        [ForeignKey("CurrencyId")]
        public virtual CountryModel? Country { get; set; }
        public int CurrencyForeignId { get; set; }
        [ForeignKey("CurrencyForeignId")]
        public virtual CountryModel? CountryForeign { get; set; }

        public double TKDebit { get; set; }
        public double TKCredit { get; set; }
        public double TKDebitLocal { get; set; }
        public double TKCreditLocal { get; set; }
        public double CurrencyRate { get; set; }
        public string? Note1 { get; set; }
        public string? Note2 { get; set; }
        public string? Note3 { get; set; }
        public string? Note4 { get; set; }
        public string? Note5 { get; set; }
        public int? RowNo { get; set; }
        public int? RefId { get; set; }
        public int? SLNo { get; set; }
        public int? EmpId { get; set; }
        [ForeignKey("EmpId")]
        public virtual EmployeeModel? EmployeeData { get; set; }


        public int? CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual CustomerModel? Customers { get; set; }

        public int? SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        public virtual SupplierModel? Suppliers { get; set; }


        public int VoucherId { get; set; }
        [ForeignKey("VoucherId")]
        public virtual Acc_VoucherMainModel? Acc_VoucherMain { get; set; }

        public int? VoucherTranGroupIdRow { get; set; }
        [Display(Name = "Transaction Group")]
        [ForeignKey("VoucherTranGroupIdRow")]
        public virtual VoucherTranGroupModel? VoucherTranGroups { get; set; }

        public virtual ICollection<Acc_VoucherSubChecknoModel>? VoucherSubChecnoes { get; set; }

        public virtual ICollection<Acc_VoucherSubSectionModel>? VoucherSubSections { get; set; }


        //public string? SerialItem { get; set; }



        public int? SalesId { get; set; }
        [ForeignKey("SalesId")]
        public virtual SalesModel? Sale { get; set; }


        public int? PurchaseId { get; set; }
        [ForeignKey("PurchaseId")]
        public virtual PurchaseModel? Purchase { get; set; }



        public int? SalesReturnId { get; set; }
        [ForeignKey("SalesReturnId")]
        public virtual SalesReturnModel? SalesReturn { get; set; }



        public int? PurchaseReturnId { get; set; }
        [ForeignKey("PurchaseReturnId")]
        public virtual PurchaseReturnModel? PurchaseReturn { get; set; }




        public int? DamageId { get; set; }
        [ForeignKey("DamageId")]
        public virtual DamageModel? Damage { get; set; }



        public int? IssueId { get; set; }
        [ForeignKey("IssueId")]
        public virtual IssueModel? Issue { get; set; }



        public int? TransferInId { get; set; }
        [ForeignKey("TransferInId")]
        public virtual InternalTransferModel? TransferIn { get; set; }



        public int? TransferOutId { get; set; }
        [ForeignKey("TransferOutId")]
        public virtual InternalTransferModel? TransferOut { get; set; }


        public int? MemberId { get; set; }
        [ForeignKey("MemberId")]
        public virtual MemberModel? Member { get; set; }
    }


    [Table("Acc_VoucherTags")]

    public class Acc_VoucherTagsModel : BaseModel
    {
        public int VoucherId { get; set; }
        [ForeignKey("VoucherId")]
        public virtual Acc_VoucherMainModel? acc_vouchermains { get; set; }
        //[Key]
        //public int VoucherSubCheckId { get; set; }
        public string? tag { get; set; }


    }


    //[Table("Country")]

    //public class Country : SelfModel
    //{
    //    //[Key]
    //    //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    //public int CountryId { get; set; }

    //    [Required]
    //    [StringLength(10, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
    //    [DataType(DataType.Text)]
    //    [Display(Name = "Country Code")]
    //    public string? CountryCode { get; set; }

    //    [Required]
    //    [StringLength(10, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
    //    [DataType(DataType.Text)]
    //    [Display(Name = "Dial Code")]
    //    public string? DialCode { get; set; }


    //    [Required]
    //    [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
    //    [DataType(DataType.Text)]
    //    [Display(Name = "Country Name")]
    //    public string? CountryName { get; set; }

    //    [Required]
    //    [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
    //    [DataType(DataType.Text)]
    //    [Display(Name = "Country Short Name")]
    //    public string? CountryShortName { get; set; }


    //    [Required]
    //    [StringLength(10, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
    //    [DataType(DataType.Text)]
    //    [Display(Name = "Culture Info")]
    //    public string? CultureInfo { get; set; }


    //    [Required]
    //    [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
    //    [Display(Name = "Currency Name")]
    //    public string? CurrencyName { get; set; }


    //    [Required]
    //    [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
    //    [Display(Name = "Currency Symbol")]
    //    public string? CurrencySymbol { get; set; }


    //    [Required]
    //    [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
    //    [DataType(DataType.Text)]
    //    [Display(Name = "Currency Short Name")]
    //    public string? CurrencyShortName { get; set; }


    //    [Required]
    //    [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
    //    [DataType(DataType.Text)]
    //    [Display(Name = "Flag Class")]
    //    public string? FlagClass { get; set; }

    //    [Display(Name = "Customer")]
    //    public virtual ICollection<CustomerModel> Customers { get; set; }
    //    public virtual ICollection<SupplierModel> Suppliers { get; set; }

    //    public bool isActive { get; set; }


    //    [Display(Name = "State")]
    //    public virtual ICollection<State> StateCountry { get; set; }



    //}

    //[Table("City")]

    //public class City : SelfModel
    //{
    //    public int CityId { get; set; }
    //    [Required]
    //    [Display(Name = "City Code")]
    //    public string? CityCode { get; set; }
    //    [Required]
    //    [Display(Name = "State")]
    //    public int StateId { get; set; }
    //    [Required]
    //    [Display(Name = "City Name")]
    //    public string? CityName { get; set; }
    //    [Display(Name = "State")]
    //    public virtual State StateCity { get; set; }
    //}

    //public class CityViewModel
    //{
    //    public int CityViewId { get; set; }
    //    [Display(Name = "City Code")]
    //    public string? CityCode { get; set; }

    //    [Display(Name = "City Name")]
    //    public string? CityName { get; set; }

    //    [Display(Name = "State")]
    //    public string? StateName { get; set; }

    //    [Display(Name = "Country")]
    //    public string? CountryName { get; set; }

    //}

    //[Table("State")]

    //public class State : SelfModel
    //{
    //    //public int StateId { get; set; }

    //    [Required]
    //    [Display(Name = "State Code")]
    //    public string? StateCode { get; set; }

    //    [Required]
    //    [Display(Name = "State Name")]
    //    public string? StateName { get; set; }
    //    [Required]
    //    [Display(Name = "Country")]
    //    public int CountryId { get; set; }
    //    [Display(Name = "Country")]
    //    public virtual Country Countries { get; set; }
    //    [Display(Name = "City")]
    //    public virtual ICollection<City> CityList { get; set; }
    //}
    [Table("Acc_VoucherTranGroup")]
    public partial class Acc_VoucherTranGroupModel : BaseModel
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int VoucherTranId { get; set; }

        public int VoucherTranGroupId { get; set; }

        [Display(Name = "Transaction Group")]
        [ForeignKey("VoucherTranGroupId")]
        public virtual VoucherTranGroupModel? VoucherTranGroups { get; set; }

        public int VoucherId { get; set; }
        [ForeignKey("VoucherId")]
        public virtual Acc_VoucherMainModel? acc_vouchermains { get; set; }

    }

    [Table("VoucherTranGroup")]

    public class VoucherTranGroupModel : SelfModel
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int VoucherTranGroupId { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Transaction Group Name")]
        public string? VoucherTranGroupName { get; set; }


    }

    [Table("Acc_VoucherSubSection")]

    public class Acc_VoucherSubSectionModel : BaseModel
    {
        //[Key]
        //public int VoucherSubSectionId { get; set; }
        public int VoucherSubId { get; set; }

        public int RowNoSSec { get; set; }
        public int VoucherId { get; set; }
        public int AccId { get; set; }
        public int SRowNo { get; set; }
        public int SubSectId { get; set; }
        public string? Note1 { get; set; }
        public string? Note2 { get; set; }
        public double Amount { get; set; }

        public virtual Cat_SubSectionModel? SubSection { get; set; }
        [ForeignKey("VoucherSubId")]

        public virtual Acc_VoucherSubModel? Acc_VoucherSub { get; set; }
    }


    //[Table("Cat_SubSection")]


    //public class Cat_SubSection : BaseModel
    //{
    //    //public Cat_SubSection()
    //    //{

    //    //}
    //    //[Key]
    //    //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    //public int SubSectId { get; set; }

    //    [Display(Name = "Sub Section Name")]
    //    [Required(ErrorMessage = "Please Provide Sub Section Name")]
    //    [StringLength(25)]
    //    [DataType("NVARCHAR(25)")]
    //    public string? SubSectName { get; set; }
    //    [Display(Name = "Sub Section Bangla")]
    //    public string? SubSectNameB { get; set; }

    //    [Display(Name = "Section Name")]
    //    public int SectId { get; set; }
    //    [Display(Name = "Department Name")]
    //    public int DeptId { get; set; }

    //    [Display(Name = "SL NO")]
    //    public short Slno { get; set; }

    //    [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
    //    public DateTime DtInput { get; set; }

    //    //public virtual Cat_Company Com { get; set; }
    //    [ForeignKey("DeptId")]
    //    public virtual Cat_DepartmentModel? Dept { get; set; }
    //    [ForeignKey("SectId")]

    //    public virtual Cat_Section Sect { get; set; }
    //}
    ////[Table("Cat_Section")]



    //public class Cat_Section : BaseModel
    //{
    //    //public Cat_Section()
    //    //{

    //    //    Cat_SubSection = new HashSet<Cat_SubSection>();
    //    //}

    //    //[Key]
    //    //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    //public int SectId { get; set; }

    //    [Display(Name = "Section Name")]
    //    [Required(ErrorMessage = "Please Provide Section Name")]
    //    [StringLength(25)]
    //    [DataType("NVARCHAR(25)")]
    //    public string? SectName { get; set; }

    //    [Display(Name = "Section Bangla")]
    //    [StringLength(25)]
    //    [DataType("NVARCHAR(25)")]
    //    public string? SectNameB { get; set; }

    //    [Display(Name = "Department")]
    //    public int? DeptId { get; set; }
    //    public virtual Cat_DepartmentModel? Dept { get; set; }

    //    [Display(Name = "SL NO")]
    //    public int Slno { get; set; }

    //    [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
    //    public DateTime DtInput { get; set; }

    //    public virtual ICollection<Cat_SubSection> Cat_SubSection { get; set; }
    //}




    [Table("Acc_VoucherSubCheckno")]

    public class Acc_VoucherSubChecknoModel : BaseModel
    {
        //[Key]
        //public int VoucherSubCheckId { get; set; }
        public int RowNoChk { get; set; }

        public int? SRowNo { get; set; }
        public string? ChkNo { get; set; }
        public DateTime? dtChk { get; set; }
        public string? dtChkTo { get; set; }

        public string? Remarks { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Amount { get; set; }

        [Display(Name = "Interest Rate")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal InterestRate { get; set; }

        public bool isClear { get; set; }
        public string? dtChkClear { get; set; }
        public string? Criteria { get; set; }

        public int? VoucherId { get; set; }
        [ForeignKey("VoucherId")]
        public virtual Acc_VoucherMainModel? Acc_VoucherMain { get; set; }
        //public int? VoucherId { get; set; }
        public int? VoucherSubId { get; set; }


        [ForeignKey("VoucherSubId")]
        public virtual Acc_VoucherSubModel? Acc_VoucherSub { get; set; }


        public int AccId { get; set; }
        [ForeignKey("AccId")]
        public virtual AccountHeadModel? vAcc_ChartOfAccount { get; set; }

        public int? LuserIdCheck { get; set; }

        public int? LuserIdApprove { get; set; }

        public bool isManualEntry { get; set; }

        //public virtual ICollection<Acc_VoucherSubCheckno_Clearing> Acc_VoucherSubCheckno_Clearings { get; set; }
    }
    [Table("Acc_VoucherNoPrefix")]

    public class Acc_VoucherNoPrefixModel : BaseModel
    {


        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Key]
        //public int VoucherNoPrefixId { get; set; }

        [Display(Name = "Voucher Type")]
        //[Key, Column(Order = 0)]
        public int VoucherTypeId { get; set; }
        [ForeignKey("VoucherTypeId")]
        public virtual Acc_VoucherTypeModel? vVoucherTypes { get; set; }

        [Display(Name = "Voucher Prefix")]

        public string? VoucherShortPrefix { get; set; }

        [Display(Name = "No Length")]
        public int Length { get; set; } = 0;


        [Display(Name = "Visible For Entry")]
        public bool isVisible { get; set; }





    }
    [Table("Acc_VoucherType")]

    public class Acc_VoucherTypeModel : SelfModel
    {
        // [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]

        //
        //public Acc_VoucherType()
        //{
        //    this.VoucherMains = new HashSet<Acc_VoucherMain>();
        //}
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Key]
        //public int VoucherTypeId { get; set; }

        [Display(Name = "Voucher Type")]
        public string? VoucherTypeName { get; set; }
        [Display(Name = "Short Name")]

        public string? VoucherTypeNameShort { get; set; }
        [Display(Name = "Voucher Type Class [HTML Design / Panel Color]")]

        public string? VoucherTypeClass { get; set; }

        [Display(Name = "Button Class [HTML Design / Button Color]")]

        public string? VoucherTypeButtonClass { get; set; }
        [Display(Name = "Visible For Entry")]
        public bool isSystem { get; set; }

        public virtual ICollection<Acc_VoucherNoPrefixModel>? VoucherNoPrefixs { get; set; }


        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Acc_VoucherMainModel>? VoucherMains { get; set; }


    }
    [Table("Acc_VoucherNoCreatedType")]

    public class Acc_VoucherNoCreatedTypeModel : SelfModel
    {
        //[Key]
        ////[Key, Column(Order = 0)]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int VoucherNoCreatedTypeId { get; set; }

        [Required]
        [Display(Name = "Voucher No Created Types Code")]
        public string? VoucherNoCreatedTypeCode { get; set; }

        [Required]
        [Display(Name = "Voucher No Created Types Name")]
        public string? VoucherNoCreatedTypeName { get; set; }

        //[Display(Name = "BusinessType Name")]

        //public virtual ICollection<Company> vBusinessTypesCompany { get; set; }
    }


    public class FiscalyearCreationModel
    {
        //[Display(Name = "Opening Year")]

        //[DisplayFormat(DataFormatString = "{0:yyyy}")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy}")]
        public int OpeningYear { get; set; }



        [Display(Name = "Fiscal Year")]
        public virtual FiscalYearTypeModel? FiscalYearType { get; set; }
        [Display(Name = "Fiscal Year")]
        [ForeignKey("FiscalYearType")]
        public int FiscalYearTypeId { get; set; }

    }




    [Table("Acc_FiscalYear")]

    public class Acc_FiscalYearModel : BaseModel
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int FiscalYearId { get; set; }

        //public int FYId { get; set; }

        //        [Required]

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Display(Name = "Fiscal Year Period")]
        public string? FYName { get; set; }

        [Display(Name = "Fiscal Year Period Bangla")]
        public string? FYNameBangla { get; set; } = string.Empty;


        [Display(Name = "Opening Date")]
        public string? OpDate { get; set; }

        [Display(Name = "Closing Date")]
        public string? ClDate { get; set; }


        [Display(Name = "Opening Date")]
        public DateTime OpeningDate { get; set; }

        [Display(Name = "Closing Date")]
        public DateTime ClosingDate { get; set; }



        public bool isWorking { get; set; }
        public bool isRunning { get; set; }
        [NotMapped]
        public bool isCheck { get; set; }

        public int? RowNo { get; set; }

        [Display(Name = "Locked Yes / No")]
        public bool isLocked { get; set; }

    }
    [Table("Acc_FiscalMonth")]

    public class Acc_FiscalMonthModel : BaseModel
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int FiscalMonthId { get; set; }
        //public int MonthId { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [NotMapped]
        public bool isCheck { get; set; }


        //        [Required]
        [Display(Name = "Month")]
        public string? MonthName { get; set; }


        [Display(Name = "Month Bangla")]
        public string? MonthNameBangla { get; set; }

        [Display(Name = "Opening Date")]
        public string? dtFrom { get; set; }

        [Display(Name = "Closing Date")]
        public string? dtTo { get; set; }


        [Display(Name = "Opening Date")]
        public DateTime OpeningdtFrom { get; set; }

        [Display(Name = "Closing Date")]
        public DateTime ClosingdtTo { get; set; }


        //public int aid { get; set; }

        public int FYId { get; set; }


        public int HYearId { get; set; }
        public int QtrId { get; set; }


        [Display(Name = "Locked Yes / No")]

        public bool isLocked { get; set; }


        [Display(Name = "Store Locked Yes / No")]

        public bool isLockedStore { get; set; }
        [Display(Name = "Accounts Locked Yes / No")]


        public bool isLockedAccounts { get; set; }
        [Display(Name = "Attendance Locked Yes / No")]


        public bool isLockedAttendance { get; set; }
        [Display(Name = "Salary Locked Yes / No")]

        public bool isLockedSalary { get; set; }

    }
    [Table("Acc_FiscalHalfYear")]

    public class Acc_FiscalHalfYear : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int FiscalHalfYearId { get; set; }

        //public int HYearId { get; set; }

        [Display(Name = "Fiscal Half Year Period")]
        public string? HyearName { get; set; }

        [Display(Name = "Fiscal Half Year Period Bangla")]
        public string? HyearNameBangla { get; set; }


        [Display(Name = "Opening Date")]
        public string? dtFrom { get; set; }

        [Display(Name = "Closing Date")]
        public string? dtTo { get; set; }

        //public int aid { get; set; }


        public int FYId { get; set; }

    }
    [Table("Acc_FiscalQtr")]

    public class Acc_FiscalQtr : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int FiscalQtrId { get; set; }
        //public int QtrId { get; set; }


        //        [Required]
        [Display(Name = "Quarter Period")]
        public string? QtrName { get; set; }


        [Display(Name = "Quarter Period Bangla")]
        public string? QtrNameBangla { get; set; }


        [Display(Name = "Opening Date")]
        public string? dtFrom { get; set; }

        [Display(Name = "Closing Date")]
        public string? dtTo { get; set; }

        //public int aid { get; set; }

        public int FYId { get; set; }
        public int HYearId { get; set; }

    }
    [Table("PrdUnit")]

    public class PrdUnit : BaseModel
    {
        //[Key]
        //public int PrdUnitId { get; set; }

        [StringLength(10)]
        [Display(Name = "PrdUnit Code")]
        public string? PrdUnitCode { get; set; }


        [Display(Name = "Operating Unit")]
        public string? PrdUnitName { get; set; }

        [StringLength(10)]
        [Display(Name = "Short name")]
        public string? PrdUnitShortName { get; set; }


        [Display(Name = "is Production Unit")]
        public bool isPrdUnit { get; set; }


        [Display(Name = "Bangla name")]
        public string? PrdUnitBanglaName { get; set; }

        [Display(Name = "SLNo")]
        public int SLNo { get; set; }

    }



    public partial class Cat_Integration_Setting_Main : BaseModel
    {

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Plz input Name")]
        [StringLength(50)]
        public string? IntegrationSettingName { get; set; }

        [Display(Name = "Integration Table Name")]
        [StringLength(100)]
        public string? IntegrationTableName { get; set; }


        [Display(Name = "Integration Remarks")]
        [DataType(DataType.MultilineText)]
        public string? IntegrationRemarks { get; set; }


        public virtual ICollection<Cat_Integration_Setting_Details>? Cat_Integration_Setting_Details { get; set; }


        [Display(Name = "Primary Serial No")]
        [StringLength(10)]
        public string? MainSLNo { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        [Display(Name = "Voucher Type")]
        public int? VoucherTypeId { get; set; }

        [ForeignKey("VoucherTypeId")]
        public virtual Acc_VoucherTypeModel? Acc_VoucherType { get; set; }


    }


    public partial class Cat_Integration_Setting_Details : BaseModel
    {


        public int IntegrationSettingMainId { get; set; }
        [ForeignKey("IntegrationSettingMainId")]
        public virtual Cat_Integration_Setting_Main? Cat_Integration_Setting_Mains { get; set; }




        [Display(Name = "Account/Salary Head Name")]
        public int AccId { get; set; }
        [ForeignKey("AccId")]
        public virtual AccountHeadModel? Acc_ChartOfAccounts { get; set; }

        [NotMapped]
        public string[]? Columns { get; set; }

        [Display(Name = "Payroll Table Column Name")]
        [StringLength(1000)]

        public string? SelectColumnNameOne { get; set; }

        public int ConditionCount { get; set; }

        [Display(Name = "Where 1st Condition")]
        [StringLength(200)]
        public string? ColNameOne { get; set; }

        [Display(Name = "1st Cond. Value")]
        [StringLength(200)]
        public string? colNameOneValue { get; set; }//OtherLinkOne

        [Display(Name = "And 2nd Condition")]
        [StringLength(200)]
        public string? ColNameTwo { get; set; }

        [Display(Name = "2nd Cond. Value")]
        [StringLength(200)]
        public string? colNameTwoValue { get; set; }//OtherLineTwo


        [Display(Name = "And 3rd Condition")]
        [StringLength(200)]
        public string? ColNameThree { get; set; }

        [Display(Name = "3rd Cond. Value")]
        [StringLength(200)]
        public string? colNameThreeValue { get; set; }//OtherLineTwo

        [Display(Name = "And 4th Condition")]
        [StringLength(200)]
        public string? ColNameFour { get; set; }

        [Display(Name = "4th Cond. Value")]
        [StringLength(200)]
        public string? colNameFourValue { get; set; }//OtherLineTwo


        [Display(Name = "Serial No")]

        public int SLNo { get; set; }


        public string? SelectStatement { get; set; }

        public string? WhereCondition { get; set; }


        public string? ColNameOneGroupBy { get; set; }
        public string? ColNameTwoGroupBy { get; set; }
        public string? ColNameThreeGroupBy { get; set; }
        public string? ColNameFourGroupBy { get; set; }
        public string? GroupByCondition { get; set; }




        [Display(Name = "Remarks")]
        [StringLength(300)]
        public string? Remarks { get; set; }




        public bool IsSubtract { get; set; }

        [Display(Name = "Is Debit")]

        public bool IsDebit { get; set; }


        [Display(Name = "Is Credit")]

        public bool IsCredit { get; set; }

        [NotMapped]
        public bool IsDelete { get; set; }

        [StringLength(128)]
        public string? ComId { get; set; }

        [StringLength(128)]
        public string? PcName { get; set; }
        [StringLength(128)]
        public string? UserId { get; set; }
        public Nullable<DateTime> DateAdded { get; set; }
        public string? UpdateByUserId { get; set; }
        public Nullable<DateTime> DateUpdated { get; set; }

    }


    public partial class Cat_PayrollIntegrationSummary : BaseModel
    {


        [Display(Name = "Data Type")]
        [DataType("nvarchar(200)")]
        public string? DataType { get; set; }

        [Display(Name = "Employee Type")]
        [DataType("nvarchar(200)")]
        public string? EmployeeType { get; set; }


        [Display(Name = "Account/Salary Head Name")]
        public int AccId { get; set; }
        [ForeignKey("AccId")]
        public virtual AccountHeadModel? Acc_ChartOfAccounts { get; set; }


        [Display(Name = "Fiscal Year")]
        public int? FiscalYearId { get; set; }
        [ForeignKey("FiscalYearId")]
        public virtual Acc_FiscalYearModel? Acc_FiscalYears { get; set; }


        [Display(Name = "Fiscal Month")]
        public int? FiscalMonthId { get; set; }
        [ForeignKey("FiscalMonthId")]
        public virtual Acc_FiscalMonthModel? Acc_FiscalMonths { get; set; }

        public double TKDebitLocal { get; set; }
        public double TKCreditLocal { get; set; }


        [Display(Name = "Serial No")]

        public string? SLNo { get; set; }


        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }


        public string? Note1 { get; set; }
        public string? Note2 { get; set; }
        public string? Note3 { get; set; }
        public string? Remarks { get; set; }

    }


    public partial class ProcessLock : BaseModel
    {

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
        public virtual Acc_FiscalMonthModel? Acc_FiscalMonths { get; set; }



        [Display(Name = "Is Lock")]
        public bool IsLock { get; set; }



    }

    public partial class ShowVoucherViewModel
    {
        [Display(Name = "From Date ")]
        public string? dtFrom { get; set; }

        [Display(Name = "To Date ")]
        public string? dtTo { get; set; }
        [Display(Name = "Currency ")]
        public int? CountryId { get; set; }
        public List<Acc_FiscalYearModel>? FiscalYs { get; set; }
        public List<Acc_FiscalMonthModel>? ProcessMonths { get; set; }
        public List<Acc_FiscalHalfYear>? ProcessHalfYear { get; set; }
        public List<Acc_FiscalQtr>? ProcessQtr { get; set; }


        [Display(Name = "Voucher Type")]
        public int VoucherTypeId { get; set; }

        [Display(Name = "Voucher ID")]
        public string? VoucherId { get; set; }

        [Display(Name = "Voucher From No")]
        public string? VoucherFrom { get; set; }
        [Display(Name = "Voucher To No")]
        public string? VoucherTo { get; set; }



        [Display(Name = "Accounts Name")]
        public int AccId { get; set; }


        [Display(Name = "Accounts Name ")]
        public int AccIdGroup { get; set; }

        [Display(Name = "Note One [CT] ")]
        public int AccIdNoteOneCT { get; set; }


        [Display(Name = "Accounts Name")]
        public int AccIdLedger { get; set; }




        [Display(Name = "Supplier")]
        public int? SupplierId { get; set; }
        [Display(Name = "Customer")]
        public int? CustomerId { get; set; }
        [Display(Name = "Employee")]
        public int? EmployeeId { get; set; }




        [Display(Name = "Accounts Name")]
        public int AccIdRecPay { get; set; }



        public Boolean isLocalCurr { get; set; }

        public Boolean isViewPageReport { get; set; }

        public Boolean isDetailsReport { get; set; }

        public Boolean isTabulatorPageReport { get; set; }


        public Boolean isOther { get; set; }
        public Boolean isPosted { get; set; }
        public Boolean isMaterial { get; set; }


        public Boolean isCompare { get; set; }
        public Boolean isCumulative { get; set; }


        public Boolean isGroup { get; set; }

        public Boolean isShowZero { get; set; }
        [Display(Name = "Operating / Prd. Unit ")]

        public Nullable<int> PrdUnitId { get; set; }



    }

    public class SubReport
    {
        public int Id { get; set; }
        public string? strRptPathSub { get; set; } // Sub Report Path name
        public string? strRFNSub { get; set; }   // Relational Field Name 
        public string? strDSNSub { get; set; }   // DSN Name Sub Report
        public string? strQuerySub { get; set; } // Query string Sub Report
    }

    [Table("Reports")]
    public class ReportModel : SelfModel
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "Report Name")]
        public string? ReportName { get; set; }

        [StringLength(60)]
        public string? ReportLink { get; set; }

        [ForeignKey("ReportGroup")]
        public int? GroupId { get; set; }
        public virtual ReportGroupModel? ReportGroup { get; set; }

        public bool InActive { get; set; }

        public bool IsNew { get; set; }
        public bool IsManagement { get; set; }

        public ReportCategory Category { get; set; }

        public string? CustomValue { get; set; }

        public string? ReportQuery { get; set; }

        public string? Type { get; set; }
        public int? ParentId { get; set; }
        public int? ComId { get; set; }

        [NotMapped]
        public bool IsChecked { get; set; }

    }

    public enum ReportCategory
    {
        Standard, Custom, Management
    }

    [Table("ReportGroup")]
    public class ReportGroupModel : SelfModel
    {
        [Required]
        [StringLength(60)]
        public string? ReportGroupName { get; set; }

        [StringLength(70)]
        public string? FileName { get; set; }

        [StringLength(60)]
        public string? Iconclass { get; set; }

    }

    [Table("ReportUserTracking")]
    public class ReportUserTrackingModel : BaseModel
    {
        [ForeignKey("Reports")]
        public int? ReportId { get; set; }
        public virtual ReportModel? Reports { get; set; }
    }
}
