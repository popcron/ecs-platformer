using Paintime.Abilities;
using Unity.Entities;
using UnityEngine;

namespace Paintime.Authoring
{
    [AddComponentMenu("Abilities/" + nameof(Groundedness))]
    public class GroundednessAuthoring : MonoBehaviour
    {
        [SerializeField]
        private int points = 5;

        [SerializeField]
        private Transform start;

        [SerializeField]
        private Transform end;

        [SerializeField]
        private float ungroundDuration = 0.1f;

        [SerializeField]
        private float groundDistance = 0.1f;

        [SerializeField]
        private float gravity = 12f;

        private void OnDrawGizmos()
        {
            for (int i = 0; i < points; i++)
            {
                float t = (float)i / (points - 1);
                Vector3 origin = Vector3.Lerp(start.position, end.position, t);
                Vector3 direction = Vector3.down;
                Gizmos.DrawLine(origin, origin + direction * groundDistance);
            }
        }

        public class Baker : Baker<GroundednessAuthoring>
        {
            public override void Bake(GroundednessAuthoring authoring)
            {
                AddComponent(new Groundedness.State());
                AddSharedComponent(new Groundedness.Data(authoring.points, authoring.start.localPosition, authoring.end.localPosition, authoring.ungroundDuration, authoring.groundDistance, authoring.gravity));
            }
        }
    }
}