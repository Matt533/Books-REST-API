namespace BookEStore.Infrastructure_Layer.Exceptions
{
    public class AuthorNotFoundException : Exception
    {
        public AuthorNotFoundException()
        {
            Console.WriteLine("Author doesn't exist!");
        }
    }
}
