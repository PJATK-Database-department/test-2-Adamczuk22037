using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using s22037.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace s22037.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly PjatkDbContext _dbContex;

        public ValuesController(PjatkDbContext dbContext)
        {
            _dbContex = dbContext;
        }
    }
}
