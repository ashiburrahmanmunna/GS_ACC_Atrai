using Atrai.Model.Core.Entity;
using Atrai.Data.Interfaces;
using Atrai.Data.Interfaces.Base;
using Atrai.Data.Context.AppDataContext;
using Atrai.Data.Repository.Base;
using Atrai.Data.Repository.Self;
using DocumentFormat.OpenXml.InkML;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atrai.Data.Repository
{
    public class ProductRepository : BaseRepository<ProductModel>, IProductRepository         
    {
        public ProductRepository(InvoiceDbContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetAllBarcodeForDropDown(bool isComId = true)
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.Code.Length < 4 ? x.Name : x.Name + " - [ " + x.Code + " ]",
                Value = x.Id.ToString()

            });
        }

        public IEnumerable<SelectListItem> GetAllProductForDropDown(bool isComId = true)
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()

            });
        }




        public IEnumerable<SelectListItem> GetComplexProductDropDown(bool isComId = true)
        {
            return All().Where(x => x.ProductType == "C").Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()

            });
        }




        public IEnumerable<SelectListItem> GetBrandDropDown(bool isComId = true)
        {
            return All().Where(x => x.Brand != null)
                .GroupBy(x => new { x.Brand.BrandName })
                 //.Select(g => new { SalesDate = g.Key.SalesDate.ToString("dd-MMM-yy"), TotalSalesCount = g.Count(), TotalSalesSum = g.Sum(x => x.NetAmount) }).ToList();
                 .Select(g => new SelectListItem
                 {
                     Text = g.Key.BrandName,
                     Value = ""

                 });
        }
        public IEnumerable<SelectListItem> GetModelDropDown(bool isComId = true)
        {
            return All().Where(x => x.ModelName.Length > 0)
                .GroupBy(x => new { x.ModelName })
                .Select(x => new SelectListItem
                {
                    Text = x.Key.ModelName,
                    Value = ""

                });
        }

        public IEnumerable<SelectListItem> GetModelByBrandDropDown(int BrandId)
        {
            return All().Where(x => x.ModelName.Length > 0 & x.BrandId == BrandId)
                .GroupBy(x => new { x.ModelName })
                .Select(x => new SelectListItem
                {
                    Text = x.Key.ModelName,
                    Value = ""

                });
        }

        public IEnumerable<SelectListItem> GetColorDropDown(bool isComId = true)
        {
            return All().Where(x => x.ColorName.Length > 0)
             .GroupBy(x => new { x.ColorName })
                .Select(x => new SelectListItem
                {
                    Text = x.Key.ColorName,
                    Value = ""

                });
        }


        public IEnumerable<SelectListItem> GetSizeDropDown(bool isComId = true)
        {
            return All().Where(x => x.SizeName.Length > 0)
                        .GroupBy(x => new { x.SizeName })
                        .Select(x => new SelectListItem
                        {
                            Text = x.Key.SizeName,
                            Value = ""

                        });
        }



    }



    public class ProductColorRepository : SelfRepository<ProductColorModel>, IProductColorRepository
    {
        public ProductColorRepository(InvoiceDbContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.ProductColorList.ColorName,
                Value = x.Id.ToString()
            });
        }
    }

    public class ProductTypeRepository : SelfRepository<ProductType>, IProductTypeRepository
    {
        public ProductTypeRepository(InvoiceDbContext context) : base(context)
        {
        }

    }

    public class ProductSizeRepository : SelfRepository<ProductSizeModel>, IProductSizeRepository
    {
        public ProductSizeRepository(InvoiceDbContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.ProductSizeList.SizeName,
                Value = x.Id.ToString()
            });
        }
    }
    public class CategoryRepository : BaseRepository<CategoryModel>, ICategoryRepository
    {
        public CategoryRepository(InvoiceDbContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true)
        {
            return All(isComId).Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
        }

        public IEnumerable<SelectListItem> GetAllForDropDownComId(bool isComId = true, int ComId = 0)
        {
            return All(isComId).Where(x => x.ComId == ComId).Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
        }


    }


    public class BrandRepository : BaseRepository<BrandModel>, IBrandRepository
    {
        public BrandRepository(InvoiceDbContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true)
        {
            return All(isComId).Select(x => new SelectListItem
            {
                Text = x.BrandName,
                Value = x.Id.ToString()
            });
        }


    }


}


