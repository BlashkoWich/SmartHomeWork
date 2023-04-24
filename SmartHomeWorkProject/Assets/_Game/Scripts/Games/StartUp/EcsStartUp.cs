using _Game.Scripts.Games.GamePlay.UI.UserModeSelector.Systems;
using _Game.Scripts.Games.GamePlay.UserMode.Event;
using _Game.Scripts.Games.GamePlay.UserMode.Systems;
using _Game.Scripts.Tools.MonoProvider;
using _Game.Scripts.Tools.PrefabPool;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using SevenBoldPencil.EasyEvents;
using UnityEngine;

namespace _Game.Scripts.Games.StartUp
{
    public class EcsStartUp : MonoBehaviour
    {
        [SerializeField] private InSceneObjects inSceneObjects;
        
        private EcsSystems _systemsUpdate;

        private readonly PrefabPool _prefabPool = new();
        private readonly EventsBus _eventsBus = new();

        private void Start()
        {
            InitEcs();
        }

        private void InitEcs()
        {
            CreateWorldAndSystems();
            AddSystems();
            AddInject();
            AddEvents();
            InitSystems();
            
            void CreateWorldAndSystems()
            {
                var world = new EcsWorld();
                _systemsUpdate = new EcsSystems(world);
            }

            void AddSystems()
            {
                _systemsUpdate
                    .Add(new UserModeInitSystem())
                    .Add(new UserModeSelectorPanelInitSystem())
                    .Add(new UserModeChangeSystem());
            }

            void AddInject()
            {
                _systemsUpdate.Inject(
                    _prefabPool, 
                    inSceneObjects,
                    _eventsBus);
            }

            void AddEvents()
            {
                _systemsUpdate.Add(_eventsBus.GetDestroyEventsSystem()
                    .IncReplicant<UserModeChangeEvent>()
                    .IncReplicant<UserModeOnChangedEvent>());
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
            _eventsBus.Destroy();
            _systemsUpdate = null;
        }
    }
}