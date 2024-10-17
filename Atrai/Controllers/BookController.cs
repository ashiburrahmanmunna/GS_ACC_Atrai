using Atrai.Data.Context.AppDataContext;
using Atrai.Data.Interfaces;
using Atrai.Model.Core.Entity;
using Atrai.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Atrai.Controllers
{
    [Authorize]
    [OverridableAuthorize]
    public class BookController : Controller
    {
        public TransactionLogRepository tranlog { get; }

        private readonly IBookRepository _bookRepository = null;
        private readonly IWebHostEnvironment _webHostEnvironment;


        private readonly IConfiguration configuration;
        private readonly InvoiceDbContext db;

        public BookController(InvoiceDbContext context, IBookRepository bookRepository, IConfiguration configuration,
        TransactionLogRepository tranlogRepository, IWebHostEnvironment webHostEnvironment)
        {
            tranlog = tranlogRepository;
            _bookRepository = bookRepository;
            _webHostEnvironment = webHostEnvironment;
            this.configuration = configuration;
            db = context;
        }









        [Route("Book/all-books")]
        public ViewResult GetAllBooks()
        {
            var data = _bookRepository.All();

            return View(data);
        }

        [Route("book-details/{id:int:min(1)}", Name = "bookDetailsRoute")]
        public ViewResult GetBook(int id)
        {
            var data = _bookRepository.All().Include(x => x.Gallery).Where(x => x.Id == id).FirstOrDefault();

            if (data != null)
            {
                return View(data);
            }
            else
            {
                data = new BookModel();
                return View(data);
            }
            return View();
        }



        [Authorize]
        public ViewResult AddNewBook(bool isSuccess = false, int bookId = 0)
        {
            var model = new BookModel();

            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View(model);
        }


        //[Authorize]
        //public ViewResult AddNewBook(bool isSuccess = false, int bookId = 0)
        //{
        //    var model = new BookModel();

        //    ViewBag.IsSuccess = isSuccess;
        //    ViewBag.BookId = bookId;
        //    return View(model);
        //}



        private JObject FormCollectionToJson(BookModel bookModel, IFormCollection obj)
        {
            dynamic json = new JObject();
            if (obj.Keys.Any())
            {
                foreach (string key in obj.Keys)
                {   //check if the value is an array                 
                    if (obj[key].Count > 1)
                    {
                        JArray array = new JArray();
                        for (int i = 0; i < obj[key].Count; i++)
                        {
                            array.Add(obj[key][i]);
                        }
                        json.Add(key, array);
                    }
                    else
                    {
                        var value = obj[key][0];
                        json.Add(key, value);
                    }
                }
            }
            return json;
        }


        [HttpPost]
        public async Task<IActionResult> AddNewBook([FromForm] BookModel bookModel, IFormCollection obj)
        {



            try
            //if (ModelState.IsValid)
            {


                //ImageFormat format;
                //switch (imageToConvert.MimeType())
                //{
                //    case "image/png":
                //        format = ImageFormat.Png;
                //        break;
                //    case "image/gif":
                //        format = ImageFormat.Gif;
                //        break;
                //    default:
                //        format = ImageFormat.Jpeg;
                //        break;
                //}



                //var item = FormCollectionToJson(obj);

                bookModel.Gallery = new List<GalleryModel>();

                var abcdef = obj.Where(x => x.Key.Contains("bookModel[GalleryFiles]")).ToList();

                for (int i = 0; i < abcdef.Count / 8; i++)
                {
                    string folderPath = "books/gallery/";


                    var filename = abcdef.Where(x => x.Key == "bookModel[GalleryFiles][" + i + "][FileName]").FirstOrDefault().Value;
                    var filestream = abcdef.Where(x => x.Key == "bookModel[GalleryFiles][" + i + "][Content]").FirstOrDefault().Value;

                    //var outputStream = new MemoryStream(Convert.FromBase64String(filestream));
                    //FormFile emp = new FormFile();
                    //emp.EmployeeId = int.Parse(form["EmployeeId"]);
                    var urllink = Guid.NewGuid().ToString() + "_" + filename;
                    var gallery = new GalleryModel()
                    {
                        Name = filename,
                        URL = folderPath + "" + urllink  //SaveFileOnDisk(outputStream, filename)
                    };



                    string wwwRootPath = _webHostEnvironment.WebRootPath;
                    string path = Path.Combine(wwwRootPath + "/" + gallery.URL);
                    System.Drawing.Image img;

                    byte[] bitmapData = Convert.FromBase64String(filestream);

                    using (var streamBitmap = new MemoryStream(bitmapData))
                    {
                        using (img = Image.FromStream(streamBitmap))
                        {
                            img.Save(path);
                        }
                    }


                    //var abc = Base64ToImage(filestream);
                    //abc.Save("~/"+gallery.URL, ImageFormat.Jpeg);



                    bookModel.Gallery.Add(gallery);


                }


                //var model = IFormFile(imagelist);

                //foreach (var key in obj.Keys)
                //{
                //    //var value = oCollection[key];

                //    if (key == "bookModel[GalleryFiles][0][FileName]")
                //    {
                //        var value = obj[key];


                //    }


                //}







                //if (bookModel.GalleryFiles != null)
                //{
                //    string folder = "books/gallery/";

                //    bookModel.Gallery = new List<GalleryModel>();

                //    foreach (var file in bookModel.GalleryFiles)
                //    {
                //        var gallery = new GalleryModel()
                //        {
                //            Name = file.FileName,
                //            URL = await UploadImage(folder, file)
                //        };
                //        bookModel.Gallery.Add(gallery);
                //    }
                //}




                //if (bookModel.CoverPhoto != null)
                //{
                //    string folder = "books/cover/";
                //    bookModel.CoverImageUrl = await UploadImage(folder, bookModel.CoverPhoto);
                //}

                //if (bookModel.GalleryFiles != null)
                //{
                //    string folder = "books/gallery/";

                //    bookModel.Gallery = new List<GalleryModel>();

                //    foreach (var file in bookModel.GalleryFiles)
                //    {
                //        var gallery = new GalleryModel()
                //        {
                //            Name = file.FileName,
                //            URL = await UploadImage(folder, file)
                //        };
                //        bookModel.Gallery.Add(gallery);
                //    }
                //}

                //if (bookModel.BookPdf != null)
                //{
                //    string folder = "books/pdf/";
                //    bookModel.BookPdfUrl = await UploadImage(folder, bookModel.BookPdf);
                //}

                int id = _bookRepository.InsertInt(bookModel);
                if (id > 0)
                {

                    //return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
                    return Json(new { Success = 1, Id = id, error = false, message = "Sales updated successfully" });
                }
                else
                {
                    return Json(new { Success = 1, Id = id, error = true, message = "Something wrong." });
                }
            }
            catch (Exception ex)
            {

                //throw ex;
                return Json(new { Success = 1, error = true, message = ex.Message });
            }

            //return View();
        }

        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {

            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }

        public Image Base64ToImage(string base64String)
        {
            // Convert base 64 string to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            // Convert byte[] to Image
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                return image;
            }
        }


    }
}