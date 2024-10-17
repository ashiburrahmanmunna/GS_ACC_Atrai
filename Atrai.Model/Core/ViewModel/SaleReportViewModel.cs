using Atrai.Model.Core.Entity;
using System;
using System.Collections.Generic;

namespace Atrai.Model.Core.ViewModel
{
    public class SaleReportViewModel
    {
        public StoreSettingModel company { get; set; }
        public SalesModel Sales { get; set; }
    }

    public class VGMReportViewModel
    {
        public StoreSettingModel company { get; set; }
        public VGMModel VGMdata { get; set; }
    }

    public class SalesTaxAgency
    {
        public List<SalesTaxModel> salesTax { get; set; }
        public List<AgencyModel> Agency { get; set; }
    }

    public class InvoiceReportViewModel
    {
        public int Id { get; set; }
    public DateTime SaleDate { get; set; }
    public string? TransactionType { get; set; }
    public string? InvoiceNumber { get; set; }
    public string? CustomerName { get; set; }
    public string? Location { get; set; }
    public string? Memo { get; set; }
    public DateTime DueDate { get; set; }
    public decimal Amount { get; set; }
    public decimal OpenBalance { get; set; }

    }
}




