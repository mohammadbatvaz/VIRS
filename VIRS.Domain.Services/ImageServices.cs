using VIRS.Domain.Core.ImageAgg.Contracts.Data;
using VIRS.Domain.Core.ImageAgg.Contracts.Services;

namespace VIRS.Domain.Services
{
    public class ImageServices(
        IFileRepository fileRepository) : IImageServices
    {
        public string SaveOnDisk(Stream imageStream, string fileFormat)
            => fileRepository.Upload(imageStream, "Image", fileFormat);
    }
}
