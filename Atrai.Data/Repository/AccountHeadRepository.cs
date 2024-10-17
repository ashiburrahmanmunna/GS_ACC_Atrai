using Atrai.Model.Core.Entity;
using Atrai.Data.Interfaces;
using Atrai.Data.Context.AppDataContext;
using Atrai.Data.Repository.Base;
using Atrai.Data.Repository.Self;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Atrai.Data.Repository
{

    //public class AccountHeadRepository : RecursiveRepository<AccountHeadModel>, IAccountHeadRepository
    public class AccountHeadRepository : BaseRepository<AccountHeadModel>, IAccountHeadRepository
    {
        public AccountHeadRepository(InvoiceDbContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.AccName + " - " + x.AccCode,
                Value = x.Id.ToString()
            });
        }


        public IEnumerable<SelectListItem> GetAccountGroupHeadForDropDown()
        {
            return All().Where(x => x.AccType == "G").Select(x => new SelectListItem
            {
                Text = x.AccName + " - [ " + x.AccCode + " ]",
                Value = x.Id.ToString()
            });
        }


        public IEnumerable<SelectListItem> GetAccountLedgerHeadForDropDown()
        {
            return All().Where(x => x.AccType == "L").Select(x => new SelectListItem
            {
                Text = x.AccName + " - " + x.AccCode,
                Value = x.Id.ToString()
            });
        }

        public IEnumerable<SelectListItem> GetCashBankHeadForDropDown(bool WithAccountCode = false)
        {
            if (WithAccountCode == true)
            {
                return All()
                //.Where(x => x.AccType == "L" && x.AccountCategory == "Asset" && (x.vAccountGroupHead.AccName.Contains("Cash") || x.vAccountGroupHead.AccName.Contains("Bank"))).ToList()
                .Where(x => x.AccType == "L" && ((x.AccountCategorys.AccountCategoryName.ToUpper() == "Cash".ToUpper()) || (x.AccountCategorys.AccountCategoryName.ToUpper() == "Bank".ToUpper()))).ToList()
                .Select(x => new SelectListItem
                {
                    Text = x.AccName + " - " + x.AccCode,
                    Value = x.Id.ToString()
                });
            }
            else
            {
                return All()
                //.Where(x => x.AccType == "L" && x.AccountCategory == "Asset" && (x.vAccountGroupHead.AccName.Contains("Cash") || x.vAccountGroupHead.AccName.Contains("Bank"))).ToList()
                .Where(x => x.AccType == "L" && ((x.AccountCategorys.AccountCategoryName.ToUpper() == "Cash".ToUpper()) || (x.AccountCategorys.AccountCategoryName.ToUpper() == "Bank".ToUpper()))).ToList()
                .Select(x => new SelectListItem
                {
                    Text = x.AccName,
                    Value = x.Id.ToString()
                });
            }
        }

        public IEnumerable<SelectListItem> GetInventoryShrinkageForDropDown()
        {
            return All()
            .Where(x => x.AccType == "L" && ((x.AccountCategorys.AccountCategoryName.ToUpper() == "Inventory Shrinkage".ToUpper()))).ToList()
            .Select(x => new SelectListItem
            {
                Text = x.AccName,
                Value = x.Id.ToString()
            });
        }
        public IEnumerable<SelectListItem> GetIncomeExpenseHeadForDropDown()
        {
            return All()
            //.Where(x => x.AccType == "L" && ((x.AccountCategory == "Income") || (x.AccountCategory == "Expense"))).ToList()
            .Where(x => x.AccType == "L" && ((x.AccountCategorys.AccountType.ToUpper() == "Income".ToUpper()) || (x.AccountCategorys.AccountType.ToUpper() == "Expense".ToUpper()) || (x.AccountCategorys.AccountCategoryName.ToUpper() == "Sales".ToUpper()) || (x.AccountCategorys.AccountCategoryName.ToUpper() == "Purchase".ToUpper()) || (x.AccountCategorys.AccountCategoryName.ToUpper() == "Inventory".ToUpper()))).ToList()
            .Select(x => new SelectListItem
            {
                Text = x.AccName + " - " + x.AccCode,
                Value = x.Id.ToString()
            });
        }

        public IEnumerable<SelectListItem> GetIncomeHeadForDropDown()
        {
            return All()
            //.Where(x => x.AccType == "L" && (x.AccountCategorys.AccountCategoryName == "Income")).ToList()
            .Where(x => x.AccType == "L" && (x.AccountCategorys.AccountType.ToUpper() == "Income".ToUpper()) && !(x.AccName.ToUpper().Contains("RETURN")) && !(x.AccName.ToUpper().Contains("DISCOUNT"))).ToList()

            .Select(x => new SelectListItem
            {
                Text = x.AccName + " - " + x.AccCode,
                Value = x.Id.ToString()
            });
        }

        public IEnumerable<SelectListItem> GetExpenseHeadForDropDown()
        {
            return All().Where(x => x.AccType == "L" && (x.AccountCategorys.AccountType.ToUpper() == "Expense".ToUpper()) || (x.AccountCategorys.AccountCategoryName.ToUpper() == "Purchase".ToUpper()) || (x.AccountCategorys.AccountCategoryName.ToUpper() == "Inventory".ToUpper())).ToList()
            .Select(x => new SelectListItem
            {
                Text = x.AccName + " - " + x.AccCode,
                Value = x.Id.ToString()
            });
        }
        public IEnumerable<SelectListItem> GetSalesHeadForDropDown()
        {
            return All()
            .Where(x => x.AccType == "L" && (x.AccountCategorys.AccountCategoryName.ToUpper() == "Sales".ToUpper())).ToList()
            .Select(x => new SelectListItem
            {
                Text = x.AccName + " - " + x.AccCode,
                Value = x.Id.ToString()
            });
        }

        public IEnumerable<SelectListItem> GetPurchaseHeadForDropDown()
        {
            return All().Where(x => x.AccType == "L" && ((x.AccountCategorys.AccountCategoryName.ToUpper() == "Purchase".ToUpper()) || (x.AccountCategorys.AccountCategoryName.ToUpper() == "Consumption".ToUpper()))).ToList()
            .Select(x => new SelectListItem
            {
                Text = x.AccName + " - " + x.AccCode,
                Value = x.Id.ToString()
            });
        }







        public IEnumerable<SelectListItem> GetDiscountIncomeHeadForDropDown()
        {
            return All()
            //.Where(x => x.AccType == "L" && (x.AccountCategorys.AccountCategoryName == "Income")).ToList()
            .Where(x => x.AccType == "L" && x.AccName.ToUpper().Contains("DISCOUNT INCOME")).ToList()

            .Select(x => new SelectListItem
            {
                Text = x.AccName + " - " + x.AccCode,
                Value = x.Id.ToString()
            });
        }
        public IEnumerable<SelectListItem> GetDiscountExpenseHeadForDropDown()
        {
            return All().Where(x => x.AccType == "L" && ((x.AccName.ToUpper() == "DISCOUNT EXPENSE".ToUpper()) || (x.AccName.ToUpper() == "VAT EXPENSE".ToUpper()) || (x.AccName.ToUpper() == "VAT Payable".ToUpper()) || (x.AccName.ToUpper() == "VAT Receivable".ToUpper()) || (x.AccName.ToUpper() == "AIT Payable".ToUpper()) || (x.AccName.ToUpper() == "AIT Receivable".ToUpper()) || (x.AccName.ToUpper() == "AIT EXPENSE".ToUpper()))).ToList()
            .Select(x => new SelectListItem
            {
                Text = x.AccName + " - " + x.AccCode,
                Value = x.Id.ToString()
            });
        }


        public IEnumerable<SelectListItem> GetInventoryDropdown()
        {
            return All()
            .Where(x => x.AccType == "L" && x.AccountCategorys.AccountCategoryName.ToUpper() == "Inventory".ToUpper()).ToList()
            .Select(x => new SelectListItem
            {
                Text = x.AccName + " - " + x.AccCode,
                Value = x.Id.ToString()
            });
        }

        public IEnumerable<SelectListItem> GetConsumptionDropdown()
        {
            return All()
            //.Where(x => x.AccType == "L" && x.isItemConsumed == true).ToList()
            .Where(x => x.AccType == "L" && x.AccountCategorys.AccountCategoryName.ToUpper() == "Consumption".ToUpper()).ToList()
            .Select(x => new SelectListItem
            {
                Text = x.AccName + " - " + x.AccCode,
                Value = x.Id.ToString()
            });
        }

        public IEnumerable<SelectListItem> GetDropdownCategoryWise(int? AccountCategoryId)
        {
            return All()
                .Where(x => x.AccType == "L" && x.AccountCategoryId == AccountCategoryId).ToList()
                .Select(x => new SelectListItem
                {
                    Text = x.AccName + " - " + x.AccCode,
                    Value = x.Id.ToString()
                });
        }

        public IEnumerable<SelectListItem> GetAssetLiabilityHeadForDropDown()
        {
            return All()
            //.Where(x => x.AccType == "L" && ((x.AccountCategory == "Asset") || (x.AccountCategory == "Liabilities")))
            .Where(x => x.AccType == "L" && ((x.AccountCategorys.AccountType.ToUpper() == "Asset".ToUpper()) || (x.AccountCategorys.AccountType.ToUpper() == "Liability".ToUpper()) || (x.AccountCategorys.AccountCategoryName.ToUpper() == "Cash".ToUpper()) || (x.AccountCategorys.AccountCategoryName.ToUpper() == "Bank".ToUpper())))
            .ToList().Select(x => new SelectListItem
            {
                Text = x.AccName + " - " + x.AccCode,
                Value = x.Id.ToString()
            });
        }

        public IEnumerable<SelectListItem> GetSalesDropdown()
        {
            return All()
            //.Where(x => x.AccType == "L" && ((x.AccountCategory == "Asset") || (x.AccountCategory == "Liabilities")))
            .Where(x => x.AccType == "L" && x.AccountCategorys.AccountCategoryName.ToUpper() == "Sales".ToUpper())
            .ToList().Select(x => new SelectListItem
            {
                Text = x.AccName + " - " + x.AccCode,
                Value = x.Id.ToString()
            });
        }

        public IEnumerable<SelectListItem> GetSalesVATDropdown()
        {
            return All()
            //.Where(x => x.AccType == "L" && ((x.AccountCategory == "Asset") || (x.AccountCategory == "Liabilities")))
            .Where(x => x.AccType == "L" && x.AccountCategorys.AccountCategoryName.ToUpper() == "VAT Payable".ToUpper())
            .ToList().Select(x => new SelectListItem
            {
                Text = x.AccName + " - " + x.AccCode,
                Value = x.Id.ToString()
            });
        }

        public IEnumerable<SelectListItem> GetPurchaseVATDropdown()
        {
            return All()
            //.Where(x => x.AccType == "L" && ((x.AccountCategory == "Asset") || (x.AccountCategory == "Liabilities")))
            .Where(x => x.AccType == "L" && ( x.AccountCategorys.AccountCategoryName.ToUpper() == "VAT Payable".ToUpper()))
            .ToList().Select(x => new SelectListItem
            {
                Text = x.AccName + " - " + x.AccCode,
                Value = x.Id.ToString()
            });
        }

        public IEnumerable<SelectListItem> GetExpenseVATDropdown()
        {
            return All()
            //.Where(x => x.AccType == "L" && ((x.AccountCategory == "Asset") || (x.AccountCategory == "Liabilities")))
            .Where(x => x.AccType == "L" && ((x.AccountCategorys.AccountCategoryName.ToUpper() == "VAT Expense".ToUpper()) 
            || (x.AccountCategorys.AccountCategoryName.ToUpper() == "AIT Expense".ToUpper())) || (

             x.AccountCategorys.AccountCategoryName.ToUpper() == "Tax Expense".ToUpper()
            ))
            .ToList().Select(x => new SelectListItem
            {
                Text = x.AccName + " - " + x.AccCode,
                Value = x.Id.ToString()
            });
        }

        public IEnumerable<SelectListItem> GetCashHeadForDropDown()
        {
            return All()
            //.Where(x => x.AccType == "L" && x.AccountCategory == "Asset" && (x.vAccountGroupHead.AccName.Contains("Cash") || x.vAccountGroupHead.AccName.Contains("Bank"))).ToList()
            .Where(x => x.AccType == "L" && ((x.AccountCategorys.AccountCategoryName.ToUpper() == "Cash".ToUpper()))).ToList()
            .Select(x => new SelectListItem
            {
                Text = x.AccName + " - " + x.AccCode,
                Value = x.Id.ToString()
            });
        }

        public IEnumerable<SelectListItem> GetBankHeadForDropDown()
        {
            return All()
            //.Where(x => x.AccType == "L" && x.AccountCategory == "Asset" && (x.vAccountGroupHead.AccName.Contains("Cash") || x.vAccountGroupHead.AccName.Contains("Bank"))).ToList()
            .Where(x => x.AccType == "L" && ((x.AccountCategorys.AccountCategoryName.ToUpper() == "Bank".ToUpper()))).ToList()
            .Select(x => new SelectListItem
            {
                Text = x.AccName + " - " + x.AccCode,
                Value = x.Id.ToString()
            });
        }

        public IEnumerable<SelectListItem> GetLoanAdvanceHeadForDropDown()
        {
            return All()
            //.Where(x => x.AccType == "L" && ((x.AccountCategory == "Asset") || (x.AccountCategory == "Liabilities")))
            //.Where(x => x.AccName.Contains("Sales Receivable") && x.AccType == "L")
            .Where((x => x.AccName.Contains("Loan To Employee") || x.AccName.Contains("Advance To Employee") && x.AccType == "L"))
            .ToList().Select(x => new SelectListItem
            {
                Text = x.AccName + " - " + x.AccCode,
                Value = x.Id.ToString()
            });
        }


        public IEnumerable<SelectListItem> GetDebitHeadForDropDown()
        {
            return All()
            //.Where(x => x.AccType == "L" && ((x.AccountCategory == "Asset") || (x.AccountCategory == "Liabilities")))
            .Where(x => x.AccType == "L" && ((x.AccountCategorys.AccountType.ToUpper() == "Asset".ToUpper()) || (x.AccountCategorys.AccountType.ToUpper() == "Expense".ToUpper())))
            .ToList().Select(x => new SelectListItem
            {
                Text = x.AccName + " - " + x.AccCode,
                Value = x.Id.ToString()
            });
        }
        public IEnumerable<SelectListItem> GetCreditHeadForDropDown()
        {
            return All()
            //.Where(x => x.AccType == "L" && ((x.AccountCategory == "Asset") || (x.AccountCategory == "Liabilities")))
            .Where(x => x.AccType == "L" && ((x.AccountCategorys.AccountType.ToUpper() == "Liability".ToUpper()) || (x.AccountCategorys.AccountType.ToUpper() == "Income".ToUpper())))
            .ToList().Select(x => new SelectListItem
            {
                Text = x.AccName + " - " + x.AccCode,
                Value = x.Id.ToString()
            });
        }

        public IEnumerable<SelectListItem> GetAssetHeadForDropDown()
        {
            return All()
            //.Where(x => x.AccType == "L" && ((x.AccountCategory == "Asset") || (x.AccountCategory == "Liabilities")))
            .Where(x => x.AccType == "L" && ((x.AccountCategorys.AccountType.ToUpper() == "Asset".ToUpper())))
            .ToList().Select(x => new SelectListItem
            {
                Text = x.AccName + " - " + x.AccCode,
                Value = x.Id.ToString()
            });
        }


        public IEnumerable<SelectListItem> GetSupplierPayableHeadForDropDown()
        {
            return All()
            //.Where(x => x.AccType == "L" && ((x.AccountCategory == "Asset") || (x.AccountCategory == "Liabilities")))
            .Where(x => x.AccType == "L" && ((x.AccountCategorys.AccountCategoryName.ToUpper() == "Supplier Payable".ToUpper()) || (x.AccountCategorys.AccountCategoryName.ToUpper() == "Accounts Payable".ToUpper())))//
            .ToList().Select(x => new SelectListItem
            {
                Text = x.AccName + " - " + x.AccCode,
                Value = x.Id.ToString()
            });
        }



        public IEnumerable<SelectListItem> GetCustomerReceivableHeadForDropDown()
        {
            return All()
            //.Where(x => x.AccType == "L" && ((x.AccountCategory == "Asset") || (x.AccountCategory == "Liabilities")))
            .Where(x => x.AccType == "L" && ((x.AccountCategorys.AccountCategoryName.ToUpper() == "Customer Receivable".ToUpper()) || (x.AccountCategorys.AccountCategoryName.ToUpper() == "Accounts Receivable".ToUpper())))//
            .ToList().Select(x => new SelectListItem
            {
                Text = x.AccName + " - " + x.AccCode,
                Value = x.Id.ToString()
            });
        }


    }

    public class AccountHeadSystemRepository : SelfRepository<AccountHeadSystemModel>, IAccountHeadSystemRepository
    {
        public AccountHeadSystemRepository(InvoiceDbContext context) : base(context)
        {
        }


        public IEnumerable<SelectListItem> GetAccountGroupHeadForDropDown()
        {
            return All().Where(x => x.AccType == "G").Select(x => new SelectListItem
            {
                Text = x.AccName + " - [ " + x.AccCode + " ]",
                Value = x.Id.ToString()
            });
        }

    }


    public class AccVoucherMainRepository : BaseRepository<Acc_VoucherMainModel>, IAccVoucherMainRepository
    {
        public AccVoucherMainRepository(InvoiceDbContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.VoucherNo,
                Value = x.Id.ToString()
            });
        }

    }

    public class DailyCurrencyRateRepository : BaseRepository<DailyCurrencyRate>, IDailyCurrencyRateRepository
    {
        public DailyCurrencyRateRepository(InvoiceDbContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.tranDate.ToString(),
                Value = x.Id.ToString()
            });
        }

    }

    public class AccVoucherSubRepository : BaseRepository<Acc_VoucherSubModel>, IAccVoucherSubRepository
    {
        public AccVoucherSubRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.Note1,
                Value = x.Id.ToString()
            });
        }
    }

    public class AccVoucherSubCheckNoRepository : BaseRepository<Acc_VoucherSubChecknoModel>, IAccVoucherSubCheckNoRepository
    {
        public AccVoucherSubCheckNoRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.ChkNo,
                Value = x.Id.ToString()
            });
        }
    }
    public class AccVoucherSubSectionRepository : BaseRepository<Acc_VoucherSubSectionModel>, IAccVoucherSubSectionRepository
    {
        public AccVoucherSubSectionRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.SubSection.SubSectName,
                Value = x.Id.ToString()
            });
        }
    }
    public class AccVoucherTranGroupRepository : BaseRepository<Acc_VoucherTranGroupModel>, IAccVoucherTranGroupRepository
    {
        public AccVoucherTranGroupRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.VoucherTranGroups.VoucherTranGroupName,
                Value = x.Id.ToString()
            });
        }
    }

    public class AccVoucherTagsRepository : BaseRepository<Acc_VoucherTagsModel>, IAccVoucherTagsRepository
    {
        public AccVoucherTagsRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.tag,
                Value = x.Id.ToString()
            });
        }
    }
    public class PurchaseTagsRepository : BaseRepository<PurchaseTagModel>, IPurchaseTagsRepository
    {
        public PurchaseTagsRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.tag,
                Value = x.Id.ToString()
            });
        }
    }

    public class TransactionTagsRepository : BaseRepository<TransactionTagsModel>, ITransactionTagsRepository
    {
        public TransactionTagsRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.tag,
                Value = x.Id.ToString()
            });
        }
    }
    public class VoucherTranGroupRepository : SelfRepository<VoucherTranGroupModel>, IVoucherTranGroupRepository
    {
        public VoucherTranGroupRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.VoucherTranGroupName,
                Value = x.Id.ToString()
            });
        }
    }
    public class AllReportRepository : SelfRepository<AccountsReportModel>, IAllReportRepository
    {
        public AllReportRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.ReportName,
                Value = x.Id.ToString()
            });
        }
    }

    public class AccVoucherNoPrefixRepository : BaseRepository<Acc_VoucherNoPrefixModel>, IAccVoucherNoPrefixRepository
    {
        public AccVoucherNoPrefixRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.VoucherShortPrefix,
                Value = x.Id.ToString()
            });
        }
    }
    public class AccVoucherTypeRepository : SelfRepository<Acc_VoucherTypeModel>, IAccVoucherTypeRepository
    {
        public AccVoucherTypeRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.VoucherTypeName,
                Value = x.Id.ToString()
            });
        }
    }
    public class AccVoucherCreatedTypeRepository : SelfRepository<Acc_VoucherNoCreatedTypeModel>, IAccVoucherCreatedTypeRepository
    {
        public AccVoucherCreatedTypeRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.VoucherNoCreatedTypeName,
                Value = x.Id.ToString()
            });
        }
    }
    public class AccFiscalYearRepository : BaseRepository<Acc_FiscalYearModel>, IAccFiscalYearRepository
    {
        public AccFiscalYearRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.FYName,
                Value = x.Id.ToString()
            });
        }
    }
    public class AccFiscalMonthRepository : BaseRepository<Acc_FiscalMonthModel>, IAccFiscalMonthRepository
    {
        public AccFiscalMonthRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.MonthName,
                Value = x.Id.ToString()
            });
        }
    }
    public class AccFiscalHalfYearRepository : BaseRepository<Acc_FiscalHalfYear>, IAccFiscalHalfYearRepository
    {
        public AccFiscalHalfYearRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.HyearName,
                Value = x.Id.ToString()
            });
        }
    }
    public class AccFiscalQtrRepository : BaseRepository<Acc_FiscalQtr>, IAccFiscalQtrRepository
    {
        public AccFiscalQtrRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.QtrName,
                Value = x.Id.ToString()
            });
        }
    }
    public class PrdUnitRepository : BaseRepository<PrdUnit>, IPrdUnitRepository
    {
        public PrdUnitRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.PrdUnitName,
                Value = x.Id.ToString()
            });
        }
    }



    public class IntegrationSettingMainRepository : BaseRepository<Cat_Integration_Setting_Main>, IIntegrationSettingMainRepository
    {
        public IntegrationSettingMainRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.IntegrationSettingName,
                Value = x.Id.ToString()
            });
        }
    }



    public class IntegrationSettingDetailsRepository : BaseRepository<Cat_Integration_Setting_Details>, IIntegrationSettingDetailsRepository
    {
        public IntegrationSettingDetailsRepository(InvoiceDbContext context) : base(context)
        {
        }
    }



    public class PayrollIntegrationSummaryRepository : BaseRepository<Cat_PayrollIntegrationSummary>, IPayrollIntegrationSummaryRepository
    {
        public PayrollIntegrationSummaryRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.Note1,
                Value = x.Id.ToString()
            });
        }
    }


    public class ProcessLockRepository : BaseRepository<ProcessLock>, IProcessLockRepository
    {
        public ProcessLockRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.LockType,
                Value = x.Id.ToString()
            });
        }
    }

    public class ReportsRepository : SelfRepository<ReportModel>, IReportsRepository
    {
        public ReportsRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.ReportName,
                Value = x.Id.ToString()
            });
        }
    }

    public class ReportGrouptRepository : SelfRepository<ReportGroupModel>, IReportGrouptRepository
    {
        public ReportGrouptRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.ReportGroupName,
                Value = x.Id.ToString()
            });
        }
    }

    public class ReportUserTrackingRepository : BaseRepository<ReportUserTrackingModel>, IReportUserTrackingRepository
    {
        public ReportUserTrackingRepository(InvoiceDbContext context) : base(context)
        {
        }
        
    }
}
