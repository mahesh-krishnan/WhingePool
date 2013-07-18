using Microsoft.WindowsAzure.Storage;

namespace BrightSword.Pegasus.API
{
    public interface IAzureStorageContext
    {
        CloudStorageAccount CloudStorageAccount { get; }
    }
}