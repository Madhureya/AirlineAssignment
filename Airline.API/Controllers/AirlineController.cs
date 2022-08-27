using Airline.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Airline.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AirlineController : Controller
    {
        
         
            private readonly AirlineDbContext _context;
            public AirlineController(AirlineDbContext context)
            {
                _context = context;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<ManageAirline>>> ShowAllAirlines()
            {
                if (_context.ManageAirlines == null)
                {
                    return NotFound("Table doesn't exists");
                }
                return await _context.ManageAirlines.ToListAsync();
            }


            [HttpGet("{searchString}")]
            public async Task<IActionResult> Search(string searchString)
            {
                if (searchString == null)
                {
                    return BadRequest("input can't be null");
                }
                if (_context.ManageAirlines == null)
                {
                    return NotFound("Table doesn't exists");
                }
                var books = await _context.ManageAirlines.Where(b => b.AirlineName.Contains(searchString) || b.FromCity.Contains(searchString)).ToListAsync();
                if (books == null)
                {
                    return NotFound("Record doesn't exists");
                }
                return Ok(books);
            }

            [HttpPost]
            public async Task<IActionResult> AddOneAirline(ManageAirline manageAirline)
            {
                if (manageAirline == null)
                {
                    return BadRequest("Airline object can't be null");
                }
                if (_context.ManageAirlines == null)
                {
                    return NotFound("Table doesn't exists");
                }
                _context.ManageAirlines.Add(manageAirline);
                await _context.SaveChangesAsync();
                return Ok("Added Successfully");
            }

            [HttpPut]
            public async Task<IActionResult> UpdateOneAirline(int Id, ManageAirline manageAirline)
            {
                if (manageAirline == null)
                {
                    return BadRequest(" object can't be null");
                }
                if (_context.ManageAirlines == null)
                {
                    return NotFound("Table doesn't exists");
                }
                var airlineToUpdate = await _context.ManageAirlines.Where(e => e.Id == Id).FirstOrDefaultAsync();
                if (airlineToUpdate == null)
                {
                    return NotFound("Airline doesn't exists");
                }
                airlineToUpdate.AirlineName = manageAirline.AirlineName;
                airlineToUpdate.FromCity = manageAirline.FromCity;
                airlineToUpdate.ToCity = manageAirline.ToCity;
                airlineToUpdate.Fare = manageAirline.Fare;
                



                _context.ManageAirlines.Update(airlineToUpdate);
                await _context.SaveChangesAsync();
                return Ok("Updated Successfully");
            }

            [HttpDelete]
            public async Task<ActionResult> DeleteOneAirline(int Id)
            {
                if (_context.ManageAirlines == null)
                {
                    return NotFound("Table doesn't exists");
                }
                var airlineToDelete = await _context.ManageAirlines.Where(e => e.Id == Id).FirstOrDefaultAsync();
                if (airlineToDelete == null)
                {
                    return NotFound("Ailrine  doesn't exists");
                }
                _context.ManageAirlines.Remove(airlineToDelete);
                await _context.SaveChangesAsync();
                return Ok("Deleted Successfully");
            }

     
    }
    }
