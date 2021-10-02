using System;
using Freedom.Players.Inputs.Buttons.ButtonHoldForSecondsInput.Helpers;
using UnityEngine;

namespace Freedom.Players.Inputs.Buttons.ButtonHoldForSecondsInput
{
	public class ButtonHoldForSecondsInput : MonoBehaviour
	{
		[SerializeField] string buttonName;

		[SerializeField] float holdSeconds = 0.18f;

		public Action OnButtonHold { get; set; }

		public Action OnButtonHeldUp { get; set; }

		public Action OnButtonUp { get; set; }

		HoldInputButton _holdInputButton;

		void Awake() => _holdInputButton = new HoldInputButton();

		void Update()
		{
			bool isHolding = _holdInputButton.HoldButton(
				buttonName,
				OnGaitButtonHold,
				OnGaitButtonHeldUp,
				OnGaitButtonUp,
				holdSeconds);

			if (isHolding) OnGaitButtonHold();
		}

		void OnGaitButtonHold() => OnButtonHold?.Invoke();

		void OnGaitButtonHeldUp() => OnButtonHeldUp?.Invoke();

		void OnGaitButtonUp() => OnButtonUp?.Invoke();
	}
}