using _Game.Scripts.Games.GamePlay.UserMode;
using _Game.Scripts.Tools.CustomButton;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _Game.Scripts.Games.GamePlay.UI.UserModeSelector.Mono
{
    public class UserModeSelectorButton : ButtonCustom
    {
        [SerializeField] private UserModeType userModeType;
        public UnityEvent<UserModeType> OnSelectUserMode { get; } = new();

        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);
            
            OnSelectUserMode.Invoke(userModeType);
        }
    }
}