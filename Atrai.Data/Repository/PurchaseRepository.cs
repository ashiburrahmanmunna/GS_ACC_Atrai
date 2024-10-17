using Atrai.Model.Core.Entity;
using Atrai.Data.Interfaces;
using Atrai.Data.Context.AppDataContext;
using Atrai.Data.Repository.Base;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Atrai.Data.Repository
{
    public class PaymentMethodRepository : BaseRepository<PaymentMethodModel>, IPaymentMethodRepository
    {
        public PaymentMethodRepository(InvoiceDbContext context) : base(context)
        {
        }


    }
    public class PurchaseRepository : BaseRepository<PurchaseModel>, IPurchaseRepository
    {
        public PurchaseRepository(InvoiceDbContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true)
        {

            //return All(isComId).Where(x => x.Status == "Due").Select(x => new SelectListItem
            //return All(isComId).Where(x => x.DueAmt - x.AccountTransaction.Where(x=>x.isSystem == false && x.isPost == true).Sum(a => a.TransactionAmount + a.DiscountAmount) > 0).Select(x => new SelectListItem
            //{
            //    Text = x.PurchaseCode + " - " + x.SupplierModel.SupplierName + " - " + x.SupplierName,
            //    Value = x.Id.ToString()
            //});


            //return All(isComId).Where(x => x.NetAmount - (x.PurchasePayments.Sum(x => x.Amount) + x.AccountTransaction.Where(x => x.isSystem == false).Sum(a => a.TransactionAmount + a.DiscountAmount)) > 0).Select(x => new SelectListItem


            return All(isComId).Where(x => x.NetAmount - (x.PurchasePayments.Sum(x => x.Amount)) > 0).Select(x => new SelectListItem
            {
                Text = x.PurchaseCode + " - " + x.SupplierModel.SupplierName + "  " + x.SupplierName + "  -   Bill : " + x.NetAmount + "    Due : " + (x.NetAmount - (x.PurchasePayments.Sum(x => x.Amount))),
                Value = x.Id.ToString()
            });

            //&& x.isPost == true



        }

        public IEnumerable<PurchaseModel> GetAllPurchase()
        {
            return AllData();
        }

        public IEnumerable<SelectListItem> GetAllForDropDownForSupplier(bool isComId = true,int SupplierId = 0)
        {


            return All(isComId).Where(x => x.NetAmount - (x.PurchasePayments.Sum(x => x.Amount)) > 0 && x.SupplierId == SupplierId).Select(x => new SelectListItem
            {
                Text = x.PurchaseCode + " - " + x.SupplierModel.SupplierName + "  " + x.SupplierName + "  -   Bill : " + x.NetAmount + "    Due : " + (x.NetAmount - (x.PurchasePayments.Sum(x => x.Amount))),
                Value = x.Id.ToString()
            });

            //&& x.isPost == true



        }

    }



    public class PurchaseItemsRepository : BaseRepository<PurchaseItemsModel>, IPurchaseItemsRepository
    {
        public PurchaseItemsRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<PurchaseItemsModel> GetAllPurchase()
        {
            return AllData();
        }
    }


    public class PurchaseProductTaxRepository : BaseRepository<PurchaseProductTaxModel>, IPurchaseProductTaxRepository
    {
        public PurchaseProductTaxRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<PurchaseProductTaxModel> GetAllPurchase()
        {
            return AllData();
        }
    }


    public class PurchaseItemsCategoryRepository : BaseRepository<PurchaseItemsCategoryModel>, IPurchaseItemsCategoryRepository
    {
        public PurchaseItemsCategoryRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<PurchaseItemsCategoryModel> GetAllPurchase()
        {
            return AllData();
        }
    }

    public class PurchasePaymentRepository : BaseRepository<PurchasePaymentModel>, IPurchasePaymentRepository
    {
        public PurchasePaymentRepository(InvoiceDbContext context) : base(context)
        {
        }

    }



    //newly added
    public class BudgetMainRepository : BaseRepository<Acc_BudgetMainModel>, IBudgetMainRepository
    {
        public BudgetMainRepository(InvoiceDbContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetAllForDropDown()
        {

            return All().Select(x => new SelectListItem
            {
                Text = x.Name + " - " + x.Acc_FiscalYears.FYName,
                Value = x.Id.ToString()
            });
        }

        public IEnumerable<Acc_BudgetMainModel> GetAllBudget()
        {
            return AllData();
        }

    }
    public class BudgetSubRepository : BaseRepository<BudgetSubModel>, IBudgetSubRepository
    {
        public BudgetSubRepository(InvoiceDbContext context) : base(context)
        {
        }

        public IEnumerable<BudgetSubModel> GetAllBudget()
        {
            return AllData();
        }

    }


    public class ColorsChildRepository : BaseRepository<ColorsChildModel>, IColorsChildRepository
    {
        public ColorsChildRepository(InvoiceDbContext context) : base(context)
        {
        }

        //public IEnumerable<SelectListItem> GetAllForDropDown()
        //{

        //    return All().Select(x => new SelectListItem
        //    {
        //        Text = x.ColorName,
        //        Value = x.Id.ToString()
        //    });
        //}

        public IEnumerable<ColorsChildModel> GetAllData()
        {
            return AllData();
        }

        public IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true)
        {


            return All(isComId).Select(x => new SelectListItem
            {
                Text = x.ColorId.ToString(),
                Value = x.Id.ToString()
            });

            //&& x.isPost == true



        }
    }

    public class PurchaseTermsRepository : BaseRepository<PurchaseTermsModel>, IPurchaseTermsRepository
    {
        public PurchaseTermsRepository(InvoiceDbContext context) : base(context)
        {
        }


        public IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true)
        {
            return All(isComId).Select(x => new SelectListItem
            {
                Text = x.TermsName.ToString(),
                Value = x.Id.ToString()
            });

        }
    }


    public class ColorsRepository : BaseRepository<ColorsModel>, IColorsRepository
    {
        public ColorsRepository(InvoiceDbContext context) : base(context)
        {
        }

        //public IEnumerable<SelectListItem> GetAllForDropDown()
        //{

        //    return All().Select(x => new SelectListItem
        //    {
        //        Text = x.ColorName,
        //        Value = x.Id.ToString()
        //    });
        //}

        public IEnumerable<ColorsModel> GetAllData()
        {
            return AllData();
        }

        public IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true)
        {


            return All(isComId).Select(x => new SelectListItem
            {
                Text = x.ColorName,
                Value = x.Id.ToString()
            });

            //&& x.isPost == true



        }
    }



    public class SizesRepository : BaseRepository<SizesModel>, ISizesRepository
    {
        public SizesRepository(InvoiceDbContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true)
        {


            return All(isComId).Select(x => new SelectListItem
            {
                Text = x.SizeName,
                Value = x.Id.ToString()
            });

            //&& x.isPost == true



        }
    }
    public class BomCategoryRepository : BaseRepository<BOMAllocationCategoryModel>, IBomCategoryRepository
    {
        public BomCategoryRepository(InvoiceDbContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true)
        {


            return All(isComId).Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });

            //&& x.isPost == true



        }
    }








    public class StyleRepository : BaseRepository<StyleModel>, IStyleRepository
    {
        public StyleRepository(InvoiceDbContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true)
        {


            return All(isComId).Select(x => new SelectListItem
            {
                Text = x.StyleNo,
                Value = x.Id.ToString()
            });

            //&& x.isPost == true



        }

        public IEnumerable<StyleModel> GetAllStyle()
        {
            return AllData();
        }

        public IEnumerable<SelectListItem> GetAllForDropDownForSupplier(bool isComId = true, int SupplierId = 0)
        {


            return All(isComId).Select(x => new SelectListItem
            {
                Text = x.StyleNo,
                Value = x.Id.ToString()
            });

            //&& x.isPost == true



        }

    }


    public class ColorChildRepository : BaseRepository<ColorsChildModel>, IColorChildRepository
    {
        public ColorChildRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<ColorsChildModel> GetAllColors()
        {
            return AllData();
        }
    }
    public class SizeChildRepository : BaseRepository<SizesChildModel>, ISizeChildRepository
    {
        public SizeChildRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SizesChildModel> GetAllSizes()
        {
            return AllData();
        }
    }











    public class MasterPORepository : BaseRepository<MasterPOModel>, IMasterPORepository
    {
        public MasterPORepository(InvoiceDbContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true)
        {


            return All(isComId).Select(x => new SelectListItem
            {
                Text = x.MasterPONo,
                Value = x.Id.ToString()
            });

            //&& x.isPost == true



        }

        public IEnumerable<MasterPOModel> GetAllStyle()
        {
            return AllData();
        }

        public IEnumerable<SelectListItem> GetAllForDropDownForSupplier(bool isComId = true, int SupplierId = 0)
        {


            return All(isComId).Select(x => new SelectListItem
            {
                Text = x.MasterPONo,
                Value = x.Id.ToString()
            });

            //&& x.isPost == true



        }

    }


    public class MasterPODetailsRepository : BaseRepository<MasterPODetailsModel>, IMasterPODetailsRepository
    {
        public MasterPODetailsRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<MasterPODetailsModel> GetAllColors()
        {
            return AllData();
        }
    }

}
