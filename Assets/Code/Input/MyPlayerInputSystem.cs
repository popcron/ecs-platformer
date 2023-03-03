using Unity.Collections;
using Unity.Entities;
using UnityEngine.InputSystem;

namespace Paintime.Abilities
{
    public partial class MyPlayerInputSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            PlayerInputState state = default;
            if (Keyboard.current is Keyboard keyboard)
            {
                state.jump = keyboard.spaceKey.isPressed;
                if (keyboard.aKey.isPressed)
                {
                    state.horizontalMovement--;
                }

                if (keyboard.dKey.isPressed)
                {
                    state.horizontalMovement++;
                }
            }

            if (Gamepad.current is Gamepad gamepad)
            {
                state.jump = gamepad.buttonSouth.isPressed;
                state.horizontalMovement = gamepad.leftStick.x.ReadValue();
            }

            EntityCommandBuffer ecb = new(Allocator.Temp);
            foreach (var player in SystemAPI.Query<Player>())
            {
                if (SystemAPI.HasComponent<MyPlayerTag>(player.self))
                {
                    if (!SystemAPI.HasComponent<PlayerInputState>(player.self))
                    {
                        ecb.AddComponent(player.self, state);
                    }
                    else
                    {
                        ecb.SetComponent(player.self, state);
                    }
                }
            }

            ecb.Playback(EntityManager);
            ecb.Dispose();
        }
    }
}
