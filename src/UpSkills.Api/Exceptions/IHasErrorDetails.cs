namespace UpSkills.Api.Exceptions
{
    public interface IHasErrorDetails
    {
        public IErrorDetails ErrorDetails { get; }
    }

    public interface IErrorDetails { }
}
