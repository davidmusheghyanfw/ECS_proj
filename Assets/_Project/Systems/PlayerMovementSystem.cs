using Leopotam.Ecs;
using UnityEngine;

public sealed class PlayerMovementSystem : IEcsRunSystem
{
    private readonly EcsFilter<PlayerTag, MoveInput, MoveSpeed, TransformRef> _filter = null;

    public void Run()
    {
        float dt = Time.deltaTime;

        foreach (var i in _filter)
        {
            ref var moveInput = ref _filter.Get2(i);
            ref var moveSpeed = ref _filter.Get3(i);
            ref var trRef     = ref _filter.Get4(i);

            Vector2 input = moveInput.Value;

            // --- 3D (двигаем по XZ) ---
            Vector3 move = new Vector3(input.x, 0f, input.y);

            // --- если делаешь 2D, используй так: ---
            // Vector3 move = new Vector3(input.x, input.y, 0f);

            if (move.sqrMagnitude > 0f)
            {
                trRef.Transform.position += move * moveSpeed.Value * dt;
            }
        }
    }
}