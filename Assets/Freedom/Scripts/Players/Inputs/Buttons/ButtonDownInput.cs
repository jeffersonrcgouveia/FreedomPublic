using System;
using UnityEngine;

namespace Freedom.Players.Inputs.Buttons
{
	public class ButtonDownInput : MonoBehaviour
	{
		[SerializeField] string buttonName;

		public Action OnButtonDown { get; set; }

		void Update()
		{
			if (Input.GetButtonDown(buttonName)) OnButtonDown?.Invoke();
		}
	}
}