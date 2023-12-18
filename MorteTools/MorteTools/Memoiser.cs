using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace MorteTools
{
    public class Memoiser
    {
        public Func<R> Memoise<R>(Func<R> func)
        {
            object cache = null;
            return () =>
            {
                if (cache == null)
                    cache = func();
                return (R)cache;
            };
        }

        public Func<A, R> Memoise<A, R>(Func<A, R> func)
        {
            var cache = new System.Collections.Generic.Dictionary<A, R>();
            return a =>
            {
                if (cache.TryGetValue(a, out R value))
                    return value;
                value = func(a);
                cache.Add(a, value);
                return value;
            };
        }

        public Func<A, R> ThreadSafeMemoise<A, R>(Func<A, R> func)
        {
            var cache = new ConcurrentDictionary<A, R>();
            return argument => cache.GetOrAdd(argument, func);
        }
    }
}