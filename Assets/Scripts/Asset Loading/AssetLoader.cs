using UnityEngine;
/// <summary>
/// Loads all the assets in the asset container
/// </summary>
public class AssetLoader : MonoBehaviour {
    public AssetContainer assetContainer;
    public AssetContainerAnalyzer assetAnalyzer;
    private int readyAssets = 1;
    private void Start() {
        LoadAssets();
    }
    /// <summary>
    /// Load all Assets that are not already in the asset container
    /// and subscribe to events
    /// </summary>
    private void LoadAssets() {
        foreach (var text in assetContainer._jsonTexts.items) {
            var asset = LoadAssetFromJson(text);
            if (!assetAnalyzer.IsAssetExistent(asset, assetContainer))
                assetContainer.assets.Add(asset);
            SubscribeToAssetEvent(asset);
            StartCoroutine(asset.Load());
        }
    }
    /// <summary>
    /// Initialize Assets from Json
    /// </summary>
    /// <param name="text">The Json asset</param>
    /// <returns></returns>
    private Asset LoadAssetFromJson(TextAsset text) {
        Asset asset = JsonHelper.ReadFromJson(text.text);
        if (asset.type == AssetType.Audio)
            asset = JsonHelper.ReadAudioAssetFromJson(text.text);
        return asset;
    }

    /// <summary>
    /// Increment readyAssets and call the LoadAssetsIntoScenes
    /// function so it can load all the assets into the scene once
    /// all assets are loaded
    /// </summary>
    /// <param name="asset">The asset with the event</param>
    private void SubscribeToAssetEvent(Asset asset) {
        asset.AssetLoadedEvent += (sender, e) => {
            LoadAssetsIntoScene();
            ++readyAssets;
        };
    }
    /// <summary>
    /// Load all asset into the scene once all of them are loaded
    /// </summary>
    private void LoadAssetsIntoScene() {
        if (assetContainer.assets.items.Count == readyAssets) {
            foreach (var asset in assetContainer.assets.items) {
                assetContainer.InstantiatedAssets.Add(asset.Instantiate());
            }
        }
    }
}
