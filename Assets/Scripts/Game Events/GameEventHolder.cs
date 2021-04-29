using UnityEngine;
/// <summary>
/// Holds an asset game event so we can get it
/// from the scene and not from Resources.Load().
/// Resources.Load() is too resource heavy
/// </summary>
public class GameEventHolder : MonoBehaviour
{
    public AssetGameEvent gameEvent;
}
