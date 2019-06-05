using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AerData.Core.Config;
using AerData.Core.Directories;
using AerData.Core.Files;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;

namespace AerData.API.Controllers
{
    [Route("aerdata/[controller]")]
    [ApiController]
    public class FileSystemController : ControllerBase
    {
        private readonly IDirectoryService _directoryService;
        public FileSystemController(IDirectoryService directoryService)
        {
            _directoryService = directoryService;
        }
        /// <summary>
        /// Get directory top 5 folders
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Get aerdata/filesystem
        ///
        /// </remarks>
        /// <returns>List of top 5 folders inside configured path</returns>
        /// <response code="204">Returns path is empty</response>
        /// <response code="200">List of top 5 folders ordered by size</response> 
        [HttpGet]
        public async ValueTask<IActionResult> Get()
        {
            var directories = await _directoryService.GetDirectoriesAsync();
            if (directories.Any())
            {
                return Ok(directories);
            }
            Response.Headers.Add("Message", "Please Configure Not Empty Path in appsetting.json");
            return NoContent();
        }
    }
}
