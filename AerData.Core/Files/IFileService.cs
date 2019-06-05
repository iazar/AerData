using System.Collections.Generic;
using System.Threading.Tasks;
using AerData.Core.Models;
using Microsoft.Extensions.FileProviders;

namespace AerData.Core.Files
{
    public interface IFileService
    {
         ValueTask<IEnumerable<FileModel>> GetDirectoryFilesAsync(string path, IList<IFileInfo> collectFileList);
    }
}