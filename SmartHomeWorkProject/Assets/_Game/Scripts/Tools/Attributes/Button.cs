using System.Reflection;
using UnityEngine;

namespace _Game.Scripts.Tools.Attributes
{
    public class Button : PropertyAttribute
    {
        public string methodName;
        public string buttonName;
        public bool useValue;
        public BindingFlags flags;

        public Button(string methodName, string buttonName, bool useValue = false, BindingFlags flags = BindingFlags.Public | BindingFlags.Instance) {
            this.methodName = methodName;
            this.buttonName = buttonName;
            this.useValue = useValue;
            this.flags = flags;
        }
        public Button(string methodName, bool useValue, BindingFlags flags) : this (methodName, methodName, useValue, flags) {}
        public Button(string methodName, bool useValue) : this (methodName, methodName, useValue) {}
        public Button(string methodName, string buttonName, BindingFlags flags) : this (methodName, buttonName, false, flags) {}
        public Button(string methodName, BindingFlags flags) : this (methodName, methodName, false, flags) {}
        public Button(string methodName) : this (methodName, methodName, false) {}

    }
}