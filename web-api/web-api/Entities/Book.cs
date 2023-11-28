namespace web_api.Entities
{
    public class Book
    {
        public int id { get; set; }
        public string name { get; set; }
        public bool statusIsRented { get; set; }
        public int branchId { get; set; }

        public Book()
        {

        }
        //public Book(int id, string name, bool statusIsRented, int branchId)
        //{
        //    this.id = id;
        //    this.name = name;
        //    this.statusIsRented = statusIsRented;
        //    this.branchId = branchId;
        //}
        //id = 1, name = "aaa", statusIsRented = true, branchId = 1 
    }
}
