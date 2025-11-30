using UnityEngine;
using Zenject;

public class BootstrapScope : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<UnityInputService>().AsSingle();
        Container.BindInterfacesAndSelfTo<EcsStartup>().AsSingle();
    }
}
