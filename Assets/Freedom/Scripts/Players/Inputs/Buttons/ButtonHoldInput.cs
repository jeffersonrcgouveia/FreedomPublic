using System;
using UnityEngine;

namespace Freedom.Players.Inputs.Buttons
{
	public class ButtonHoldInput : MonoBehaviour
	{
		[SerializeField] string buttonName;

		public event Action OnButton;

		public event Action OnButtonUp;

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