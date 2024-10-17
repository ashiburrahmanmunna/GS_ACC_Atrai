using Atrai.Model.Core.Entity.Base;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Atrai.Model.Core.Entity.Self;

namespace Atrai.Model.Core.Entity
{
    [Table("Style")]
    public class StyleModel : BaseModel
    {
        [DisplayName("Style No")]

        [StringLength(100)]
        public string? StyleNo { get; set; }

        [StringLength(150)]
        public string? GoodsDescription { get; set; }

        [StringLength(100)]
        public string? StyleName { get; set; }

        [StringLength(200)]
        public string? UnitPrice { get; set; }
        [StringLength(200)]
        public string? HSCode { get; set; }
        public DateTime? StyleDate { get; set; }

        public ICollection<ColorsChildModel> ColorsChilds { get; set; }
        public ICollection<SizesChildModel> SizesChilds { get; set; }

        [DisplayName("BuyerId")]
        [ForeignKey("Buyers")]
        public int BuyerId { get; set; }
        public virtual CustomerModel? Buyers { get; set; }
    }

    [Table("ColumnFilter")]
    public class ColumnFilterModel : BaseModel
    {
        [StringLength(100)]
        public string? ListName { get; set; }


        public string? KeyValue { get; set; }
        
    }

    [Table("ColorChild")]
    public class ColorsChildModel : BaseModel
    {
        [DisplayName("ColorId")]
        [ForeignKey("Colors")]
        public int ColorId { get; set; }
        public virtual ColorsModel? Colors { get; set; }

        [DisplayName("Style")]
        [ForeignKey("StyleModel")]
        public int StyleId { get; set; }
        public StyleModel StyleModel { get; set; }

        public int? SLNo { get; set; } = 0;
    }

    [Table("SizeChild")]
    public class SizesChildModel : BaseModel
    {
        [DisplayName("SizeId")]
        [ForeignKey("Sizes")]
        public int SizeId { get; set; }
        public virtual SizesModel? Sizes { get; set; }

        [DisplayName("Style")]
        [ForeignKey("StyleModel")]
        public int StyleId { get; set; }
        public StyleModel StyleModel { get; set; }
        public int? SLNo { get; set; } = 0;
    }

    [Table("BuyerPO_Master")]
    public class BuyerPO_MasterModel : BaseModel
    {
        [DisplayName("StyleId")]
        [ForeignKey("Style")]
        public int? StyleId { get; set; }
        public virtual StyleModel? Style { get; set; }

        [DisplayName("BuyerId")]
        [ForeignKey("Buyers")]
        public int? BuyerId { get; set; }
        public virtual CustomerModel? Buyers { get; set; }

        public double TotalQuantity { get; set; }
        public double UnitPrice { get; set; }
        public double TotalAmount { get; set; }

        public DateTime? OrderDate { get; set; }
        public DateTime? ShipmentDate { get; set; }

        [StringLength(200)]
        public string? BuyerPO { get; set; }

        [StringLength(50)]
        public string? FabricNo { get; set; }

        [StringLength(100)]
        public string? FabricName { get; set; }

        [StringLength(200)]
        public string? GoodsDescription { get; set; }
        public ICollection<BuyerPO_DetailsModel> BuyerPO_Details { get; set; }

        [ForeignKey("CommercialCompany")]
        public int? CommercialCompanyId { get; set; }
        public virtual CommercialCompanyModel? CommercialCompany { get; set; }
    }

    [Table("BuyerPO_Details")]
    public class BuyerPO_DetailsModel : BaseModel
    {
        [DisplayName("BuyerPOId")]
        [ForeignKey("BuyerPO_Master")]
        public int BuyerPOId { get; set; }
        public virtual BuyerPO_MasterModel? BuyerPO_Master { get; set; }

        [DisplayName("ColorId")]
        [ForeignKey("Colors")]
        public int? ColorId { get; set; }
        public virtual ColorsModel? Colors { get; set; }

        [DisplayName("SizeId")]
        [ForeignKey("Sizes")]
        public int? SizeId { get; set; }
        public virtual SizesModel? Sizes { get; set; }
        public double Quantity { get; set; }
    }

