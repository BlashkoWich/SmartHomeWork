using SevenBoldPencil.EasyEvents;

namespace _Game.Scripts.Games.GamePlay.UserMode.Event
{
    public struct UserModeOnChangedEvent : IEventReplicant
    {
        public UserModeType Type;

        public UserModeOnChangedEvent(UserModeType type)
        {
            Type = type;
        }
    }
}