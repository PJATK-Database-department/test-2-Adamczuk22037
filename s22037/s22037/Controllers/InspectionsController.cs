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
        public async Task<IActionResult> GetInspections()
        {

            //For each inspection includes and includes
            var inspections = _dbContex.Inspections.Include(i => i.Car).Include(i => i.Mechanic)
                .Select(i => new
                {
                    InspectionId = i.IdInspection,
                    InspectionDate = i.InspectionDate,
                    Car = _dbContex.Cars.Where(c => i.IdCar == c.IdCar)
                        .Select(c => new { Name = c.Name, YearOfProduction = c.ProductionYear }).Single(),
                    Mechanic = _dbContex.Mechanics.Where(m => i.IdMechanic == m.IdMechanic)
                        .Select(m => new { Name = m.FirstName, Surname = m.LastName }).Single(),
                    ListOfServices = "ToBeImplemented",
                    Comment = i.Comment
                });
            return Ok(await inspections.ToListAsync());
        }
    }
}
