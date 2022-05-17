using Godot;
using System;

public class PlayerCharacter : Actor
{
	protected SpringArm _cameraArm;
	protected Spatial _model;
	protected Vector3 _cameraOffset = new Vector3(0.0f, 2.0f, 0.0f);
	
	public override void _Ready()
	{
		_cameraArm = GetNode<SpringArm>("CameraArm");
		_model = GetNode<Spatial>("Model");
	}
	public override void _PhysicsProcess(float delta)
	{
		Vector3 moveDirection = Vector3.Zero;
		moveDirection.x = Input.GetActionStrength("right") - Input.GetActionStrength("left");
		moveDirection.z = Input.GetActionStrength("backward") - Input.GetActionStrength("forward");
		moveDirection = moveDirection.Rotated(Vector3.Up, _cameraArm.Rotation.y).Normalized();
		
		_velocity.x = moveDirection.x * _speed;
		_velocity.z = moveDirection.z * _speed;
		_velocity.y -= _gravity * delta;
		
		if (IsOnFloor())
		{
			if (Input.IsActionJustPressed("jump"))
			{
				_velocity.y = _jumpStrength;
				_snapVector = Vector3.Zero;
			}
			else if (_snapVector == Vector3.Zero)
			{
				_snapVector = Vector3.Down;
			}
		}
		
		_velocity = MoveAndSlideWithSnap(_velocity, _snapVector, Vector3.Up, true);
		
		if (_velocity.Length() > 0.2f)
		{
			Vector3 rot = _model.Rotation;
			
			Vector2 lookDirection = new Vector2(_velocity.z, _velocity.x);
			rot.y = lookDirection.Angle();
			
			_model.Rotation = rot;
			
			
		}
		_cameraArm.Translation = Translation + _cameraOffset;
	}
}
