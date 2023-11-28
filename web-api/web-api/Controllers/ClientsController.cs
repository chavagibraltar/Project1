using Microsoft.AspNetCore.Mvc;
using web_api.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        /*
        public static List<Book> booksList1 = new List<Book> {
        new Book { id = 1, name = "aaa", statusIsRented = true, branchId = 1 },
        new Book { id = 2, name = "bbb", statusIsRented = false, branchId = 1 } };
        public static List<Book> booksList2 = new List<Book> {
        new Book { id = 3, name = "ccc", statusIsRented = true, branchId = 2 },
        new Book { id = 4, name = "ddd", statusIsRented = false, branchId = 2 },};
        */

        private DataContext dataContext;
        public ClientsController(DataContext context)
        {
            dataContext = context;
        }
        // GET: api/<ClientsController>
        [HttpGet]
        public IEnumerable<Client> Get([FromBody] bool? hasBook)
        {
     
            if(hasBook != null)
            {
                return dataContext.Clients.FindAll(e=>e.hasBook == hasBook).ToList();
            }
            return dataContext.Clients;
        }

        // GET api/<ClientsController>/5
        [HttpGet("{id}")]
        public Client Get(int id)
        {
            return dataContext.Clients.Find(e=>e.id == id);        
        }        

        // POST api/<ClientsController>
        [HttpPost]
        public void Post([FromBody] Client value)
        {
            dataContext.Clients.Add(value);
        }

        // PUT api/<ClientsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Client value)
        {
            dataContext.Clients.Remove(dataContext.Clients.Find(e => e.id == id));
            dataContext.Clients.Add(value);            
        }

        // DELETE api/<ClientsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            dataContext.Clients.Remove(dataContext.Clients.Find(e => e.id == id));
        }
    }
}
