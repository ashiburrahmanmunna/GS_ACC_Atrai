
using Atrai.Model.Core.Entity;
using Atrai.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atrai.Controllers
{
    public class GalleryController : Controller
    {
        private readonly IMediaService _mediaService;
        public GalleryController(IMediaService mediaService)
        {
            _mediaService = mediaService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("getpagedmedia")]
        [Route("[controller]/[action]")]
        [HttpGet]
        public async Task<ActionResult> GetMedia(int pageIndex, int pageSize)
        {
            //var ComId = HttpContext.Session.GetInt32("ComId");
            //System.Threading.Thread.Sleep(1000);
            var query = await _mediaService.GetPagedAsync(pageIndex, pageSize);
            return Json(query);
        }

        [Route("getmediabyid/{id}")]
        [Route("[controller]/[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult> GetMediaById(string id)
        {
            var query = await _mediaService.GetByIdAsync(id);
            return Json(query);
        }


        [HttpPost]
        [Route("uploadmedia")]
        [Route("[controller]/[action]/{id}")]
        public async Task<IActionResult> UploadMedia(ICollection<IFormFile> files)
        {
            if (files.Count != 0)
            {
                foreach (var file in files)
                {
                    MediaUploadVM fileUpload = new()
                    {
                        File = file
                    };
                    await _mediaService.FileUploadAsync(fileUpload);
                }
                return Json("{success}");
            }
            return Json("{No media detected!}");
        }

        [HttpPost]
        [Route("updatemedia")]
        [Route("[controller]/[action]/{id}")]
        public async Task<ActionResult> UpdateMediaInfo(Gallery gallery)
        {
            var res = await _mediaService.UpdateAsync(gallery);
            return Json("{success:true}");
        }

        [Route("deletemedia")]
        [Route("[controller]/[action]")]
        [HttpPost]
        public async Task<ActionResult> DeleteMedia(string id)
        {
            try
            {
                var res = await _mediaService.RemoveAsync(id);
                return Json("success");
            }
            catch
            {
                return Json("failed");
            }

        }
    }
}
