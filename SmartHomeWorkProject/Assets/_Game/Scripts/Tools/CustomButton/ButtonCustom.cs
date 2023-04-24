using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _Game.Scripts.Tools.CustomButton
{
    [ExecuteAlways]
    public class ButtonCustom : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
    {
        [SerializeField] private Animator animator;
        [Attributes.Button(nameof(UpdateManually))] public bool UpdateButton;
        [field: SerializeField] public UnityEvent OnClick { get; private set; }
        private ButtonBaseState state;
        private static readonly int Pressed = Animator.StringToHash("Pressed");

        private void OnEnable()
        {
            Activate();
        }

        private void OnDisable()
        {
            Deactivate();
        }

        private void Activate()
        {
            state.IsActivated = true;
        }

        private void Deactivate()
        {
            state = default;

            state.IsActivated = false;
        }

        public void UpdateManually()
        {
            Activate();
        }

        public void SetEnabled(bool isActive)
        {
            state.IsDisabled = !isActive;
        }

        public virtual void OnPointerDown(PointerEventData eventData)
        {
            if(!IsActivated())
                return;
            
            UpdatePressedState(true);
        }

        private bool IsActivated()
        {
            return state.IsActivated;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if(!IsActivated())
                return;
            
            UpdatePressedState(false);
        }

        private void UpdatePressedState(bool isPressed)
        {
            state.IsPressed = isPressed;

            if (!animator) return;
            animator.SetBool(Pressed, isPressed);
        }


        public void OnPointerClick(PointerEventData eventData)
        {
            if(!IsActivated())
                return;
            
            OnClick.Invoke();
        }
        
        private struct ButtonBaseState
        {
            public bool IsPressed;
            public bool IsDisabled;
            public bool IsActivated;
        }

    }
}