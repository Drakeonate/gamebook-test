using System.Linq;
using UnityEngine;
/// <summary>
/// Asset anaylzer used to apply functions to the asset container
/// Can be plugged in anywhere if you need to analyze the container
/// Isn't seperation of functions and data amazing?
/// </summary>
[CreateAssetMenu(menuName = "Assets/Asset Analyzer")]
public class AssetContainerAnalyzer : ScriptableObject
{
    public bool IsAssetExistent(Asset asset, AssetContainer container)
        => container.assets.items.Any(e => (Asset)e == asset);
}
