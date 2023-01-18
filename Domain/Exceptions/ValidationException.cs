namespace Domain.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException()
        {
            Errors = new List<string>();
        }

        public ValidationException(List<string> errors)
            : this()
        {
            Errors = errors;
        }
        public override string Message => base.Message + String.Join(" | | ", Errors);

        public List<string> Errors { get; } = new List<string>();
    }
}
