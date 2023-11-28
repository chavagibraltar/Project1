using Microsoft.Extensions.Logging;
using web_api.Entities;

namespace web_api
{
    public class DataContext : IDataContext
    {
        public List<Event> Events { get; set; }
        public List<Client> Clients { get; set; }

        public List<Book> Books { get; set; }

        public List<Branch> Branches { get; set; }
        public DataContext()
        {
            Events = new List<Event> { new Event { Id = 1, Title = "default event1",Start=DateTime.Now },
            new Event { Id = 2, Title = "default event2",Start=DateTime.Now },
            new Event { Id = 3, Title = "default event3",Start=DateTime.Now } 
            };


            Clients = new List<Client> {
            new Client { id = 1, name = "a", booksList = {1,2,3}, hasBook = true , branchId = 1, phoneNumber = "050-1111111"},
            new Client { id = 2, name = "b", booksList = {4,5,6}, hasBook = false , branchId = 1, phoneNumber = "050-2222222"},
            new Client { id = 2, name = "c", booksList = {7,8,9}, hasBook = true , branchId = 2, phoneNumber = "050-3333333"}
            };

            Books = new List<Book> {
            new Book { id = 1, name = "aaa", statusIsRented = true, branchId = 1 },
            new Book { id = 2, name = "bbb", statusIsRented = false, branchId = 1 },
            new Book { id = 3, name = "ccc", statusIsRented = true, branchId = 2 },
            new Book { id = 4, name = "ddd", statusIsRented = false, branchId = 2 },
            };
            Branches = new List<Branch> {
            new Branch{id = 1, name = "a", address = "B-B Y-M 43", phoneNumber = "054-0001111" },
            new Branch{id = 2, name = "b", address = "B-B Y-M 43", phoneNumber = "054-0002222" },
            new Branch{id = 3, name = "c", address = "B-B Y-M 43", phoneNumber = "054-0003333" }
            };


        }
    }
}
