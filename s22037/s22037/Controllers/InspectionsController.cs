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

        [HttpGet]
        public async Task<IActionResult> GetInspections()
        {
            var inspections = _dbContex.Inspections.Include(i => i.Car).Include(i => i.Mechanic)
                .Select(i => new
                {
                    InspectionId = i.IdInspection,
                    InspectionDate = i.InspectionDate,
                    Car = _dbContex.Cars.Where(c => i.IdCar == c.IdCar)
                        .Select(c => new { Name = c.Name, YearOfProduction = c.ProductionYear }).Single(),
                    Mechanic = _dbContex.Mechanics.Where(m => i.IdMechanic == m.IdMechanic)
                        .Select(m => new { Name = m.FirstName, Surname = m.LastName }).Single(),
                    ListOfServices = _dbContex.ServiceTypeDict_Inspections.Where(sti => sti.IdInspection == i.IdInspection)
                        .Include(sti => sti.ServiceType)
                        .Select(sti => sti.ServiceType.ServiceType ).ToList(),
                    Comment = i.Comment
                });
            return Ok(await inspections.ToListAsync());
        }

        //The second part may be in inspection too - not the best way but idk what else. The association between services and cars is literally inspection.
    }
}
