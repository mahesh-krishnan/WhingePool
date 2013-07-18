using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;

using WhingePool.Core.Pegasus.API;

namespace WhingePool.Core.Pegasus.Configuration
{
    public class AzureStorageContext : IAzureStorageContext
    {
        private readonly CloudStorageAccount _cloudStorageAccount;

        protected AzureStorageContext(IAzureStorageConfiguration configuration)
        {
            _cloudStorageAccount = new CloudStorageAccount(new StorageCredentials(configuration.StorageAccount,
                                                                                  configuration.StorageAccountKey),
                                                           true);
        }

        public CloudStorageAccount CloudStorageAccount
        {
            get { return _cloudStorageAccount; }
        }
    }
}