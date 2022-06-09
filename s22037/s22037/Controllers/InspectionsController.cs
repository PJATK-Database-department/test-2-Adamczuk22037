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
                        .Select(sti => sti.ServiceType.ServiceType).ToList(),
                    Comment = i.Comment
                });
            return Ok(await inspections.ToListAsync());
        }

        //Task update: not chaning service for the car
        //(makes no sense, service is a dictionary type, it does not belong to a car in any sense)
        //but instead changing which car undergoes the specific inspection.

        [HttpPut("{idInspection}")]
        public IActionResult ChangeCar(int idInspection)
        {
            Models.Inspection inspection = _dbContex.Inspections.Where(i => i.IdInspection == idInspection).SingleOrDefault();
            if (inspection == null) return NotFound("The database contains no inspection of this id.");
            //First, check if this inspection exists.
            return Ok("Testing stage");
        }
    }
}
