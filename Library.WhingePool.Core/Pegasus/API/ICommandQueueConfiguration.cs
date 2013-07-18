namespace WhingePool.Core.Pegasus.API
{
    public interface ICommandQueueConfiguration : ICommandHandlerConfiguration
    {
        string CommandQueueName { get; }

        string CommandResultsTableName { get; }
    }
}