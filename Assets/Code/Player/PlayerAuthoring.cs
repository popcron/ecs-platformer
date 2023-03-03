using Unity.Entities;
using UnityEngine;

namespace Paintime.Abilities
{
    [AddComponentMenu("Paintime/" + nameof(Player))]
    public class PlayerAuthoring : MonoBehaviour
    {
        [SerializeField]
        private bool isMyPlayer;

        public class Baker : Baker<PlayerAuthoring>
        {
            public override void Bake(PlayerAuthoring authoring)
            {
                AddComponent(new Player.Tag());
                if (authoring.isMyPlayer)
                {
                    AddComponent(new MyPlayerTag());
                }
            }
        }
    }
}
