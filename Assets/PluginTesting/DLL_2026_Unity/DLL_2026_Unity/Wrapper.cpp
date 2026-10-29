#include "Wrapper.h"
#include "GameObject.h"

GameObject gameObject;

PLUGIN_API int GetID()
{
	return gameObject.GetID();
}

PLUGIN_API void SetID(int id)
{
	gameObject.SetID(id);
}

PLUGIN_API int GetRotation()
{
	return gameObject.GetRotation();
}

PLUGIN_API void SetRotation(int rotation)
{
	gameObject.SetRotation(rotation);
}

PLUGIN_API Vector2D GetPosition()
{
	return gameObject.GetPosition();
}

PLUGIN_API void SetPosition(float x, float y)
{
	gameObject.SetPosition(x, y);
}