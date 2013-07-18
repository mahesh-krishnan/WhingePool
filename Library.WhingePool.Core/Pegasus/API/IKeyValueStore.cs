using System;

namespace WhingePool.Core.Pegasus.API
{
    public interface IKeyValueStore
    {
        T GetOrAdd<T>(string key,
                      Func<T> valueFactory);
    }
}