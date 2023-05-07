using _Game.Scripts.Games.GamePlay.UI.UserModeSelector.Components;
using _Game.Scripts.Games.GamePlay.UI.UserModeSelector.Mono;
using _Game.Scripts.Games.GamePlay.UserMode;
using _Game.Scripts.Games.GamePlay.UserMode.Event;
using _Game.Scripts.Tools.MonoProvider;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using SevenBoldPencil.EasyEvents;
using UnityEngine;

namespace _Game.Scripts.Games.GamePlay.UI.UserModeSelector.Systems
{
    public class UserModeSelectorPanelInitSystem : IEcsInitSystem
    {
        private EcsCustomInject<InSceneObjects> _inSceneObjects = default;
        private EcsCustomInject<EventsBus> _eventsBus = default;

        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();

            var userModeSelectorPanelEntity = world.NewEntity();
           
            var poolUserModeSelectorPanel = world.GetPool<UserModeSelectorPanelComponent>();
            ref var userModeSelectorPanelComponent = ref poolUserModeSelectorPanel.Add(userModeSelectorPanelEntity);
            _inSceneObjects.Value.Test();
            userModeSelectorPanelComponent.UserModeSelectorPanel = _inSceneObjects.Value.Get<UserModeSelectorPanel>();
            
            var selectorButtons = userModeSelectorPanelComponent.UserModeSelectorPanel.UserModeSelectorButtons;
            foreach (var button in selectorButtons)
            {
               button.OnSelectUserMode.AddListener(CreateUserModeChangeEvent);
            }
        }

        private void CreateUserModeChangeEvent(UserModeType type)
        {
            var userModeChangeEvent = new UserModeChangeEvent(type);
            _eventsBus.Value.NewEvent<UserModeChangeEvent>() = userModeChangeEvent;
        }
    }
}