using System;

using WhingePool.Core.API;

namespace WhingePool.Core.Commands
{
    public class SaveWhingeCommand : BaseCommand<IWhinge>
    {
        public SaveWhingeCommand(IWhinge whinge)
            : base(whinge)
        {
            if (whinge.Whinge.Length > 150)
            {
                throw new WhingeTooLongException(whinge.Whinge,
                                                 150);
            }
        }
    }

    public class WhingeTooLongException : Exception
    {
        public WhingeTooLongException(string whinge,
                                      int maxLength)
        {
            Whinge = whinge;
            MaxLength = maxLength;
        }

        public string Whinge { get; set; }
        public int MaxLength { get; set; }
    }
}