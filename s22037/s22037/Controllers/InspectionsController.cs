using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using s22037.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace s22037.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InspectionsController : ControllerBase
    {
        private readonly PjatkDbContext _dbContex;

        public InspectionsController(PjatkDbContext dbContext)
        {
            _dbContex = dbContext;
        }
        
        //Make this async, a requirement.

        [HttpGet]
        public IActionResult GetInspections()
        {
            //For each inspection includes and includes
            var inspections = _dbContex.Inspections.Include(i => i.Car).Include(i => i.Mechanic)
                .Select(i => new
                {
                    InspectionId = i.IdInspection,
                    InspectionDate = i.InspectionDate,
                    Car = i.Car,
                    Mechanic = i.Mechanic,
                    Comment = i.Comment
                });
            return Ok(inspections.ToList());
        }
    }
}
