using Atrai.Model.Core.Entity;
using Atrai.Data.Interfaces;
using Atrai.Data.Context.AppDataContext;
using Atrai.Data.Repository.Base;
using Atrai.Data.Repository.Self;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Atrai.Data.Repository
{
    public class CompanyRepository : SelfRepository<CompanyModel>, ICompanyRepository
    {
        
        public CompanyRepository(InvoiceDbContext context) : base(context)
        {
          
        }

        public string? GetComName(int id)
        {
            return Find(id).CompanyName;
        }


        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Where(x => x.Id > 0).Select(x => new SelectListItem
            {
                Text = x.CompanyName,
                Value = x.Id.ToString()
            });
        }

        public IEnumerable<SelectListItem> GetActiveForDropDown()
        {
            return All().Where(x => x.Id > 0 && x.IsInActive == false).Select(x => new SelectListItem
            {
                Text = x.CompanyName,
                Value = x.Id.ToString()
            });
        }

        public IEnumerable<SelectListItem> GetAllForDropDownSuperAdmin()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.CompanyName,
                Value = x.Id.ToString()
            });
        }


    }

    public class CompanyPermissionRepository : SelfRepository<CompanyPermissionModel>, ICompanyPermissionRepository
    {
        public CompanyPermissionRepository(InvoiceDbContext context) : base(context)
        {

        }

        public IEnumerable<SelectListItem> GetActiveForDropDown()
        {
            return All().Where(x => x.Id > 0 && x.isChecked == true).Select(x => new SelectListItem
            {
                Text = x.CompanyList.CompanyName,
                Value = x.Id.ToString()
            });
        }

        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Where(x => x.Id > 0).Select(x => new SelectListItem
            {
                Text = x.CompanyList.CompanyName,
                Value = x.CompanyList.Id.ToString()
            });
        }

        public IEnumerable<SelectListItem> GetActivePermitUserDropDown(int ComId)
        {
            //var ComId = httpcon httpcontext.Session.GetInt32("ComId");

            return All().Where(x => x.Id > 0 && x.ComId == ComId).Select(x => new SelectListItem
            {
                Text = x.UserList.Name + " - " + x.UserList.Email,
                Value = x.UserList.Id.ToString()
            });
        }

        



    }
    public class CompanyCurrencyRepository : BaseRepository<CompanyCurrencyModel>, ICompanyCurrencyRepository
    {
        public CompanyCurrencyRepository(InvoiceDbContext context) : base(context)
        {
        }
    }
    public class CustomFormStyleRepository : BaseRepository<CustomFormStyleModel>, ICustomFormStyleRepository
    {
        public CustomFormStyleRepository(InvoiceDbContext context) : base(context)
        {
        }
    }
    public class StoreSettingRepository : BaseRepository<StoreSettingModel>, IStoreSettingRepository
    {
        public StoreSettingRepository(InvoiceDbContext context) : base(context)
        {
        }
    }


    public class SoftwarePackageRepository : SelfRepository<SoftwarePackageModel>, ISoftwarePackageRepository
    {
        public SoftwarePackageRepository(InvoiceDbContext context) : base(context)
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

    public class PackageActivationRepository : BaseRepository<PackageActivationModel>, IPackageActivationRepository
    {
        public PackageActivationRepository(InvoiceDbContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.InvoiceNo + " " + x.Amount + " " + x.Remarks,
                Value = x.Id.ToString()
            });
        }
    }


    public class AccountsReportRepository : SelfRepository<AccountsReportModel>, IAccountsReportRepository
    {
        public AccountsReportRepository(InvoiceDbContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Where(x => x.Id > 0).Select(x => new SelectListItem
            {
                Text = x.Tab,
                Value = x.Id.ToString()
            });
        }

        public IEnumerable<SelectListItem> GetActiveForDropDown()
        {
            return All().Where(x => x.Id > 0 && x.IsFavorite == false).Select(x => new SelectListItem
            {
                Text = x.Tab,
                Value = x.Id.ToString()
            });
        }

        public IEnumerable<SelectListItem> GetAllForDropDownSuperAdmin()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.Tab,
                Value = x.Id.ToString()
            });
        }

    }

    public class BusinessTypeRepository : SelfRepository<BusinessTypeModel>, IBusinessTypeRepository
    {
        public BusinessTypeRepository(InvoiceDbContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Where(x => x.Id > 0).Select(x => new SelectListItem
            {
                Text = x.BusinessTypeName,
                Value = x.Id.ToString()
            });
        }

        public IEnumerable<SelectListItem> GetActiveForDropDown()
        {
            return All().Where(x => x.Id > 0 && x.IsInActive == false).Select(x => new SelectListItem
            {
                Text = x.BusinessTypeName,
                Value = x.Id.ToString()
            });
        }

        public IEnumerable<SelectListItem> GetAllForDropDownSuperAdmin()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.BusinessTypeName,
                Value = x.Id.ToString()
            });
        }

    }
    public class TaxFormRepository : SelfRepository<TaxFormModel>, ITaxFormRepository
    {
        public TaxFormRepository(InvoiceDbContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Where(x => x.Id > 0).Select(x => new SelectListItem
            {
                Text = x.TaxFormName,
                Value = x.Id.ToString()
            });
        }

        public IEnumerable<SelectListItem> GetActiveForDropDown()
        {
            return All().Where(x => x.Id > 0 && x.IsInActive == false).Select(x => new SelectListItem
            {
                Text = x.TaxFormName,
                Value = x.Id.ToString()
            });
        }

        public IEnumerable<SelectListItem> GetAllForDropDownSuperAdmin()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.TaxFormName,
                Value = x.Id.ToString()
            });
        }

    }



    public class FiscalYearTypeRepository : SelfRepository<FiscalYearTypeModel>, IFiscalYearTypeRepository
    {
        public FiscalYearTypeRepository(InvoiceDbContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Where(x => x.Id > 0).Select(x => new SelectListItem
            {
                Text = x.FYName,
                Value = x.Id.ToString()
            });
        }



    }
    public class ReportStyleVariableRepository : SelfRepository<CustomFormStyleVariableModel>, IReportStyleVariableRepository
    {
        public ReportStyleVariableRepository(InvoiceDbContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetAllVariableForTemplate()
        {
            return All().Where(x => x.Id > 0 && x.VariableFor == "Template").Select(x => new SelectListItem
            {
                Text = x.VariableName,
                Value = x.Id.ToString()
            });
        }
        public IEnumerable<SelectListItem> GetAllVariableForColor()
        {
            return All().Where(x => x.Id > 0 && x.VariableFor == "Color").Select(x => new SelectListItem
            {
                Text = x.VariableName,
                Value = x.Id.ToString()
            });
        }
        public IEnumerable<SelectListItem> GetAllVariableForLogoSize()
        {
            return All().Where(x => x.Id > 0 && x.VariableFor == "LogoSize").Select(x => new SelectListItem
            {
                Text = x.VariableName,
                Value = x.Id.ToString()
            });
        }
        public IEnumerable<SelectListItem> GetAllVariableForFontSize()
        {
            return All().Where(x => x.Id > 0 && x.VariableFor == "FontSize").Select(x => new SelectListItem
            {
                Text = x.VariableName,
                Value = x.Id.ToString()
            });
        }
        public IEnumerable<SelectListItem> GetAllVariableForLogoPlacement()
        {
            return All().Where(x => x.Id > 0 && x.VariableFor == "LogoPlacement").Select(x => new SelectListItem
            {
                Text = x.VariableName,
                Value = x.Id.ToString()
            });
        }
        public IEnumerable<SelectListItem> GetAllVariableForFontFamily()
        {
            return All().Where(x => x.Id > 0 && x.VariableFor == "FontFamily").Select(x => new SelectListItem
            {
                Text = x.VariableName,
                Value = x.Id.ToString()
            });
        }
        public IEnumerable<SelectListItem> GetAllVariableForPageMargins()
        {
            return All().Where(x => x.Id > 0 && x.VariableFor == "PageMargins").Select(x => new SelectListItem
            {
                Text = x.VariableName,
                Value = x.Id.ToString()
            });
        }
        public IEnumerable<SelectListItem> GetAllVariableForGreetingAppeal()
        {
            return All().Where(x => x.Id > 0 && x.VariableFor == "GreetingAppeal").Select(x => new SelectListItem
            {
                Text = x.VariableName,
                Value = x.Id.ToString()
            });
        }
        public IEnumerable<SelectListItem> GetAllVariableForGreetingName()
        {
            return All().Where(x => x.Id > 0 && x.VariableFor == "GreetingName").Select(x => new SelectListItem
            {
                Text = x.VariableName,
                Value = x.Id.ToString()
            });
        }


    }
    public class ReportStyleRepository : SelfRepository<ReportStyleModel>, IReportStyleRepository
    {
        public ReportStyleRepository(InvoiceDbContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetAllInvoiceReportForDropDown()
        {
            return All().Where(x => x.Id > 0 && x.ReportFor == "Invoice").Select(x => new SelectListItem
            {
                Text = x.ReportStyleName + " " + x.ReportStyleRemarks,
                Value = x.Id.ToString()
            });
        }

        public IEnumerable<SelectListItem> GetAllPurchaseReportForDropDown()
        {
            return All().Where(x => x.Id > 0 && x.ReportFor == "Purchase").Select(x => new SelectListItem
            {
                Text = x.ReportStyleName + " " + x.ReportStyleRemarks,
                Value = x.Id.ToString()
            });
        }

        public IEnumerable<SelectListItem> GetAllBarcodeReportForDropDown()
        {
            return All().Where(x => x.Id > 0 && x.ReportFor == "Barcode").Select(x => new SelectListItem
            {
                Text = x.ReportStyleName + " " + x.ReportStyleRemarks,
                Value = x.Id.ToString()
            });
        }


    }
}
