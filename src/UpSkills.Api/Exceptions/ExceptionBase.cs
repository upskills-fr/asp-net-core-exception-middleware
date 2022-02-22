namespace UpSkills.Api.Exceptions
{
    public abstract class ExceptionBase : Exception
    {
        public abstract ErrorKeys ErrorKey { get; }

        public ExceptionBase(string? message) : base(message)
        {
        }
    }

    public enum ErrorKeys
    {
        Undefined = 0,
        InvalidNumber = 1,
    }
}
