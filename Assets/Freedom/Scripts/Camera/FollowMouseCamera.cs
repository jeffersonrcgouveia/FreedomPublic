using System;
using UnityEngine;

namespace Freedom.Camera
{
	[RequireComponent(typeof(UnityEngine.Camera))]
	[RequireComponent(typeof(FollowCamera))]
	public class FollowMouseCamera : MonoBehaviour
	{
		[SerializeField] float acceleration = 0.6f;

		[SerializeField] float maxDistance = 4;

		public Action<Vector3> OnCalculateMouseDirection { get; set; }

		UnityEngine.Camera _camera;

		FollowCamera _followCamera;

		Vector3 _lastFollowedPosition;

		Vector3 _pointerPosition;

		void Awake()
		{
			_camera = GetComponent<UnityEngine.Camera>();
			_followCamera = GetComponent<FollowCamera>();
		}

		void Start() => SetCalculatePositionCallback();

		Vector3 CalculatePosition()
		{
			Transform followedTransform = _followCamera.FollowedTransform;
			Vector3 followedPosition = followedTransform ? followedTransform.position : _lastFollowedPosition;
			Vector3 mousePosition = FindMousePosition(followedPosition);
			Vector3 mouseDirection = mousePosition - followedPosition;
			OnCalculateMouseDirection?.Invoke(mouseDirection);
			Vector3 position = followedPosition + mouseDirection * acceleration;
			return _lastFollowedPosition = ClampDistance(position, followedPosition, maxDistance);
		}

		Vector3 FindMousePosition(Vector3 targetPos)
		{
			float cameraDistance = Vector3.Distance(_camera.transform.position, targetPos);
			Vector3 mousePositionInput = _pointerPosition;
			Vector3 mousePosition = new Vector3(mousePositionInput.x, mousePositionInput.y, cameraDistance);
			return _camera.ScreenToWorldPoint(mousePosition);
		}

		Vector3 ClampDistance(Vector3 position, Vector3 followedPosition, float distance)
		{
			float x = Mathf.Clamp(position.x, followedPosition.x - distance, followedPosition.x + distance);
			float z = Mathf.Clamp(position.z, followedPosition.z - distance, followedPosition.z + distance);
			return new Vector3(x, position.y, z);
		}

		void SetCalculatePositionCallback() => _followCamera.CalculatePositionCallback = CalculatePosition;

		public void SetPointerPosition(Vector3 pointerPosition) => _pointerPosition = pointerPosition;
	}
}