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
        IService<RakutenShoppingListRequest, List<RakutenShopping>> service 
            = new RakutenShoppingListService();
        
        [HttpGet]
        public List<RakutenShopping> GetItemList([FromQuery] string id)
        {
            return service.execute(new RakutenShoppingListRequest(id.ToInt() ?? 0));
        }
    }
}