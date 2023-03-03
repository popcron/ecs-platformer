using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Physics.Systems;
using UnityEngine;
using RaycastHit = Unity.Physics.RaycastHit;

namespace Paintime.Abilities
{
    [UpdateInGroup(typeof(BeforePhysicsSystemGroup))]
    [UpdateAfter(typeof(BuildPhysicsWorld))]
    public partial class GroundednessSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            var players = SystemAPI.GetComponentLookup<Player.Tag>(true);
            PhysicsWorldSingleton physWorld = SystemAPI.GetSingleton<PhysicsWorldSingleton>();
            CollisionWorld collisionWorld = physWorld.CollisionWorld;

            float3 direction = new(0, -1, 0);
            float time = (float)SystemAPI.Time.ElapsedTime;
            foreach (Groundedness groundedness in SystemAPI.Query<Groundedness>())
            {
                float3 localStart = groundedness.data.localStart;
                float3 localEnd = groundedness.data.localEnd;
                float3 position = groundedness.ltw.ValueRO.Position;
                quaternion rotation = groundedness.ltw.ValueRO.Rotation;
                float3 worldStart = math.mul(rotation, localStart) + position;
                float3 worldEnd = math.mul(rotation, localEnd) + position;
                for (int i = 0; i < groundedness.data.points; i++)
                {
                    float t = (float)i / (groundedness.data.points - 1);
                    float3 origin = math.lerp(worldStart, worldEnd, t);
                    RaycastInput input = new()
                    {
                        Start = origin,
                        End = origin + direction * groundedness.data.groundDistance,
                        Filter = new CollisionFilter
                        {
                            BelongsTo = ~0u,
                            CollidesWith = ~0u,
                            GroupIndex = 0
                        }
                    };

                    Debug.DrawLine(origin, origin + direction * groundedness.data.groundDistance, Color.red);
                    if (collisionWorld.CastRay(input, out RaycastHit hit))
                    {
                        if (!players.HasComponent(hit.Entity))
                        {
                            groundedness.state.ValueRW = new Groundedness.State(true, time + groundedness.data.ungroundDuration);
                        }
                    }
                }

                if (time >= groundedness.state.ValueRW.nextUngroundTime)
                {
                    groundedness.state.ValueRW.isGrounded = false;
                }
            }
        }
    }
}