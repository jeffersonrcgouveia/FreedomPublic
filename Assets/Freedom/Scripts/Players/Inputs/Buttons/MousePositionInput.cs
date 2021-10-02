using System;
using UnityEngine;

namespace Freedom.Players.Inputs.Buttons
{
	public class MousePositionInput : MonoBehaviour
	{
		[field: SerializeField, Space] public Action<Vector3> OnPositionMouse { get; set; }

		void Update()
		{
			OnPositionMouse?.Invoke(Input.mousePosition);
		}
	}
}