using Atrai.Model.Core.Entity;
using System;
using System.Collections.Generic;

namespace Atrai.Model.Core.ViewModel
{

    public class SummaryViewModel
    {
        //public List<SalesModel> DayWiseSales { get; set; }
        public List<DayWiseSales> DayWiseSales { get; set; }
        public List<DayWiseSalesReturn> DayWiseSalesReturn { get; set; }

        public List<DayWisePurchase> DayWisePurchase { get; set; }
        public List<DayWiseTransaction> DayWiseReceived { get; set; }
        public List<DayWiseTransaction> DayWisePaid { get; set; }

        //public decimal CustomerDue { get; set; }
        //public decimal SupplierDue { get; set; }

        public List<CustomerDueSummary> CustomerWiseDue { get; set; }
        public List<SupplierDueSummary> SupplierWiseDue { get; set; }

        public List<AccountHeadModel> AccountHeadBalance { get; set; }
        public List<AccountHeadModel> AssetBalance { get; set; }
        public List<AccountHeadModel> LiabilityBalance { get; set; }


        public List<DayWiseTransaction> DayWiseIncome { get; set; }

        public List<DayWiseTransaction> DayWiseExpense { get; set; }


        public string? FromDate { get; set; }
        public string? ToDate { get; set; }

    }


    public class DayWiseSales
    {
        public string? SalesType { get; set; }
        public string? SalesDate { get; set; }
        public int SalesCount { get; set; }
        public double SalesQty { get; set; }

        public decimal TotalSalesAmount { get; set; }

        public ICollection<SalesModel> sales { get; set; }

    }

    public class DayWiseSalesReturn
    {
        public string? SalesReturnDate { get; set; }
        public int SalesReturnCount { get; set; }
        public decimal TotalSalesReturnAmount { get; set; }
        public ICollection<SalesReturnModel> salesReturn { get; set; }

    }

    public class DayWisePurchase
    {
        public string? PurchaseType { get; set; }
        public string? PurchaseDate { get; set; }
        public int PurchaseCount { get; set; }
        public double PurchaseQty { get; set; }

        public decimal TotalPurchaseAmount { get; set; }

    }
    public class DayWiseTransaction
    {
        public string? AccName { get; set; }
        public decimal TransactionAmount { get; set; }

        public decimal TransactionExpenseAmount { get; set; }


    }

    public class CustomerDueSummary
    {
        public string? CustomerName { get; set; }
        public decimal TotalSales { get; set; }
        public decimal TotalReceived { get; set; }
        public decimal TotalDue { get; set; }
        public double OpBalance { get; set; }


    }

    public class SupplierDueSummary
    {
        public string? SupplierName { get; set; }
        public decimal TotalPurchase { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal TotalDue { get; set; }

    }



    public class DashboardViewModel
    {
        public int Products { get; set; }
        public int UnderROL { get; set; }

        public decimal CustomerDue { get; set; }
        public decimal SupplierDue { get; set; }

        public decimal QuotationValue { get; set; }
        public decimal POValue { get; set; }




        public decimal CustomerLedgerDue { get; set; }
        public decimal SupplierLedgerDue { get; set; }

        public int Suppliers { get; set; }
        public int Customers { get; set; }

        public int TotalPurchase { get; set; }
        public decimal TotalPurchaseValue { get; set; }
        public decimal TotalSaleValue { get; set; }
        public int TotalSales { get; set; }

        public int TotalSaleableSerial { get; set; }
        public int TotalSerialSold { get; set; }



        public List<SalesModel> LastFiveSales { get; set; }
        public List<PurchaseModel> LastFivePurchase { get; set; }
        public List<TransactionModel> LastFiveReceive { get; set; }
        public List<TransactionModel> LastFivePayments { get; set; }


        public int Accounts { get; set; }
        public int ReceiveHead { get; set; }
        public int PaymentHead { get; set; }
        public int CashBankHead { get; set; }


        public decimal TotalReceive { get; set; }
        public decimal TotalPayment { get; set; }

        public int PrevMonthAddedProduct { get; set; }
        public int CurrMonthAddedProduct { get; set; }

        public decimal PrevMonthReceive { get; set; }
        public decimal PrevMonthPayment { get; set; }


        public decimal CurrMonthReceive { get; set; }
        public decimal CurrMonthPayment { get; set; }

        public int Post { get; set; }
        public int UnPost { get; set; }




        public int PrevMonthSalesQty { get; set; }
        public int CurrMonthSalesQty { get; set; }

