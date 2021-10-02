using System;
using UnityEngine;

namespace Freedom.Players.Inputs.Buttons
{
	public class DirectionalInput : MonoBehaviour
	{
		[SerializeField] string horizontalAxisName = "Horizontal";
		[SerializeField] string verticalAxisName = "Vertical";

		public Action<float, float> OnDirectionalAxis { get; set; }

		void Update()
		{
			float horizontalInput = Input.GetAxis(horizontalAxisName);
			float verticalInput = Input.GetAxis(verticalAxisName);

			OnDirectionalAxis?.Invoke(horizontalInput, verticalInput);
		}
	}
}