namespace Exo02_R_API_Tatouille.Exceptions
{
    public class UserAlreadyExistException : Exception
    {
        public UserAlreadyExistException(string? message) : base(message)
        {
        }

    }
}
