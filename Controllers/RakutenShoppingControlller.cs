using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Application.Model.Rakuten;
using Application.Service;
using Application.Service.Rakuten;
using Util;

namespace shopping_api.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class RakutenShoppingController : ControllerBase
    {
        IService<RakutenShoppingListRequest, Task<List<RakutenShopping>>> service 
            = new RakutenShoppingListService();
        
        [HttpGet]
        public List<RakutenShopping> GetItemList([FromQuery] string searchParam)
        {
            return service.execute(new RakutenShoppingListRequest(searchParam)).Result;
        }
    }
}