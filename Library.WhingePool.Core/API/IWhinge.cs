using WhingePool.Core.Commands;

namespace WhingePool.Core.API
{
    public interface IWhinge : ICommandArgument
    {
        string Whinge { get; set; }
        string Whinger { get; set; }
        string WhingePool { get; set; }
    }


}