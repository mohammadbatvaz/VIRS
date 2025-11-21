namespace VIRS.Domain.AppServices.Exceptions
{
    public class InspectionDateValidationException(string message) 
        : BaseValidationException("InspectionDate", message);
}
