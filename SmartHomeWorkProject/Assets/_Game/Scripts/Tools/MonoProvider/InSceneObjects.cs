using System.Linq;
using UnityEngine;

namespace _Game.Scripts.Tools.MonoProvider
{
    public class InSceneObjects : MonoBehaviour
    {
        [SerializeField] private MonoProvider[] monoProviders;

        public T Get<T>() where T : MonoProvider
        {
            return monoProviders.OfType<T>().FirstOrDefault();
        }
    }
}