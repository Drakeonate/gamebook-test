/// <summary>
/// Generic game event that can store a value
/// </summary>
/// <typeparam name="T">Type of the value stored</typeparam>
public class TransferingGameEvent<T> : GameEvent {
    public T TransferValue;

    public void Raise(T transferValue) {
        TransferValue = transferValue;
        Raise();
    }
}
