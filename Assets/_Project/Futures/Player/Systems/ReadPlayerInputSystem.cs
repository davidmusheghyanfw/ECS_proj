using System;
using Leopotam.Ecs;
using UniRx;
using UnityEngine;
using _Project.Futures.Player.Components;

namespace _Project.Futures.Player.Systems
{
    public class ReadPlayerInputSystem : IEcsInitSystem, IEcsRunSystem, IEcsDestroySystem
    {
        private readonly EcsWorld _world = null;
        private readonly IInputService _inputService = null;
        
        private readonly EcsFilter<PlayerTag, PositionRef, MoveSpeedRef> _playerFilter = null;

        private Vector2 _latestInput = Vector2.zero;
        private IDisposable _inputSubscription;

        public void Init()
        {
            _inputSubscription = _inputService.MoveAxis
                .Subscribe(input => _latestInput = input);
        }

        public void Run()
        {
            foreach (var i in _playerFilter)
            {
                ref var positionRef = ref _playerFilter.Get2(i);
                ref var moveSpeedRef = ref _playerFilter.Get3(i);
                
                var movement = new Vector3(_latestInput.x, 0f, _latestInput.y);
                
                if (movement.magnitude > 1f)
                {
                    movement.Normalize();
                }
                
                positionRef.position += movement * (moveSpeedRef.moveSpeed * Time.deltaTime); 
            }
        }

        public void Destroy()
        {
            _inputSubscription?.Dispose();
        }
    }
}