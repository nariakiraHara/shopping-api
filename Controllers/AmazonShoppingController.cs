using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Application.Service;
using Application.Service.Amazon;
using Application.Model.Amazon;

namespace Application.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    // コントローラークラス
    public class AmazonShoppingController : ControllerBase
    {
        IService<AmazonShoppingListRequest, Task<AmazonShoppingList>> service
            = new AmazonShoppingListService();

        [HttpGet("list")]
        public AmazonShoppingList GetList([FromQuery] string searchParam)
        {
            return this.service.execute(new AmazonShoppingListRequest(searchParam)).Result;
        }
    }
}
