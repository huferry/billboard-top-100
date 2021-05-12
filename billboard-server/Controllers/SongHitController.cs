using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using billboard_server.Database;
using billboard_server.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace billboard_server.Controllers
{
    [ApiController]
    [EnableCors("MyPolicy")]
    [Route("/api/[controller]")]
    public class SongHitController : ControllerBase
    {
        private readonly ILogger<SongHitController> _logger;
        private readonly ApplicationDbContext _applicationDbContext;

        public SongHitController(ILogger<SongHitController> logger, ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetByWeek(int year, int month, int day, CancellationToken cancellationToken)
        {
            var hitDate = GetSaturdayBefore(new DateTime(year, month, day));
            var hits = await _applicationDbContext
                .SongHits
                .Where(d => d.Date == hitDate)
                .ToArrayAsync(cancellationToken);

            return hits.Any() ? Ok(hits) : NotFound();
        }

        private DateTime GetSaturdayBefore(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday ? date : GetSaturdayBefore(date.AddDays(-1));
        }
    }
}
