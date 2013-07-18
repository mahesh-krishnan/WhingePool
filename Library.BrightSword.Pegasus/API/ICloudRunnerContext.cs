using BrightSword.Pegasus.Configuration;

namespace BrightSword.Pegasus.API
{
    public interface ICloudRunnerContext : ICommandHandlerContext
    {
        CloudRunnerCommandResultsTable CommandResultsTable { get; }

        CloudRunnerCommandsQueue CommandsQueue { get; }
    }
}