public class DocApprovalSettingRepository : BaseRepository<DocApprovalSettingModel>, IDocApprovalSettingRepository
{
    public DocApprovalSettingRepository(InvoiceDbContext context) : base(context)
    {
    }

    public IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true)
    {
        return All(isComId).Select(x => new SelectListItem
        {
            Text = x.DocType.DocType,
            Value = x.Id.ToString()
        });
    }


}

public class ApprovalStatusRepository : SelfRepository<ApprovalStatusModel>, IApprovalStatusRepository
{
    public ApprovalStatusRepository(InvoiceDbContext context) : base(context)
    {
    }

    public IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true)
    {
        return All(isComId).Select(x => new SelectListItem
        {
            Text = x.ApprovalStatus,
            Value = x.Id.ToString()
        });
    }


}

public class TransactionApprovalStatusRepository : BaseRepository<TransactionApprovalStatusModel>, ITransactionApprovalStatusRepository
{
    public TransactionApprovalStatusRepository(InvoiceDbContext context) : base(context)
    {
    }

    
}


public class DesignationRepository : BaseRepository<Cat_DesignationModel>, IDesignationRepository
{
    public DesignationRepository(InvoiceDbContext context) : base(context)
    {
    }

    public IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true)
    {
        return All(isComId).Select(x => new SelectListItem
        {
            Text = x.DesigName + " " + x.DesigNameB,
            Value = x.Id.ToString()
        });
    }


}


public class ProductWarehouseRepository : BaseRepository<ProductWarehouseModel>, IProductWarehouseRepository
{
    public ProductWarehouseRepository(InvoiceDbContext context) : base(context)
    {
    }

}

public class ProductReviewsRepository : SelfRepository<ProductReviewsModel>, IProductReviewsRepository
{
    public ProductReviewsRepository(InvoiceDbContext context) : base(context)
    {
    }

    public IEnumerable<SelectListItem> GetAllForDropDown()
    {
        return All().Select(x => new SelectListItem
        {
            Text = x.Reviews + " - " + x.Ratings,
            Value = x.Id.ToString()
        });
    }
}

public class EmailSettingRepository : BaseRepository<EmailSettingModel>, IEmailSettingRepository
{
    public EmailSettingRepository(InvoiceDbContext context) : base(context)
    {
    }

    public IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true)
    {
        return All(isComId).Select(x => new SelectListItem
        {
            Text = x.MailServer,
            Value = x.Id.ToString()
        });
    }
}


public class SmsSettingRepository : BaseRepository<SmsSettingModel>, ISmsSettingRepository
{
    public SmsSettingRepository(InvoiceDbContext context) : base(context)
    {
    }

    public IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true)
    {
        return All(isComId).Select(x => new SelectListItem
        {
            Text = x.smsAddress,
            Value = x.Id.ToString()
        });
    }
}


public class VoterRepository : BaseRepository<VoterModel>, IVoterRepository
{
    public VoterRepository(InvoiceDbContext context) : base(context)
    {
    }

    public IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true)
    {
        return All(isComId).Select(x => new SelectListItem
        {
            Text = x.nameEn,
            Value = x.Id.ToString()
        });
    }
}

public class WarrentyRepository : SelfRepository<WarrentyModel>, IWarrentyRepository
{
    public WarrentyRepository(InvoiceDbContext context) : base(context)
    {
    }

    public IEnumerable<SelectListItem> GetAllForDropDown()
    {
        return All().Select(x => new SelectListItem
        {
            Text = x.Name + " - " + x.Day + " " + x.DurationTime.DurationName,
            Value = x.Id.ToString()
        });
    }
}


