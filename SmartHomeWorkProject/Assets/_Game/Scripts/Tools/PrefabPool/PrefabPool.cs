using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Game.Scripts.Tools.PrefabPool
{
    public class PrefabPool
    {
        private readonly List<IPrefabPoolable> _poolablesDie = new();
        private readonly List<IPrefabPoolable> _poolablesLife = new();

        public T GetOrCreate<T>(T target) where T : MonoBehaviour, IPrefabPoolable
        {
            var poolObject = _poolablesDie.FirstOrDefault(x => x.Name.Equals(target.Name));
            if (poolObject == default)
            {
                poolObject = Object.Instantiate(target);
                poolObject.Name = target.Name;
                poolObject.OnGoToPool.AddListener(AddToPool);
            }

            _poolablesLife.Add(poolObject);
            var monoBehaviour = (T)poolObject;
            monoBehaviour.gameObject.SetActive(true);
            return monoBehaviour;
        }

        private void AddToPool(IPrefabPoolable prefabPoolable)
        {
            _poolablesDie.Add(prefabPoolable);
        }
    }
}