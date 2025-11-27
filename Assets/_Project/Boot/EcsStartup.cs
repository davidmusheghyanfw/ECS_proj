using _Project.Systems;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

public sealed class EcsStartup : MonoBehaviour
{
    private EcsWorld _world;
    private EcsSystems _systems;
    private EcsSystems _systemsLate;

   
    private void Start()
    {
        // 1. Создаём мир
        _world = new EcsWorld();

        // 2. Создаём набор систем
        _systems = new EcsSystems(_world);
        _systemsLate = new EcsSystems(_world);

        _systems.ConvertScene();
        _systemsLate.ConvertScene();

        AddInjections();
        AddOneFrames();
        AddSystems();
        
        _systems.Init();
        _systemsLate.Init();

    }

    private void AddInjections()
    {
        
    }

    private void AddOneFrames()
    {
        
    }
    

    private void AddSystems()
    {
        _systems
            .Add(new PlayerInputSystem())
            .Add(new PlayerMovementSystem());

        _systemsLate.Add(new CameraFollowSystem());
    }
    

    private void Update()
    {
        _systems?.Run();
    }

    private void LateUpdate()
    {
        _systemsLate?.Run();
    }

    private void OnDestroy()
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