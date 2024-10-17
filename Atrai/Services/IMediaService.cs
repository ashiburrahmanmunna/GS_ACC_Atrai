using Atrai.Model.Core.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atrai.Services
{
    public interface IMediaService
    {
        Task<IEnumerable<Gallery>> GetAsync(int? ComId);
        Task<ICollection<Gallery>> GetAsyncCollection(int? ComId);
        Task<Gallery> GetByIdAsync(string id);
        Task<IEnumerable<Gallery>> GetPagedAsync(int pageIndex, int pageSize);
        Task<Gallery> UpdateAsync(Gallery gallery);
        Task<string> RemoveAsync(string id);
        Task<string> FileUploadAsync(MediaUploadVM mediaUpload);
    }
}
