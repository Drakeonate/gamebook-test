using System.Collections;
/// <summary>
/// Defines what a loadable asset needs to be loaded
/// </summary>
public interface ILoadableAsset
{
    IEnumerator Load();
}
