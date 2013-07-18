﻿namespace BrightSword.Pegasus.API
{
    public interface ICommandService<T>
        where T : ICommandArgument
    {
        ISaveResult Save(T instance);
    }
}