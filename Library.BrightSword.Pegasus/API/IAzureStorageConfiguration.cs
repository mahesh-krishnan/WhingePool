namespace BrightSword.Pegasus.API
{
    public interface IAzureStorageConfiguration
    {
        string StorageAccount { get; }

        string StorageAccountKey { get; }
    }
}