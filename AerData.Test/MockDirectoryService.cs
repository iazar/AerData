using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using AerData.Core.Directories;
using AerData.Core.Models;
using Microsoft.Extensions.FileProviders;
namespace AerData.Test
{
    public class MockDirectoryService : IDirectoryService
    {
        public ValueTask<IEnumerable<DirectoryModel>> GetDirectoriesAsync()
        {
            var mockResult = new List<DirectoryModel>{
                new DirectoryModel{
                    Name = "TestFolder1",
                    Path = "TestPath1",
                    Size = 10
                },
                 new DirectoryModel{
                    Name = "TestFolder2",
                    Path = "TestPath2",
                    Size = 20
                },
                 new DirectoryModel{
                    Name = "TestFolder3",
                    Path = "TestPath3",
                    Size = 30
                },
                 new DirectoryModel{
                    Name = "TestFolder4",
                    Path = "TestPath4",
                    Size = 40
                },
                new DirectoryModel{
                    Name = "TestFolder5",
                    Path = "TestPath5",
                    Size = 50
                },
                new DirectoryModel{
                    Name = "TestFolder5",
                    Path = "TestPath5",
                    Size = 35
                }
                }.OrderByDescending(f => f.Size).Take(5);
            return new ValueTask<IEnumerable<DirectoryModel>>(mockResult);
        }

        public ValueTask<BigInteger> GetDirectorySizeAsync(string path, IList<IFileInfo> collectFileList)
        {
            return new ValueTask<BigInteger>(new BigInteger(999));
        }
    }
}