using UnityEngine;
using System;
using System.Collections;
using UnityEngine.Networking;
/// <summary>
/// Asset class for GameObjects
/// </summary>
[Serializable]
public class StandardAsset : Asset {
    /// <summary>
    /// Load the game object file from a web req
    /// </summary>
    /// <returns>Construced as a coroutine so it can wait for the
    /// file to be loaded from the web</returns>
    public override IEnumerator Load() {
        using (_uwr = UnityWebRequestAssetBundle.GetAssetBundle(url)) {
            yield return _uwr.SendWebRequest();
            if (!IsResultASuccess()) {
                Debug.Log(_uwr.error);
            } else {
                var req = DownloadHandlerAssetBundle.GetContent(_uwr)
                    .LoadAllAssetsAsync();
                WaitForContent(req);
                AssetObject = req.asset;
                OnAssetLoaded(new AssetLoadedEventArgs(type));
            }
        }
    }
    public override string ToString() {
        return "Character " + Name
           + " from " + url;
    }
    /// <summary>
    /// Waits for the file download to be done
    /// </summary>
    /// <param name="req">The download handler responsible for the download</param>
    private IEnumerator WaitForContent(AssetBundleRequest req) {
        while (!req.isDone) {
            yield return null;
        }
    }
}