public class TimeZoneSettingsRepository : SelfRepository<TimeZoneSettingsModel>, ITimeZoneSettingsRepository
{
    public TimeZoneSettingsRepository(InvoiceDbContext context) : base(context)
    {
    }

    public IEnumerable<SelectListItem> GetAllForDropDown()
    {
        return All().Select(x => new SelectListItem
        {
            Text = x.TimeZoneName + x.UTCTime,
            Value = x.Id.ToString()
        });
    }
}

public class DurationTimeRepository : SelfRepository<DurationTimeModel>, IDurationTimeRepository
{
    public DurationTimeRepository(InvoiceDbContext context) : base(context)
    {
    }

    public IEnumerable<SelectListItem> GetAllForDropDown()
    {
        return All().Select(x => new SelectListItem
        {
            Text = x.DurationName + " - " + x.Day + " " + x.DurationName,
            Value = x.Id.ToString()
        });
    }
}

//public class ColorRepository : SelfRepository<ColorModel>, IColorRepository
//{
//    public ColorRepository(InvoiceDbContext context) : base(context)
//    {
//    }

//    public IEnumerable<SelectListItem> GetAllForDropDown()
//    {
//        return All().Select(x => new SelectListItem
//        {
//            Text = x.ColorName,// + " - " + x.ColorCode,
//            Value = x.ColorCode
//        });
//    }

//    public IEnumerable<SelectListItem> GetAllForDropDownWtihValue()
//    {
//        return All().Select(x => new SelectListItem
//        {
//            Text = x.ColorName,// + " - " + x.ColorCode,
//            Value = x.Id.ToString()
//        });
//    }
//}
public class BOMMasterRepository : BaseRepository<BOMMasterModel>, IBOMMasterRepository
{
    public BOMMasterRepository(InvoiceDbContext context) : base(context)
    {
    }
}
public class MasterPOConsumptionRepository : BaseRepository<MASTERPO_ConsumptionModel>, IMasterPOConsumptionRepository
{
    public MasterPOConsumptionRepository(InvoiceDbContext context) : base(context)
    {
    }
}

public class BOMDetailsRepository : BaseRepository<BOMDetailsModel>, IBOMDetailsRepository
{
    public BOMDetailsRepository(InvoiceDbContext context) : base(context)
    {
    }
}
public class BOMQuantitySizeWiseRepository : BaseRepository<BOMQuantitySizeWiseModel>, IBOMQuantitySizeWiseRepository
{
    public BOMQuantitySizeWiseRepository(InvoiceDbContext context) : base(context)
    {
    }
}
public class DailyProduction_MasterRepository : BaseRepository<DailyProduction_MasterModel>, IDailyProduction_MasterRepository
{
    public DailyProduction_MasterRepository(InvoiceDbContext context) : base(context)
    {
    }
}
public class DailyProduction_DetailsRepository : BaseRepository<DailyProduction_DetailsModel>, IDailyProduction_DetailsRepository
{
    public DailyProduction_DetailsRepository(InvoiceDbContext context) : base(context)
    {
    }
}

public class DeptWiseDailyProduction_MasterRepository : BaseRepository<DeptWise_DailyProduction_MasterModel>, IDeptWiseDailyProduction_MasterRepository
{
    public DeptWiseDailyProduction_MasterRepository(InvoiceDbContext context) : base(context)
    {
    }
}
public class DeptWiseDailyProduction_DetailsRepository : BaseRepository<DeptWise_DailyProduction_DetailsModel>, IDeptWiseDailyProduction_DetailsRepository
{
    public DeptWiseDailyProduction_DetailsRepository(InvoiceDbContext context) : base(context)
    {
    }
}
public class BOMAllocationCategoryRepository : BaseRepository<BOMAllocationCategoryModel>, IBOMAllocationCategoryRepository
{
    public BOMAllocationCategoryRepository(InvoiceDbContext context) : base(context)
    {
    }

