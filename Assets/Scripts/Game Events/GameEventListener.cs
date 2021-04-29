using UnityEngine;
/// <summary>
/// Basic game event listener that registers itself to the
/// game event
/// </summary>
public class GameEventListener : ResponseInvoker
{
    public GameEvent Event;
    private void OnEnable() {
        Event.RegisterListener(this);
    }

    private void OnDisable() {
        Event.UnregisterListener(this);
    }
}
