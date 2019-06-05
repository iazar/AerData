using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using AerData.Core.Files;
using AerData.Core.Models;
using Microsoft.Extensions.FileProviders;

namespace AerData.Core.Directories
{
    public class DirectoryService : IDirectoryService
    {
        private readonly IFileProvider _fileProvider;
        private readonly IFileService _fileService;

        public DirectoryService(IFileProvider fileProvider, IFileService fileService)
        {
            _fileProvider = fileProvider;
            _fileService = fileService;
        }
        public ValueTask<IEnumerable<DirectoryModel>> GetDirectoriesAsync()
        {
            var results = _fileProvider.GetDirectoryContents("")
                .Where(f => f.IsDirectory)
                .Select(dir => new DirectoryModel
                {
                    Name = dir.Name,
                    Path = dir.PhysicalPath,
                    Size = GetDirectorySizeAsync(dir.Name , new List<IFileInfo>()).Result
                })
                .OrderByDescending(dir => dir.Size)
                .Take(5);

            return new ValueTask<IEnumerable<DirectoryModel>>(results);
        }

        public async ValueTask<BigInteger> GetDirectorySizeAsync(string path, IList<IFileInfo> collectFileList)
        {
            var directoryFiles = await _fileService.GetDirectoryFilesAsync(path, collectFileList);
            return directoryFiles.Sum(f => f.Size);
        }
    }
}