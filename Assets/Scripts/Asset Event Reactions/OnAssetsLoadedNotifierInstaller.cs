using Zenject;
/// <summary>
/// Injects the dependency of AssetGameEventListener to OnAssetsLoadedNotifier
/// </summary>
public class OnAssetsLoadedNotifierInstaller : MonoInstaller
{
    public override void InstallBindings() {
        Container.Bind<OnAssetsLoadedNotifier>().FromComponentInChildren().AsSingle();
    }
}
