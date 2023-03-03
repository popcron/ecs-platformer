using Unity.Entities;
using Unity.Mathematics;

namespace Paintime.Abilities
{
    public partial class JumpingSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            foreach (var q in SystemAPI.Query<Jumping, RefRO<PlayerInputState>>())
            {
                PlayerInputState inputState = q.Item2.ValueRO;
                Jumping jumping = q.Item1;
                jumping.input.ValueRW.jump = inputState.jump;
            }

            foreach (var jumping in SystemAPI.Query<Jumping>())
            {
                ref bool jump = ref jumping.input.ValueRW.jump;
                if (jump && jumping.groundedness.ValueRO.isGrounded)
                {
                    jump = false;
                    DoJump(jumping);
                }
            }
        }

        private void DoJump(Jumping jumping)
        {
            ref float3 velocity = ref jumping.velocity.ValueRW.Linear;
            float jumpHeight = jumping.data.jumpHeight;
            float jumpVelocity = math.sqrt(2f * math.abs(jumping.groundednessData.gravity) * jumpHeight);
            velocity.y = jumpVelocity * math.sign(jumping.groundednessData.gravity);
            jumping.groundedness.ValueRW.isGrounded = false;
        }
    }
}
