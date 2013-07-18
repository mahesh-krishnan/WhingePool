using WhingePool.Core.API;
using WhingePool.Core.Entities;
using WhingePool.Core.Pegasus.Commands;

namespace WhingePool.Core.Commands
{
    public class SaveWhingeCommand : Command<WhingeEntity>
    {
        public SaveWhingeCommand(WhingeEntity whinge)
            : base(whinge)
        {
            if (whinge.Whinge.Length > 150)
            {
                throw new WhingeTooLongException(whinge.Whinge,
                                                 150);
            }
        }
    }
}