    [Table("BOMAllocationCategory")]
    public class BOMAllocationCategoryModel : BaseModel
    {
        [StringLength(200)]
        public string? Code { get; set; }

        [StringLength(100)]
        public string? Name { get; set; }

        [StringLength(20)]
        public string? ShortName { get; set; }

        [ForeignKey("CategoryType")]
        public int? CategoryTypeId { get; set; }
        public virtual CategoryTypeModel? CategoryType { get; set; }
    }

    [Table("CategoryType")]
    public class CategoryTypeModel : SelfModel
    {
        [StringLength(100)]
        public string? Name { get; set; }

        [StringLength(20)]
        public string? ShortName { get; set; }


    }

    [Table("BoxCategory")]
    public class BoxCategoryModel : BaseModel
    {
        [StringLength(100)]
        public string? MeasurementName { get; set; }

        [StringLength(40)]
        public string? MeasurementNo { get; set; }
        public double? BoxHeight { get; set; } = 0;
        public double? BoxWidth { get; set; } = 0;
        public double? BoxLength { get; set; } = 0;
        public double? Calculation { get; set; } = 0;


    }

    [Table("BOMMaster")]
    public class BOMMasterModel : BaseModel
    {
        public string? BOMCode { get; set; }

        [ForeignKey("BOMMaster")]
        public int? ParentId { get; set; }
        public virtual BOMMasterModel? BOMMaster { get; set; }

        [DisplayName("StyleId")]
        [ForeignKey("Style")]
        public int StyleId { get; set; }
        public virtual StyleModel? Style { get; set; }

        [DisplayName("ColorId")]
        [ForeignKey("Colors")]
        public int? ColorId { get; set; }
        public virtual ColorsModel? Colors { get; set; }

        [DisplayName("SizeId")]
        [ForeignKey("Sizes")]
        public int? SizeId { get; set; }
        public virtual SizesModel? Sizes { get; set; }

        public double LossPercentage { get; set; }
        public ICollection<BOMDetailsModel>? BOMDetails { get; set; }

        public bool IsRevised { get; set; }

        public int? Revision { get; set; }
    }

    [Table("BOMDetails")]
    public class BOMDetailsModel : BaseModel
    {
        [StringLength(50)]
        public string? Remarks1 { get; set; }

        [StringLength(50)]
        public string? Remarks2 { get; set; }

        [DisplayName("BOMMasterId")]
        [ForeignKey("BOMMaster")]
        public int BOMMasterId { get; set; }
        public virtual BOMMasterModel? BOMMaster { get; set; }

        [DisplayName("ProductId")]
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual ProductModel? Product { get; set; }

        [DisplayName("ColorId")]
        [ForeignKey("Colors")]
        public int? ColorId { get; set; }
        public virtual ColorsModel? Colors { get; set; }

        [DisplayName("SizeId")]
        [ForeignKey("Sizes")]
        public int? SizeId { get; set; }
        public virtual SizesModel? Sizes { get; set; }

        [DisplayName("BOMAllocationCategoryId")]
        [ForeignKey("BOMAllocationCategory")]
        public int? BOMAllocationCategoryId { get; set; }
        public virtual BOMAllocationCategoryModel BOMAllocationCategory { get; set; }
        
        [ForeignKey("CostCategory")]
        public int? CostCategoryId { get; set; }
        public virtual BOMAllocationCategoryModel CostCategory { get; set; }

        public bool IsCost { get; set; } = false;

        public ICollection<BOMQuantitySizeWiseModel> BOMQuantitySizeWise { get; set; }

        public double LossPercentage { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public double Amount { get; set; }
        public double UniqueId { get; set; }
    }

    [Table("BOMQuantitySizeWise")]
    public class BOMQuantitySizeWiseModel : BaseModel
    {
        [ForeignKey("BOMDetails")]
        public int BOMDetailsId { get; set; }
        public virtual BOMDetailsModel BOMDetails { get; set; }
        public double UniqueId { get; set; }
        public double Quantity { get; set; }

