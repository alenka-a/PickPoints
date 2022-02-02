using Microsoft.AspNetCore.Mvc;
using PickPoints.Core.Services.Interfaces;
using System.Threading.Tasks;

namespace PickPoints.API.Controllers
{
    [ApiController]
    [Route("api/postamps")]
    public class PostampsController : Controller
    {
        private readonly IPostampService _postampService;

        public PostampsController(IPostampService postampService)
        {
            _postampService = postampService;
        }

        [HttpGet()]
        // TODO Добавить параметр для сортировки
        public async Task<IActionResult> GetPostamps()
        {
            var postamps = await _postampService.GetActivePostamps();
            return Ok(postamps);
        }

        [HttpGet("{number}")]
        // TODO Добавить валидацию номера по аналогии с заказом
        public async Task<IActionResult> GetPostamp(string number)
        {
            var postamp = await _postampService.GetPostamp(number);
            return Ok(postamp);
        }
    }
}
