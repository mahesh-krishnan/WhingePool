using System;
using System.IO;
using System.Linq;
using System.Reflection;

using BrightSword.Pegasus.API;
using BrightSword.Pegasus.Configuration;
using BrightSword.Pegasus.Utilities;
using BrightSword.SwissKnife;

using Microsoft.WindowsAzure.Storage.Blob;

namespace ConsoleApp.BrightSword.Pegasus.RegisterCommandHandlers
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var parameters = new Parameters
                             {
                                 FullAssemblyPath = args.GetArgumentValue("--assembly",
                                                                          _ => _)
                             };

            var context = new CloudRunnerContext();
            
            var assembly = Assembly.LoadFrom(parameters.FullAssemblyPath);
            if (assembly == null)
            {
                throw new ArgumentException(String.Format("Unable to load assembly {0}",
                                                          parameters.FullAssemblyPath));
            }

            var commandHandlerTypes = from type in assembly.ExportedTypes
                                      where typeof (ICommandHandler).IsAssignableFrom(type)
                                      let attr = type.GetCustomAttribute<RegisterCommandHandlerAttribute>()
                                      where attr != null
                                      select new
                                             {
                                                 Type = type,
                                                 Attribute = attr
                                             };

            var assemblyName = Path.GetFileNameWithoutExtension(assembly.CodeBase);

            foreach (var commandHandlerType in commandHandlerTypes)
            {

                context.RegisteredCommandHandlersTable.EnsureInstance(new CommandHandler(commandHandlerType.Attribute.Type.FullName,
                                                                                         assemblyName,
                                                                                         commandHandlerType.Type.FullName));
            }

            context.RegisteredCommandHandlersBlobContainer.SetPermissions(new BlobContainerPermissions
                                                                   {
                                                                       PublicAccess = BlobContainerPublicAccessType.Container
                                                                   });

            var blob = context.RegisteredCommandHandlersBlobContainer.GetBlockBlobReference(assemblyName);
            if (blob.Exists())
            {
                blob.FetchAttributes();
            }

            using (var stream = new FileStream(parameters.FullAssemblyPath,
                                               FileMode.Open,
                                               FileAccess.Read,
                                               FileShare.Read))
            {
                blob.UploadFromStream(stream);
            }
        }

        private class Parameters
        {
            public string FullAssemblyPath { get; set; }
        }
    }
}
