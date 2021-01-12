using Microsoft.AspNetCore.Mvc;
using Microsoft.Docs.Samples;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace areioredis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AreioredisController : ControllerBase
    {
        [HttpGet]   // GET /api/test2
        public int Get()
        {
            return 12;
        }

        [HttpGet("{id}")]   // GET /api/test2/xyz
        public int GetId(int id)
        {
            return id;
        }

    }
}
