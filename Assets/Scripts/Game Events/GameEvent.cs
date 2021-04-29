using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// SO Event that can be plugged in anywhere to be
/// raised or listened to
/// </summary>
[CreateAssetMenu(menuName = "Game Events/Simple Game Event")]
public class GameEvent : ScriptableObject
{
    private List<ResponseInvoker> _listeners =
        new List<ResponseInvoker>();

    public void Raise() {
        for(int i = _listeners.Count - 1; i >= 0; i--) {
            _listeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(ResponseInvoker invoker) {
        _listeners.Add(invoker);
    }

    public void UnregisterListener(ResponseInvoker invoker) {
        _listeners.Remove(invoker);
    }
}
