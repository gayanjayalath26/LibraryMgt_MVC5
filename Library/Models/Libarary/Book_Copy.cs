namespace Library.Models.Libarary
{
    public class Book_Copy
    {
        public int Book_CopyID { get; set; }

        public bool LendingStatus { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int BookID { get; set; }

        public Book Book { get; set; }
    }
}