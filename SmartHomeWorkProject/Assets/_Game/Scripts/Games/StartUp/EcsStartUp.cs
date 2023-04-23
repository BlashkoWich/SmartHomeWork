using _Game.Scripts.Tools.PrefabPool;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace _Game.Scripts.Games.StartUp
{
    public class EcsStartUp : MonoBehaviour
    {
        private EcsSystems _systemsUpdate;

        private readonly PrefabPool _prefabPool = new();

        private void Start()
        {
            InitEcs();
        }

        private void InitEcs()
        {
            CreateWorldAndSystems();
            AddSystems();
            AddInject();
            InitSystems();
            
            void CreateWorldAndSystems()
            {
                var world = new EcsWorld();
                _systemsUpdate = new EcsSystems(world);
            }

            void AddSystems()
            {
            }

            void AddInject()
            {
                _systemsUpdate.Inject(_prefabPool);
            }

            void InitSystems()
            {
                _systemsUpdate.Init();
            }
        }

        private void Update()
        {
            _systemsUpdate?.Run();
        }

        private void OnDestroy()
        {
            _systemsUpdate?.Destroy();
            _systemsUpdate?.GetWorld()?.Destroy();
            _systemsUpdate = null;
        }
    }
}