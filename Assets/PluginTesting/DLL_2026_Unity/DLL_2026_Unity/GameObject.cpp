#include "GameObject.h"

GameObject::GameObject()
{
	SetID();
	SetPosition();
	SetRotation();
}

int GameObject::GetID() const
{
	return m_id;
}

void GameObject::SetID(const int id)
{
	m_id = id+420;
}

int GameObject::GetRotation() const
{
	return m_rotation;
}

void GameObject::SetRotation(const int rotation)
{
	m_rotation = rotation+1;
}

Vector2D GameObject::GetPosition() const
{
	return m_position;
}

void GameObject::SetPosition(const float x, const float y)
{
	m_position.x = x;
	m_position.y = y;
}