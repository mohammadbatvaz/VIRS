namespace VIRS.Domain.AppServices.Exceptions
{
    public class ManufactureYearValidationException(string message) 
        : BaseValidationException("CarManufactureYear", message);
}
