using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ObjectPooling
{
    public class PoolTask
    {
        private readonly List<IPoolable> _freeObject;
        private readonly Transform _container;

        public PoolTask(Transform container)
        {
            _freeObject = new List<IPoolable>();
            _container = container;
        }

        public T GetFreeObject<T>(T prefab) where T : MonoBehaviour, IPoolable
        {
            T poolObject = null;
            if (_freeObject.Count > 0)
            {

                poolObject = _freeObject.Last() as T;
                poolObject.GameObject.SetActive(true);
                _freeObject.Remove(poolObject);
            }
            poolObject ??= Object.Instantiate(prefab);
            poolObject.OnReturnToPool += ReturnToPool;

            return poolObject as T;

        }

        private void ReturnToPool(IPoolable poolObject)
        {
            _freeObject.Add(poolObject);
            poolObject.GameObject.SetActive(false);
            poolObject.Transform.SetParent(_container);
            poolObject.OnReturnToPool -= ReturnToPool;
        }
    }
}
