namespace UpSkills.Api.Exceptions
{
    public class AlgoComputeException : ExceptionBase, IHasErrorDetails
    {
        public IErrorDetails ErrorDetails { get; }

        public override ErrorKeys ErrorKey => ErrorKeys.InvalidNumber;

        public AlgoComputeException(string? message, AlgoComputeErrorDetails errorPayload) : base(message)
        {
            ErrorDetails = errorPayload;
        }
    }

    public class AlgoComputeErrorDetails : IErrorDetails
    {
        public string AdditionnalData1 { get; set; }
        public int AdditionnalData2 { get; set; }

        public AlgoComputeErrorDetails(string additionnalData1, int additionnalData2)
        {
            AdditionnalData1 = additionnalData1;
            AdditionnalData2 = additionnalData2;
        }
    }
}
