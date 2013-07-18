using System;

namespace BrightSword.Pegasus.API
{
    public interface IKeyValueStore
    {
        T GetOrAdd<T>(string key,
                      Func<T> valueFactory);
    }
}