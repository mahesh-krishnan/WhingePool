namespace WhingePool.Core.Pegasus.API
{
    public interface IAzureStorageConfiguration
    {
        string StorageAccount { get; }

        string StorageAccountKey { get; }
    }
}