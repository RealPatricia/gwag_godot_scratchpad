using Godot;
using System;

public abstract class Actor : KinematicBody
{
	public override void _Ready()
	{
		GD.Print("If you can see this, This is an Actor, or a class that inherits from Actor!");
	}
}
