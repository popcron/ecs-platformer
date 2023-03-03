using Unity.Entities;
using Unity.Physics;

namespace Paintime.Abilities
{
    public readonly partial struct GroundedMovement : IAspect
    {
        public readonly Entity self;
        public readonly RefRW<Input> input;
        public readonly RefRW<PhysicsVelocity> velocity;
        public readonly Data data;

        public struct Input : IComponentData
        {
            public float horizontal;
        }

        public readonly struct Data : ISharedComponentData
        {
            public readonly float speed;
            public readonly float acceleration;

            public Data(float speed, float acceleration)
            {
                this.speed = speed;
                this.acceleration = acceleration;
            }
        }
    }
}
