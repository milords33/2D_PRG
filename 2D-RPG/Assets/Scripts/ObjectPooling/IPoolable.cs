using UnityEngine;
using System;

namespace ObjectPooling
{
    public interface IPoolable
    {
        Transform Transform { get; }
        GameObject GameObject { get; }
        event Action<IPoolable> OnReturnToPool;

        void ReturnToPool();
    }
}
