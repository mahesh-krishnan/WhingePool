namespace BrightSword.Pegasus.API
{
    public interface ICommandHandler
    {
        void ProcessCommand(ICommand command,
                            ICloudRunnerContext context);
    }
}