        [DisplayName("SizeId")]
        [ForeignKey("Sizes")]
        public int? SizeId { get; set; }
        public virtual SizesModel? Sizes { get; set; }

    }

    [Table("BuyerPO_Consumption")]
    public class BuyerPO_ConsumptionModel : BaseModel
    {
        [DisplayName("BuyerPOId")]
        [ForeignKey("BuyerPO_Master")]
        public int BuyerPOId { get; set; }
        public virtual BuyerPO_MasterModel? BuyerPO_Master { get; set; }



        [DisplayName("BOMMasterId")]
        [ForeignKey("BOMMaster")]
        public int BOMMasterId { get; set; }
        public virtual BOMMasterModel? BOMMaster { get; set; }

        [StringLength(50)]
        public string? Remarks1 { get; set; }

        [StringLength(50)]
        public string? Remarks2 { get; set; }

        [DisplayName("ProductId")]
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual ProductModel? Product { get; set; }

        [DisplayName("ColorId")]
        [ForeignKey("Colors")]
        public int? ColorId { get; set; }
        public virtual ColorsModel? Colors { get; set; }

        [DisplayName("SizeId")]
        [ForeignKey("Sizes")]
        public int? SizeId { get; set; }
        public virtual SizesModel? Sizes { get; set; }

        [DisplayName("BOMAllocationCategoryId")]
        [ForeignKey("BOMAllocationCategory")]
        public int? BOMAllocationCategoryId { get; set; }
        public virtual BOMAllocationCategoryModel BOMAllocationCategory { get; set; }

        public double Quantity { get; set; }
        public double Price { get; set; }
        public double Amount { get; set; }

    }

    [Table("MASTERPO_Consumption")]
    public class MASTERPO_ConsumptionModel : BaseModel

    {
        [DisplayName("Master PO")]
        [ForeignKey("MasterPO")]
        public int MasterPOId { get; set; }
        public virtual MasterPOModel? MasterPO { get; set; }

        [DisplayName("BuyerPOId")]
        [ForeignKey("BuyerPO_Master")]
        public int BuyerPOId { get; set; }
        public virtual BuyerPO_MasterModel? BuyerPO_Master { get; set; }

        [DisplayName("BOMMasterId")]
        [ForeignKey("BOMMaster")]
        public int BOMMasterId { get; set; }
        public virtual BOMMasterModel? BOMMaster { get; set; }

        [StringLength(50)]
        public string? Remarks1 { get; set; }

        [StringLength(50)]
        public string? Remarks2 { get; set; }

        [DisplayName("ProductId")]
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual ProductModel? Product { get; set; }

        [DisplayName("SupplierId")]
        [ForeignKey("Supplier")]
        public int? SupplierId { get; set; }
        public virtual SupplierModel? Supplier { get; set; }

        [DisplayName("ColorId")]
        [ForeignKey("Colors")]
        public int? ColorId { get; set; }
        public virtual ColorsModel? Colors { get; set; }

        [DisplayName("SizeId")]
        [ForeignKey("Sizes")]
        public int? SizeId { get; set; }
        public virtual SizesModel? Sizes { get; set; }

        [DisplayName("BOMAllocationCategoryId")]
        [ForeignKey("BOMAllocationCategory")]
        public int? BOMAllocationCategoryId { get; set; }
        public virtual BOMAllocationCategoryModel BOMAllocationCategory { get; set; }

        public double Quantity { get; set; }
        public double Price { get; set; }
        public double Amount { get; set; }

    }


    [Table("DailyProduction_Master")]  
    public class DailyProduction_MasterModel : BaseModel 
    {

        [DisplayName("StyleId")]
        [ForeignKey("Style")]
        public int? StyleId { get; set; }
        public virtual StyleModel? Style { get; set; }

        [DisplayName("BuyerPOId")]
        [ForeignKey("BuyerPO_Master")]
        public int? BuyerPOId { get; set; }
        public virtual BuyerPO_MasterModel? BuyerPO_Master { get; set; }

        [DisplayName("BuyerId")]
        [ForeignKey("Buyers")]
        public int? BuyerId { get; set; }
        public virtual CustomerModel? Buyers { get; set; }

