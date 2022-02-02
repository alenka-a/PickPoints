using PickPoints.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PickPoints.Core.Services.Interfaces
{
    public interface IPostampService
    {
        Task<IEnumerable<PostampResponse>> GetActivePostamps();
        Task<PostampResponse> GetPostamp(string number);
    }
}