    public IEnumerable<SelectListItem> GetAllForDropDown()
    {
        return All().Select(x => new SelectListItem
        {
            Text = x.Name,
            Value = x.Id.ToString()
        });
    }
}

public class BuyerPO_MasterRepository : BaseRepository<BuyerPO_MasterModel>, IBuyerPO_MasterRepository
{
    public BuyerPO_MasterRepository(InvoiceDbContext context) : base(context)
    {
    }
}

public class BuyerPO_DetailsRepository : BaseRepository<BuyerPO_DetailsModel>, IBuyerPO_DetailsRepository
{
    public BuyerPO_DetailsRepository(InvoiceDbContext context) : base(context)
    {
    }
}
//public class SizeRepository : SelfRepository<SizeModel>, ISizeRepository
//{
//    public SizeRepository(InvoiceDbContext context) : base(context)
//    {
//    }

//    public IEnumerable<SelectListItem> GetAllForDropDown()
//    {
//        return All().Select(x => new SelectListItem
//        {
//            Text = x.SizeName,
//            Value = x.Id.ToString()
//        });
//    }

//}

public class DocTypeRepository : SelfRepository<DocTypeModel>, IDocTypeRepository
{
    public DocTypeRepository(InvoiceDbContext context) : base(context)
    {
    }
    public IEnumerable<DocTypeModel> GetAllDoctype()
    {
        return All();
    }
    public IEnumerable<SelectListItem> GetAllDocForDropDown()
    {
        return All().Select(x => new SelectListItem
        {
            Text = x.DocType,
            Value = x.Id.ToString()
        });
    }
    public IEnumerable<SelectListItem> GetAllDoctypeList()
    {
        return All().Where(x => x.DocFor != "Approval").Select(x => new SelectListItem
        {
            Text = x.DocType,
            Value = x.Id.ToString(),
        });
    }

    public IEnumerable<SelectListItem> GetSalesDocForDropDown()
    {
        return All().Where(x => x.DocFor == "Sales").Select(x => new SelectListItem
        {
            Text = x.DocType,
            Value = x.Id.ToString()
        });
    }
    public List<DocTypeModel> GetAllDocTypeSalesForDropDown()
    {
        return All().Where(x => x.DocFor == "Sales").Select(x => new DocTypeModel
        {
            DocType = x.DocType,
            Id = x.Id
        }).ToList();
    }


    public IEnumerable<SelectListItem> GetPurchaseDocForDropDown()
    {
        return All().Where(x => x.DocFor == "Purchase").Select(x => new SelectListItem
        {
            Text = x.DocType,
            Value = x.Id.ToString()
        });
    }

    public IEnumerable<SelectListItem> GetApprovalDocForDropDown()
    {
        return All().Where(x => x.DocFor == "Approval").Select(x => new SelectListItem
        {
            Text = x.DocType,
            Value = x.Id.ToString()
        });
    }

    public IEnumerable<SelectListItem> GetApprovalDocValueForDropDown()
    {
        return All().Where(x => x.DocFor == "Approval").Select(x => new SelectListItem
        {
            Text = x.DocType,
            Value = x.DocTypeValue.ToString()
        });
    }
}



public class ApprovalTypeRepository : SelfRepository<ApprovalTypeModel>, IApprovalTypeRepository
{
    public ApprovalTypeRepository(InvoiceDbContext context) : base(context)
    {
    }

    public IEnumerable<SelectListItem> GetAllForDropDown()
    {
        return All().Select(x => new SelectListItem
        {
            Text = x.ApprovalType,
            Value = x.Id.ToString()
        });
    }

}

public class CostCalculatedRepository : BaseRepository<CostCalculatedModel>, ICostCalculatedRepository
{
    public CostCalculatedRepository(InvoiceDbContext context) : base(context)
    {
    }
}


