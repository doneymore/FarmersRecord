using FarmersRecord.FarmersRepository.IFarmer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmersRecord.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JoinTablesController : ControllerBase
    {
        private readonly ITableJoin _tableJoin;

        public JoinTablesController(ITableJoin tableJoin)
        {
            this._tableJoin = tableJoin;
        }
        [HttpGet]
        public IActionResult GetAllDbRec()
        {
            var resp = _tableJoin.GetAllDbContent().ToList();
            return Ok(resp);

        }
        
        [HttpGet, Route("GetDashBoardItem")]
        public async Task<IActionResult>  GetDashBoardItems()
        {
          var resp =   await _tableJoin.GetDashBoardItems();
            return Ok(resp);
            
        }

        

    }
}
