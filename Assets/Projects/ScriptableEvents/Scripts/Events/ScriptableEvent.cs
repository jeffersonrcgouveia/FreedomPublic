using System.Collections.Generic;
using ScriptableEvents.Listeners;
using UnityEngine;
using static ScriptableEvents.Constants.ScriptableEventsConstants;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(menuName = MenuName + ScriptableEventName, fileName = ScriptableEventName, order = 0)]
    public class ScriptableEvent : ScriptableObject
    {
        List<ScriptableEventListener> Listeners { get; set; } = new List<ScriptableEventListener>();

        public void Invoke()
        {
            for (int i = Listeners.Count - 1; i >= 0; i--) Listeners[i].InvokeResponse();
        }

        public void AddListener(ScriptableEventListener listener) => Listeners.Add(listener);

        public void RemoveListener(ScriptableEventListener listener) => Listeners.Remove(listener);
    }
}
