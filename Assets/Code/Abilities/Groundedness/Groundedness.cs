using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Paintime.Abilities
{
    public readonly partial struct Groundedness : IAspect
    {
        public readonly Entity self;
        public readonly RefRO<LocalToWorld> ltw;
        public readonly RefRW<State> state;
        public readonly Data data;

        public struct State : IComponentData
        {
            public bool isGrounded;
            public float nextUngroundTime;

            public State(bool isGrounded, float nextUngroundTime)
            {
                this.isGrounded = isGrounded;
                this.nextUngroundTime = nextUngroundTime;
            }
        }

        public readonly struct Data : ISharedComponentData
        {
            public readonly int points;
            public readonly float3 localStart;
            public readonly float3 localEnd;
            public readonly float ungroundDuration;
            public readonly float groundDistance;
            public readonly float gravity;

            public Data(int points, float3 localStart, float3 localEnd, float ungroundDuration, float groundDistance, float gravity)
            {
                this.points = points;
                this.localStart = localStart;
                this.localEnd = localEnd;
                this.ungroundDuration = ungroundDuration;
                this.groundDistance = groundDistance;
                this.gravity = gravity;
            }
        }
    }
}