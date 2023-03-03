using System;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;

namespace Paintime.Abilities
{
    public readonly partial struct Jumping : IAspect
    {
        public readonly Entity self;
        public readonly Data data;
        public readonly Groundedness.Data groundednessData;
        public readonly RefRW<Input> input;
        public readonly RefRW<Groundedness.State> groundedness;
        public readonly RefRW<PhysicsVelocity> velocity;

        public struct Input : IComponentData
        {
            public bool jump;
        }

        public readonly struct Data : ISharedComponentData
        {
            public readonly float jumpHeight;

            public Data(float jumpHeight)
            {
                this.jumpHeight = jumpHeight;
            }
        }
    }
}
