using System;

using Microsoft.WindowsAzure.Storage.Table;

using WhingePool.Core.Configuration;
using WhingePool.Core.Pegasus.API;

namespace WhingePool.Core.Pegasus.Configuration
{
    public class CloudRunnerTask : TableEntity,
                                   ICloudRunnerTask
    {
        internal CompletionStatus InternalCompletionStatus { get; set; }

        public string Name { get; set; }

        public DateTime NextScheduledRuntime { get; set; }

        public string CompletionStatus
        {
            get
            {
                return InternalCompletionStatus.ToString();
            }
            set
            {
                InternalCompletionStatus = (CompletionStatus) Enum.Parse(typeof (CompletionStatus),
                                                                         value);
            }
        }

        public string TaskHandlerName { get; set; }

        public string TaskInputParameters { get; set; }

        public string TaskOutputParameters { get; set; }
    }
}