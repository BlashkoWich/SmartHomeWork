using System;
using _Game.Scripts.Games.GamePlay.UserMode;
using _Game.Scripts.Tools.MonoProvider;
using UnityEngine;
using UnityEngine.Events;

namespace _Game.Scripts.Games.GamePlay.UI.UserModeSelector.Mono
{
    public class UserModeSelectorPanel : MonoProvider
    {
        [field: SerializeField] public UserModeSelectorButton[] UserModeSelectorButtons { get; private set; }
    }
}