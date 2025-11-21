namespace VIRS.Domain.AppServices.Exceptions
{
    public abstract class BaseValidationException(string fieldName, string message) : Exception(message)
    {
        public string FieldName { get; } = fieldName;
    }
}
