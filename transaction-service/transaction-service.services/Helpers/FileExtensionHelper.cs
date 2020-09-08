using System;
using System.IO;
using transaction_service.domain.Enums;

namespace transaction_service.services.Helpers
{
    public class FileExtensionHelper
    {
        public static FileExtension GetFileExtension(string fileName)
        {
            var extension = Path.GetExtension(fileName).Substring(1);
            Enum.TryParse(extension, true, out FileExtension parsedExtension);
            return parsedExtension;
        }
    }
}
