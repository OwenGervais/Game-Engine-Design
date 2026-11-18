Lab Assignment 2:
Owen Gervais 100884566

This game is TPC, Try and survive a simple projectile bullet hell. WASD or Arrow keys to move, Hold shift to move half as fast, and press R to Replay your last attempt. Depending on how close you got to a projectile you'll get score. Press left mouse button to have enemy 3 fire.

Before:
<img width="1920" height="1032" alt="image" src="https://github.com/user-attachments/assets/40c49fe9-0a0b-4e6a-a0b9-06683b932320" />

After:

<img width="1920" height="1032" alt="image" src="https://github.com/user-attachments/assets/3ff9f183-94a3-4b8e-b4a7-d310f00e737d" />


Previously the many projectiles I would spawn would heavily impact the performance of my project but now that I've implemented object pooling, performance is much better.

I've implemented a factory for spawning patterns of projectiles, currently I have a sort of fan of projectiles that is sent out when enemy3 attacks.

The performance appears to be worse with the addition of the Factory pattern, although, I may have just been clicking faster the second time.

The profiling process revealed that factory patterns are not effective for enhancing performance.

Project Check-in:
Owen Gervais: Project Manager, Programmer, Time Keeper, Artist, Game Designer, Writer. Contribution: 100% of project

Project Description: This game is THPC, Try and survive a simple projectile bullet hell. WASD to move, Hold shift to move half as fast, and press R to restart if you die. Depending on how close you got to a projectile you'll get score.

Singleton: My singleton is used for the point management of the Game Manager. Whenever a projectile is in range of the player’s Graze range (a small circle around the player) their score will increase by 1 point. I also plan on having more implementation for adding many points when defeating enemies or bosses, so having a easy system like this is nice.

Factory: The Factory controls the Waves of projectiles that come at the player. On start the GameManager tells the factory to create the enemies that will spawn the projectiles. After that, wave 1 starts and the first enemy begins its attack, after 10 seconds the enemy dies and the second begins its attack.

Command Pattern: My Command Pattern is a replay system in which the player can watch back their own gameplay to see where they could improve. When the scene begins, as long as there isn’t currently any recorded frames, the players own inputs will be recorded every frame. When the scene is restarted, instead of using the inputs of the player, the player’s inputs will be replayed up to the point where the scene was restarted. After that, the player can record more movement on top of it.

Plugin/DLL: My plugin is a modified version of the one from the tutorial with rotation functionality. The goal of this DLL is to have an incredibly simple way to rotate any object at a fixed pace. I’ll be able to make great use of this script as I’d like for several game objects to be spinning.


In-Lab Assignment 1:
Owen Gervais (100884566)

This game is TPC, Try and survive a simple projectile bullet hell. WASD or Arrow keys to move, Hold shift to move half as fast, and press R to restart if you die. Depending on how close you got to a projectile you'll get score.

GameController Script:
GameController instance so that it may be called whenever

currentScore can be accessed and changed by any script.

Check if an instance already exists and if it does destroy the duplicate.

set the current GameController to the active instance

Graze Script:
if player is close to projectile
{
	Add +1 currentScore to the GameController
}

Using the Singleton Design Pattern allows me to cut down on scripts and functions for cleaner and better code.

No External Assets.
