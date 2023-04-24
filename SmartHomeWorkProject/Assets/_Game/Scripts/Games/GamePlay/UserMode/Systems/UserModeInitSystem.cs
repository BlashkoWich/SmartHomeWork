using _Game.Scripts.Games.GamePlay.UserMode.Components;
using Leopotam.EcsLite;

namespace _Game.Scripts.Games.GamePlay.UserMode.Systems
{
    public class UserModeInitSystem : IEcsPreInitSystem
    {
        public void PreInit(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var userModeEntity = world.NewEntity();

            var userModeComponentPool = world.GetPool<UserModeComponent>();
            ref var userModeComponent = ref userModeComponentPool.Add(userModeEntity);
            userModeComponent.UserModeType = UserModeType.NotSelected;
        }
    }
}