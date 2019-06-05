using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.FileProviders;

namespace AerData.Core.Config
{
    public static class FileProviderExtension
    {
        public static IServiceCollection AddFileProvider(this IServiceCollection services,string path)
        {
            if(string.IsNullOrWhiteSpace(path))
                path = System.IO.Directory.GetCurrentDirectory();
            return services.AddScoped<IFileProvider>(p => new PhysicalFileProvider(path));
        }
    }
}