public class UnitRepository : BaseRepository<UnitModel>, IUnitRepository
{
    public UnitRepository(InvoiceDbContext context) : base(context)
    {
    }
    public IEnumerable<SelectListItem> GetAllForDropDown()
    {
        return All().Select(x => new SelectListItem
        {
            Text = x.UnitName,
            Value = x.Id.ToString()
        });
    }
}
public class VariableRepository : SelfRepository<VariableModel>, IVariableRepository
{
    public VariableRepository(InvoiceDbContext context) : base(context)
    {
    }

    //public IEnumerable<VariableModel> GetAllTerms()
    //{
    //    return AllData();
    //}

    public IEnumerable<SelectListItem> GetAllForDropDown(string VarType)
    {
        return All().Where(x => x.VariableFor == VarType).Select(x => new SelectListItem
        {
            Text = x.VariableName,
            Value = x.Id.ToString()
        });
    }
    public List<VariableModel> GetAllVariableForDropDown(string VarType)
    {
        return All().Where(x => x.VariableFor == VarType).Select(x => new VariableModel
        {
            VariableName = x.VariableName,
            Id = x.Id
        }).ToList();
    }

}
public class TermRepository : BaseRepository<PaymentTermsModel>, ITermRepository
{
    public TermRepository(InvoiceDbContext context) : base(context)
    {
    }

    public IEnumerable<PaymentTermsModel> GetAllTerms()
    {
        return AllData();
    }

    public IEnumerable<SelectListItem> GetAllForDropDown()
    {
        return All().Select(x => new SelectListItem
        {
            Text = x.TermName,
            Value = x.Id.ToString()
        });
    }

    public List<PaymentTermsModel> GetAlltermsForDropDown()
    {
        return All().Select(x => new PaymentTermsModel
        {
            TermName = x.TermName,
            Id = x.Id
        }).ToList();
    }

}


public class TermMainRepository : BaseRepository<TermsMainModel>, ITermMainRepository
{
    public TermMainRepository(InvoiceDbContext context) : base(context)
    {
    }

    public IEnumerable<TermsMainModel> GetAllTerms()
    {
        return AllData();
    }

    public IEnumerable<SelectListItem> GetAllForDropDown()
    {
        return All().Select(x => new SelectListItem
        {
            Text = x.TermsName,
            Value = x.Id.ToString()
        });
    }

    public List<TermsMainModel> GetAlltermsForDropDown()
    {
        return All().Select(x => new TermsMainModel
        {
            TermsName = x.TermsName,
            Id = x.Id
        }).ToList();
    }

}



public class TradeTermRepository : BaseRepository<TradeTermsModel>, ITradeTermRepository
{
    public TradeTermRepository(InvoiceDbContext context) : base(context)
    {
    }

    public IEnumerable<TradeTermsModel> GetAllTerms()
    {
        return AllData();
    }
    public IEnumerable<SelectListItem> GetAllForDropDown()
    {
        return All().Select(x => new SelectListItem
        {
            Text = x.TradeTermCaption,
            Value = x.Id.ToString()
        });
    }
    public IEnumerable<SelectListItem> GetAllTradeTerms()
    {
        return All().Select(x => new SelectListItem
        {
            Text = x.TradeTermCaption,
            Value = x.Id.ToString()
        });
    }
}

















public class ShippingChargeRepository : BaseRepository<ShippingChargeModel>, IShippingChargeRepository
{
    public ShippingChargeRepository(InvoiceDbContext context) : base(context)
    {
    }
    public IEnumerable<SelectListItem> GetAllForDropDown()
    {
        return All().Select(x => new SelectListItem
        {
            Text = x.ShippingLocationName,
            Value = x.Id.ToString()
        });
    }
}


public class OfferRepository : BaseRepository<OfferModel>, IOfferRepository
{
    public OfferRepository(InvoiceDbContext context) : base(context)
    {
    }
    public IEnumerable<SelectListItem> GetAllForDropDown()
    {
        return All().Select(x => new SelectListItem
        {
            Text = x.OfferName,
            Value = x.Id.ToString()
        });
    }
}


public class LinkShareRepository : BaseRepository<LinkShareModel>, ILinkShareRepository
{
    public LinkShareRepository(InvoiceDbContext context) : base(context)
    {
    }

}




