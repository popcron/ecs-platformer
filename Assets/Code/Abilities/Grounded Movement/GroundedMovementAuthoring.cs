using Paintime.Abilities;
using Unity.Entities;
using UnityEngine;

namespace Paintime.Authoring
{
    [AddComponentMenu("Abilities/" + nameof(GroundedMovement))]
    public class GroundedMovementAuthoring : MonoBehaviour
    {
        [SerializeField]
        private float speed = 3f;

        [SerializeField]
        private float acceleration = 2f;

        public class Baker : Baker<GroundedMovementAuthoring>
        {
            public override void Bake(GroundedMovementAuthoring authoring)
            {
                AddComponent(new GroundedMovement.Input());
                AddSharedComponent(new GroundedMovement.Data(authoring.speed, authoring.acceleration));
            }
        }
    }
}