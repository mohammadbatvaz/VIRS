namespace VIRS.Domain.AppServices.Exceptions
{
    public class CarPlatValidationException(string message)
        : BaseValidationException("CarPlatFirstPart", message);
}
