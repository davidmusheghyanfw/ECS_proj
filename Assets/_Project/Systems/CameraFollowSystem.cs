using _Project.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace _Project.Systems
{
    public class CameraFollowSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, TransformRef>  _filter = null;
        private readonly EcsFilter<CameraRef>  _cameraFilert = null;
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var playerTransform = ref _filter.Get2(i);
                foreach (var c in _cameraFilert)
                {
                    ref var camera = ref _cameraFilert.Get1(c);
                    
                    // position
                    camera.camera.transform.position = playerTransform.Transform.position + camera.gapToPlayer;
                    // rotation
                    camera.camera.transform.rotation = Quaternion.Euler(camera.rotation);
                }
            }
            
        }
    }
}