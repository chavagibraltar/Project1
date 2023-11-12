using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {

        //public static int count = 4;
        public static List<Event> events = new List<Event> { new Event { Id = 1, Title = "default event1",Start=DateTime.Now },
         new Event { Id = 2, Title = "default event2",Start=DateTime.Now }
        , new Event { Id = 3, Title = "default event3",Start=DateTime.Now } };


        // GET: api/<EventsController>
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return events;
        }   

        // POST api/<EventsController>
        [HttpPost]
        public void Post([FromBody] Event newEvent)
        {
            events.Add(new Event { Id = newEvent.Id, Title = newEvent.Title, Start = newEvent.Start, End = newEvent.End });
        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Event newEvent)
        {
            var eve = events.Find(e => e.Id == id);
            eve.Start = newEvent.Start;
            eve.End = newEvent.End;
            eve.Title = newEvent.Title;
        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            events.Remove(events.Find(e => e.Id == id));
        }
    }
}
