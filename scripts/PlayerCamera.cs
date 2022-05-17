using Godot;
using System;

public class PlayerCamera : SpringArm
{
	[Export]
	private float _mouseSensitivity = 0.05f;
	[Export]
	private float _maxCameraAngle = -80.0f;
	[Export]
	private float _minCameraAngle = 20.0f;
	
	public override void _Ready()
	{
		SetAsToplevel(true);
		Input.SetMouseMode(Input.MouseMode.Captured);
	}
	
	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event is InputEventMouseMotion mouse)
		{
			Vector3 rot = RotationDegrees;
			
			rot.x -= mouse.Relative.y * _mouseSensitivity;
			rot.x = Mathf.Clamp(rot.x, _maxCameraAngle, _minCameraAngle);
			
			rot.y -= mouse.Relative.x * _mouseSensitivity;
			rot.y = Mathf.Wrap(rot.y, 0.0f, 360.0f);
			
			RotationDegrees = rot;
		}
	}
}
