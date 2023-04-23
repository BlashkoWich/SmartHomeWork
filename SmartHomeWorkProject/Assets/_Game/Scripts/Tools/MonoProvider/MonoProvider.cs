using _Game.Scripts.Tools.PrefabPool;
using UnityEngine;
using UnityEngine.Events;

namespace _Game.Scripts.Tools.MonoProvider
{
    public abstract class MonoProvider : MonoBehaviour, IPrefabPoolable
    {
        public string Name
        {
            get => gameObject.name;
            set => gameObject.name = value;
        }
        public UnityEvent<IPrefabPoolable> OnGoToPool { get; } =new();
    }
}