namespace VIRS.Domain.Core.ImageAgg.Contracts.Data
{
    public interface IFileRepository
    {
        string Upload(Stream file, string folder, string fileFormat);
    }
}
