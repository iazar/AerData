using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using AerData.Core.Models;
using Microsoft.Extensions.FileProviders;

namespace AerData.Core.Directories
{
    /// <summary>
    /// Directory service
    /// Contains all methods for read directory content
    /// </summary>
    public interface IDirectoryService
    {
        /// <summary>
        /// Get a list of 5 folders ordered by size from biggest to smaller
        /// </summary>
        /// <returns>
        /// List of DirectoryModel
        /// </returns>
        ValueTask<IEnumerable<DirectoryModel>> GetDirectoriesAsync();
        /// <summary>
        /// Get directory size including subdirectories files in bytes
        /// </summary>
        /// <returns> Folder size in bytes </returns>
        /// <param name="path"> string of the relative path of the directory</param>
        /// <param name="collectFileList">New list of IFileInfo to be filled from the specified path</param>
        ValueTask<BigInteger> GetDirectorySizeAsync(string path, IList<IFileInfo> collectFileList);
    }
}