using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;

namespace WhingePool.Core.Configuration
{
    public class AzureApplicationContext
    {
        private readonly CloudStorageAccount _cloudStorageAccount;

        protected AzureApplicationContext(IAzureStorageConfiguration configuration)
        {
            AzureStorageConfiguration = configuration;
            _cloudStorageAccount = new CloudStorageAccount(new StorageCredentials(AzureStorageConfiguration.StorageAccount,
                                                                                  AzureStorageConfiguration.StorageAccountKey),
                                                           true);
        }

        public CloudStorageAccount CloudStorageAccount
        {
            get
            {
                return _cloudStorageAccount;
            }
        }

        public IAzureStorageConfiguration AzureStorageConfiguration { get; private set; }
    }
}