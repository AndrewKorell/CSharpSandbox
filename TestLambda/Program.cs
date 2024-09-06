namespace TestLambda
{

    class Program
    {

        static void main(string args[])
        {

            // x =>
            //(x,y,z) =>


            Func<int, int> square = number => number * number;

            Console.WriteLine(square(5));

            const int factor = 5;

            Func<int, int> multiplier = n => n * factor;

            var result = multiplier(5);

            Console.WriteLine(result);


            var books = new BookRepository().GetBooks();


            var cheap = books.FindAll(book => book.Price < 5);
            //Is equivalent to
            //var cheap = books.FindAll(GetBookIsCheaperThan5Dollars);

            foreach (var book in cheap)
            {
                Console.WriteLine(book.Title);
            }

        }

        //Predicate Function 
        public static bool GetBookIsCheaperThan5Dollars(Book book)
        {
            return book.Price < 5;
        }
    }
}