using UnityEngine;

namespace Freedom.Camera
{
	[RequireComponent(typeof(UnityEngine.Camera))]
	public class FollowCamera : MonoBehaviour
	{
		[field: SerializeField] public Transform FollowedTransform { get; set; }

		[SerializeField] Vector3 positionOffset;

		[SerializeField] float speed = 4f;

		// [field: SerializeField, Space] public UnityEvent<Transform> OnSetFollowedTransform { get; set; }

		// private IMenuInput playerMenuInput;

		public CameraPositionCallback CalculatePositionCallback { get; set; }

		public delegate Vector3 CameraPositionCallback();

		Transform _lastFollowedTransform;

		Vector3 _lastCameraPosition;

		void Awake()
		{
			RestoreCalculatePositionCallback();
			if (!FollowedTransform) return;
			TeleportCameraToPosition(CalculatePosition());
		}

		void FixedUpdate()
		{
			if (!FollowedTransform) return;
			if (_lastFollowedTransform != FollowedTransform)
			{
				_lastFollowedTransform = FollowedTransform;
				// OnSetFollowedTransform.Invoke(FollowedTransform);
			}
			Vector3 cameraPosition = _lastCameraPosition;
			// if (!playerMenuInput.IsMenuOpened)
			// {
			cameraPosition = _lastCameraPosition = positionOffset + CalculatePositionCallback();
			// }
			HandleMovement(cameraPosition);
			// HandleZoom();
		}

		void HandleMovement(Vector3 position)
		{
			position.y = transform.position.y;

			Vector3 cameraMoveDir = (position - transform.position).normalized;
			float distance = Vector3.Distance(position, transform.position);

			if (distance > 0)
			{
				Vector3 newCameraPosition = transform.position + cameraMoveDir * (distance * speed * Time.deltaTime);

				float distanceAfterMoving = Vector3.Distance(newCameraPosition, position);

				if (distanceAfterMoving > distance)
				{
					newCameraPosition = position;
				}

				transform.position = newCameraPosition;
			}
		}

		Vector3 CalculatePosition() => FollowedTransform.position;

		void TeleportCameraToPosition(Vector3 position)
		{
			position.y = transform.position.y;
			transform.position = position;
		}

		public void RestoreCalculatePositionCallback() => CalculatePositionCallback = CalculatePosition;
	}
}