        public decimal PrevMonthSalesValue { get; set; }
        public decimal CurrMonthSalesValue { get; set; }




        public int PrevMonthPurchaseQty { get; set; }
        public int CurrMonthPurchaseQty { get; set; }

        public decimal PrevMonthPurchaseValue { get; set; }
        public decimal CurrMonthPurchaseValue { get; set; }

        public decimal? StockQty { get; set; }
        public decimal? StockValue { get; set; }




    }





    public class AssociationDashboardViewModel
    {
        public int TotalMember { get; set; }
        public int TotalLifeMember { get; set; }
        public int TotalGeneralMember { get; set; }

        public int TotalMarket { get; set; }
        public int TotalShop { get; set; }


        public double TotalExpense { get; set; }
        public double TotalIncome { get; set; }

        public double TotalApplied { get; set; }
        public double TotalChecked { get; set; }
        public double TotalVerified { get; set; }
        public double TotalApproved { get; set; }
        public double TotalCanceled { get; set; }



        public List<TransactionModel> LastFiveTransaction { get; set; }
    }



    public class InternetServiceDashboardViewModel
    {
        public int TotalTerminatedUsers { get; set; }
        public decimal TotalCashReceived { get; set; }
        public decimal TotalDue { get; set; }

        public decimal TotalBkashPersonalReceived { get; set; }
        public decimal TotalBankReceived { get; set; }
        public decimal TotalBkashMerchantReceived { get; set; }

        public decimal TodaysBilledAmount { get; set; }
        public decimal TodaysReceivedAmount { get; set; }
        public decimal TotalBilledAmount { get; set; }
        public decimal TotalReceivedAmount { get; set; }
        public decimal TotalBadDebtAmount { get; set; }
        public decimal TotalDiscountAmount { get; set; }




        public decimal LastMonthDue { get; set; }
        public decimal LastMonthReceived { get; set; }
        public decimal LastMonthExpense { get; set; }



        public decimal CurrentMonthDue { get; set; }
        public decimal CurrentMonthExpense { get; set; }
        public decimal CurrentMonthReceived { get; set; }


        public List<InvoiceBillModel> LastFiveBilled { get; set; }
        public List<InvoiceBillModel> LastFiveReceived { get; set; }




        public int TotalRegisteredUser { get; set; }
        public int TotalActiveUser { get; set; }
        public int TotalInactiveUser { get; set; }
        public int TotalExpiredUser { get; set; }
        public int ExpiringInThreeDays { get; set; }
        public int TodayExpired { get; set; }



    }


    public class UrlShortenDashboardViewModel
    {
        public decimal TotalLink { get; set; }
        public int TodayClicked { get; set; }
        public int TotalClicked { get; set; }
        public int LastMontClicked { get; set; }

        public decimal CurrentMonthClicked { get; set; }

        public int ExpireDays { get; set; }
        public List<ShortLinkModel> LastFiveCreatedLink { get; set; }
        public List<ShortLinkHitModel> LastFiveClickedFrom { get; set; }

        public DateTime UserExpiredDate { get; set; }

        public int RemainingDays { get; set; }

    }
    public class CustomerDashboardViewModel
    {
        public decimal LedgerBalance { get; set; }
    }

    public class SupplierDashboardViewModel
    {
        public decimal LedgerBalance { get; set; }
    }


    public class UserAccountViewModelList
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? EmployeeName { get; set; }
        public string? RoleRemarks { get; set; }
        public double? ValidityDay { get; set; }
        public string? ActiveToDate { get; set; }
        public Boolean IsEmailVerified { get; set; }
        public Boolean IsPhoneVerified { get; set; }
        public string? LastLoginDate { get; set; }
        public string? LastTransactionDate { get; set; }
        public Boolean IsBaseUser { get; set; }

        public Boolean IsInacitve { get; set; }
    }



    public class MonthWiseCashBankBalance
    {
        public string? MonthId { get; set; }
        public string? MonthName { get; set; }
        public string? AccountCategoryName { get; set; }
        public double ClosingBalance { get; set; }

    }


    public class MonthWiseBalance
    {
        public int MonthId { get; set; }
        public string? YearName { get; set; }

        public string? AccountCategoryName { get; set; }

        public double January { get; set; }
        public double February { get; set; }
        public double March { get; set; }
        public double April { get; set; }
        public double May { get; set; }
        public double June { get; set; }
        public double July { get; set; }
        public double August { get; set; }
        public double September { get; set; }
        public double October { get; set; }
        public double November { get; set; }
        public double December { get; set; }

        //public double ClosingBalance { get; set; }

    }


}
