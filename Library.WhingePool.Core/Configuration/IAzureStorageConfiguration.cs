namespace WhingePool.Core.Configuration
{
    public interface IAzureStorageConfiguration
    {
        string StorageAccount { get; set; }

        string StorageAccountKey { get; set; }
    }
}