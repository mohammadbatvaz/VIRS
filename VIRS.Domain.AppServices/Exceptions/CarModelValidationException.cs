namespace VIRS.Domain.AppServices.Exceptions
{
    public class CarModelValidationException(string message)
        : BaseValidationException("CarModelManufacturer", message);

}
