using Microsoft.AspNetCore.Mvc;
using web_api.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {

        private IDataContext dataContext;

        public EventsController(IDataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        // GET: api/<EventsController>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(dataContext.Events);
        }

        // GET: api/<EventsController>
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var eve = dataContext.Events.Find(e => e.Id == id);
            if (eve is null)
            {
                return NotFound();
            }
            return Ok(eve);
        }


        // POST api/<EventsController>
        [HttpPost]
        public ActionResult Post([FromBody] Event newEvent)
        {
            if(newEvent.Id == 0)
                return NotFound();
            dataContext.Events.Add(newEvent);
            return Ok();
        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Event newEvent)
        {
            var eve = dataContext.Events.Find(e => e.Id == id);
            if(eve is null)
            {
                return NotFound();
            }

            dataContext.Events.Remove(eve);
            dataContext.Events.Add(newEvent);
            return Ok();
            
        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var eve = dataContext.Events.Find(e => e.Id == id);
            if (eve is null)
            {
                return NotFound();
            }
            dataContext.Events.Remove(eve);
            return Ok();
        }
    }
}
