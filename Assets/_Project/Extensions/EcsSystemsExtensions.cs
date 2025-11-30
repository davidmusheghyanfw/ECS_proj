using _Project.Futures.Player.Systems;
using Leopotam.Ecs;

namespace _Project.Extensions
{
    public static class EcsSystemsExtensions {
        public static EcsSystems AddMovementFeature(this EcsSystems systems) {
            return systems.Add(new ReadPlayerInputSystem())
                .Add(new ApplyToTransformSystem());
        }
    }
}