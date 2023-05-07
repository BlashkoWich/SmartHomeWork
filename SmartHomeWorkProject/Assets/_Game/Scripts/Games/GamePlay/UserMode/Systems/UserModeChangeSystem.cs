using _Game.Scripts.Games.GamePlay.UserMode.Components;
using _Game.Scripts.Games.GamePlay.UserMode.Event;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using SevenBoldPencil.EasyEvents;

namespace _Game.Scripts.Games.GamePlay.UserMode.Systems
{
    public class UserModeChangeSystem : IEcsRunSystem
    {
        private EcsCustomInject<EventsBus> _eventsBus = default;
     
        public void Run(IEcsSystems systems)
        {
            foreach (var eventEntity in _eventsBus.Value.GetEventBodies<UserModeChangeEvent>(out var userModeChangeEventPool))
            {
                ref var userModeEvent = ref userModeChangeEventPool.Get(eventEntity);

                var world = systems.GetWorld();
                
                var filter = world.Filter<UserModeComponent>().End();
                var poolUserModeComponent = world.GetPool<UserModeComponent>();

                foreach (var entity in filter)
                {
                    ref var userModeComponent = ref poolUserModeComponent.Get(entity);
                    userModeComponent.UserModeType = userModeEvent.ToType;

                    var userModeOnChangedEvent = new UserModeOnChangedEvent(userModeComponent.UserModeType);
                    _eventsBus.Value.NewEvent<UserModeOnChangedEvent>() = userModeOnChangedEvent;
                }
            }
        }
    }
}