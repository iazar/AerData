using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using AerData.Core.Models;
using Microsoft.Extensions.FileProviders;
using NUnit.Framework;
namespace AerData.Test
{
    [TestFixture]
    public class DirectoryServiceTests
    {
        [Test]
        public void GetDirectoriesAsync_Result_OfTypeDirectoryModel()
        {
            var service = new MockDirectoryService();
            var result = service.GetDirectoriesAsync().Result;

            CollectionAssert.AllItemsAreInstancesOfType(result, typeof(DirectoryModel));
        }

        [Test]
        public void GetDirectoriesAsync_Result_IsNotEmpty()
        {
            var service = new MockDirectoryService();
            var result = service.GetDirectoriesAsync().Result;

            CollectionAssert.IsNotEmpty(result);
        }

        [Test]
        public void GetDirectoriesAsync_ResultItems_NotNull()
        {
            var service = new MockDirectoryService();
            var result = service.GetDirectoriesAsync().Result;
            CollectionAssert.AllItemsAreNotNull(result);
        }

        [Test]
        public void GetDirectoriesAsync_Result_ReturnDescendingOrderBySize()
        {
            var service = new MockDirectoryService();
            var result = service.GetDirectoriesAsync().Result;
            var expectedList = result.OrderByDescending(x => x.Size);
            Assert.IsTrue(expectedList.SequenceEqual(result));
        }

        [Test]
        public void GetDirectoriesAsync_Result_ReturnTop5()
        {
            var service = new MockDirectoryService();
            var result = service.GetDirectoriesAsync().Result;
            var expectedList = result.Take(5);
            Assert.IsTrue(expectedList.SequenceEqual(result));
        }

        [Test]
        public void GetDirectorySizeAsync_Result_ReturnBigInt()
        {
            var service = new MockDirectoryService();
            var result = service.GetDirectorySizeAsync(string.Empty,new List<IFileInfo>()).Result;

           Assert.That(result, Is.TypeOf<BigInteger>());
        }
    }
}