public class BarcodePrintRepository : BaseRepository<BarcodePrintModel>, IBarcodePrintRepository
{
    public BarcodePrintRepository(InvoiceDbContext context) : base(context)
    {
    }

}

public class PurchaseBatchItemsRepository : BaseRepository<PurchaseBatchItemsModel>, IPurchaseBatchItemsRepository
{
    public PurchaseBatchItemsRepository(InvoiceDbContext context) : base(context)
    {
    }
}

public class ProductSecUnitRepository : BaseRepository<ProductSecUnitModel>, IProductSecUnitRepository
{
    public ProductSecUnitRepository(InvoiceDbContext context) : base(context)
    {
    }
}


public class WarrantyItemsRepository : BaseRepository<WarrantyItemsModel>, IWarrantyItemsRepository
{
    public WarrantyItemsRepository(InvoiceDbContext context) : base(context)
    {
    }
}



public class WarehouseRepository : BaseRepository<WarehouseModel>, IWarehouseRepository
{
    public WarehouseRepository(InvoiceDbContext context) : base(context)
    {
    }

    public IEnumerable<SelectListItem> GetAllForDropDown()
    {
        return All().Where(x => x.Id > 0).Select(x => new SelectListItem
        {
            Text = x.WhShortName,
            Value = x.Id.ToString()
        });
    }

    public IEnumerable<SelectListItem> GetWarehouseLedgerHeadForDropDown()
    {
        return All().Where(x => x.Id > 0).Where(x => x.WhType == "L").Select(x => new SelectListItem
        {
            Text = x.WhShortName,
            Value = x.Id.ToString()
        });
    }


    public IEnumerable<SelectListItem> GetWarehouseGroupHeadForDropDown()
    {
        return All().Where(x => x.Id > 0).Where(x => x.WhType == "G").Select(x => new SelectListItem
        {
            Text = x.WhShortName,
            Value = x.Id.ToString()
        });
    }




}

public class TagsRepository : BaseRepository<TagsModel>, ITagsRepository
{
    public TagsRepository(InvoiceDbContext context) : base(context)
    {
    }

    public IEnumerable<SelectListItem> GetAllForDropDown()
    {
        return All().Where(x => x.Id > 0).Select(x => new SelectListItem
        {
            Text = x.TagName,
            Value = x.Id.ToString()
        });
    }

    public IEnumerable<SelectListItem> GetAllForDropDownForGroup()
    {

        return All().Where(x => x.Id > 0).Where(x => x.TagsType == "G").Select(x => new SelectListItem
        {
            Text = x.TagName,
            Value = x.Id.ToString()
        });
    }

}



public class BookRepository : BaseRepository<BookModel>, IBookRepository
{
    private readonly InvoiceDbContext _context = null;

    public BookRepository(InvoiceDbContext context) : base(context)
    {
    }

