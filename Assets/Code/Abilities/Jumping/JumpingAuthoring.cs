using UnityEngine;
using Unity.Entities;

namespace Paintime.Abilities
{
    [AddComponentMenu("Abilities/" + nameof(Jumping))]
    public class JumpingAuthoring : MonoBehaviour
    {
        [SerializeField]
        private float jumpHeight = 1;

        public class Baker : Baker<JumpingAuthoring>
        {
            public override void Bake(JumpingAuthoring authoring)
            {
                AddSharedComponent(new Jumping.Data(authoring.jumpHeight));
                AddComponent(new Jumping.Input());
            }
        }
    }
}
