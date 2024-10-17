using Atrai.Model.Core.Entity.Base;
using Atrai.Model.Core.Entity.Self;
//using Atrai.Migrations;
using DocumentFormat.OpenXml.VariantTypes;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Net.NetworkInformation;
using DataType = System.ComponentModel.DataAnnotations.DataType;

namespace Atrai.Model.Core.Entity
{
    [Table("CommercialCompanies")]
    public class CommercialCompanyModel: BaseModel
    {
        public string? CompanyName { get; set; }
        [Display(Name = "Concern")]

        public string? CompanyShortName { get; set; }
        [Display(Name = "Address")]

        public string? Address { get; set; }

        [Display(Name = "Address2")]

        public string? Address2 { get; set; }
        public string? Address3 { get; set; }

        [Display(Name = "Phone Number")]

        public string? PhoneNumber { get; set; }


        [Display(Name = "Factory Phone Number")]

        public string? FactoryPhoneNumber { get; set; }

        [Display(Name = "Fax")]

        public string? FaxNumber { get; set; }
        [Display(Name = "Email")]

        public string? EmailID { get; set; }

        [Display(Name = "Web Address")]

        public string? Web { get; set; }
        [Display(Name = "Trade License No")]

        public string? TradeLicenceNo { get; set; }
        [Display(Name = "TIN No")]

        public string? TINNo { get; set; }
        [Display(Name = "VAT No")]

        public string? VATNo { get; set; }
        [Display(Name = "IRC No")]

        public string? IRCNo { get; set; }
        [Display(Name = "BKMEA Reg No")]

        public string? BKMEARegNo { get; set; }



        [Display(Name = "Contact Person")]
        public string? ContactPerson { get; set; }

        [Display(Name = "Cont. Designation")]

        public string? ContactPersonDesignation { get; set; }

        public string? ShippingMarks { get; set; }

        [Display(Name = "Business Type")]
        public string? BusinessType { get; set; }
        public bool? Status { get; set; }   
    }



    [Table("ItemGroup")]
    public class ItemGroupModel : BaseModel
    {
        [StringLength(100)]
        [Display(Name = "Item Group")]
        public string? ItemGroupName { get; set; }

        [Display(Name = "Item Group Code")]
        public string? ItemGroupCode { get; set; }

        [Display(Name = "HSCode")]
        public string? ItemGroupHSCode { get; set; }

        [Display(Name = "Item Margin [Bill Discounting]")]
        public decimal? ItemMargin { get; set; }


        [StringLength(100)]
        [Display(Name = "Item Group Short Name")]
        public string? ItemGroupShortName { get; set; }

    }




    [Table("PIType")]
    public class PITypeModel:BaseModel
    {
        [Required]
        [StringLength(100)]
        [Display(Name = "PI Tytpe Name")]
        public string? PITytpeName { get; set; }
        [Required]
        [StringLength(100)]
        public string? PITytpeShortName { get; set; }
    }


    [Table("ItemDescription")]
    public class ItemDescriptionModel:BaseModel
    {
        [Display(Name = "Item Desc Code")]
        public string? ItemDescCode { get; set; }

        [Display(Name = "HSCode")]
        public string? ItemDescHSCode { get; set; }

        [Required]
        [StringLength(200)]

        [Display(Name = "Item Desc")]
        public string? ItemDescName { get; set; }
        [Required]
        [StringLength(100)]

        public string? ItemDescShortName { get; set; }

        public int? ItemGroupId { get; set; }
        [ForeignKey("ItemGroupId")]

        public virtual ItemGroupModel? ItemGroups { get; set; }

    }


    [Table("Com_GroupLC_Main")]
    public partial class GroupLC_MainModel:BaseModel
    {

        [Display(Name = "Magin")]
        public decimal Margin { get; set; }

        [Display(Name = "Freight Charge %")]
        public decimal FreightChargePer { get; set; }


        public int? CommercialCompanyId { get; set; }
        [ForeignKey("CommercialCompanyId")]
        public virtual CommercialCompanyModel? CommercialCompanies { get; set; }

        public int? BuyerId { get; set; }
        [ForeignKey("BuyerId")]
        public virtual CustomerModel? Buyers { get; set; }

        [Display(Name = "Group LC Ref.")]
        [StringLength(100)]
        [Required]
        public string? GroupLCRefName { get; set; }

        [Display(Name = "Group LC Value [Final Export Value]")]
        public Decimal? TotalGroupLCValue { get; set; }

        [Display(Name = "Group LC Value [LC Opening Value]")]

        public Decimal? TotalGroupLCValueManual { get; set; }


        [Display(Name = "Group LC Qty")]

        public Decimal? TotalGroupLCQty { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "First Shipment Date")]

        public DateTime? FirstShipDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Last Shipment Date")]


        public DateTime? LastShipDate { get; set; }


        public virtual ICollection<GroupLC_SubModel>? GroupLC_Sub { get; set; }


