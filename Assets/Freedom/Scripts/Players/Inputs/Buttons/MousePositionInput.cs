using System;
using UnityEngine;

namespace Freedom.Players.Inputs.Buttons
{
	public class MousePositionInput : MonoBehaviour
	{
		public event Action<Vector3> OnPositionMouse;

		void Update()
		{
			OnPositionMouse?.Invoke(Input.mousePosition);
		}
	}
}