using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// Defines a class that can invoke a UnityEvent
/// </summary>
public abstract class ResponseInvoker : MonoBehaviour
{
    public UnityEvent Response;
    public void OnEventRaised() {
        Response.Invoke();
    }
}
