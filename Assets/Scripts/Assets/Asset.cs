using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
/// <summary>
/// Abstract class for an asset pulled from a JSon Object
/// Implements the IAsset interface for event handling, loading, and instantiation
/// ALso implements IEquatable for comparison functions
/// </summary>
public abstract class Asset : IAsset, IEquatable<Asset> {
    public string Name;
    public string type;
    public string url;
    public GameObject InstantiatedAsset { get; protected set; }
    public UnityWebRequest _uwr;
    public event IAssetEventHandler.AssetLoadedEventHandler AssetLoadedEvent;
    public AssetGameEvent OnAssetLoadedGameEvent;
    private UnityEngine.Object _assetObject;
    public UnityEngine.Object AssetObject {
        get => _assetObject;
        set {
            if (_assetObject == null) {
                _assetObject = value;
            }
        }
    }

    public Asset() {
        OnAssetLoadedGameEvent = GameObject.FindGameObjectWithTag("OnAssetLoadedEventHandler")
            .GetComponent<GameEventHolder>().gameEvent;
    }

    public virtual GameObject Instantiate() {
        if (!AssetObject)
            return null;
        InstantiatedAsset = GameObject.Instantiate(AssetObject, Vector3.zero, Quaternion.identity) as GameObject;
        return InstantiatedAsset;
    }
    public static bool operator ==(Asset obj1, Asset obj2) {
        if (ReferenceEquals(obj1, obj2)) {
            return true;
        }
        if (ReferenceEquals(obj1, null)) {
            return false;
        }
        if (ReferenceEquals(obj2, null)) {
            return false;
        }

        return obj1.Equals(obj2);
    }
    public static bool operator !=(Asset obj1, Asset obj2) {
        return !(obj1 == obj2);
    }
    public bool Equals(Asset other) {
        if (ReferenceEquals(other, null)) {
            return false;
        }
        if (ReferenceEquals(this, other)) {
            return true;
        }

        return Name.Equals(other.Name)
               && Name.Equals(other.Name)
               && type.Equals(other.type);
    }
    public override bool Equals(object obj) {
        return Equals(obj as Asset);
    }
    public override int GetHashCode() {
        unchecked {
            int hashCode = Name.GetHashCode();
            hashCode = (hashCode * 397) ^ type.GetHashCode();
            hashCode = (hashCode * 397) ^ Name.GetHashCode();
            return hashCode;
        }
    }
    public abstract IEnumerator Load();
    public abstract override string ToString();
    protected virtual void OnAssetLoaded(AssetLoadedEventArgs e) {
        AssetLoadedEvent?.Invoke(this, e);
        OnAssetLoadedGameEvent.Raise(this);
    }
    protected bool IsResultASuccess() => _uwr.result == UnityWebRequest.Result.Success;
}
