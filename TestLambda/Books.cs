namespace TestLambda
{
    public class Book
    {
        public Book(string title, double price)
        {
            Title = title;
            Price = price;
        }
        public string Title { set; get; } = "";
        public double Price { set; get; }
    }


    public class BookRepository
    {
        public List<Book> GetBooks()
        {
            return new List<Book>
            {
              new Book("Book 1", 1.00),
              new Book("Book 2", 2.00),
              new Book("Book 3", 3.00),
              new Book("Book 4", 4.00),
              new Book("Book 5", 5.00),

            };
        }
    }

}