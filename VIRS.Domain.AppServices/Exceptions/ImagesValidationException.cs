namespace VIRS.Domain.AppServices.Exceptions
{
    public class ImagesValidationException(string message)
        : BaseValidationException("Images", message);
}
