using Leopotam.Ecs;
using UnityEngine;

public sealed class PlayerInputSystem : IEcsRunSystem
{
    private readonly EcsFilter<PlayerTag, MoveInput> _filter = null;

    public void Run()
    {
        foreach (var i in _filter)
        {
            // Get2, потому что второй компонент в фильтре — MoveInput
            ref var moveInput = ref _filter.Get2(i);

            var dir = new Vector2(
                Input.GetAxisRaw("Horizontal"),
                Input.GetAxisRaw("Vertical")
            );

            if (dir.sqrMagnitude > 1f)
                dir.Normalize();

            moveInput.Value = dir;
        }
    }
}