    public IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true)
    {
        return All(isComId).Select(x => new SelectListItem
        {
            Text = x.Title,
            Value = x.Id.ToString()
        });
    }

    public async Task<int> AddNewBook(BookModel model)
    {
        var newBook = new BookModel()
        {
            //Author = model.Author,
            //CreatedOn = DateTime.UtcNow,
            //Description = model.Description,
            Title = model.Title
            //LanguageId = model.LanguageId,
            //TotalPages = model.TotalPages.HasValue ? model.TotalPages.Value : 0,
            //UpdatedOn = DateTime.UtcNow,
            //CoverImageUrl = model.CoverImageUrl,
            //BookPdfUrl = model.BookPdfUrl
        };

        newBook.Gallery = new List<GalleryModel>();

        foreach (var file in model.Gallery)
        {
            newBook.Gallery.Add(new GalleryModel()
            {
                Name = file.Name,
                URL = file.URL
            });
        }

        await _context.Books.AddAsync(newBook);
        await _context.SaveChangesAsync();

        return newBook.Id;

    }

    public async Task<List<BookModel>> GetAllBooks()
    {
        return await _context.Books
              .Select(book => new BookModel()
              {
                  //Author = book.Author,
                  //Category = book.Category,
                  //Description = book.Description,
                  Id = book.Id,
                  //LanguageId = book.LanguageId,
                  //Language = book.Language.Name,
                  Title = book.Title,
                  //TotalPages = book.TotalPages,
                  //CoverImageUrl = book.CoverImageUrl
              }).ToListAsync();
    }



    public async Task<BookModel> GetBookById(int id)
    {
        return await _context.Books.Where(x => x.Id == id)
             .Select(book => new BookModel()
             {
                 //Author = book.Author,
                 // Category = book.Category,
                 //Description = book.Description,
                 Id = book.Id,
                 //LanguageId = book.LanguageId,
                 //Language = book.Language.Name,
                 Title = book.Title,
                 //TotalPages = book.TotalPages,
                 //CoverImageUrl = book.CoverImageUrl,
                 Gallery = book.Gallery.Select(g => new GalleryModel()
                 {
                     Id = g.Id,
                     Name = g.Name,
                     URL = g.URL
                 }).ToList(),
                 //BookPdfUrl = book.BookPdfUrl
             }).FirstOrDefaultAsync();
    }



}

public class GalleryRepository : SelfRepository<GalleryModel>, IGalleryRepository
{
    public GalleryRepository(InvoiceDbContext context) : base(context)
    {
    }
}



public class NotificationRepository : BaseRepository<NotificationModel>, INotificationRepository
{
    public NotificationRepository(InvoiceDbContext context) : base(context)
    {
    }

    public IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true)
    {
        return All(isComId).Select(x => new SelectListItem
        {
            Text = x.TextMessage,
            Value = x.Id.ToString()
        });
    }


}




public class DiscountTypeRepository : BaseRepository<DiscountTypeModel>, IDiscountTypeRepository
{
    public DiscountTypeRepository(InvoiceDbContext context) : base(context)
    {
    }

    public IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true)
    {
        return All(isComId).Select(x => new SelectListItem
        {
            Text = x.DisPer.ToString(),
            Value = x.Id.ToString()
        });
    }


}


public class DocStatusRepository : SelfRepository<DocStatusModel>, IDocStatusRepository
{
    public DocStatusRepository(InvoiceDbContext context) : base(context)
    {
    }

    //public IEnumerable<SelectListItem> GetAllForDropDown()
    //{
    //    return All().Select(x => new SelectListItem
    //    {
    //        Text = x.DocStatus.ToString(),
    //        Value = x.Id.ToString()
    //    });
    //}
    public IEnumerable<DocStatusModel> GetAllDoctype()
    {
        return All();
    }

}
public class StatusRepository : SelfRepository<StatusModel>, IStatusRepository
{
    public StatusRepository(InvoiceDbContext context) : base(context)
    {
    }

    public IEnumerable<SelectListItem> GetAllForDropDown()
    {
        return All().Select(x => new SelectListItem
        {
            Text = x.Status.ToString(),
            Value = x.Id.ToString()
        });
    }
    //public IEnumerable<StatusModel> GetAllDocStatusForExpenses()
    //{
    //    return All().Where(x=>x.DocTypes.DocType=="Bill").Select(x => new SelectListItem
    //    {
    //        Text = x.Status.ToString(),
    //        Value = x.Id.ToString()
    //    });
    //}
    public IEnumerable<StatusModel> GetAllDocStatusForExpenses()
    {
        return All()
            .Where(x => x.DocTypes.DocType == "Bill")
            .Select(x => new StatusModel
            {
                // Assuming StatusModel has properties like 'Status' and 'Id'
                Status = x.Status,
                Id = x.Id
            });
    }


}


public class NotificationSeenRepository : BaseRepository<NotificationSeenModel>, INotificationSeenRepository
{
    public NotificationSeenRepository(InvoiceDbContext context) : base(context)
    {
    }


}

