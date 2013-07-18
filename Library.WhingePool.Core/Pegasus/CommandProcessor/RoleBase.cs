using System;

using WhingePool.Core.Configuration;
using WhingePool.Core.Pegasus.API;
using WhingePool.Core.Pegasus.Configuration;
using WhingePool.Core.Pegasus.Services;

namespace WhingePool.Core.Pegasus.CommandProcessor
{
    public abstract class RoleBase : ForeverRunningRole
    {
        protected override void Action()
        {
            ProcessNextCommand(Context);
        }

        internal static void ProcessNextCommand(WhingePoolApplicationContext context)
        {
            var commandAndMessage = context.CommandsQueue.DequeueCommand();
            if (commandAndMessage == null)
            {
                return;
            }

            try
            {
                var completionStatus = InvokeCommandHandler(commandAndMessage.Item1,
                                                            context);

                context.CommandResultsTable.EnsureInstance(new CloudRunnerCommandResult(commandAndMessage.Item1,
                                                                                        completionStatus));
            }
            finally
            {
                context.CommandsQueue.DeleteCommandMessage(commandAndMessage.Item2);
            }
        }

        internal static CompletionStatus InvokeCommandHandler(ICommand command,
                                                              WhingePoolApplicationContext context)
        {
            if (String.IsNullOrWhiteSpace(command.CommandName))
            {
                return CompletionStatus.Warning_NoHandlerSpecified;
            }

            ICommandHandler commandHandler;
            try
            {
                commandHandler = command.GetCommandHandler(context);
            }
            catch
            {
                return CompletionStatus.Error_HandlerCouldNotBeLoaded;
            }

            try
            {
                commandHandler.ProcessCommand(command,
                                              context);

                return CompletionStatus.Completed;
            }
            catch (Exception)
            {
                return CompletionStatus.Error_HandlerNotInvokedSuccessfully;
            }
        }
    }
}