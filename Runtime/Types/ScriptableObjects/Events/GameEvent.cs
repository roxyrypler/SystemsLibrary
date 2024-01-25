using System;
using System.Collections.Generic;
using UnityEngine;

namespace Plugins.SystemsLibrary.Runtime.Types.ScriptableObjects.Events
{
    [CreateAssetMenu(menuName = "ModularSystem/Events/GameEvent", fileName = "GameEvent")]
    public class GameEvent: ScriptableObject
    {
        private List<GameEventListener> listeners = new();

        public void Raise()
        {
            Debug.Log(listeners.Count);
            for (int i = listeners.Count - 1; i >= 0; i-- )
            {
                listeners[i].OnEventRaised();
            }
        }

        public void RegisterListener(GameEventListener listener)
        {
            if (!listeners.Contains(listener))
            {
                listeners.Add(listener);
            }
        }

        public void UnregisterListener(GameEventListener listener)
        {
            if (listeners.Contains(listener))
            {
                listeners.Remove(listener);
            }
        }
    }
}