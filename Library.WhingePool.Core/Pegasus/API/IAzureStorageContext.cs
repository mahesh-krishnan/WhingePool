using Microsoft.WindowsAzure.Storage;

namespace WhingePool.Core.Pegasus.API
{
    public interface IAzureStorageContext
    {
        CloudStorageAccount CloudStorageAccount { get; }
    }
}