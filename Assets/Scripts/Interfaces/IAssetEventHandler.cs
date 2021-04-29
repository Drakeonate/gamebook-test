/// <summary>
/// Defines what events an asset needs
/// </summary>
public interface IAssetEventHandler
{
    public delegate void AssetLoadedEventHandler(object sender, AssetLoadedEventArgs e);
    public abstract event AssetLoadedEventHandler AssetLoadedEvent;
}