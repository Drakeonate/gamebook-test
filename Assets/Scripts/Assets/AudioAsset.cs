using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
/// <summary>
/// Asset that only loads Audio files
/// </summary>
[System.Serializable]
public class AudioAsset : Asset {
    /// <summary>
    /// Load the audio file from a web req
    /// </summary>
    /// <returns>Construced as a coroutine so it can wait for the
    /// file to be loaded from the web</returns>
    public override IEnumerator Load() {
        using (_uwr = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.UNKNOWN)) {
            yield return _uwr.SendWebRequest();
            if (!IsResultASuccess()) {
                Debug.Log(_uwr.error);
            } else {
                var req = _uwr.downloadHandler as DownloadHandlerAudioClip;
                WaitForContent(req);
                AssetObject = req.audioClip;
                OnAssetLoaded(new AssetLoadedEventArgs(type));
            }
        }
    }
    /// <summary>
    /// Instantiates an empty GO with an AudioSource where the audio 
    /// is then played on
    /// </summary>
    /// <returns></returns>
    public override GameObject Instantiate() {
        if(!base.Instantiate())
            InstantiatedAsset = new GameObject();
        AudioSource audiosource = InstantiatedAsset.AddComponent<AudioSource>();
        audiosource.clip = (AudioClip)AssetObject;
        audiosource.Play();
        return InstantiatedAsset;
    }
    public override string ToString() {
        return "Audio " + Name
           + " from " + url;
    }

    /// <summary>
    /// Waits for the file download to be done
    /// </summary>
    /// <param name="req">The download handler responsible for the download</param>
    private IEnumerator WaitForContent(DownloadHandlerAudioClip req) {
        while (!req.isDone) {
            yield return null;
        }
    }
}