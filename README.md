# ECS Platformer
A project made with Unity's ECS that implements a 2D player that can move sideways and jump. With authoring components for game objects and prefabs, matching the ECS components.

### Players
When an entity has a [Player](https://github.com/popcron/ecs-platformer/blob/main/Assets/Code/Player/Player.cs) component, it can also have a [PlayerInputState](https://github.com/popcron/ecs-platformer/blob/main/Assets/Code/Input/PlayerInputState.cs) component, abilities will be performed based on the input state.
In this project's example implementation, only the player entity with the [MyPlayerTag](https://github.com/popcron/ecs-platformer/blob/main/Assets/Code/Player/MyPlayerTag.cs) will end up with an input state component at runtime, this is done by the [MyPlayerInputSystem](https://github.com/popcron/ecs-platformer/blob/main/Assets/Code/Input/MyPlayerInputSystem.cs). 

### Abilities
Abilities are implemented as a combination of components and 1 aspect to represent it (the aspect acts as a top level abstraction to contain all the pieces).
If they're abilities that make the player perform or do something in response to some input, they will read the input from PlayerInputState component on the same entity (how much to move, should jump or not for example).
* [Grounded Movement](https://github.com/popcron/ecs-platformer/blob/main/Assets/Code/Abilities/Grounded%20Movement/GroundedMovement.cs)
* [Groundedness](https://github.com/popcron/ecs-platformer/blob/main/Assets/Code/Abilities/Groundedness/Groundedness.cs)
* [Jumping](https://github.com/popcron/ecs-platformer/blob/main/Assets/Code/Abilities/Jumping/Jumping.cs)
