using System;
using UnityEngine;

namespace Freedom.Players.Inputs.Buttons
{
	public class ButtonHoldInput : MonoBehaviour
	{
		[SerializeField] string buttonName;

		public Action OnButton { get; set; }

		public Action OnButtonUp { get; set; }

		void Update()
		{
			if (Input.GetButton(buttonName))
			{
				OnButton?.Invoke();
			}
			else if (Input.GetButtonUp(buttonName))
			{
				OnButtonUp?.Invoke();
			}
		}
	}
}