using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Args sent through the AssetLoadedEvent
/// </summary>
public class AssetLoadedEventArgs {
    public AssetLoadedEventArgs(string type) { Type = type; }
    public string Type { get; }
}
