using UnityEngine;

namespace Freedom.UI.Billboard
{
	public class TransformFollower : MonoBehaviour
	{
		[field: SerializeField] public Transform FollowTransform { get; set; }

		[field: SerializeField] public Vector3 PositionOffset { get; set; }

		Transform _thisTransform;

		void Awake() => _thisTransform = transform;

		void Update() => _thisTransform.position = FollowTransform.position + PositionOffset;
	}
}