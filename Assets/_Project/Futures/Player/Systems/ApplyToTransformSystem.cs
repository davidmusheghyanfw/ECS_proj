using Leopotam.Ecs;
using UnityEngine;
using _Project.Futures.Player.Components;

namespace _Project.Futures.Player.Systems
{
    public class ApplyToTransformSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, PositionRef, TransformRef> _playerFilter = null;

        public void Run()
        {
            foreach (var i in _playerFilter)
            {
                ref var positionRef = ref _playerFilter.Get2(i);
                ref var transformRef = ref _playerFilter.Get3(i);

                if (transformRef.value != null)
                {
                    transformRef.value.position = positionRef.position;
                }
            }
        }
    }
}
