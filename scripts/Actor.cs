using Godot;
using System;

public abstract class Actor : KinematicBody
{
	[Export]
	protected float _speed = 8.0f;
	[Export]
	protected float _jumpStrength = 50.0f;
	[Export]
	protected float _gravity = 20.0f;
	
	protected Vector3 _velocity = Vector3.Zero;
	protected Vector3 _snapVector = Vector3.Down;
}
