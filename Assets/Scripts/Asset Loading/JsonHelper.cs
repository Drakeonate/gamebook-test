using UnityEngine;
/// <summary>
/// Helper class that can Create Assets from Jsons
/// Put more functions here if you want to load more kinds of assets
/// </summary>
public static class JsonHelper
{
    public static StandardAsset ReadFromJson(string JSONString) {
        return JsonUtility.FromJson<StandardAsset>(JSONString);
    }
    public static AudioAsset ReadAudioAssetFromJson(string JSONString) {
        return JsonUtility.FromJson<AudioAsset>(JSONString);
    }
}
