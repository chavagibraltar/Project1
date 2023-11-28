using Microsoft.AspNetCore.Mvc;
using web_api.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public static Book b = new Book();
        //public static List<Book> bl = new List<Book> {};
        private DataContext dataContext = new DataContext();
        // GET: api/<BooksController>
        [HttpGet]
        public IEnumerable<Book> Get(bool? statusIsRented)
        {
            if (statusIsRented != null)
            {
                return dataContext.Books.Where(x => x.statusIsRented == statusIsRented).ToList();
            }
            return dataContext.Books;
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public Book Get(int id)
        {         
            return dataContext.Books.Find(x => x.id == id);            
        }        

        // POST api/<BooksController>
        [HttpPost]
        public void Post([FromBody] Book value)
        {
            dataContext.Books.Add(value);
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Book value)
        {
            dataContext.Books.Remove(dataContext.Books.Find(e => e.id == id));
            dataContext.Books.Add(value);           
        }
        [HttpPut("{id}/statusIsRented")]
        public void Put(int id, [FromBody] bool statusIsRented)
        {
            b = dataContext.Books.Find(e => e.id == id);
            b.statusIsRented = statusIsRented;
            dataContext.Books.Remove(dataContext.Books.Find(e => e.id == id));
            dataContext.Books.Add(b);
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            dataContext.Books.Remove(dataContext.Books.Find(e => e.id == id));
        }
    }
}
