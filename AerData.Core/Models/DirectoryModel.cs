using System.Collections.Generic;
using System.Numerics;
using Microsoft.Extensions.FileProviders;

namespace AerData.Core.Models
{
    public class DirectoryModel
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public BigInteger Size { get; set; }
    }
}