using System;

namespace WhingePool.Core.API
{
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