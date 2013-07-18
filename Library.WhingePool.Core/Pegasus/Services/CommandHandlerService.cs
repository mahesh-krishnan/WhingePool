using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

using BrightSword.SwissKnife;

using Microsoft.WindowsAzure.Storage.Table;

using WhingePool.Core.API;
using WhingePool.Core.Pegasus.API;
using WhingePool.Core.Pegasus.Configuration;

namespace WhingePool.Core.Pegasus.Services
{
    internal static class CommandHandlerService
    {
        internal static ICommandHandler GetCommandHandler(this ICommand command,
                                                          ICommandHandlerContext context)
        {
            return context.GetOrAdd(command.CommandName,
                                    () => GetCommandHandlerInternal(command,
                                                                    context));
        }

        private static ICommandHandler GetCommandHandlerInternal(this ICommand command,
                                                                 ICommandHandlerContext context)
        {
            var filter = TableQuery.GenerateFilterCondition(ObjectDescriber.GetName((CommandHandler _) => _.CommandName),
                                                            QueryComparisons.Equal,
                                                            command.CommandName);

            var query = new TableQuery<CommandHandler>().Where(filter);

            var commandHandlerQueryResult = context.RegisteredCommandHandlersTable.GetInstances(query)
                                                   .FirstOrDefault();

            if (commandHandlerQueryResult == null)
            {
                throw new NoRegisteredHandlerFoundException(command.CommandName);
            }

            var assembly = LoadAssembly(commandHandlerQueryResult) ?? DownloadAndLoadAssembly(commandHandlerQueryResult,
                                                                                              context);

            if (assembly == null)
            {
                throw new AssemblyFailedToLoadException(commandHandlerQueryResult.CommandHandlerTypeAssembly);
            }

            return GetCommandHandlerFromAssembly(assembly,
                                                 commandHandlerQueryResult);
        }

        private static Assembly LoadAssembly(CommandHandler commandHandlerQueryResult)
        {
            try
            {
                return Assembly.Load(commandHandlerQueryResult.CommandHandlerTypeAssembly);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static Assembly DownloadAndLoadAssembly(CommandHandler commandHandlerQueryResult,
                                                        ICommandHandlerContext context)
        {
            MemoryStream stream;
            try
            {
                stream = context.GetOrAdd(commandHandlerQueryResult.CommandHandlerTypeAssembly,
                                          () => DownloadAssemblyFromBlob(commandHandlerQueryResult,
                                                                         context));
            }
            catch (Exception exception)
            {
                throw new FailedToDownloadAssemblyException(commandHandlerQueryResult.CommandHandlerTypeAssembly,
                                                            exception);
            }

            try
            {
                return Assembly.Load(stream.GetBuffer());
            }
            catch (Exception exception)
            {
                throw new FailedToLoadDownloadedAssemblyException(commandHandlerQueryResult.CommandHandlerTypeAssembly,
                                                                  exception);
            }
        }

        private static MemoryStream DownloadAssemblyFromBlob(CommandHandler commandHandlerQueryResult,
                                                             ICommandHandlerContext context)
        {
            var blockBlobReference = context.RegisteredCommandHandlersBlobContainer.GetBlockBlobReference(commandHandlerQueryResult.CommandHandlerTypeAssembly);

            var result = new MemoryStream();
            blockBlobReference.DownloadToStream(result);
            result.Seek(0,
                        SeekOrigin.Begin);

            return result;
        }

        private static ICommandHandler GetCommandHandlerFromAssembly(Assembly assembly,
                                                                     CommandHandler commandHandlerQueryResult)
        {
            try
            {
                var commandHandlerType = assembly.GetExportedTypes()
                                                 .FirstOrDefault(_ => _.FullName.Equals(commandHandlerQueryResult.CommandHandlerTypeAssemblyQualifiedName));

                Debug.Assert(commandHandlerType != null);

                var commandHandler = (ICommandHandler) Activator.CreateInstance(commandHandlerType);

                return commandHandler;
            }
            catch (Exception exception)
            {
                throw new FailedToCreateCommandHandlerException(commandHandlerQueryResult.CommandHandlerTypeAssemblyQualifiedName,
                                                                exception);
            }
        }
    }
}