using System;
using UnityEngine;

public class DirectionalMover
{
	private readonly Rigidbody2D _body2d;
	private readonly DirectionalMovementData _directionalMovementData;
	private readonly Animator _animator;
	private readonly DirectionalCameraPlayer _cameras;


	public DirectionalMover(Rigidbody2D body2d, Animator animator, DirectionalCameraPlayer cameras, DirectionalMovementData directionalMovementData)
	{
		_body2d = body2d;
		_animator = animator;
		_cameras = cameras;
		_directionalMovementData = directionalMovementData;
	}

	public void PlayerMovement(float inputX)
	{
		//_directionalMovementData.Speed = 2.5f;

		// Swap direction of sprite depending on walk direction
		if (inputX > 0)
		{
			_animator.GetComponent<SpriteRenderer>().flipX = false;
			_directionalMovementData.Direction = Direction.Right;
			foreach (var cameraPair in _cameras.DirectionalCameras)
				cameraPair.Value.enabled = cameraPair.Key == _directionalMovementData.Direction;
		}

		if (inputX < 0)
		{
			_animator.GetComponent<SpriteRenderer>().flipX = true;
			_directionalMovementData.Direction = Direction.Left;
			foreach (var cameraPair in _cameras.DirectionalCameras)
				cameraPair.Value.enabled = cameraPair.Key == _directionalMovementData.Direction;
		}

		_body2d.velocity = new Vector2(inputX * _directionalMovementData.Speed, _body2d.velocity.y);
	}
}
