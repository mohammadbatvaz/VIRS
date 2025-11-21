using System.IO;
using VIRS.Domain.Core.ImageAgg.Contracts.Data;

namespace VIRS.Infra.DataAccess.Storage
{
    public class FileRepository : IFileRepository
    {
        public string Upload(Stream file, string folder, string fileFormat)
        {

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folder);

            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var uniqueFileName = Guid.NewGuid() + fileFormat;

            var filePath = Path.Combine(uploadsFolder, uniqueFileName);


            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return $"{Path.Combine("/", folder, uniqueFileName)}";
        }
    }
}
