using UnityEngine.Events;

namespace _Game.Scripts.Tools.PrefabPool
{
    public interface IPrefabPoolable
    {
        public string Name { get; set; }
        public UnityEvent<IPrefabPoolable> OnGoToPool { get; }
    }
}