        [Column(TypeName = "VARCHAR")]
        [StringLength(200)]
        [Display(Name = "Group LC Rev. Amd No.")]
        public string? GroupLCAmdNo { get; set; }
    }
    [Table("Com_GroupLC_Sub")]
    public partial class GroupLC_SubModel : BaseModel
    {
        public int? MasterLCID { get; set; }
        [ForeignKey("MasterLCID")]
        public virtual MasterLCModel? MasterLC { get; set; }
        public int? GroupLCId { get; set; }
        [ForeignKey("GroupLCId")]
        public virtual GroupLC_MainModel? GroupLC_Mains { get; set; }


    }
    [Table("MasterLC")]
    public partial class MasterLCModel:BaseModel
    {
        [Display(Name = "Sales Contract No.")]
        [Required]
        [StringLength(100)]
        public string? LCRefNo { get; set; }
        [Display(Name = "LC Margin")]
        public float? LCMargin { get; set; } = 0;

        [Display(Name = "LC Type")]

        public int? LCTypeId { get; set; }
        [ForeignKey("LCTypeId")]
        public virtual LCType? LCType { get; set; }

        [Display(Name = "Trade term")]
        public int? TradeTermId { get; set; }
        [ForeignKey("TradeTermId")]
        public virtual CommercialTradeTerm? TradeTerm { get; set; }

        public int? CommercialTypeId { get; set; }
        [ForeignKey("CommercialTypeId")]
        public virtual CommercialType? CommercialType { get; set; }

        [Display(Name = "Destination")]
        public int? DestinationId { get; set; }
        [ForeignKey("DestinationId")]
        public virtual Destination? Destination { get; set; }

        [Display(Name = "Ship Mode")]
        public int? ShipModeId { get; set; }
        [ForeignKey("ShipModeId")]
        public virtual ShipMode? ShipMode { get; set; }

        [StringLength(100)]
        [Display(Name = "Export LC No.")]
        public string? BuyerLCRef { get; set; }

        [StringLength(100)]
        [Display(Name = "CMT Permission")]
        public string? CMTPermission { get; set; }

        [StringLength(100)]
        [Display(Name = "PI No.")]
        public string? PINo { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(200)]
        [Display(Name = "Export LC No. [Import Dept.] Rev. Amd No.")]
        public string? LCNOforImport { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(200)]
        [Display(Name = "Remaining Contract Value")]
        public string? RemainingContractValue { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "PI Date")]
        public DateTime? PIDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Export LC Issue Date")]
        public DateTime? LCOpenDate { get; set; }


        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Sales Contract Issue Date")]
        public DateTime? SalesContractIssueDate { get; set; }


        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Sales Contract Last Shipment Date")]
        public DateTime? LCExpirydate { get; set; }


        [Display(Name = "Last Shipment Date")]
        public DateTime? LastShipmentDate { get; set; }

        [Display(Name = "Export LC/ Contract Qty")]
        public decimal? TotalLCQty { get; set; } = 0;
        [Display(Name = "UOM")]
        public string? UnitMasterId { get; set; }
        [Display(Name = "Export LC/ Contract Value")]

        public decimal? LCValue { get; set; } = 0;

        [Display(Name = "Remaining Contract Value")]

        public decimal? Balance { get; set; } = 0;


        [Display(Name = "Manual Sales Contract Value")]

        public decimal? MasterLCValueManual { get; set; }


        [Display(Name = "Manual Export LC Value")]

        public decimal? ExportLCValueManual { get; set; }

        [Display(Name = "LC Status")]
        //[Required(ErrorMessage = "Please select LC Status")]
        //[Range(0, int.MaxValue, ErrorMessage = "Please select LC Status")]
        public int? LCStatusId { get; set; }
        [ForeignKey("LCStatusId")]
        public virtual LCStatus? LCStatus { get; set; }

        [Display(Name = "LC Nature")]
        public int? LCNatureId { get; set; }
        [ForeignKey("LCNatureId")]
        public virtual LCNature? LCNature { get; set; }

        [Display(Name = "Tenor")]

        public int? Tenor { get; set; }
        //[Display(Name = "Trade Term")]
        //[Required(ErrorMessage = "Please select Trade Term")]
        //[Range(0, int.MaxValue, ErrorMessage = "Please select Trade Term")]

        //public int? TradeTermId { get; set; }


        //public virtual TradeTerm? TradeTerms { get; set; }

        [Display(Name = "Ship Mode")]
        //[Range(0, int.MaxValue, ErrorMessage = "Please select Ship Mode")]
        public int? ShipModelId { get; set; }
        [ForeignKey("ShipModelId")]

        public virtual ShipModel? ShipModels { get; set; }


        [Display(Name = "Payment Terms")]
        public int? PaymentTermsId { get; set; }
        [ForeignKey("PaymentTermsId")]

        public virtual CommercialPaymentTerms? PaymentTerms { get; set; }

        public int? DayListId { get; set; }
        [ForeignKey("DayListId")]

        public virtual DayList? DayList { get; set; }

        //for later
        public virtual ICollection<COM_MasterLCExport>? COM_MasterLCExport { get; set; }
        public virtual ICollection<COM_MasterLC_Details>? COM_MasterLC_Details { get; set; }
        public virtual ICollection<ExportInvoiceMaster>? ExportInvoiceMasters { get; set; }
        public virtual ICollection<GroupLC_SubModel>? COM_GroupLC_Subs { get; set; }



        [Display(Name = "Buyer")]
        //[Required(ErrorMessage = "Please select Buyer")]
        //[Range(0, int.MaxValue, ErrorMessage = "Please select Buyer")]
        public int? BuyerID { get; set; }
        [Display(Name = "Buyer")]
        [ForeignKey("BuyerID")]

        public virtual CustomerModel? BuyerInformations { get; set; }


        [Display(Name = "Group Buyer")]
        //[Range(0, int.MaxValue, ErrorMessage = "Please select Buyer")]
        public int? BuyerGroupID { get; set; }
        [Display(Name = "Group Buyer")]
        [ForeignKey("BuyerGroupID")]

        public virtual BuyerGroup? BuyerGroups { get; set; }
        [Display(Name = "Final Destination")]
        //[Required(ErrorMessage = "Please select Destination")]
        //[Range(0, int.MaxValue, ErrorMessage = "Please select Destination")]
        //public int DestinationId { get; set; }
        //[Display(Name = "Final Destination")]

        //public virtual Destination? Destinations { get; set; }
        public string? DestinationContract { get; set; }


        [Display(Name = "Remarks")]
        public string? Remarks { get; set; }


        [Display(Name = "Company / Concern")]
        //[Required(ErrorMessage = "Please select Concern")]
        //[Range(0, int.MaxValue, ErrorMessage = "Please select Concern")]


        public int? CommercialCompanyId { get; set; }
        [Display(Name = "Company / Concern")]
        [ForeignKey("CommercialCompanyId")]

        public virtual CommercialCompanyModel? CommercialCompanies { get; set; }
        public int? unitId { get; set; }
        [ForeignKey("unitId")]

        public virtual UnitMaster? UnitMaster { get; set; }
        [Display(Name = "Currency")]
        public int? CurrencyId { get; set; }
        [ForeignKey("CurrencyId")]

        public virtual CountryModel? Currency { get; set; }

        //for later
        public int? OpeningBankId { get; set; }
        [ForeignKey("OpeningBankId")]

        public virtual OpeningBank? OpeningBank { get; set; }

        //later
        public int? BankAccountId { get; set; }
        [ForeignKey("BankAccountId")]

        public virtual BankAccountNo? BankAccountNos { get; set; }

        public int? LienBankId { get; set; }
        [ForeignKey("LienBankId")]

        public virtual LienBank? LienBank { get; set; }
        public int? PortOfLoadingId { get; set; }
        [ForeignKey("PortOfLoadingId")]


        public virtual PortOfLoading? PortOfLoading { get; set; }

        public int? PortOfDischargeId { get; set; }
        [ForeignKey("PortOfDischargeId")]


        public virtual PortOfDischarge? PortOfDischarge { get; set; }


        [Display(Name = "Tolerance")]

        public decimal? Tolerance { get; set; }

        [Display(Name = "Shipping Agent")]

        public int? SupplierId { get; set; }///supplier table

        [ForeignKey("SupplierId")]

        public virtual SupplierModel? ShippingAgent { get; set; }
        public string? Insurance { get; set; }

        public string? AccountNo { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FirstShipmentDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public string? RemarksOne { get; set; }
        public string? RemarksTwo { get; set; }
        public string? RemarksThree { get; set; }
        public string? RemarksFour { get; set; }
        public string? RemarksFive { get; set; }

        public string? FileNo { get; set; } //need to add later

    }




    public partial class PortOfDischarge:BaseModel
    {
        [Column(TypeName = "VARCHAR")]
        [StringLength(200)]
        [Required]
        public string? PortOfDischargeName { get; set; }
        [Display(Name = "Port Code")]

        public string? PortCode { get; set; }
        [Display(Name = "Country")]

        public int? CountryId { get; set; }
        [ForeignKey("CountryId")]

        public virtual CountryModel? Countrys { get; set; }
        [Display(Name = "Master LC")]

        public virtual ICollection<MasterLCModel>? COM_MasterLC { get; set; }
    }


    public partial class PortOfLoading:BaseModel
    {

        [Display(Name = "Port Of Loading")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(200)]
        [Required]
        public string? PortOfLoadingName { get; set; }
        [Display(Name = "Port Code")]

        public string? PortCode { get; set; }
        [Display(Name = "Country")]

        public int? CountryId { get; set; }
        [ForeignKey("CountryId")]
        public virtual CountryModel? Countrys { get; set; }
        [Display(Name = "Master LC")]

        public virtual ICollection<MasterLCModel>? COM_MasterLC { get; set; }

    }


    public partial class LienBank:BaseModel
    {
        public string? LienBankName { get; set; }
        [Display(Name = "Country")]
        public int? CountryId { get; set; }
        [ForeignKey("CountryId")]

        public virtual CountryModel? Country { get; set; }
        [Display(Name = "Swift Code")]

        public string? SwiftCode { get; set; }

        [Display(Name = "Lien Bank Account No")]

        public string? LienBankAccountNo { get; set; }


        [Display(Name = "Branch Address")]

        public string? BranchAddress { get; set; }

        [Display(Name = "Branch Address 2")]

        public string? BranchAddress2 { get; set; }
        [Display(Name = "Phone No")]

        public string? PhoneNo { get; set; }
        [Display(Name = "Remarks")]

        public string? Remarks { get; set; }

        public virtual ICollection<MasterLCModel>? COM_MasterLC { get; set; }
    }

    public class BankAccountNo:BaseModel
    {
        [StringLength(100)]
        [Display(Name = "Bank Account No")]
        public string? BankAccountNumber { get; set; }

        public int? CommercialCompanyId { get; set; }
        [ForeignKey("CommercialCompanyId")]
        public virtual CommercialCompanyModel? CommercialCompanies { get; set; }

        public int? OpeningBankId { get; set; }
        [ForeignKey("OpeningBankId")]

        //later
        public virtual OpeningBank? OpeningBanks { get; set; }
    }


    public partial class OpeningBank:BaseModel
    {
        public string? OpeningBankName { get; set; }
        [Display(Name = "Country")]
        public int? CountryId { get; set; }
        [ForeignKey("CountryId")]

        public virtual CountryModel? Country { get; set; }

        [Display(Name = "Swift Code")]

        public string? SwiftCode { get; set; }

        [Display(Name = "Branch Address")]

        public string? BranchAddress { get; set; }
        [Display(Name = "Branch Address 2")]

        public string? BranchAddress2 { get; set; }
        [Display(Name = "Phone No")]

        public string? PhoneNo { get; set; }
        public string? ShortName { get; set; }
        [Display(Name = "Remarks")]

        public string? Remarks { get; set; }

        public virtual ICollection<MasterLCModel>? COM_MasterLC { get; set; }
        public virtual ICollection<BankAccountNo>? BankAccountNos { get; set; }
    }




    public partial class UnitMaster:BaseModel
    {
        public string? UnitMasterId { get; set; }
        [Display(Name = "Unit Short Name")]
        public string? UnitName { get; set; }
        [Display(Name = "Relative Factor")]

        public decimal? RelativeFactor { get; set; }
        [Display(Name = "isBase UOM")]

        public bool? IsBaseUOM { get; set; }
        [NotMapped]
        public string? UMId { get; set; }
        //later
        public int? ExportOrdersId { get; set; }

        public virtual ICollection<ExportOrder> ExportOrders { get; set; }
        public int? UnitGroupId { get; set; }
        [ForeignKey("UnitGroupId")]

        public virtual UnitGroup UnitGroup { get; set; }
    }

    public partial class ExportOrder:BaseModel
    {
        [Display(Name = "Buyer PO No.")]
        public string? BuyerContactPONo { get; set; }
        [Display(Name = "PO Line No")]

        public string? POLineNo { get; set; }
        //[Key, Column(Order = 1)]


        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "PO Date")]
        public System.DateTime PoDate { get; set; }
        [Display(Name = "Destination")]

        public int? DestinationID { get; set; }
        [Display(Name = "Order Qty")]

        public decimal OrderQty { get; set; }
        [Display(Name = "Rate")]

        public decimal Rate { get; set; }
        [Display(Name = "CM")]


        public decimal? CM { get; set; }
        [Display(Name = "Order Value")]

        public decimal OrderValue { get; set; }
        [Display(Name = "Ship Mode")]

        public int? ShipModelId { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ex Factory Date")]
        public DateTime? ExFactoryDate { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ship Date")]
        public DateTime? ShipDate { get; set; }
        [Display(Name = "Order Status")]


        public int? ExportOrderStatusId { get; set; }
        [Display(Name = "Order Category")]

        public int? ExportOrderCategoryId { get; set; }


        [Display(Name = "Remark")]

        public string? Remark { get; set; }


         public int?StyleId { get; set; }
        [ForeignKey("StyleId")]
        public virtual StyleModel? StyleInformation { get; set; }

        ///for later
        //public int? UnitMasterId { get; set; }
        //[ForeignKey("UnitMasterId")]

        //public virtual UnitMaster? UnitMaster { get; set; }

        //for later
        //public virtual Destination? Destination { get; set; }
        //public virtual ShipModel? ShipModels { get; set; }
        //public virtual ExportOrderStatus ExportOrderStatus { get; set; }
        //public virtual ExportOrderCategory ExportOrderCategorys { get; set; }
    }


    public partial class ExportInvoiceMaster:BaseModel
    {
        [Display(Name = "Invoice No")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        [Required]
        public string? InvoiceNo { get; set; }

        [Display(Name = "Invoice Date")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime InvoiceDate { get; set; }

        [Display(Name = "Delivery Term")]
        public string? DeliveryTerm { get; set; }
        [Display(Name = "Total Shipped")]
        public decimal? TotalShipped { get; set; }

        [Display(Name = "Balance Shipped")]
        public decimal? BalanceShip { get; set; }

        [Display(Name = "MasterLCId")]
        public int? MasterLCId { get; set; }
        [ForeignKey("MasterLCId")]

        public virtual MasterLCModel? COM_MasterLC { get; set; }

        [Display(Name = "Buyer")]
        public int? BuyerId { get; set; }
        [ForeignKey("BuyerId")]

        public virtual CustomerModel? BuyerInformation { get; set; }

        //later
        //[Display(Name = "Buyer Group")]
        //public int? BuyerGroupId { get; set; }
        //public virtual BuyerGroup? BuyerGroups { get; set; }


        [Display(Name = "Manufacture Company")]
        public int? ManufactureId { get; set; }
        [ForeignKey("ManufactureId")]
        public virtual CommercialCompanyModel? ComercialCompanyss { get; set; }


        [Display(Name = "Notify Party 1st")]
        public int? FirstNotifyPartyId { get; set; }
        [ForeignKey("FirstNotifyPartyId")]
        public virtual NotifyParty? NotifyPartyFirst { get; set; }

        [Display(Name = "Notify Party 2nd")]
        public int? SecondNotifyPartyId { get; set; }
        [ForeignKey("SecondNotifyPartyId")]
        public virtual NotifyParty? NotifyPartySecound { get; set; }


        [Display(Name = "Notify Party 3rd")]
        public int? ThirdNotifyPartyId { get; set; }
        [ForeignKey("ThirdNotifyPartyId")]
        public virtual NotifyParty? NotifyPartyThird { get; set; }


        [Display(Name = "Exporter")]

        public int? CommercialCompanyId { get; set; }
        [ForeignKey("CommercialCompanyId")]
        public virtual CommercialCompanyModel? CommercialCompany { get; set; }

        [Display(Name = "Port Of Loading")]
        public int? PortOfLoadingId { get; set; }
        [ForeignKey("PortOfLoadingId")]

        public virtual PortOfLoading? PortOfLoading { get; set; }
        [Display(Name = "Port Of Discharge")]
        public int? PortOfDischargeId { get; set; }
        [ForeignKey("PortOfDischargeId")]

        public virtual PortOfDischarge? PortOfDischarge { get; set; }


        [Display(Name = "Final Destination")]
        public int? DestinationId { get; set; }
        public virtual Destination? Destination { get; set; }

        [Display(Name = "ShipModel")]
        public int? ShipModeId { get; set; }
        public virtual ShipModel? ShipModel { get; set; }

        [Display(Name = "Cond. Of Sales")]
        public int? TradeTermId { get; set; }
        public virtual CommercialTradeTerm? Tradeterms { get; set; }

        [Display(Name = "Forwarder")]
        public int? SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        public virtual SupplierModel? SupplierInformation { get; set; }

        [Display(Name = "Exfactory Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ExfactoryDate { get; set; }

        [Display(Name = "Onboard Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? OnboardDate { get; set; }

        [Display(Name = "Exp No")]
        [StringLength(100)]
        public string? ExpNo { get; set; }

        [Display(Name = "Rex Reg")]
        [StringLength(100)]
        public string? RexReg { get; set; }

        [Display(Name = "Ex-Bond No")]
        [StringLength(100)]
        public string? ExBondNo { get; set; }

        [Display(Name = "EP No")]
        [StringLength(100)]
        public string? EPNo { get; set; }

        [Display(Name = "ExBond Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ExBondDate { get; set; }

        [Display(Name = "EP Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EPDate { get; set; }

        [Display(Name = "Exp Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ExpDate { get; set; }

        [Display(Name = "BL No")]
        [StringLength(100)]
        public string? BLNo { get; set; }

        [Display(Name = "BL Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? BLDate { get; set; }

        [Display(Name = "BOOKING No")]
        public string? BookingNo { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Booking Date")]
        public DateTime? BookingDate { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Goods Description")]
        [StringLength(500)]
        public string? GoodsDescription { get; set; }

        [Display(Name = "Carton Measurement")]
        [StringLength(500)]
        [DataType(DataType.MultilineText)]

        public string? CartonMeasurement { get; set; }


        [Display(Name = "Vessel Name")]
        [StringLength(500)]
        public string? VesselName { get; set; }


        [Display(Name = "Shipment Authorization")]
        [StringLength(500)]
        public string? ShipmentAuthorization { get; set; }


        [Display(Name = "Voyage No")]
        [StringLength(500)]
        public string? VoyageNo { get; set; }
        [Display(Name = "Remarks")]
        [StringLength(500)]
        [DataType(DataType.MultilineText)]
        public string? Remarks { get; set; }

        [Display(Name = "Main Marks")]
        [StringLength(500)]
        [DataType(DataType.MultilineText)]
        public string? MainMark { get; set; }

        [Display(Name = "Net Weight")]
        public decimal? NetWeight { get; set; }

        [Display(Name = "Gross Weight")]
        public decimal? GrossWeight { get; set; }
        [Display(Name = "CBM")]
        public decimal? CBM { get; set; }
        [Display(Name = "Number Of Carton")]
        public decimal? TotalCartonQty { get; set; }
        [Display(Name = "Packing Type")]
        public string? PackingType { get; set; }


        [Display(Name = "Payment Terms Manual")]
        public string? PaymentTermsManual { get; set; }

        [Display(Name = "Session")]
        public string? Session { get; set; }

        [Display(Name = "Total Invoice Qty")]
        //[RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid Number")]
        public decimal? TotalInvoiceQty { get; set; }


        [Display(Name = "Total Invoice Qty [Pcs]")]
        public decimal? TotalInvoiceQtyPcs { get; set; }

        public decimal? Rate { get; set; }

        [Display(Name = "Total Value")]
        public decimal? TotalValue { get; set; }


        [Display(Name = "Discount")]
        public decimal? Discount { get; set; }

        [Display(Name = "Net Value")]
        public decimal? NetValue { get; set; }



        [Display(Name = "CMP Percentage")]
        public decimal? CMPPercentage { get; set; }

        [Display(Name = "CMP Value")]
        public decimal? CMPValue { get; set; }

        [Display(Name = "CMT Percentage")]
        public decimal? CMTPercentage { get; set; }


        [Display(Name = "Cargo Handover Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]

        public DateTime? CargoHandoverDate { get; set; }

        [Display(Name = "Container No :")]
        public string? ContainerNo { get; set; }
        public string? BankAccNo { get; set; }
        public virtual ICollection<ExportInvoiceDetails>? ExportInvoiceDetails { get; set; }
        public virtual ICollection<ExportInvoiceTruckDetails>? ExportInvoiceTruckDetails { get; set; }

        //later

        //[Display(Name = "Exporter Bank")]
        //public int? OpeningBankId { get; set; }
        //public virtual OpeningBank? OpeningBank { get; set; }

        //[Display(Name = "Bank Account No")]
        //public int? BankAccountId { get; set; }


        //public virtual BankAccountNo? BankAccountNos { get; set; }



        [Display(Name = "Shipping Bill No")]
        public string? ShippingBillNo { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Shipping Bill Date")]
        public DateTime? ShippingBillDate { get; set; }


        [Display(Name = "Is Revised")]
        public bool IsRevised { get; set; }

        [Display(Name = "Revised No")]
        public int RevisedNo { get; set; }

        //later

        //[ForeignKey("BaseInvoice")]
        //[Display(Name = "Base Invoice No")]
        ////public int? ParentAccId { get; set; }
        //public int? BaseInvoiceId { get; set; }

        //public virtual ExportInvoiceMaster? BaseInvoice { get; set; }

        //later
        //[ForeignKey("MasterInvoice")]
        //[Display(Name = "Master Invoice No")]
        ////public int? ParentAccId { get; set; }
        //public int? MasterInvoiceId { get; set; }

        //public virtual ExportInvoiceMaster? MasterInvoice { get; set; }

    }
    public partial class Destination:BaseModel
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public Destination()
        //{
        //    ExportOrders = new HashSet<ExportOrder>();
        //}
        public string? DestinationNameSearch { get; set; }

        public string? DestinationCode { get; set; }
        public string? DestinationName { get; set; }
        public int? CountryId { get; set; }
        [ForeignKey("CountryId")]

        public virtual CountryModel? Countrys { get; set; }
        //public int? ExportOrdersId { get; set; }
        //public virtual ICollection<ExportOrder> ExportOrders { get; set; }
    }


    public partial class ExportInvoiceDetails:BaseModel
    {

        //public int InvoiceId { get; set; }

        [Display(Name = "ExportInvoiceMasterId")]
        public int ExportInvoiceMasterId { get; set; }
        [ForeignKey("ExportInvoiceMasterId")]

        public virtual ExportInvoiceMaster? ExportInvoiceMaster { get; set; }


        //[Key, Column(Order = 1)]
        public int MasterLCDetailsID { get; set; }
        [ForeignKey("MasterLCDetailsID")]

        public virtual COM_MasterLC_Details? MasterLCdetailsInfo { get; set; }

        [NotMapped]
        public Boolean isDelete { get; set; }


        [MaxLength(50)]
        [Display(Name = "Style No")]
        public string? StyleNo { get; set; }

        [MaxLength(50)]

        [Display(Name = "Export PoNo")]
        public string? ExportPoNo { get; set; }
        public string? ManualBuyerPO { get; set; }

        [MaxLength(50)]

        [Display(Name = "Destination")]
        public string? Destination { get; set; }

        //public int? DestinationId { get; set; }
        //public virtual Destination? Destination { get; set; }

        [Display(Name = "LC Qty")]
        public decimal? LCQty { get; set; }
        //[Display(Name = "UOM")]
        //public string? UnitMasterId { get; set; }
        public virtual UnitMaster? UnitMaster { get; set; }

        //[RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid Number")]
        [Display(Name = "Invoice Qty")]
        public decimal? InvoiceQty { get; set; }

        [Display(Name = "Invoice Rate")]
        public decimal? InvoiceRate { get; set; }

        [Display(Name = "Invoice Value")]
        public decimal? InvoiceValue { get; set; }


        [Display(Name = "CMTUnitPrice")]
        [DataType("decimal(18,3)")]
        public decimal? CMTUnitPrice { get; set; }
        public decimal? CMTTotalAmount { get; set; }


        [Display(Name = "Shipment Date")]

        public DateTime? ShipmentDate { get; set; }


        [Display(Name = "Net Weight")]
        public decimal? NetWeightLine { get; set; }

        [Display(Name = "Gross Weight")]
        public decimal? GrossWeightLine { get; set; }
        [Display(Name = "CBM")]
        public double? CBMLine { get; set; }
        [Display(Name = "Number of Carton")]
        public int? CartonQty { get; set; }


        [Display(Name = "Document Send Date")]

        public DateTime? DocumentSendDate { get; set; }
        [Display(Name = "Bill Receive Date")]

        public DateTime? BillReceiveDate { get; set; }


        [Display(Name = "Master BBLC")]

        //later
        //public virtual ExportInvoiceMaster? ExportInvoiceMasters { get; set; }
        //public virtual COM_MasterLC_Details COM_MasterLC_Detail { get; set; }
        public virtual ICollection<ExportInvoicePackingList> ExportInvoicePackingLists { get; set; }


        [MaxLength(50)]
        public string? ColorCode { get; set; }

        [Display(Name = "PO Date")]
        public DateTime? PODate { get; set; }
        [Display(Name = "Box Length")]
        public decimal? BoxLength { get; set; }

        [Display(Name = "Box Width")]
        public decimal? BoxWidth { get; set; }

        [Display(Name = "Box Height")]
        public decimal? BoxHeight { get; set; }

        [Display(Name = "SL NO")]
        public int? SLNO { get; set; }

        [Display(Name = "Factor")]
        public decimal? InvoiceFactor { get; set; }

        [Display(Name = "Invoice Qty [Pcs]")]
        public decimal? InvoiceQtyInPcs { get; set; }

        public int? BoxCategoryId { get; set; }
        [ForeignKey("BoxCategoryId")]
        public virtual BoxCategoryModel? BoxCategory { get; set; }

        

    }


    public class ExportInvoiceTruckDetails: BaseModel
    {
        [Display(Name = "ExportInvoiceMasterId")]
        public int ExportInvoiceMasterId { get; set; }
        [ForeignKey("ExportInvoiceMasterId")]

        public virtual ExportInvoiceMaster? ExportInvoiceMaster { get; set; }

        [StringLength(50)]
        public string? TruckNo { get; set; }
        [StringLength(50)]
        public string? DriverName { get;set; }
        [StringLength(50)]
        public string? MobileNo { get; set; }
    }
    public partial class ExportInvoicePackingList:BaseModel
    {

        public int ExportInvoiceDetailsId { get; set; }
        [ForeignKey("ExportInvoiceDetailsId")]
        public virtual ExportInvoiceDetails ExportInvoiceDetails { get; set; }

        [Display(Name = "Export PoNo")]
        public string? ExportPoNo { get; set; }

        [Display(Name = "Number of Carton")]
        public int? CartonQty { get; set; }

        public decimal? InvoiceQty { get; set; }

        [Display(Name = "Gross Weight")]
        public decimal? GrossWeightLinePacking { get; set; }

        [Display(Name = "Net Weight")]
        public decimal? NetWeightLinePacking { get; set; }


        [Display(Name = "Box Length")]
        public decimal? BoxLengthLinePacking { get; set; }

        [Display(Name = "Box Width")]
        public decimal? BoxWidthLinePacking { get; set; }

        [Display(Name = "Box Height")]
        public decimal? BoxHeightLinePacking { get; set; }
        [Display(Name = "CBM")]
        public double? CBMLinePacking { get; set; }


        [Display(Name = "SL NO")]
        public int? SLNOLinePacking { get; set; }
        [Display(Name = "Item Number")]
        public string? ItemNumber { get; set; }

        [Display(Name = "UPC Number")]
        public string? UPCNumber { get; set; }

        [Display(Name = "Qty")]
        public decimal? Qty { get; set; }

        [Display(Name = "Unit Price")]
        public decimal? UnitPrice { get; set; }

        [Display(Name = "Total Value")]
        public decimal? TotalValue { get; set; }
        [Display(Name = "Color")]
        public string? ColorPL { get; set; }

        [Display(Name = "Total PCS")]
        public decimal? ttlPcsPL { get; set; }

        [Display(Name = "Total PCS")]
        public decimal? remainingPL { get; set; }

        [Display(Name = "Total PCS")]
        public decimal? netPcsPL { get; set; }


        [Display(Name = "Pcs / CTN")]
        public decimal? PcsCTN { get; set; }


        [Display(Name = "Carton From No.")]
        public string? CtnNoFromPL { get; set; }



        [Display(Name = "Carton To No.")]
        public string? CtnNoToPL { get; set; }

        //later
        //[Display(Name = "Size")]
        //public string? SizePL { get; set; }

        //public virtual ExportInvoiceDetails ExportInvoiceDetailss { get; set; }
        [Display(Name = "Total Net Weight")]
        public decimal? TotalNetWeightPL { get; set; }

        [Display(Name = "Total Gross Weight")]
        public decimal? TotalGrossWeightPL { get; set; }

        public int? ColorId { get; set; }
        [ForeignKey("ColorId")]
        public virtual ColorsModel? Colors { get; set; }
        
        public int? SizeId { get; set; }
        [ForeignKey("SizeId")]
        public virtual SizesModel? Sizes { get; set; }

        public int? CartonFrom { get; set; } = 0;
        public int? CartonTo { get; set; } = 0;
    }

    public partial class ExportRealization_Master : BaseModel
    {

        [Display(Name = "Export Form Number")]
        [StringLength(100)]
        public string? ExportFormNo { get; set; }

        [Display(Name = "File Number")]
        [StringLength(100)]
        public string? FileNumber { get; set; }

        [Display(Name = "MasterLCID")]
        public int? MasterLCId { get; set; }
        [ForeignKey("MasterLCId")]
        public virtual MasterLCModel? MasterLC { get; set; }

        [Display(Name = "FBP Number")]
        [StringLength(100)]
        public string? FBPNo { get; set; }

        [Display(Name = "FBP Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FBPDate { get; set; }


        [Display(Name = "Due Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DueDate { get; set; }

        [Display(Name = "Payment Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? PaymentDate { get; set; }


        [Display(Name = "Bank Reference")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string? BankRef { get; set; }

        [Display(Name = "COURIER NO")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string? CourierNo { get; set; }

        [Display(Name = "Courier Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CourierDate { get; set; }


        [Display(Name = "Realization Amount")]
        [DisplayFormat(DataFormatString = "{0:#,#.00}")]
        public decimal? RealizationAmount { get; set; }

        [Display(Name = "Realization Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RealizationDate { get; set; }


        public decimal? TotalInvoiceQty { get; set; }
        public decimal? TotalValue { get; set; }
        public decimal? ReceivingVlaue { get; set; }
        public decimal? BankCharge { get; set; }


        [Display(Name = "Remarks")]
        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string? Remarks { get; set; }


        
        //public virtual ICollection<ExportInvoiceDetails>? ExportInvoiceDetails { get; set; }

        public virtual ICollection<ExportRealization_Details>? ExportRealization_Details { get; set; }

    }

    public partial class ExportRealization_Details : BaseModel
    {

        public int RealizationId { get; set; }
        [ForeignKey("RealizationId")]
        public virtual ExportRealization_Master? RealizationMaster { get; set; }

        public int InvoiceId { get; set; }
        [ForeignKey("InvoiceId")]
        public virtual ExportInvoiceMaster? ExportInvoiceMaster { get; set; }

        public decimal? TotalQty { get; set; }

        //public decimal Rate { get; set; }

        public decimal? TotalValue { get; set; }

        public decimal? ReceivingValue { get; set; }

        public decimal? BankCharge { get; set; }


        //public Nullable<System.DateTime> DocumentSendDate { get; set; }
        //public Nullable<System.DateTime> DocumentReceivedDate { get; set; }

        

        // public virtual ICollection<ExportInvoiceMaster>? ExportInvoiceMasters { get; set; }
    }


    public partial class COM_MasterLC_Details:BaseModel
    {
        [Display(Name = "SL No")]
        public int? SL { get; set; }
        [MaxLength(200)]
        public string? ExportPONo { get; set; }
        [MaxLength(100)]

        public string? StyleName { get; set; }
        [MaxLength(100)]

        public string? ItemName { get; set; }
        [MaxLength(100)]

        public string? HSCode { get; set; }
        [MaxLength(1000)]

        public string? Fabrication { get; set; }
        public float OrderQty { get; set; }
        [Display(Name = "Order UOM")]
       
        public int? UnitMasterId { get; set; }
        [Display(Name = "Unit")]
        [ForeignKey("UnitMasterId")]

        public virtual UnitModel? Unit { get; set; }

        public float? Factor { get; set; }
        public decimal? QtyInPcs { get; set; }
        //[Column(TypeName = "decimal(16,3)")]
        [Display(Name = "FOB")]
        [DataType("decimal(18,3)")]
        public decimal? UnitPrice { get; set; } ///qty in pcs * qtyinpcs
        public decimal? TotalValue { get; set; }

        public decimal? CMTPercentage { get; set; }
        
        [Display(Name = "CMTUnitPrice")]
        [DataType("decimal(18,3)")]
        public decimal? CMTUnitPrice { get; set; }
        public decimal? CMTTotalAmount { get; set; }


        [Display(Name = "Shipment Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")] //, ApplyFormatInEditMode = true
        public DateTime? ShipmentDate { get; set; }
        [MaxLength(100)]

        public string? Destination { get; set; }
        [MaxLength(100)]
        [Display(Name = "Contract No")]

        public string? ContractNo { get; set; }
        [Display(Name = "Order Type")]
        [MaxLength(100)]

        public string? OrderType { get; set; }
        [NotMapped]
        public Boolean? isTransaction { get; set; }

        [Display(Name = "Cat No")]
        [MaxLength(100)]

        public string? CatNo { get; set; }

        [Display(Name = "Delivery No")]
        [MaxLength(100)]

        public string? DeliveryNo { get; set; }

        [MaxLength(200)]

        [Display(Name = "Destination PO")]

        public string? DestinationPO { get; set; }
        [Display(Name = "Kimball")]
        [MaxLength(150)]

        public string? Kimball { get; set; }

        [Display(Name = "Color Code")]
        [MaxLength(100)]

        public string? ColorCode { get; set; }


        [Display(Name = "Contract Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime? ContractDate { get; set; }

        [Display(Name = "Master LC")]
        public int MasterLCID { get; set; }

        [ForeignKey("MasterLCID")]
        public virtual MasterLCModel? COM_MasterLC { get; set; }

        [Display(Name = "BuyerPO_Master")]
        public int? BuyerPOId { get; set; }
        [ForeignKey("BuyerPOId")]
        public virtual BuyerPO_MasterModel? BuyerPO_Master { get; set; }


        //later
        //public virtual ICollection<ExportInvoiceDetails>? ExportInvoiceDetails { get; set; }
    }
    public partial class COM_MasterLCExport:BaseModel
    {
        public int ExportOrderID { get; set; }
        public string? ExportPONo { get; set; }
        public string? ExportOrderStatus { get; set; }


        //later

        //[Display(Name = "Master LC")]


        //public virtual MasterLCModel? COM_MasterLC { get; set; }

        //[Display(Name = "Export Orders")]

        //public virtual ExportOrder ExportOrders { get; set; }
    }

    public partial class COM_MasterLC_Details_Temp : BaseModel
    {
        [Display(Name = "SL No")]
        public int? SLNo { get; set; }
        [MaxLength(200)]
        public string? ExportPONo { get; set; }
        [MaxLength(100)]

        public string? StyleName { get; set; }
        [MaxLength(100)]

        public string? ItemName { get; set; }
        [MaxLength(100)]

        public string? HSCode { get; set; }
        [MaxLength(1000)]

        public string? Fabrication { get; set; }
        public float OrderQty { get; set; }

        public float Factor { get; set; }
        public decimal QtyInPcs { get; set; }
       
        [DataType("decimal(18,3)")]
        public decimal UnitPrice { get; set; } 
        public decimal TotalValue { get; set; }
        
        public DateTime? ShipmentDate { get; set; }
        [MaxLength(100)]

        public string? Destination { get; set; }
        [MaxLength(100)]
        [Display(Name = "Contract No")]

        public string? ContractNo { get; set; }
        [Display(Name = "Order Type")]
        [MaxLength(100)]

        public string? OrderType { get; set; }

        [Display(Name = "Cat No")]
        [MaxLength(100)]

        public string? CatNo { get; set; }

        [Display(Name = "Delivery No")]
        [MaxLength(100)]

        public string? DeliveryNo { get; set; }

        [MaxLength(200)]

        [Display(Name = "Destination PO")]

        public string? DestinationPO { get; set; }
        [Display(Name = "Kimball")]
        [MaxLength(150)]

        public string? Kimball { get; set; }

        [Display(Name = "Color Code")]
        [MaxLength(100)]

        public string? ColorCode { get; set; }


        [Display(Name = "Contract Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime? ContractDate { get; set; }


    }

    public class BuyerGroup:BaseModel
    {
        [StringLength(100)]
        [Display(Name = "Buyer Group")]
        public string? BuyerGroupName { get; set; }

        [Display(Name = "Buyer Group Code")]
        public string? BuyerGroupCode { get; set; }


        [StringLength(100)]
        [DataType(DataType.Text)]
        [Display(Name = "Buyer Group Short Name")]
        public string? BuyerGroupShortName { get; set; }
        //public virtual ICollection<MasterLCModel> COM_MasterLCs { get; set; }

    }


    public partial class NotifyParty:BaseModel
    {
        [Display(Name = "Notify Party Name")]
        public string? NotifyPartyName { get; set; }
        [Display(Name = "Notify Party Search Name")]
        public string? NotifyPartyNameSearch { get; set; }

        [DataType(DataType.MultilineText)]

        public string? Address1 { get; set; }
        [DataType(DataType.MultilineText)]

        public string? Address2 { get; set; }

        public string? PhoneNo { get; set; }
        public string? Email { get; set; }

        public int? BuyerId { get; set; }
        [ForeignKey("BuyerId")]
        public virtual CustomerModel? buyers { get; set; }
        public int? CountryId { get; set; }
        [ForeignKey("CountryId")]
        public virtual CountryModel? Countrys { get; set; }
        public int? PortOfDischargeId { get; set; }
        public virtual PortOfDischarge? PortOfDischarge { get; set; }
        [Display(Name = "Shop Code")]

        public string? ShopCode { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Shipped To")]

        public string? ShippedTo { get; set; }

        public bool ? isInactive { get; set; }

        public int? SLNO { get; set; }
        //later
        public int? DynamicReportId { get; set; }
        [ForeignKey("DynamicReportId")]
        public virtual DynamicReport? DynamicReports { get; set; }
    }

    public class DynamicReport:SelfModel
    {
        [StringLength(200)]
        [DataType(DataType.Text)]
        [Display(Name = "Invoice Report Name")]
        public string? DynamicReportName { get; set; }
        [Display(Name = "Packing List Report Name")]

        public string? DynamicReportPackingListName { get; set; }
        [Display(Name = "Packing Details Report Name")]

        public string? DynamicReportPackingDetailsName { get; set; }
        public string? DynamicReportCaption { get; set; }
        public string? DynamicReportActionName { get; set; }
        public string? ReportDesignByPerson { get; set; }
        public string? ReportLocation { get; set; }
        public string? ReportController { get; set; }

        public string? VerifiedByPerson { get; set; }
        public bool? isVerified { get; set; }
        public decimal? CompletePercentage { get; set; }


        [DataType(DataType.MultilineText)]
        public string? Remarks { get; set; }
        public int? BuyerId { get; set; }
        [ForeignKey("BuyerId")]
        public virtual CustomerModel? BuyerInformations { get; set; }
    }

    public partial class UnitGroup:BaseModel
    {
        public virtual ICollection<UnitMaster> UnitMaster { get; set; }
    }

    public partial class COM_ProformaInvoice:BaseModel
    {
        public string? PINo { get; set; }
        [Display(Name = "PI Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PIDate { get; set; }

        [Display(Name = "PI Receiving Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PIReceivingDate { get; set; }

        public int? CommercialCompanyId { get; set; }
        [ForeignKey("CommercialCompanyId")]
        public virtual CommercialCompanyModel? CommercialCompanies { get; set; }

        public int? CurrencyId { get; set; }
        [ForeignKey("CurrencyId")]
        public virtual CountryModel? Currencies { get; set; }


        public int? SupplierId { get; set; }
        [ForeignKey("SupplierId")]

        public virtual SupplierModel? Suppliers { get; set; }

        public int? DoctypeId { get; set; }
        [ForeignKey("DoctypeId")]

        public virtual DocTypeModel? DocType { get; set; }

        [StringLength(500)]
        public string? ImportPONo { get; set; }
        [StringLength(50)]

        public string? FileNo { get; set; }
        [StringLength(500)]
        public string? LCAF { get; set; }


        [Display(Name = "Item Group")]

        [NotMapped]
        public string[]? ItemDescArray { get; set; }

        public string? ItemDescList { get; set; }

        public int? ItemGroupId { get; set; }

        [ForeignKey("ItemGroupId")]

        public virtual ItemGroupModel? ItemGroups { get; set; }


        [Display(Name = "Group LC Contract")]
        public int? GroupLCId { get; set; }
        [ForeignKey("GroupLCId")]

        public virtual GroupLC_MainModel? COM_GroupLC_Mains { get; set; }



        [StringLength(500)]

        public string? ItemGroupName { get; set; }

        [StringLength(500)]

        public string? ItemDescription { get; set; }


        [Display(Name = "Item Description")]
        public int? ItemDescId { get; set; }
        [ForeignKey("ItemDescId")]

        public virtual ItemDescriptionModel? ItemDescs { get; set; }


        [StringLength(40)]

        public string? Size { get; set; }

        [Display(Name = "Remarks")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(500)]

        public string? Remarks { get; set; }

        [Display(Name = "Qty.")]

        public decimal? ImportQty { get; set; }
        [Display(Name = "Import Rate")]
        [DisplayFormat(DataFormatString = "{0:0.0000}", ApplyFormatInEditMode = true)]

        public decimal? ImportRate { get; set; }

        [Display(Name = "Carton/Roll Qty.")]

        public decimal? CartonRollQty { get; set; }
        [Display(Name = "Total Value")]

        public decimal? TotalValue { get; set; }

        [Display(Name = "HSCode")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]

        public string? HSCode { get; set; }

        [Display(Name = "Employee")]

        public int? EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]

        public virtual EmployeeModel? employees { get; set; }
        [StringLength(300)]

        public string? MerchandiserName { get; set; }

        [Display(Name = "Rev No.")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(300)]

        public string? RevNo { get; set; }


        [Display(Name = "Unit")]

        public int? UnitId { get; set; }

        [ForeignKey("UnitId")]

        public virtual UnitModel? UnitMaster { get; set; }

        public int? SecondaryUnitId { get; set; }

        [ForeignKey("SecondaryUnitId")]

        public virtual UnitModel? SecondaryUnit { get; set; }

        public virtual ICollection<BBLC_Details>? BBLC_Info { get; set; }
        //public virtual ICollection<COM_MachinaryLC_Details>? COM_MachinaryLC_Details { get; set; }

        //public virtual ICollection<COM_GroupLC_Main> COM_GroupLC_Main { get; set; }

        public virtual ICollection<COM_ProformaInvoice_Sub>? COM_ProformaInvoice_Subs { get; set; }


        [Display(Name = "Payment Terms")]
        public int? PaymentTermsId { get; set; }
        [ForeignKey("PaymentTermsId")]

        public virtual CommercialPaymentTerms? PaymentTerms { get; set; }

        public int? DayListId { get; set; }
        [ForeignKey("DayListId")]

        public virtual DayList? DayList { get; set; }

        public int? BankAccountNoLienBankId { get; set; }
        [ForeignKey("BankAccountNoLienBankId")]

        public virtual BankAccountNoLienBank? BankAccountNoLienBanks { get; set; }

        public int? OpeningBankId { get; set; }
        [ForeignKey("OpeningBankId")]

        public virtual OpeningBank? OpeningBanks { get; set; }

        public int? BankAccountId { get; set; }
        [ForeignKey("BankAccountId")]

        public virtual BankAccountNo? BankAccountNos { get; set; }

        public int? LienBankId { get; set; }
        [ForeignKey("LienBankId")]

        public virtual LienBank? LienBanks { get; set; }


        public int? PITypeId { get; set; }
        [ForeignKey("PITypeId")]

        public virtual PITypeModel? PITypes { get; set; }

        [Display(Name = "Port Of Loading :")]
        public int? PortOfLoadingId { get; set; }
        [ForeignKey("PortOfLoadingId")]
        public virtual PortOfLoading? PortOfLoading { get; set; }

        [Display(Name = "Port Of Destination :")]

        public int? PortOfDestinationId { get; set; }
        [ForeignKey("PortOfDestinationId")]
        public virtual Destination? Destinations { get; set; }

        public int? PortOfLoadingDestinationId { get; set; }
        [ForeignKey("PortOfLoadingDestinationId")]
        public virtual PortOfLoading? PortOfLoadingDestination { get; set; }
        [Display(Name = "Country Of Origin :")]
        public int? PortOfLoadingCountryOfOriginId { get; set; }
        [ForeignKey("PortOfLoadingCountryOfOriginId")]
        public virtual PortOfLoading? PortOfLoadingCountryOfOrigin { get; set; }

        public int? PINatureId { get; set; }
        [ForeignKey("PINatureId")]
        public virtual PINature? PINatures { get; set; }

    }
    public partial class COM_ProformaInvoice_Sub:BaseModel
    {
        public int? ItemDescId { get; set; }
        [ForeignKey("ItemDescId")]
        public virtual ItemDescriptionModel? ItemDescription { get; set; }
        public int? PIId { get; set; }
        [ForeignKey("PIId")]
        public virtual COM_ProformaInvoice? Com_proformaInvoices { get; set; }

    }

    public class ShipMode: SelfModel
    {
        [StringLength(100)]
        public string? ShipModeName { get; set; }
        [StringLength(100)]
        public string? ShipModeShortName { get; set; }
    }

    public class DayListTerm:SelfModel
    {
        [StringLength(100)]
        public string? DayListTermName { get; set; }
        [StringLength(100)]
        public string? DayListTermShortName { get; set; }
        public string? DayListTermGroup { get; set; }
    }
    public class BBLCMain:BaseModel
    {
        [StringLength(100)]
        public string? BBLCNo { get; set; }

        [Display(Name = "BBLC Amendment NO")]
        public string? BBLCAmdNo { get; set; }

        [Display(Name = "UD NO")]
        public string? UDNo { get; set; }

        [Display(Name = "UD Amendment NO")]
        public string? AmdNo { get; set; }

        [Display(Name = "Concern")]
        public int? CommercialCompanyId { get; set; }
        [ForeignKey("CommercialCompanyId")]
        public virtual CommercialCompanyModel? Company { get; set; }

        public int? LCTypeId { get; set; }
        [ForeignKey("LCTypeId")]
        public virtual CommercialLCType? LCType { get; set; }
        public int? TruckInfoId { get; set; }
        [ForeignKey("TruckInfoId")]
        public virtual TruckInfo? TruckInfo { get; set; }
        [Display(Name = "ShipMode")]
        public int? ShipModeId { get; set; }
        public virtual ShipMode? ShipMode { get; set; }

        [Display(Name = "Group LC")]
        public int? GroupLCId { get; set; }

        [ForeignKey("GroupLCId")]
        public virtual GroupLC_MainModel? COM_GroupLC_Main { get; set; }
        [Display(Name = "Total Value")]
        public decimal? TotalValue { get; set; }
        [Display(Name = "Tenor")]
        public decimal? Tenor { get; set; }
        [Display(Name = "Payment Term")]
        public string? PaymentTerm { get; set; }
        [Display(Name = "Payment Term")]
        public int? PaymentTermsId { get; set; }
        [ForeignKey("PaymentTermsId")]
        public virtual CommercialPaymentTerms? PaymentTermss { get; set; }
        [Display(Name = "Day List Term")]
        public int? DayListId { get; set; }
        [ForeignKey("DayListId")]
        public virtual DayList? daylists { get; set; }
        [Display(Name = "Days Terms Description")]
        public int? DayListTermId { get; set; }
        [ForeignKey("DayListTermId")]
        public virtual DayListTerm? dayliststerm { get; set; }
        public string? Insurance { get; set; }
        [Display(Name = "Currency")]
        public int? CurrencyId { get; set; }
        public virtual CountryModel? Currency { get; set; }

        [Display(Name = "Port Of Loading")]
        public int? PortOfLoadingId { get; set; }
        public virtual PortOfLoading? PortOfLoading { get; set; }
        [Display(Name = "Port Of Discharge")]
        public int? PortOfDischargeId { get; set; }
        public virtual PortOfDischarge? PortOfDischarge { get; set; }
        [Display(Name = "Concern Bank")]
        public int? OpeningBankId { get; set; }
        public virtual OpeningBank? OpeningBank { get; set; }
        [Display(Name = "Supplier Bank")]
        public int? LienBankId { get; set; }
        public virtual LienBank? LienBank { get; set; }
        [Display(Name = "Incoterm")]
        public int? TradeTermId { get; set; }
        [ForeignKey("TradeTermId")]

        public virtual CommercialTradeTerm? TradeTerms { get; set; }
        [Display(Name = "LC Opening Date")]
        public DateTime? LcOpeningDate { get; set; }
        [Display(Name = "Expiry Date")]
        public DateTime? ExpiryDate { get; set; }
        [Display(Name = "UD Date")]
        public DateTime? UDDate { get; set; }
        [Display(Name = "First Shipment Date")]
        public DateTime? FirstShipmentDate { get; set; }

        [Display(Name = "Last Shipment Date")]
        public DateTime? LastShipmentDate { get; set; }


        [Display(Name = "Final Destination")]
        public int? DestinationID { get; set; }
        public virtual Destination? Destination { get; set; }
        [Display(Name = "ConvertRate")]
        public decimal? ConvertRate { get; set; }
        [Display(Name = "BBLC Value")]
        public decimal? BBLCValue { get; set; }
        [Display(Name = "BBLC Qty")]
        public decimal? BBLCQty { get; set; }
        public decimal? SecondaryQty { get; set; }

        [Display(Name = "Margin [%]")]
        public decimal? GroupLCAverage { get; set; }
        public decimal? Balance { get; set; }
        public decimal? PrevBBLCValue { get; set; }


        [Display(Name = "Increase")]
        public decimal? IncreaseValue { get; set; }

        [Display(Name = "Decrease")]

        public decimal? DecreaseValue { get; set; }
        [Display(Name = "Final Value")]
        public decimal? NetValue { get; set; }
        [StringLength(50)]

        public string? BBLCPrintDocRef { get; set; }
        public System.DateTime? BBLCPrintDocDate { get; set; }


        [Display(Name = "Supplier")]
        public int? SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        public virtual SupplierModel? SupplierInformation { get; set; }

        [Display(Name = "Forwarder")]
        public int? ForwarderId { get; set; }
        [ForeignKey("ForwarderId")]
        public virtual SupplierModel? ForwarderInformation { get; set; }

        public virtual MasterLCModel? COM_MasterLC { get; set; }
        public virtual ICollection<BBLC_Details>? BBLC_Details { get; set; }
        //public virtual ICollection<COM_CommercialInvoice> COM_CommercialInvoice { get; set; }
        public string? ApprovalPerson { get; set; }
        public string? ApprovedBy { get; set; }
        public System.DateTime? DateApproval { get; set; }

        [Display(Name = "Remarks")]

        [DataType(DataType.MultilineText)]
        public string? Remarks { get; set; }
        public string? RefNo { get; set; }
        public string? PrintDate { get; set; }
        public string? Percentage { get; set; }

        [Display(Name = "LC For :")]
        public int? ItemGroupId { get; set; }
        [ForeignKey("ItemGroupId")]

        public virtual ItemGroupModel? ItemGroups { get; set; }
    }

    public partial class BBLC_Details : BaseModel
    {
        public int? BBLCMainId { get; set; }
        [ForeignKey("BBLCMainId")]
        public virtual BBLCMain? BBLCMain { get; set; }

        [Display(Name = "Proforma Invoice")]
        public int? PIId { get; set; }
        [ForeignKey("PIId")]
        public virtual COM_ProformaInvoice? COM_ProformaInvoice { get; set; }
        //public virtual ICollection<COM_GroupLC_Main> COM_GroupLC_Main { get; set; }
    }


    public partial class COM_CommercialInvoice:BaseModel
    {
        [StringLength(30)]
        [Display(Name = "Com. Inv. No")]
        public string? CommercialInvoiceNo { get; set; }
        [Display(Name = "Con. Inv. Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]

        public System.DateTime? CommercialInvoiceDate { get; set; }
        [Display(Name = "Concern")]
        public int? CommercialCompanyID { get; set; }
        [ForeignKey("CommercialCompanyID")]
        public virtual CommercialCompanyModel? CommercialCompany { get; set; }

        [Display(Name = "BBLC No.")]

        public int? BBLCId { get; set; }
        [ForeignKey("BBLCId")]
        public virtual BBLCMain? COM_BBLC_Master { get; set; }
        [Display(Name = "Supplier")]

        public int? SupplierID { get; set; }
        [ForeignKey("SupplierID")]
        public virtual SupplierModel? SupplierInformations { get; set; }
        [Display(Name = "Total PI")]

        public decimal? TotalPI { get; set; }
        [Display(Name = "Document Receipt Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]

        public System.DateTime? DocumentReceiptDate { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? SecondaryQuantity { get; set; }
        [Display(Name = "Total Value")]
        public decimal? TotalValue { get; set; }
        [Display(Name = "Currency")]

        public int? CurrencyId { get; set; }
        [ForeignKey("CurrencyId")]
        public virtual CountryModel? Currency { get; set; }
        [Display(Name = "Unit Master")]
        public int? UnitMasterId { get; set; }
        [ForeignKey("UnitMasterId")]
        public virtual UnitModel? UnitMaster { get; set; }

        public int? SecondaryUnitId { get; set; }
        [ForeignKey("SecondaryUnitId")]
        public virtual UnitModel? SecondaryUnit { get; set; }

        [Display(Name = "Conversion Rate")]
        public decimal? ConversionRate { get; set; }
        [Display(Name = "Item Category")]
        public string? ItemGroupName { get; set; }
        [Display(Name = "Goods Description")]
        public string? ItemDescription { get; set; }

        [NotMapped]
        public string[]? ItemDescArray { get; set; }

        public string? ItemDescList { get; set; }

        [Display(Name = "Item Group")]
        public int? ItemGroupId { get; set; }

        [ForeignKey("ItemGroupId")]
        public virtual ItemGroupModel? ItemGroups { get; set; }


        [Display(Name = "Item Description")]
        public int? ItemDescId { get; set; }
        [ForeignKey("ItemDescId")]
        public virtual ItemDescriptionModel? ItemDescs { get; set; }
        [Display(Name = "Bill Of Lading No")]

        public string? BLNo { get; set; }

        [Display(Name = "BL Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]

        public System.DateTime? BLDate { get; set; }
        [Display(Name = "Document Status")]

        public int? DocumentStatusId { get; set; }
        [ForeignKey("DocumentStatusId")]
        public virtual DocumentStatus? DocumentStatus { get; set; }
        [Display(Name = "Doc. Assesment Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]

        public System.DateTime? DocumentAssesmentDate { get; set; }
        [Display(Name = "Bill Of Entry No")]
        public string? BillOfEntryNo { get; set; }
        [Display(Name = "Bill Of Entry Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]

        public System.DateTime? BillOfEntryDate { get; set; }
        [Display(Name = "Custom Assesment Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]

        public System.DateTime? CustomAssesmentDate { get; set; }
        [Display(Name = "Vassel ETA Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]

        public System.DateTime? VasselETADate { get; set; }
        [Display(Name = "ETB Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]

        public System.DateTime? ETBDate { get; set; }
        [Display(Name = "Good Inhouse Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]

        public System.DateTime? GoodsInhouseDate { get; set; }

        [Display(Name = "Mother Vassel")]

        public string? MotherVassel { get; set; }
        [Display(Name = "Fider Vassel")]

        public string? FidderVasel { get; set; }

        public virtual ICollection<COM_CommercialInvoice_Sub>? COM_CommercialInvoice_Subs { get; set; }



        [Display(Name = "LC Type")]

        public string? LCType { get; set; }

        [Display(Name = "LC Type")]

        public int? CommercialLCTypeId { get; set; }
        [ForeignKey("CommercialLCTypeId")]
        public virtual CommercialLCType? CommercialLCTypes { get; set; }


        [Display(Name = "Regular LC No.")]

        public int? MachinaryLCId { get; set; }
        [ForeignKey("MachinaryLCId")]
        public virtual COM_MachinaryLC_Master? COM_MachinaryLC_Master { get; set; }

        [StringLength(500)]
        [Display(Name = "Remarks")]
        public string? Remarks { get; set; }
    }

    public partial class COM_CommercialInvoice_Sub:BaseModel
    {
        [Display(Name = "Item Desc")]
        public int ItemDescId { get; set; }
        [ForeignKey("ItemDescId")]

        [Display(Name = "Item Description")]

        public virtual ItemDesc? ItemDescs { get; set; }

        public int CommercialInvoiceId { get; set; }
        [ForeignKey("CommercialInvoiceId")]
        public virtual COM_CommercialInvoice? COM_CommercialInvoices { get; set; }

    }
    public partial class COM_MachinaryLC_Master:BaseModel
    {
        [Display(Name = "MachinaryLC NO")]
        [StringLength(100)]
        public string? MachinaryLCNo { get; set; }

        [Display(Name = "UD NO")]
        public string? UDNo { get; set; }

        [Display(Name = "Concern")]
        public int? CommercialCompanyId { get; set; }
        [ForeignKey("CommercialCompanyId")]


        [Display(Name = "ShipMode")]
        public int? ShipModeId { get; set; }

        [Display(Name = "Total Value")]
        public decimal TotalValue { get; set; }
        [Display(Name = "Tenor")]
        public decimal? Tenor { get; set; }
        [Display(Name = "Payment Term")]
        public string? PaymentTerm { get; set; }

        [Display(Name = "Payment Term")]
        public int? PaymentTermsId { get; set; }
        [ForeignKey("PaymentTermsId")]

        public virtual CommercialPaymentTerms? PaymentTermss { get; set; }


        [Display(Name = "Day List Term")]
        public int? DayListId { get; set; }
        [ForeignKey("DayListId")]

        public virtual DayList? daylists { get; set; }


        public string? Insurance { get; set; }
        [Display(Name = "Currency")]
        public int? CurrencyId { get; set; }
        [ForeignKey("CurrencyId")]

        [Display(Name = "Port Of Loading")]
        public int? PortOfLoadingId { get; set; }
        [ForeignKey("PortOfLoadingId")]

        [Display(Name = "Port Of Discharge")]
        public int? PortOfDischargeId { get; set; }
        [ForeignKey("PortOfDischargeId")]


        [Display(Name = "Concern Bank")]
        public int? OpeningBankId { get; set; }
        [ForeignKey("OpeningBankId")]


        [Display(Name = "Supplier Bank")]
        public int? LienBankId { get; set; }
        [ForeignKey("LienBankId")]


        [Display(Name = "Incoterm")]
        public int? TradeTermId { get; set; }
        [ForeignKey("TradeTermId")]

        public virtual CommercialTradeTerm? TradeTerms { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "LC Opening Date")]
        public DateTime LcOpeningDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Expiry Date")]
        public DateTime ExpiryDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "UD Date")]
        public DateTime? UDDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "First Shipment Date")]
        public DateTime? FirstShipmentDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Last Shipment Date")]
        public DateTime? LastShipmentDate { get; set; }
        [Display(Name = "Final Destination")]
        public int? DestinationID { get; set; }
        [ForeignKey("DestinationID")]


        [DisplayFormat(DataFormatString = "{0:#,#.00}")]
        [Display(Name = "ConvertRate")]
        public decimal ConvertRate { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,#.00}")]
        [Display(Name = "Regular LC Value")]
        public decimal MachinaryLCValue { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,#.00}")]
        [Display(Name = "Regular LC Qty")]
        public decimal MachinaryLCQty { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,#.00}")]
        [Display(Name = "Increase")]
        public decimal IncreaseValue { get; set; }

        [Display(Name = "Decrease")]

        [DisplayFormat(DataFormatString = "{0:#,#.00}")]
        public decimal DecreaseValue { get; set; }
        [Display(Name = "Final Value")]

        [DisplayFormat(DataFormatString = "{0:#,#.00}")]
        public decimal NetValue { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,#.00}")]
        [Display(Name = "Margin [%]")]
        public decimal GroupLCAverage { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,#.00}")]
        public decimal Balance { get; set; }


        [Display(Name = "MachinaryLC Print Doc Ref")]
        [StringLength(50)]

        public string? MachinaryLCPrintDocRef { get; set; }

        [Display(Name = "MachinaryLC Print Doc Date")]
        public System.DateTime? MachinaryLCPrintDocDate { get; set; }

        public virtual CommercialCompanyModel? Company { get; set; }

        [Display(Name = "Supplier")]
        public int? SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        public virtual SupplierModel? SupplierInformation { get; set; }
        public virtual ShipMode? ShipMode { get; set; }
        public virtual CountryModel? Currency { get; set; }
        public virtual PortOfLoading? PortOfLoading { get; set; }
        public virtual PortOfDischarge? PortOfDischarge { get; set; }

        public virtual Destination? Destination { get; set; }

        public virtual OpeningBank? OpeningBank { get; set; }
        public virtual LienBank? LienBank { get; set; }
        public virtual ICollection<COM_MachinaryLC_Details>? COM_MachinaryLC_Details { get; set; }

        [Display(Name = "Remarks")]

        [DataType(DataType.MultilineText)]
        public string? Remarks { get; set; }

        [Display(Name = "Item Group")]
        public int? ItemGroupId { get; set; }

        public virtual ItemGroupModel? ItemGroups { get; set; }
        [StringLength(400)]
        [Display(Name = "LC Rev. Amd No.")]
        public string? LCAmdNo { get; set; }
        [StringLength(600)]
        [Display(Name = "Amd Notes / Remarks / Description")]
        public string? LCAmdNote { get; set; }


    }

    public partial class COM_MachinaryLC_Details:BaseModel
    {

        [Display(Name = "Master MachinaryLC")]
        public int? MachinaryLCMasterID { get; set; }

        [ForeignKey("MachinaryLCMasterID")]

        public virtual COM_MachinaryLC_Master? COM_MachinaryLC_Master { get; set; }

        [Display(Name = "Proforma Invoice")]

        public int? PIId { get; set; }

        [ForeignKey("PIId")]
        public virtual COM_ProformaInvoice? COM_ProformaInvoice { get; set; }
    }


    public partial class COM_DocumentAcceptance_Master:BaseModel
    {

        [Display(Name = "DA No.")]
        [StringLength(30)]
        public string? BillOfExchangeRef { get; set; }
        [Display(Name = "Bill Date")]

        public System.DateTime? BillDate { get; set; }

        [Display(Name = "Bill Maturity Date")]

        public System.DateTime? BillMaturityDate { get; set; }

        [Display(Name = "Bill Payment Date")]

        public System.DateTime? BillPaymentDate { get; set; }

        [Display(Name = "Concern")]

        public int? CommercialCompanyId { get; set; }
        [ForeignKey("CommercialCompanyId")]
        public virtual CommercialCompanyModel? CommercialCompanys { get; set; }

        public int? BuyerId { get; set; }
        [ForeignKey("BuyerId")]
        public virtual CustomerModel? BuyerInformation { get; set; }
        [Display(Name = "Supplier")]

        public int? SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        public virtual SupplierModel? SupplierInformations { get; set; }
        public int? BBLCId { get; set; }
        [ForeignKey("BBLCId")]

        public virtual BBLCMain? COM_BBLC_Master { get; set; }

        public int? GroupLCId { get; set; }
        [ForeignKey("GroupLCId")]

        public virtual GroupLC_MainModel? COM_GroupLC_Main { get; set; }

        public string? MasterLCRef { get; set; }
        public int? MasterLCId { get; set; }
        [ForeignKey("MasterLCId")]
        public virtual MasterLCModel? MasterLC { get; set; }
        [Display(Name = "BBLC Amount")]

        public decimal TotalBBLCAmount { get; set; }
        public int? CurrencyId { get; set; }
        [ForeignKey("CurrencyId")]
        public virtual CountryModel? Currency { get; set; }
        [Display(Name = "Paid Amount")]

        public decimal PaidAmount { get; set; }
        [Display(Name = "Payable Amount")]

        public decimal PayableAmount { get; set; }
        [Display(Name = "Previous Accepted")]

        public decimal AcceptedAmount { get; set; }
        [Display(Name = "New CI Amount")]


        public decimal NewCIAmount { get; set; }
        public decimal ConversionRate { get; set; }
        public virtual ICollection<COM_DocumentAcceptance_Details>? COM_DocumentAcceptance_Details { get; set; }
    }

    public partial class COM_DocumentAcceptance_Details:BaseModel
    {
        [Display(Name = "CI No.")]

        public int? CommercialInvoiceId { get; set; }
        [ForeignKey("CommercialInvoiceId")]

        public virtual COM_CommercialInvoice? COM_CommercialInvoice { get; set; }

        [Display(Name = "Document Acceptance")]
        public int? DocumentAcceptanceMasterId { get; set; }
        [ForeignKey("DocumentAcceptanceMasterId")]
        public virtual COM_DocumentAcceptance_Master? COM_DocumentAcceptance_Master { get; set; }
    }

    public partial class WorkOrderMaster:BaseModel
    {
        [Display(Name = "Company")]

        public int? CommercialCompanyId { get; set; }
        [ForeignKey("CommercialCompanyId")]
        public virtual CommercialCompanyModel? CommercialCompany { get; set; }
        [Display(Name = "WorkOrder No")]
        public string? WorkOrderNo { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "WO.Date")]

        public System.DateTime? WorkOrderDate { get; set; }
        [Display(Name = "To Company")]
        //[Display(Name = "supplier")]
        public int? SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        public virtual SupplierModel? SupplierInformation { get; set; }
        [Display(Name = "To Person")]

        public string? ToPerson { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Agreement Date")]

        public System.DateTime? AgreementDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Delivery Date")]

        public System.DateTime? DeliveryDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Service Start")]

        public System.DateTime? ServiceContractStartDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Service End")]

        public System.DateTime? ServiceContractEndDate { get; set; }

        [Display(Name = "Currency")]

        public int? CurrencyId { get; set; }
        [ForeignKey("CurrencyId")]
        public virtual CountryModel? Currency { get; set; }
        [Display(Name = "Conv. Rate")]

        public decimal? ConversionRate { get; set; }
        [Display(Name = "Workorder Type")] ////fahad confusion

        public string? WorkOrderType { get; set; }



        [Display(Name = "Subject")]

        public string? Subject { get; set; }
        public string? Body { get; set; }
        [Display(Name = "Pay. Terms")]

        public string? PaymentTerms { get; set; }
        [Display(Name = "Others Terms")]

        public string? OtherTerms { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,#.00}")]
        [Display(Name = "WorkOrder Qty")]
        public decimal? WorkOrderQty { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,#.00}")]
        [Display(Name = "WorkOrder Rate")]
        public decimal? WorkOrderRate { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,#.00}")]
        [Display(Name = "Total Amount")]
        public decimal? SubTotal { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,#.00}")]
        [Display(Name = "Sales Tax")]
        public decimal? SalesTax { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,#.00}")]
        [Display(Name = "Other Exp")]
        public decimal? OtherExp { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,#.00}")]
        [Display(Name = "WorkOrder Amt")]
        public decimal? WorkOrderAmt { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,#.00}")]
        [Display(Name = "Advance Pay")]
        public decimal? AdvancePayment { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,#.00}")]
        [Display(Name = "Net Payable")]
        public decimal? NetPayable { get; set; }
        [Display(Name = "Remarks")]

        [DataType(DataType.MultilineText)]
        public string? Remarks { get; set; }
        public bool IsLocked { get; set; }
        [Display(Name = "Service Contract")]

        public string? ServiceContract { get; set; }
        [Display(Name = "WO Status")]
        public int? WorkOrderStatusId { get; set; }
        [ForeignKey("WorkOrderStatusId")]
        public virtual WorkorderStatus? WorkorderStatus { get; set; }


        [DataType(DataType.MultilineText)]
        [Display(Name = "WO Details")]
        public string? WODetails { get; set; }
        [Display(Name = "Ship To")]
        public string? ShipTo { get; set; }
        [Display(Name = "Shipping")]
        public string? Shipping { get; set; }
        [Display(Name = "Total")]
        public decimal? Total { get; set; }
        [Display(Name = "Approved By")]
        public int? ApprovedById { get; set; }
        [ForeignKey("ApprovedById")]
        public virtual ApprovedBy? ApprovedBy { get; set; }

        [Display(Name = "Recommened By")]
        public int? RecommenedById { get; set; }
        [ForeignKey("RecommenedById")]
        public virtual ApprovedBy? RecommenedBy { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Approved Date")]
        public System.DateTime? DateApproval { get; set; }

        [Display(Name = "Item Group")]
        [NotMapped]
        public string[]? ItemDescArray { get; set; }
        public string? ItemDescList { get; set; }
        public int? ItemGroupId { get; set; }
        [ForeignKey("ItemGroupId")]
        public virtual ItemGroupModel? ItemGroups { get; set; }

        [Display(Name = "Item Group")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(500)]
        public string? ItemGroupName { get; set; }

        [Display(Name = "Item Desc.")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(500)]
        public string? ItemDescription { get; set; }


        [Display(Name = "Item Description")]
        public int? ItemDescId { get; set; }
        [ForeignKey("ItemDescId")]
        public virtual ItemDescriptionModel? ItemDescs { get; set; }

        public virtual ICollection<COM_MachineryLCDetails>? COM_MachineryLCDetailss { get; set; }
    }
    public partial class COM_MachineryLCDetails:BaseModel
    {
        public int MachineryLCId { get; set; }
        [ForeignKey("MachineryLCId")]
        public virtual COM_MachineryLCMaster? COM_MachineryLCMaster { get; set; }

        public int WorkOrderId { get; set; }
        [ForeignKey("WorkOrderId")]
        public virtual WorkOrderMaster? WorkOrderMaster { get; set; }
        public string? WorkOrderRef { get; set; }
    }

    public partial class COM_MachineryLCMaster:BaseModel
    {
        public string? LCNumber { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "LC Date")]
        public System.DateTime? LCDate { get; set; }

        public int? SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        public virtual SupplierModel? SupplierInformation { get; set; }

        [Display(Name = "Payment Type")]
        public int? PaymentTermsId { get; set; }
        [ForeignKey("PaymentTermsId")]
        public virtual CommercialPaymentTerms? PaymentTerms { get; set; }
        [Display(Name = "Payment Days")]
        public int? DefferredPaymentDays { get; set; } //comes from payment
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ship Date")]
        public System.DateTime? ShipDate { get; set; }
        public int? InsuranceCompanyId { get; set; }
        public string? InsurancePayStatus { get; set; }
        public string? ImportBillNo { get; set; }
        public System.DateTime? ImportBillDate { get; set; }
        public System.DateTime? BillMacturityDate { get; set; }
        public System.DateTime? BillPayDate { get; set; }
        public decimal? TotalBillAmount { get; set; }
        public string? Addedby { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime? DateAdded { get; set; }
        public ICollection<COM_MachineryLCDetails>? COM_MachineryLCDetailses { get; set; }
    }
    public class TruckInfo:BaseModel
    {
        [DataType(DataType.Text)]
        [Display(Name = "TruckNo")]
        public string? TruckNo { get; set; }

        [Display(Name = "PrintDate")]
        public string? PrintDate { get; set; }

        [Display(Name = "RefNo")]
        public string? RefNo { get; set; }
        [Display(Name = "Percentage")]
        public string? Percentage { get; set; }


        [DataType(DataType.Text)]
        [Display(Name = "DriverName")]
        public string? DriverName { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "MobileNo")]
        public string? MobileNo { get; set; }

        public int? LCId { get; set; }

        public string? LCNo { get; set; }
        public string? ReportName { get; set; }
        public string? PINo { get; set; }
        public int? GroupLcId { get; set; }
        public string? MasterLC { get; set; }
    }


    public class ContainerModel : BaseModel
    {
        public string? ContainerName { get; set; }
    }

    public partial class ImportCI_Master : BaseModel
    {
        [StringLength(100)]
        public string? CICode { get; set; }

        [Display(Name = "Port Of Loading")]
        public int? PortOfLoadingId { get; set; }
        [ForeignKey("PortOfLoadingId")]
        public virtual PortOfLoading? PortOfLoading { get; set; }

        [Display(Name = "Port Of Discharge")]
        public int? PortOfDischargeId { get; set; }
        [ForeignKey("PortOfDischargeId")]
        public virtual PortOfDischarge? PortOfDischarge { get; set; }

        [Display(Name = "Port Of Destination :")]

        public int? PortOfDestinationId { get; set; }
        [ForeignKey("PortOfDestinationId")]
        public virtual Destination? Destinations { get; set; }

        [Display(Name = "Port Of Origin :")]

        public int? PortOfOriginId { get; set; }
        [ForeignKey("PortOfOriginId")]
        public virtual PortOfLoading? PortOfOrigin { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "LC Opening Date")]
        public DateTime CIDate { get; set; }

        public int? CommercialCompanyID { get; set; }
        [ForeignKey("CommercialCompanyID")]
        public virtual CommercialCompanyModel? CommercialCompany { get; set; }

        public int? TradeTermId { get; set; }
        [ForeignKey("TradeTermId")]
        public virtual CommercialTradeTerm? CommercialTradeTerm { get; set; } 

        public int? CNFId { get; set; }
        [ForeignKey("CNFId")]
        public virtual SupplierModel? CNF { get; set; }

        public int? SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        public virtual SupplierModel? Supplier { get; set; }

        [StringLength(300)]
        public string? Description { get; set; }
        public string? BLNo { get; set; }
        public string? Remarks { get; set; }

        public virtual ICollection<ImportCI_Details>? ImportCI_DetailsList { get; set; }
    }


    public partial class ImportCI_Details : BaseModel
    {
        public int? ImportCIMasterId { get; set; }
        [ForeignKey("ImportCIMasterId")]
        public virtual ImportCI_Master? ImportCI_Master { get; set; }

        [Display(Name = "Item Description")]
        public int? ItemDescId { get; set; }
        [ForeignKey("ItemDescId")]
        public virtual ItemDescriptionModel? ItemDescs { get; set; }

        [StringLength(100)]
        public string? HSCode { get; set; }

        public double? PKG { get; set; }
        public double? Quantity { get; set; }

        public double? ExtraPercentage { get; set; }
        public double? GrossQty { get; set; }

        public int? UnitId { get; set; }
        [ForeignKey("UnitId")]
        public virtual UnitModel? Unit { get; set; }

        public double? UnitPrice { get; set; }
        public double? TotalAmount { get; set; }
        public double? NetWeight { get; set; }
        public double? GrossWeight { get; set; }
        public double? CBM { get; set; }
        public virtual ICollection<ImportCI_Container>? ImportCI_ContainerList { get; set; }
    }
    

    public partial class ImportCI_Container : BaseModel
    {
        [Display(Name = "Item Description")]
        public int? ItemDescId { get; set; }
        [ForeignKey("ItemDescId")]
        public virtual ItemDescriptionModel? ItemDescs { get; set; }

        public int? ContainerId { get; set; }
        [ForeignKey("ContainerId")]
        public virtual ContainerModel? Container { get; set; }

        public int? ImportCI_DetailsId { get; set; }
        [ForeignKey("ImportCI_DetailsId")]
        public virtual ImportCI_Details? ImportCIDetails { get; set; }
        public string? PKG { get; set; }
        public double? GrossQty { get; set; }

        public double? NetWeight { get; set; }
        public double? GrossWeight { get; set; }
    }

    [Table("ReportFilter")]
    public class ReportFilterModel : BaseModel
    {     
        public string? ReportType { get; set; }
        public string? KeyValue { get; set; }

    }

    #region self models
    public class ApprovedBy:SelfModel
    {
        [StringLength(100)]
        [Display(Name = "Status")]
        public string? ApprovedByName { get; set; }
        [StringLength(100)]
        [Display(Name = "Status")]
        public string? ApprovedByShortName { get; set; }
    }

    public class WorkorderStatus:SelfModel
    {
        [StringLength(100)]
        [Display(Name = "Status")]
        public string? WorkorderStatusName { get; set; }
        [StringLength(100)]
        [Display(Name = "Status")]
        public string? WorkorderStatusShortName { get; set; }
    }


    public class CommercialLCType:SelfModel
    {
        [StringLength(100)]
        [Display(Name = "Status")]
        public string? CommercialLCTypeName { get; set; }
        [StringLength(100)]
        [Display(Name = "Status")]
        public string? CommercialLCTypeShortName { get; set; }
    }


    public class DocumentStatus:SelfModel
    {
        [StringLength(100)]
        [Display(Name = "Status")]
        public string? DocumentStatusName { get; set; }
        [StringLength(100)]
        [Display(Name = "Status")]
        public string? DocumentStatusShortName { get; set; }
    }




    public class LCType : SelfModel
    {
        [StringLength(100)]
        public string? LCTypeName { get; set; }
        [StringLength(100)]
        public string? LCTypeShortName { get; set; }

    }


    public class LCStatus : SelfModel
    {
        [StringLength(100)]
        public string? LCStatusName { get; set; }
        [StringLength(100)]
        public string? LCStatusShortName { get; set; }
    }


    public class LCNature : SelfModel
    {
        [StringLength(100)]
        public string? LCNatureName { get; set; }
        [StringLength(100)]
        public string? LCNatureShortName { get; set; }
    }

    public class CommercialTradeTerm : SelfModel
    {
        [StringLength(100)]
        [Display(Name = "Trade Term")]
        public string? TradeTermName { get; set; }
        [StringLength(100)]
        [Display(Name = "Trade Term")]
        public string? TradeTermShortName { get; set; }
    }

    public class CommercialType : SelfModel
    {
        [StringLength(100)]
        
        public string? CommercialTypeName { get; set; }
        [StringLength(100)]
        
        public string? CommercialTypeShortName { get; set; }
    }
    public class ShipModel : SelfModel
    {
        [StringLength(100)]
        public string? ShipName { get; set; }
        [StringLength(100)]
        [DataType(DataType.Text)]
        public string? ShipShortName { get; set; }
    }
    public class CommercialPaymentTerms : SelfModel
    {
        [StringLength(100)]
        [Display(Name = "Payment Terms")]
        public string? PaymentTermsName { get; set; }
        [StringLength(100)]
        [Display(Name = "Payment Terms")]
        public string? PaymentTermsShortName { get; set; }

        public int Days { get; set; }
    }


    public class DayList : SelfModel
    {
        [Required]
        [StringLength(100)]
        public string? DayListName { get; set; }
        [Required]
        [StringLength(100)]
        public string? DayListShortName { get; set; }
        public string? DayListGroup { get; set; }
    }
    public class ExportOrderStatus : SelfModel
    {

        [Required]
        [StringLength(100)]
        public string? ExportOrderStatusName { get; set; }
        [Required]
        [StringLength(100)]
        public string? ExportOrderStatusShortName { get; set; }
    }
    public class ExportOrderCategory : SelfModel
    {
        [StringLength(100)]
        public string? ExportOrderCategoryName { get; set; }
        [StringLength(100)]
        public string? ExportOrderCategoryShortName { get; set; }
    }

    public class PINature : SelfModel
    {
        [StringLength(100)]
        public string? PINatureName { get; set; }

        [StringLength(100)]
        public string? PINatureShortName { get; set; }
    }
    public class ItemDesc : SelfModel
    {
        public string? ItemDescCode { get; set; }

        [Display(Name = "HSCode")]
        public string? ItemDescHSCode { get; set; }
        [StringLength(100)]
        [Display(Name = "Item Desc")]
        public string? ItemDescName { get; set; }
        [StringLength(100)]
        [Display(Name = "Item Desc. Short Name")]
        public string? ItemDescShortName { get; set; }

        public int? ItemGroupId { get; set; }
        [ForeignKey("ItemGroupId")]

        public virtual ItemGroupModel? ItemGroups { get; set; }

    }
    public class BankAccountNoLienBank: BaseModel
    {
        [StringLength(100)]
        [Display(Name = "Bank Account No")]
        public string? BankAccountNumber { get; set; }

        [StringLength(200)]
        [Display(Name = "Bank Account Name")]
        public string? BankAccountName { get; set; }
        public string? SwiftCodeBankAccountNoLienBank { get; set; }

        public int? CommercialCompanyId { get; set; }
        [ForeignKey("CommercialCompanyId")]

        public virtual CommercialCompanyModel? CommercialCompanys { get; set; }

        public int? LienBankId { get; set; }
        [ForeignKey("LienBankId")]

        public virtual LienBank? LienBanks { get; set; }
        public int? CountryId { get; set; }
        [ForeignKey("CountryId")]

        public virtual CountryModel? Countrys { get; set; }
        public int? SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        public virtual SupplierModel? SupplierInformations { get; set; }

        public int? BuyerId { get; set; }
        [ForeignKey("BuyerId")]
        public virtual CustomerModel? BuyerInformations { get; set; }
    }

    #endregion
}
