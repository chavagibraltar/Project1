using web_api;

namespace TestProject1
{
    public class DataContextFake:IDataContext
    {
        public List<Event> Events { get; set; }
        public DataContextFake()
        {
            Events = new List<Event> { 
            new Event { Id = 1, Title = "default event1",Start=DateTime.Now },
            new Event { Id = 2, Title = "default event2",Start=DateTime.Now },
            new Event { Id = 3, Title = "default event3",Start=DateTime.Now } };

        }
    }
}
