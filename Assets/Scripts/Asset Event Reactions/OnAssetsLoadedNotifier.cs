using UnityEngine;
using Zenject;
/// <summary>
/// Debugs something to the Log once an asset was loaded
/// </summary>
[RequireComponent(typeof(AssetGameEventListener))]
public class OnAssetsLoadedNotifier : MonoBehaviour
{
    [Inject]
    private AssetGameEventListener _listener;

    public void DebugEvent() {
        Debug.Log(_listener.Event.TransferValue.ToString() + " loaded");
    }
}
