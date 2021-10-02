using UnityEngine;

namespace Freedom.UI.Billboard
{
	public class BillboardBehaviour : MonoBehaviour
	{
		[field: SerializeField] public Transform CameraTransform { get; set; }

		Transform _thisTransform;

		void Awake() => _thisTransform = transform;

		void Update()
		{
			if (!CameraTransform) return;
			_thisTransform.LookAt(CameraTransform);
			_thisTransform.rotation = CameraTransform.rotation;
		}
	}
}