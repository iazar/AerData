using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AerData.Core.Models;
using Microsoft.Extensions.FileProviders;

namespace AerData.Core.Files
{
    public class FileService : IFileService
    {
        private readonly IFileProvider _fileProvider;
        public FileService(IFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
        }
        public ValueTask<IEnumerable<FileModel>> GetDirectoryFilesAsync(string path, IList<IFileInfo> existingFileList)
        {

            var contents = _fileProvider.GetDirectoryContents(path);

            foreach (var content in contents)
            {
                if (!content.IsDirectory)
                {
                    existingFileList.Add(content);
                }
                else
                {
                    GetDirectoryFilesAsync($"{path}/{content.Name}", existingFileList);
                }
            }
            var results = existingFileList.Select(f => new FileModel
            {
                Name = f.Name,
                Path = f.PhysicalPath,
                Size = f.Length == -1 ? 0 : f.Length
            });
            return new ValueTask<IEnumerable<FileModel>>(results);
        }
    }
}