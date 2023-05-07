using _Game.Scripts.Games.GamePlay.UserMode.Event;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using SevenBoldPencil.EasyEvents;

namespace _Game.Scripts.Games.GamePlay.UserMode.Systems
{
    public class UserModeOnChangedSystem : IEcsRunSystem
    {
        private EcsCustomInject<EventsBus> _eventsBus = default;
     
        public void Run(IEcsSystems systems)
        {
            foreach (var eventEntity in _eventsBus.Value.GetEventBodies<UserModeOnChangedEvent>(out var userModeChangeEventPool))
            {
                ref var userModeEvent = ref userModeChangeEventPool.Get(eventEntity);
            }
        }
    }
}