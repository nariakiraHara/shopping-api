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

namespace Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RakutenShoppingController : ControllerBase
    {
        IService<RakutenShoppingListRequest, Task<RakutenShoppingList>> service 
            = new RakutenShoppingListService();
        
        [HttpGet("list")]
        public RakutenShoppingList GetItemList([FromQuery] string searchParam)
        {
            return service.execute(new RakutenShoppingListRequest(searchParam.Replace(",", "+"))).Result;
        }
    }
}