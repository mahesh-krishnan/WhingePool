namespace BrightSword.Pegasus.API
{
    public interface ICloudRunnerConfiguration : ICommandHandlerConfiguration
    {
        string CommandQueueName { get; }

        string CommandResultsTableName { get; }
    }
}