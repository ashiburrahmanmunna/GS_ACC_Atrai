using Atrai.Data.Context.AppDataContext;
using Atrai.Model.Core.Entity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Atrai.Services
{
    public class MediaService : IMediaService
    {
        public IHttpContextAccessor Accessor { get; set; }

        private readonly InvoiceDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _configuration;
        public MediaService(InvoiceDbContext context, IWebHostEnvironment webHostEnvironment, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
            Accessor = httpContextAccessor;
        }

        public async Task<string> FileUploadAsync(MediaUploadVM fileUpload)
        {
            try
            {
                var ComId = Accessor.HttpContext.Session.GetInt32("ComId");
                var UserId = Accessor.HttpContext.Session.GetInt32("UserId");

                string fileName = null;
                string filePath = _configuration.GetValue<string>("MediaManager:MediaPath");
                string fileId = Guid.NewGuid().ToString();
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, filePath);
                var timeNow = DateTime.Now;

                if (fileUpload.File != null)
                {
                    fileName = fileUpload.FileName ?? Guid.NewGuid().ToString();
                    fileName += Path.GetExtension(fileUpload.File.FileName).ToLower();
                    using (var fileStream = new FileStream(Path.Combine(uploadsFolder, fileName), FileMode.Create))
                    {
                        fileUpload.File.CopyTo(fileStream);
                    }
                }

                Gallery fileStore = new()
                {
                    Id = fileId,
                    Name = filePath + "/" + fileName,
                    UploadTime = timeNow,
                    ModifiedTime = timeNow,
                    ComId = ComId,
                    LuserId = UserId
                };
                await _context.Galleries.AddAsync(fileStore);
                await _context.SaveChangesAsync();

                return fileStore.Id;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Gallery>> GetAsync(int? ComId)
        {
            if (ComId != null)
            {
                var filelist = await _context.Galleries.AsNoTracking().Where(x => x.ComId == ComId).OrderByDescending(o => o.ModifiedTime).ToListAsync();
                return filelist;
            }
            else
            {
                var filelist = await _context.Galleries.AsNoTracking().OrderByDescending(o => o.ModifiedTime).ToListAsync();
                return filelist;
            }

        }


        public async Task<ICollection<Gallery>> GetAsyncCollection(int? ComId)
        {
            if (ComId != null)
            {
                var filelist = await _context.Galleries.AsNoTracking().Where(x => x.ComId == ComId).OrderByDescending(o => o.ModifiedTime).ToListAsync();
                return filelist;
            }
            else
            {
                var filelist = await _context.Galleries.AsNoTracking().OrderByDescending(o => o.ModifiedTime).ToListAsync();
                return filelist;
            }

        }


        public async Task<Gallery> GetByIdAsync(string id)
        {
            var file = await _context.Galleries.Where(o => o.Id == id).AsNoTracking().FirstOrDefaultAsync();
            return file;
        }

        public async Task<IEnumerable<Gallery>> GetPagedAsync(int pageIndex, int pageSize)
        {
            var ComId = Accessor.HttpContext.Session.GetInt32("ComId");
            if (ComId != null)
            {
                var query = await _context.Galleries.Where(x => x.ComId == ComId).OrderByDescending(o => o.ModifiedTime).Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();

                return query;
            }
            else
            {
                var query = await _context.Galleries.OrderByDescending(o => o.ModifiedTime).Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();

                return query;
            }
        }

        public async Task<string> RemoveAsync(string id)
        {
            var ComId = Accessor.HttpContext.Session.GetInt32("ComId");
            var UserId = Accessor.HttpContext.Session.GetInt32("UserId");

            var file = await _context.Galleries.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id && x.ComId == ComId);
            //string filesFolder = Path.Combine(_webHostEnvironment.WebRootPath, "gallery");
            //string filePath = Path.Combine(filesFolder.Replace("/", "\\"), file.Name);

            string filesFolder = Path.Combine(_webHostEnvironment.WebRootPath, file.Name);
            string filePath = filesFolder.Replace("/", "\\");

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            _context.Galleries.Remove(file);
            await _context.SaveChangesAsync();
            return file.Id;
        }

        public async Task<Gallery> UpdateAsync(Gallery image)
        {
            var ComId = Accessor.HttpContext.Session.GetInt32("ComId");
            var UserId = Accessor.HttpContext.Session.GetInt32("UserId");

            var file = await _context.Galleries.AsNoTracking().FirstOrDefaultAsync(x => x.Id == image.Id);
            file.Title = image.Title;
            file.Tags = image.Tags;
            file.ModifiedTime = DateTime.Now;
            file.ComId = ComId;

            _context.Galleries.Update(file);
            await _context.SaveChangesAsync();
            return file;
        }
    }
}
