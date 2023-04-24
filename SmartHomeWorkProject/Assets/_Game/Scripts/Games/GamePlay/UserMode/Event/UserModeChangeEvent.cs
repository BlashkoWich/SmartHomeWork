using SevenBoldPencil.EasyEvents;

namespace _Game.Scripts.Games.GamePlay.UserMode.Event
{
    public struct UserModeChangeEvent : IEventReplicant
    {
        public UserModeType ToType;

        public UserModeChangeEvent(UserModeType toType)
        {
            ToType = toType;
        }
    }
}