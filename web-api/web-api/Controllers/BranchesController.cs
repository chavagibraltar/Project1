using Microsoft.AspNetCore.Mvc;
using web_api.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        /*
        public static List<Book> booksList_ = new List<Book> {
        new Book { id = 1, name = "aaa", statusIsRented = true, branchId = 1 },
        new Book { id = 2, name = "bbb", statusIsRented = false, branchId = 1 },
        new Book { id = 3, name = "ccc", statusIsRented = true, branchId = 2 },
        new Book { id = 4, name = "ddd", statusIsRented = false, branchId = 2 },};

        public static List<Book> booksList1 = new List<Book> {
        new Book { id = 1, name = "aaa", statusIsRented = true, branchId = 1 },
        new Book { id = 2, name = "bbb", statusIsRented = false, branchId = 1 } };
        public static List<Book> booksList2 = new List<Book> {
        new Book { id = 3, name = "ccc", statusIsRented = true, branchId = 2 },
        new Book { id = 4, name = "ddd", statusIsRented = false, branchId = 2 },};
        public static List<Client> clients = new List<Client> {
            new Client { id = 1, name = "a", booksList = {1,2,3}, hasBook = true , branchId = 1, phoneNumber = "050-1111111"},
            new Client { id = 1, name = "b", booksList = {4,5,6}, hasBook = false , branchId = 1, phoneNumber = "050-2222222"},
            new Client { id = 1, name = "c", booksList = {7,8,9}, hasBook = true , branchId = 2, phoneNumber = "050-3333333"}};
        */

        public Branch b  = new Branch();
        private DataContext dataContext;
        public BranchesController(DataContext context)
        {
            dataContext = context;
        }
    
        // GET: api/<BranchesController>
        [HttpGet]
        public IEnumerable<Branch> Get(string? address)
        {
     
            if(address != null)
            {
                return dataContext.Branches.FindAll(e => e.address == address).ToList();
            }
            return dataContext.Branches;
        }

        // GET api/<BranchesController>/5
        [HttpGet("{id}")]
        public Branch Get(int id)
        {
            return dataContext.Branches.Find(e => e.id == id);
        }

        // POST api/<BranchesController>
        [HttpPost]
        public void Post([FromBody] Branch value)
        {
            dataContext.Branches.Add(value);
        }

        // PUT api/<BranchesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Branch value)
        {

            dataContext.Branches.Remove(dataContext.Branches.Find(e => e.id == id));
            dataContext.Branches.Add(value);
           
        }
        [HttpPut("{id}/adress")]
        public void Put(int id, [FromBody] string address)
        {
            b = dataContext.Branches.Find(e => e.id == id);
            dataContext.Branches.Remove(dataContext.Branches.Find(e => e.id == id));
            b.address = address;
            dataContext.Branches.Add(b);
        }

        // DELETE api/<BranchesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            dataContext.Branches.Remove(dataContext.Branches.Find(e => e.id == id));
        }
    }
}
