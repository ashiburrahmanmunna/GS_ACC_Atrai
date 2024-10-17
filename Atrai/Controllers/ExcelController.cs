using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Atrai.Controllers
{
    public class ExcelController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }


        //public IActionResult Index()
        //{
        //   //List<string> column = new List<string>();
        //   // column.Add("AccId");
        //   // column.Add("AccName");
        //   // column.Add("OP_Balance");
        //   // column.Add("OP_Date");
        //   // column.Add("Type");
        //   // column.Add("Sl_No");
        //   // return View(column);

        //}

        [AllowAnonymous]
        public JsonResult GetDataMappingList()
        {
            try
            {
                // var voucherquery = _accVoucherRepository.All().Where(x => x.Id == VoucherId);



                //if (voucherdata == null)
                //{
                //    return Json("No Data Found");
                //}


                // var voucher = voucherquery.Select(p => new
                //{
                //    p.Id,
                //    p.VoucherSerialId,
                //    p.VoucherNo,

                //}).FirstOrDefault();

                var datamappinglist = new List<DataMappingModel>();

                //DataMappingModel a = new DataMappingModel 
                //{
                //    AtraiColumn = "AccName",
                //    ExcelColumn = ""
                //};
                datamappinglist.Add(new DataMappingModel { AtraiColumn = "AccName", ExcelColumn = "" });
                datamappinglist.Add(new DataMappingModel { AtraiColumn = "AccId", ExcelColumn = "" });
                datamappinglist.Add(new DataMappingModel { AtraiColumn = "OP_Date", ExcelColumn = "" });
                datamappinglist.Add(new DataMappingModel { AtraiColumn = "OP_Balance", ExcelColumn = "" });
                datamappinglist.Add(new DataMappingModel { AtraiColumn = "Type", ExcelColumn = "" });



                //voucher.Items.Add(a);
                return Json(datamappinglist);
                //return Json(new { Success = 1, error = false, VoucherList = abcd, PageInfo = pageinfo });

            }
            catch (Exception e)
            {
                return Json(e.ToString());
            }

        }


        public class DataMappingModel
        {
            [Required]

            public string? AtraiColumn { get; set; }
            [Required]

            public string? ExcelColumn { get; set; }

        }
    }
}