public class EmployeeAttendanceRepository : BaseRepository<EmployeeAttendanceModel>, IEmployeeAttendanceRepository
{
    public EmployeeAttendanceRepository(InvoiceDbContext context) : base(context)
    {
    }


}

public class MobileTextAnimationRepository : BaseRepository<MobileTextAnimationModel>, IMobileTextAnimationRepository
{
    public MobileTextAnimationRepository(InvoiceDbContext context) : base(context)
    {
    }
}
public class TaskToDoRepository : BaseRepository<TaskToDoModel>, ITaskToDoRepository
{
    public TaskToDoRepository(InvoiceDbContext context) : base(context)
    {
    }

    public IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true)
    {
        return All(isComId).Where(x => x.IsComplete == false && x.ParentTaskToDo == null).Select(x => new SelectListItem
        {
            Text = x.TaskTitle,
            Value = x.Id.ToString()
        });
    }

}


public class PaymentTypeRepository : SelfRepository<PaymentTypeModel>, IPaymentTypeRepository
{
    public PaymentTypeRepository(InvoiceDbContext context) : base(context)
    {
    }

    public IEnumerable<SelectListItem> GetAllForDropDown()
    {
        return All().Select(x => new SelectListItem
        {
            Text = x.TypeShortName,
            Value = x.Id.ToString()
        });
    }


    public IEnumerable<SelectListItem> GetAllForDropDownTrading()
    {
        return All().Where(x => x.IsTrading == true).Select(x => new SelectListItem
        {
            Text = x.TypeShortName,
            Value = x.Id.ToString()
        });
    }

    public IEnumerable<SelectListItem> GetAllForDropDownDeliveryService()
    {
        return All().Where(x => x.IsDeliveryService == true).Select(x => new SelectListItem
        {
            Text = x.TypeShortName,
            Value = x.Id.ToString()
        });
    }
}


public class OrdersRepository : BaseRepository<OrdersModel>, IOrdersRepository
{
    public OrdersRepository(InvoiceDbContext context) : base(context)
    {
    }



    public IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true)
    {
        //return All(isComId).Where(x=>x.DueAmt - x.AccountTransaction.Sum(a => a.TransactionAmount + a.DiscountAmount) > 0).Select(x => new SelectListItem
        return All(isComId).Where(x => x.NetAmount > 0).Select(x => new SelectListItem
        {
            Text = x.OrderCode + " - " + x.CustomerModel.Name + "  " + x.CustomerName,
            Value = x.Id.ToString()
        });
    }




}

public class OrdersPaymentRepository : BaseRepository<OrdersPaymentModel>, IOrdersPaymentRepository
{
    public OrdersPaymentRepository(InvoiceDbContext context) : base(context)
    {
    }

}


public class OrdersItemRepository : BaseRepository<OrdersItemsModel>, IOrdersItemsRepository
{
    public OrdersItemRepository(InvoiceDbContext context) : base(context)
    {
    }
}

public class DyDashBoardModelRepository : BaseRepository<DyDashBoardModel>, IDyDashBoardModelRepository
{
    public DyDashBoardModelRepository(InvoiceDbContext context) : base(context)
    {
    }


}
public class DashBoardLayoutOrderRepository : BaseRepository<DashBoardLayoutOrder>, IDashBoardLayoutOrderRepository
{
    public DashBoardLayoutOrderRepository(InvoiceDbContext context) : base(context)
    {
    }

}


public class NotificationSettingRepository : BaseRepository<NotificationSetting>, INotificationSettingRepository
{
    public NotificationSettingRepository(InvoiceDbContext context) : base(context)
    {


    }

    public IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true)
    {
        //return All(isComId).Where(x=>x.DueAmt - x.AccountTransaction.Sum(a => a.TransactionAmount + a.DiscountAmount) > 0).Select(x => new SelectListItem
        return All().Where(x => x.IsDelete == false).Select(x => new SelectListItem
        {
            Text = x.DeviceToken,
            Value = x.Id.ToString()
        });
    }
}