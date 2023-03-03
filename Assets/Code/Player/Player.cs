using Unity.Entities;

namespace Paintime.Abilities
{
    public readonly partial struct Player : IAspect
    {
        public readonly Entity self;

        private readonly RefRO<Tag> tag;

        public readonly struct Tag : IComponentData
        {

        }
    }
}