        public double TotalQuantity { get; set; }

        [DisplayName("DepartmentId")]
        [ForeignKey("Departments")]
        public int? DepartmentId { get; set; }
        public virtual Cat_DepartmentModel? Departments { get; set; }

        public ICollection<DailyProduction_DetailsModel> DailyProduction_Details { get; set; }
    }

    [Table("DailyProduction_Details")]
    public class DailyProduction_DetailsModel : BaseModel
    {

        [DisplayName("DailyProductionId")]
        [ForeignKey("DailyProduction_Master")]
        public int DailyProductionId { get; set; }
        public virtual DailyProduction_MasterModel DailyProduction_Master { get; set; }

        [DisplayName("ColorId")]
        [ForeignKey("Colors")]
        public int? ColorId { get; set; }
        public virtual ColorsModel? Colors { get; set; }

        [DisplayName("SizeId")]
        [ForeignKey("Sizes")]
        public int? SizeId { get; set; }
        public virtual SizesModel? Sizes { get; set; }
        public double ReceivedQuantity { get; set; }

        [ForeignKey("Departments")]
        public int? DepartmentId { get; set; }
        public virtual Cat_DepartmentModel? Departments { get; set; }
    }

    [Table("DeptWise_DailyProduction_Master")]
    public class DeptWise_DailyProduction_MasterModel : BaseModel
    {

        [DisplayName("StyleId")]
        [ForeignKey("Style")]
        public int? StyleId { get; set; }
        public virtual StyleModel? Style { get; set; }

        [DisplayName("BuyerPOId")]
        [ForeignKey("BuyerPO_Master")]
        public int? BuyerPOId { get; set; }
        public virtual BuyerPO_MasterModel? BuyerPO_Master { get; set; }
        public double TotalQuantity { get; set; }

        [DisplayName("DepartmentId")]
        [ForeignKey("Departments")]
        public int? DepartmentId { get; set; }
        public virtual Cat_DepartmentModel? Departments { get; set; }

        [StringLength(30)]
        public string? Type { get; set; }

        public ICollection<DeptWise_DailyProduction_DetailsModel>? DailyProduction_Details { get; set; }
    }

    [Table("DeptWise_DailyProduction_Details")]
    public class DeptWise_DailyProduction_DetailsModel : BaseModel
    {

        [ForeignKey("DailyProduction_Master")]
        public int DailyProductionId { get; set; }
        public virtual DeptWise_DailyProduction_MasterModel DailyProduction_Master { get; set; }

        [ForeignKey("Style")]
        public int? StyleId { get; set; }
        public virtual StyleModel? Style { get; set; }

        [ForeignKey("BuyerPO")]
        public int? BuyerPOId { get; set; }
        public virtual BuyerPO_MasterModel? BuyerPO { get; set; }

        [ForeignKey("ParentBuyerPO")]
        public int? ParentBuyerPOId { get; set; }
        public virtual BuyerPO_MasterModel? ParentBuyerPO { get; set; }

        [DisplayName("ColorId")]
        [ForeignKey("Colors")]
        public int? ColorId { get; set; }
        public virtual ColorsModel? Colors { get; set; }

        [DisplayName("SizeId")]
        [ForeignKey("Sizes")]
        public int? SizeId { get; set; }
        public virtual SizesModel? Sizes { get; set; }
        public int TQty { get; set; } = 0;
        public int TQty2 { get; set; } = 0;
        public DateTime? ProductionDate { get; set; }
        public string? WNo { get; set; }
        public string? WSlipNo { get; set; }
        public string? SNo { get; set; }
        public string? SSlipNo { get; set; }
        public string? CNo { get; set; } 
        public string? CSlipNo { get; set; }
        public string? FNo { get; set; } 
        public int QtyB { get; set; } = 0;
        public int QtyC { get; set; } = 0;
        public int GradeAQty { get; set; } = 0;
        public int GradeBQty { get; set; } = 0;
        public int GradeCQty { get; set; } = 0;
        public int? DepartmentId { get; set; }
        public string? LayNo { get; set; }
        public double? Utilization { get; set; }
        public double? Width { get; set; }

    }


}
