using WhingePool.Core.Pegasus.Configuration;

namespace WhingePool.Core.Pegasus.API
{
    public interface ICloudRunnerContext
    {
        CloudRunnerCommandResultsTable CommandResultsTable { get; }

        CloudRunnerCommandsQueue CommandsQueue { get; }
    }
}