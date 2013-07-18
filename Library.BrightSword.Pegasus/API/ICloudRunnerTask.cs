namespace WhingePool.Core.Pegasus.API
{
    public interface ICloudRunnerTask
    {
        string TaskHandlerName { get; set; }

        string TaskInputParameters { get; set; }

        string TaskOutputParameters { get; set; }
    }
}