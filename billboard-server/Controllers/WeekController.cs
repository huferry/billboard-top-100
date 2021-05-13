using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using billboard_server.Database;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace billboard_server.Controllers
{
    [ApiController]
    [EnableCors("MyPolicy")]
    [Route("/api/[controller]")]
    public class WeekController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public WeekController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        /// <summary>
        /// Get the available weeks.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The available weeks with top 40 list.</returns>
        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var dates = await _applicationDbContext.SongHits
                .Select(s => s.Date)
                .Distinct()
                .ToArrayAsync(cancellationToken);

            return dates.Any() ? Ok(dates) : NotFound();
        }
    }
}