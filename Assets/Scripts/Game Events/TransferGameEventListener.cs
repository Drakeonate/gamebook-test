using System.Collections;
/// <summary>
/// Game event listener that can listen for events that
/// transfer/hold information
/// </summary>
/// <typeparam name="T"></typeparam>
public class TransferGameEventListener<T> : ResponseInvoker
{
    public TransferingGameEvent<T> Event;

    private void OnEnable() {
        Event.RegisterListener(this);
    }

    private void OnDisable() {
        Event.UnregisterListener(this);
    }
}
