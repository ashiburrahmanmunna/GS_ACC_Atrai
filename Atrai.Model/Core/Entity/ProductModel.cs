using Atrai.Model.Core.Entity.Base;
using Atrai.Model.Core.Entity.Self;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atrai.Model.Core.Entity
{
    [Table("Product")]
    public class ProductModel : BaseModel
    {
        [Required]
        [DisplayName("Product Name")]

        [StringLength(200, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string? Name { get; set; }


        [DisplayName("Name Local Language")]

        [StringLength(200)]
        public string? LocalName { get; set; }


        [Required]
        [DisplayName("Code / Barcode / EAN / UPC")]
        [Remote("CheckExistingBarcode", "Values", HttpMethod = "POST", AdditionalFields = "Id", ErrorMessage = "Code Already exists. Try with a different Code.")]
        [StringLength(50)]

        public string? Code { get; set; }


        [DisplayName("EAN")]
        [Remote("CheckExistingEANCode", "Values", HttpMethod = "POST", AdditionalFields = "Id", ErrorMessage = "EAN Already exists. Try with a different Code.")]
        [StringLength(50)]

        public string? EANCode { get; set; }

        [Required]
        [DisplayName("Sales Price")]
        [Column(TypeName = "decimal(18,4)")]
        public double Price { get; set; }

        [DisplayName("Cost Price")]
        [Column(TypeName = "decimal(18,4)")]
        public double CostPrice { get; set; }

        [DisplayName("Whole Sale Price")]
        [Column(TypeName = "decimal(18,4)")]
        public double WholeSalePrice { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(300)]

        public string? Description { get; set; }

        [Required]
        [Display(Name = "Category")]
        [ForeignKey("CategoryModel")]
        public int? CategoryId { get; set; }

        public virtual CategoryModel? Category { get; set; }



        [Display(Name = "Brand")]
        [ForeignKey("BrandModel")]
        public int? BrandId { get; set; }

        public virtual BrandModel? Brand { get; set; }


        [Required]
        [Display(Name = "Unit")]
        [ForeignKey("UnitModel")]
        public int? UnitId { get; set; }

        public virtual UnitModel? Unit { get; set; }

        [Display(Name = "Warrenty")]
        [ForeignKey("Warrenty")]
        public int? WarrentyId { get; set; }
        public virtual WarrentyModel? Warrenty { get; set; }


        [Display(Name = "Inventory Head :")]
        public int? AccIdInventory { get; set; }
        [ForeignKey("AccIdInventory")]
        public virtual AccountHeadModel? InventoryAccounts { get; set; }


        [Display(Name = "Consumption Head :")]
        public int? AccIdConsumption { get; set; }
        [ForeignKey("AccIdConsumption")]
        public virtual AccountHeadModel? ConsumptionAccount { get; set; }


        [Display(Name = "Sales Head :")]
        public int? AccIdSales { get; set; }
        [ForeignKey("AccIdSales")]
        public virtual AccountHeadModel? SalesAccount { get; set; }



        [Display(Name = "Sales VAT Code :")]
        public int? AccIdSalesVAT { get; set; }
        [ForeignKey("AccIdSalesVAT")]
        public virtual AccountHeadModel? SalesVATAccount { get; set; }



        [Display(Name = "Purchase VAT Code :")]
        public int? AccIdPurchaseVAT { get; set; }
        [ForeignKey("AccIdPurchaseVAT")]
        public virtual AccountHeadModel? PurchaseVATAccount { get; set; }


        [DisplayName("Default Supplier")]
        [ForeignKey("SupplierModel")]
        public int? SupplierId { get; set; }
        public SupplierModel? SupplierModel { get; set; }


        //[Display(Name = "Image [DB]")]
        ////[ValidateFile(ErrorMessage = "Please select a PNG image smaller than 1MB")]

        //public byte[] ProductImage { get; set; }

        //[Required]
        //[DataType(DataType.ImageUrl)]
        [NotMapped]
        public string? ProductImageString { get; set; }



        [Display(Name = "Image [Folder]")]

        public string? ImagePath { get; set; }

        [Display(Name = "Files Extension")]
        public string? FileExtension { get; set; }

        public virtual IEnumerable<ProductReviewsModel>? ProductReviews { get; set; }
        public virtual IEnumerable<ProductImageModel>? ProductImages { get; set; }

        public virtual IEnumerable<ProductColorModel>? ColorList { get; set; }
        public virtual IEnumerable<ProductSizeModel>? SizeList { get; set; }
        public virtual IEnumerable<ProductWarehouseModel>? ProductWarehouseList { get; set; }



        public virtual IEnumerable<CostCalculatedModel>? CostCalculated { get; set; }

        public virtual IEnumerable<SalesItemsModel>? SalesItems { get; set; }

        public virtual IEnumerable<SalesReturnItemsModel>? SalesReturnItems { get; set; }

        public virtual IEnumerable<PurchaseReturnItemsModel>? PurchaseReturnItems { get; set; }

        public virtual IEnumerable<PurchaseItemsModel>? PurchaseItems { get; set; }

        public virtual IEnumerable<IssueItemsModel>? IssueItems { get; set; }

        public virtual IEnumerable<DamageItemsModel>? DamageItems { get; set; }


        public virtual IEnumerable<InternalTransferItemsModel>? InternalTransferItems { get; set; }

        public virtual IEnumerable<PurchaseBatchItemsModel>? PurchaseBatchItems { get; set; }

        [Display(Name = "Re-Order Level")]
        [Column(TypeName = "decimal(18,4)")]
        public double ROL { get; set; }
        [Display(Name = "2nd Re-Order Level")]
        [Column(TypeName = "decimal(18,4)")]
        public double ROLTwo { get; set; }
        [Display(Name = "3rd Re-Order Level")]
        [Column(TypeName = "decimal(18,4)")]
        public double ROLThree { get; set; }


        [Display(Name = "Re-Order Status")]
        public int ROLStatus { get; set; }




        [Display(Name = "Re-Order Qty.")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal ROQ { get; set; }
        [Display(Name = "Minimum Ord. Qty")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal MOQ { get; set; }
        [Display(Name = "PCTN / PCS Per Carton")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal PCTN { get; set; }
        [Display(Name = "Old Price")]
        [Column(TypeName = "decimal(18,4)")]
        public double OldPrice { get; set; }
        //[Display(Name = "Brand Name")]
        //[StringLength(50)]
        //[NotMapped]
        //public string? BrandName { get; set; }

        [Display(Name = "Model")]

        [StringLength(50)]
        public string? ModelName { get; set; }


        [StringLength(20)]
        [Display(Name = "Size")]
        public string? SizeName { get; set; }

        [StringLength(50)]
        [Display(Name = "GSM")]
        public string? GSM { get; set; }

        [Display(Name = "Color")]

        [StringLength(30)]
        public string? ColorName { get; set; }

        [Display(Name = "Is Published")]

        public bool IsPublished { get; set; }


        [Display(Name = "Is Featured")]

        public bool IsFeatured { get; set; }

        [Display(Name = "Is Service / Non Inventory")]

        public bool IsNonInventory { get; set; }


        //[StringLength(50)]
        [Display(Name = "Commission %")]
        [Column(TypeName = "decimal(18,4)")]

        public decimal CommissionPer { get; set; } = 0;

        //[StringLength(50)]
        [Display(Name = "Commission Amount")]
        [Column(TypeName = "decimal(18,4)")]

        public double CommissionAmount { get; set; } = 0;


        //public virtual IEnumerable<CostCalculatedModel>? Get(
        //Expression<Func<CostCalculatedModel, bool>> filter = null,
        //Func<IQueryable<CostCalculatedModel>, IOrderedQueryable<CostCalculatedModel>> orderBy = null,
        //string includeProperties = "", int? maxResults = null)


        //[Required]
        [StringLength(1)]
        [Display(Name = "Product Type")]
        public string? ProductType { get; set; }



        [Display(Name = "System Head")]
        public bool isSystem { get; set; }
        [Display(Name = "Base / Complex Product")]
        public virtual ProductModel? ParentProduct { get; set; }
        [Display(Name = "Base / Complex Product")]
        [ForeignKey("ParentProduct")]
        public int? ParentProductId { get; set; }

        public virtual MasterSalesTaxModel? SalesTax { get; set; }
        [ForeignKey("SalesTax")]
        public int? SalesTaxId { get; set; }


        public virtual MasterSalesTaxModel? PurchaseTax { get; set; }
        [ForeignKey("PurchaseTax")]
        public int? PurchaseTaxId { get; set; }

        public virtual ProductType? ProductTypes { get; set; }
        [ForeignKey("ProductTypes")]
        public int? ProductTypeId { get; set; }

        [Display(Name = "Size")]
        [ForeignKey("Size")]
        public int? SizeId { get; set; }

        public virtual SizesModel? Size { get; set; }


        [NotMapped]
        public string[]? ProductColorArray { get; set; }
        [Display(Name = "Color Group")]

        public string? ProductColorList { get; set; }



        [NotMapped]
        public string[]? ProductSizeArray { get; set; }
        [Display(Name = "Size Group")]

        public string? ProductSizeList { get; set; }




        [Display(Name = "Color")]
        [ForeignKey("Color")]
        public int? ColorId { get; set; }

        public virtual ColorsModel? Color { get; set; }



        //[Display(Name = "Discount % [For Offer]")]
        //[Column(TypeName = "decimal(18,4)")]
        //public double ProductDisPer { get; set; } = 0;

        //[StringLength(50)]
        [Display(Name = "Discount %")]
        [Column(TypeName = "decimal(18,4)")]

        public decimal ProductDiscountPer { get; set; } = 0;

        //[StringLength(50)]
        [Display(Name = "Discount Amount")]
        [Column(TypeName = "decimal(18,4)")]

        public double ProductDiscountAmount { get; set; } = 0;



        //[NotMapped]
        [Display(Name = "Profit %")]
        [Column(TypeName = "decimal(18,4)")]
        public double ProductProfitPer { get; set; } = 0;


        [NotMapped]
        public double StockQty { get; set; }

        public double RunTimeLiveStock { get; set; } = 0;

        //public double LiveBalance { get; set; } = 0;

        public DateTime OpeningDate { get; set; }

        public bool IsTaxInclusive { get; set; }

        public bool IsPurchaseTaxInclusive { get; set; }

        [StringLength(250)]
        public string? Remarks { get; set; }

        [NotMapped]
        public string? ProductTypeFlag { get; set; }

    }


    [Table("ProductWarehouse")]
    public class ProductWarehouseModel: BaseModel
    {
        [ForeignKey("Warehouse")]
        public int WarehouseId { get; set; }
        public virtual WarehouseModel? Warehouse { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual ProductModel? Product { get; set; }
    }





    [Table("ProductImage")]
    public class ProductImageModel : SelfModel
    {
        [DisplayName("Product Image")]
        [ForeignKey("ProductModel")]
        public int ProductId { get; set; }
        public virtual ProductModel? Product { get; set; }
        [StringLength(50)]
        public string? ProductImageTitle { get; set; }


        [Display(Name = "Image")]
        public string? ImagePath { get; set; }

    }


    [Table("ProductSize")]
    public class ProductSizeModel : SelfModel
    {
        [DisplayName("ProductId")]
        [ForeignKey("ProductModel")]
        public int ProductId { get; set; }
        public virtual ProductModel? ProductModel { get; set; }

        [DisplayName("Size")]
        [ForeignKey("ProductSizeList")]
        public int SizeId { get; set; }
        public virtual SizesModel? ProductSizeList { get; set; }
    }


    [Table("ProductColor")]
    public class ProductColorModel : SelfModel
    {
        [DisplayName("ProductId")]
        [ForeignKey("ProductModel")]
        public int ProductId { get; set; }
        public virtual ProductModel? ProductModel { get; set; }

        [DisplayName("Product Color")]
        [ForeignKey("ProductColorList")]
        public int ColorId { get; set; }
        public virtual ColorsModel? ProductColorList { get; set; }
    }



    [Table("ProductReviews")]
    public class ProductReviewsModel : SelfModel
    {
        [DisplayName("ProductId")]
        [ForeignKey("ProductModel")]
        public int ProductId { get; set; }
        public virtual ProductModel? Product { get; set; }


        public int Ratings { get; set; }
        [StringLength(500)]

        public string? Reviews { get; set; }


    }

    [Table("ProductType")]
    public class ProductType : SelfModel
    {
        [StringLength(100)]
        public string? TypeName { get; set; }

        [StringLength(100)]
        public string? IconClass { get; set; }

        [StringLength(100)]
        public string? DivId { get; set; }

        [StringLength(200)]
        public string? Description { get; set; }
    }

    [Table("ProductSecoundaryUnit")]
    public class ProductSecUnitModel : BaseModel
    {
        [DisplayName("ProductId")]
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual ProductModel? Product { get; set; }


        [DisplayName("Sec. Unit")]
        [ForeignKey("Units")]
        public int UnitId { get; set; }
        public UnitModel Units { get; set; }


        [Required]
        public double Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        //[Required]
        //public double Amount { get; set; }
        [StringLength(50)]
        public string? SecUnitRemarks { get; set; }

    }


    [Table("Unit")]
    public class UnitModel : BaseModel
    {
        [Required]
        [Display(Name = "Unit Name")]
        [StringLength(50)]
        public string? UnitName { get; set; }

        [Display(Name = "Unit Name Bangla")]
        [StringLength(50)]
        public string? UnitNameBangla { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Unit Short Name")]
        public string? UnitShortName { get; set; }

        [NotMapped]
        public int ProductCount { get; set; }

        public virtual ICollection<ProductModel>? ProductList { get; set; }
    }


    [Table("PaymentTerms")]
    public class PaymentTermsModel : BaseModel
    {

        [Display(Name = "Term Name")]
        [StringLength(50)]
        public string? TermName { get; set; } = string.Empty;


        [Display(Name = "Due in fixed number of days")]
        public int? DueInFixedDays { get; set; }

        [Display(Name = "Due by certain day of the month")]
        public int? DueByDayOfMonth { get; set; }

        [Display(Name = "Due the next month if issued within days of due date")]
        public int? DueNextMonthWithinDays { get; set; }
    }



    //[Table("UserSize")]
    //public class UserSizeModel : BaseModel
    //{
    //    [Required]
    //    [Display(Name = "Size Name")]
    //    [StringLength(50)]
    //    public string? SizeName { get; set; }


    //    [Required]
    //    [StringLength(50)]
    //    [Display(Name = "Size Short Name")]
    //    public string? SizeShortName { get; set; }

    //    [NotMapped]
    //    public int ProductCount { get; set; }

    //    public virtual ICollection<ProductModel>? ProductList { get; set; }
    //}





    [Table("Offer")]
    public class OfferModel : BaseModel
    {
        [Required]
        [Display(Name = "Offer Name")]
        [StringLength(50)]
        public string? OfferName { get; set; }


        [Required]
        [Display(Name = "Offer Type")]
        [StringLength(50)]
        public string? OfferType { get; set; }


        [Display(Name = "Offer Randge Start")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal OfferRangeStart { get; set; }


        [Display(Name = "Offer Randge End")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal OfferRangeEnd { get; set; }


        [Display(Name = "Offer Amount / Percentage")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal OfferFigure { get; set; }
    }


    [Table("ShippingCharge")]
    public class ShippingChargeModel : BaseModel
    {
        [Required]
        [Display(Name = "Shipping Location")]
        [StringLength(50)]
        public string? ShippingLocationName { get; set; }

        [Required]
        [Display(Name = "Amount")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal ChargeAmount { get; set; }

    }



    [Table("BarcodePrintInfo")]
    public class BarcodePrintModel : BaseModel
    {
        [Required]
        [Display(Name = "ProductId")]
        public int ProductId { get; set; }


        //[Required]
        [Display(Name = "Warehosue")]
        public int? WarehosueId { get; set; }




        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

    }

    public class MessageVM
    {
        [StringLength(50)]
        public string? CssClassName { get; set; }
        [StringLength(50)]
        public string? Title { get; set; }
        [StringLength(50)]
        public string? Message { get; set; }

    }

    public class ProductResultDemo
    {
        public int? CategoryId { get; set; }
        public int ProductId { get; set; }
        public string? ProductImage { get; set; }
        public string? CategoryName { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyPhone { get; set; }


        public string? ProductName { get; set; }
        public string? ProductCode { get; set; }
        public string? ProductBarcode { get; set; }
        public string? Description { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public double CostPrice { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public double SalesPrice { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public double OldPrice { get; set; }

        public string? BlankData { get; set; }
        public string? ImagePath { get; set; }

        public string? SizeName { get; set; }
        public string? ColorName { get; set; }
        public string? BrandName { get; set; }
        public double Ratings { get; set; }
        public double Discount { get; set; }


        public int? ProductReviewsCount { get; set; }

        public virtual IEnumerable<ProductReviewsModel>? ProductReviews { get; set; }
    }


    public class CategoryResultDemo
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }

        public string? CategoryImage { get; set; }
        public string? Description { get; set; }
        public int ProductCount { get; set; }
    }


    public class ProductResult
    {
        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? UnitName { get; set; }

        public string? Name { get; set; }
        public string? LocalName { get; set; }
        public string? Code { get; set; }
        public string? ParentCode { get; set; }

        public string? ProductBarcode { get; set; }
        public string? Description { get; set; }


        public string? BrandName { get; set; }
        public string? SizeName { get; set; }
        public string? ColorName { get; set; }

        public string? ModelName { get; set; }
        public string? VariantName { get; set; }


        [Column(TypeName = "decimal(18,4)")]
        public double OldPrice { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public double Price { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public double CostPrice { get; set; }

        public List<WarehouseResult>? WarehouseList { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public double stock { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public double TotalPurchase { get; set; }
        public string? LastPurchaseDate { get; set; }
        public string? LastPurchaseSupplier { get; set; }


        public double TotalSales { get; set; }

        public string? LastSalesDate { get; set; }
        public string? LastSalesCustomer { get; set; }
        public string? ImagePath { get; set; }

        public string? Type { get; set; }
        public string? Status { get; set; }
        public double CommissionAmount { get; set; } = 0;
        public decimal CommissionPer { get; set; } = 0;
        public decimal PCTN { get; set; }



    }



    public class WarehouseResult
    {
        public int? WarehouseId { get; set; }

        //public int Id { get; set; }
        public int CostCalculatedId { get; set; }

        public string? WhShortName { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public double CurrentStock { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public double AverageCosting { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public double CostingValue { get; set; }


        [Column(TypeName = "decimal(18,4)")]
        public double SalesValue { get; set; }

        //public int? WarehouseId { get; set; }


        //public decimal CostingValue { get; set; }
        //public decimal SalesValue { get; set; }
    }

    public class GatePassResultList : GatePassModel
    {

        public int GatePassId { get; set; }

        public string? GatePassDateString { get; set; }
        public string? EntryTimeString { get; set; }

        public string? EntryUser { get; set; }

        public object GatePassItems { get; set; }

    }


    public class SalesResultList : SalesModel
    {
        public string? StatusPosted { get; set; }
        public string? SalesDateString { get; set; }
        public string? EntryTimeString { get; set; }


        public string? ReceivingHead { get; set; }
        public string? SalesUser { get; set; }
        public string? Location { get; set; }
        public string? DocType { get; set; }

        public object SalesPayments { get; set; }
        public object SalesItems { get; set; }



        public object SalesReturnPayments { get; set; }
        public object SalesReturnAmount { get; set; }


    }

    public class OrdersResultList : OrdersModel
    {
        public string? StatusPosted { get; set; }
        public string? OrdersDateString { get; set; }
        public string? ReceivingHead { get; set; }
        public string? OrdersUser { get; set; }
        public string? Location { get; set; }

    }
}
