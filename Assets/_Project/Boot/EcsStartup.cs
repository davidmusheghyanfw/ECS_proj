using System;
using _Project.Extensions;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;
using Zenject;

public sealed class EcsStartup : IInitializable, ITickable, ILateTickable, IDisposable
{
    [Inject] readonly IInputService _inputService;
    
    private EcsWorld _world;
    private EcsSystems _systems;
    private EcsSystems _systemsLate;
    
    public void Initialize()
    {
        _world = new EcsWorld();

        _systems = new EcsSystems(_world);
        _systemsLate = new EcsSystems(_world);

        _systems.ConvertScene();
        _systemsLate.ConvertScene();


        _systems.Inject(_inputService);

        _systems.AddMovementFeature();


        _systems.Init();
        _systemsLate.Init();
    }

    public void Tick()
    {
        _systems?.Run();
    }

    public void LateTick()
    {
        _systemsLate?.Run();
    }

    public void Dispose()
    {
        if (_systems != null)
        {
            _systems.Destroy();
            _systems = null;
        }
        if (_systemsLate != null)
        {
            _systemsLate.Destroy();
            _systemsLate = null;
        }

        if (_world != null)
        {
            _world.Destroy();
            _world = null;
        }
    }
}