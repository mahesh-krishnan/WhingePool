﻿using BrightSword.Pegasus.API;

namespace WhingePool.Core.API
{
    public interface IWhingePool : ICommandArgument
    {
        string Name { get; set; }
    }
}