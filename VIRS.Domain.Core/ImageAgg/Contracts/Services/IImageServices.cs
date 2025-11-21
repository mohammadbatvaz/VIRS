namespace VIRS.Domain.Core.ImageAgg.Contracts.Services
{
    public interface IImageServices
    {
        string SaveOnDisk(Stream imageStream, string fileFormat);
    }
}
