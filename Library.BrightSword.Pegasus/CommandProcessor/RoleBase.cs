using System;

using BrightSword.Pegasus.API;
using BrightSword.Pegasus.Configuration;
using BrightSword.Pegasus.Services;

namespace BrightSword.Pegasus.CommandProcessor
{
    public abstract class CommandProcessorRole : ForeverRunningRole
    {
        protected override void Action()
        {
            ProcessNextCommand(Context);
        }

        internal static void ProcessNextCommand(ICloudRunnerContext context)
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
                                                              ICloudRunnerContext context)
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