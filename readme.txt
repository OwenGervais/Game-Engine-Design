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