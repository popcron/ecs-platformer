using Unity.Entities;

namespace Paintime.Abilities
{
    public struct PlayerInputState : IComponentData
    {
        public bool jump;
        public float horizontalMovement;
    }
}
