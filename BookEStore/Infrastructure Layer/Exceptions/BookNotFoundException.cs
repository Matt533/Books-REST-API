namespace BookEStore.Infrastructure_Layer.Exceptions
{
    public class BookNotFoundException : Exception
    {
        public BookNotFoundException()
        {
            Console.WriteLine("Book doesn't exist!");
        }
    }
}
