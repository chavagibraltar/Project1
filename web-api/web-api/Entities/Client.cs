namespace web_api.Entities
{
    public class Client
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<int> booksList { get; set; }
        public string phoneNumber { get; set; }
        public bool hasBook { get; set; }
        public int branchId { get; set; }
        public Client()
        {

        }
    }
}
