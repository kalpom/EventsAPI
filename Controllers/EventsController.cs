using EventsAPI.Models;
using EventsAPI.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {

        private readonly IUnitOfWork<EventsDbContext> _uow;
        private readonly ILogger<EventsController> _logger;
        public EventsController(ILogger<EventsController> logger, IUnitOfWork<EventsDbContext> db)
        {
            _logger = logger;
            _uow = db;
        }
        [HttpGet("GetEvents")]
        public List<Events> GetEventsList()
        {
            var output = _uow.GetRepository<Events>().Get().ToList();
            return output;
        }

        [HttpGet("GetEventById/{id}")]
        public List<Events> GetEventById(int id)
        {
            var output = _uow.GetRepository<Events>().Get().Where(a => a.id == id).ToList();
            return output;
        }


    }
}
