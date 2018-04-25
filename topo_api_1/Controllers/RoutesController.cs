using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using topo_api_1.Models;

namespace topo_api_1.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class RoutesController : Controller
    {
        public const double RADIUS = 1;
        private readonly RouteContext _context;

        public RoutesController(RouteContext context)
        {
            _context = context;
        }

        // GET: api/Routes
        [HttpGet]
        public IEnumerable<Route> GetRoutes()
        {
            return _context.Routes;
        }
        
        // GET: api/...
        [HttpGet("/api/routes/limited/{limit}/{page}", Name = "Limited_List")]
        public IEnumerable<Route> Limited(int limit, int page)
        {
            return _context.Routes.Skip((page - 1) * limit).Take(limit);
        }

        // GET: api/Routes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoute([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var route = await _context.Routes.SingleOrDefaultAsync(m => m.Id == id);

            if (route == null)
            {
                return NotFound();
            }

            return Ok(route);
        }

        // GET: api/Routes/5
        [HttpGet("{lat:double}/{lon:double}")]
        public IEnumerable<Route> GetRoutes(double lat, double lon)
        {
            return _context.Routes
                    .Where(a =>
                        a.Lat <= lat + RADIUS
                        && a.Lat >= lat - RADIUS
                        && a.Lon <= lon + RADIUS
                        && a.Lon >= lon - RADIUS)
                    .OrderBy(a => 
                    Math.Sqrt(
                    (double)Math.Pow((a.Lat-lat),2)
                    + (double)Math.Pow((a.Lon - lon), 2)))
                    .ToList();
        }

        private bool RouteExists(long id)
        {
            return _context.Routes.Any(e => e.Id == id);
        }
    }
}