namespace WhingePool.Core.Configuration
{
    public interface IPegasusConfiguration : IAzureStorageConfiguration
    {
        string ScheduledTasksQueueName { get; set; }

        string RegisteredHandlersTableName { get; set; }

        string RegisteredHandlersBlobContainerName { get; set; }

        string RuntimeErrorsTableName { get; set; }
    }
}