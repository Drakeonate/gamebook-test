using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
/// <summary>
/// Container that stores the Json texts defined by the user
/// and has references to the intitialized assets
/// </summary>
[CreateAssetMenu(menuName = "Assets/Asset Container")]
public class AssetContainer : ScriptableObject
{
    public TextAssetSet _jsonTexts;

    public AssetRuntimeSet assets;
    public GameObjectRuntimeSet InstantiatedAssets;
    
    public int AssetCount {
        get => assets.items.Count;
        set {
            if (assets.items.Count > value) {
                assets.items.RemoveRange(value, assets.items.Count - value);
            }
        }
    }
}
