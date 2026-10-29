#pragma once
#ifndef _GAME_OBJECT_
#define _GAME_OBJECT_

#include "PluginSettings.h"
#include "Vector2D.h"

class PLUGIN_API GameObject
{
public:
	//Constructor
	GameObject();

	//Getters and Setters
	int GetID() const;
	void SetID(int id = 0);

	int GetRotation() const;
	void SetRotation(int rotation = 0);

	Vector2D GetPosition() const;
	void SetPosition(float x = 0.0f, float y = 0.0f);

private:
	int m_id;
	int m_rotation;
	Vector2D m_position;

};

#endif /* defined (_GAME_OBJECT_) */