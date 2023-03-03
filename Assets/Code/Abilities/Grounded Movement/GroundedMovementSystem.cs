using Unity.Entities;
using Unity.Mathematics;

namespace Paintime.Abilities
{
    public partial class GroundedMovementSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            float deltaTime = SystemAPI.Time.DeltaTime;
            foreach (var q in SystemAPI.Query<GroundedMovement, RefRO<PlayerInputState>>())
            {
                PlayerInputState inputState = q.Item2.ValueRO;
                GroundedMovement groundedMovement = q.Item1;
                groundedMovement.input.ValueRW.horizontal = inputState.horizontalMovement;
            }

            foreach (var groundedMovement in SystemAPI.Query<GroundedMovement>())
            {
                ref float3 velocity = ref groundedMovement.velocity.ValueRW.Linear;
                float horizontal = groundedMovement.input.ValueRW.horizontal;
                float speed = groundedMovement.data.speed;
                float acceleration = groundedMovement.data.acceleration;
                float desiredX = math.clamp(horizontal, -1, 1) * speed;
                velocity.x = math.lerp(velocity.x, desiredX, acceleration * deltaTime);
            }
        }
    }
}
