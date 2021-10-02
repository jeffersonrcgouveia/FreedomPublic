using System;
using Freedom.Characters.Locomotion.Direction;
using UnityEngine;

namespace Freedom.Characters.Locomotion.Gait
{
	public class CharacterGait : MonoBehaviour
	{
		[SerializeField] CharacterDirection characterDirection;

		[field:SerializeField] public float WalkingSpeed { get; private set; }
		[field:SerializeField] public float RunningSpeed { get; private set; }
		[field:SerializeField] public float SprintingSpeed { get; private set; }

		[field: SerializeField, Space] public Action<bool> OnSetWalking { get; set; }
		[field: SerializeField] public Action<bool> OnSetSprinting { get; set; }
		[field: SerializeField] public Action OnSprinting { get; set; }
		[field: SerializeField] public Action OnNotSprinting { get; set; }
		[field: SerializeField] public Action<float> OnCalculateGaitSpeed { get; set; }

		public bool CanSprint { get; set; } = true;

		public bool CanInvokeSprintingEvents { get; set; } = true;

		public bool IsWalking
		{
			get => _isWalking;
			set
			{
				OnSetSprinting.Invoke(_isSprinting = false);
				OnSetWalking.Invoke(_isWalking = value);
				OnCalculateGaitSpeed.Invoke(GetCurrentSpeed());
			}
		}

		public bool IsSprinting
		{
			get => _isSprinting;
			set
			{
				if (!CanSprint && value) return;
				OnSetWalking.Invoke(_isWalking = false);
				OnSetSprinting.Invoke(_isSprinting = value && characterDirection.IsMoving());
				OnCalculateGaitSpeed.Invoke(GetCurrentSpeed());
			}
		}

		bool _isWalking;

		bool _isSprinting;

		void Start() => OnCalculateGaitSpeed.Invoke(GetCurrentSpeed());

		void FixedUpdate()
		{
			if (CanInvokeSprintingEvents) (_isSprinting ? OnSprinting : OnNotSprinting).Invoke();
		}

		public void ToggleIsWalking() => IsWalking = !IsWalking;

		public float GetCurrentSpeed() => IsWalking ? WalkingSpeed : IsSprinting ? SprintingSpeed : RunningSpeed;

		public void InvokeEvents()
		{
			OnSetWalking.Invoke(_isWalking);
			OnSetSprinting.Invoke(_isSprinting = _isSprinting && characterDirection.IsMoving());
			OnCalculateGaitSpeed.Invoke(GetCurrentSpeed());
		}

		public void StopSprinting()
		{
			IsSprinting = false;
			CanSprint = false;
		}
	}
}