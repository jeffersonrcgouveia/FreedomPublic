using System;
using Freedom.Characters.Conditions;
using UnityEngine;

namespace Freedom.Characters.Attributes
{
	public class CharacterHealth : MonoBehaviour
	{
		[SerializeField] CharacterDied characterDied;

		[field: SerializeField] public int MaxHealth { get; set; }

		[field: SerializeField] public int Health { get; private set; }

		[SerializeField] bool invincible;

		public Action<int> OnChange { get; set; }

		public Action<float> OnChangePercent { get; set; }

		public Action OnOver { get; set; }

		const int MinHealth = 0;

		void Start()
		{
			InvokeChangeEvents();
			OnOver += characterDied.Die;
		}

		public void AddHealth(int amount)
		{
			Health = Mathf.Clamp(Health + amount, MinHealth, MaxHealth);
			InvokeChangeEvents();
			if (IsHealthOver()) OnOver.Invoke();
		}

		void InvokeChangeEvents()
		{
			if (invincible) Health = MaxHealth;
			OnChange?.Invoke(Health);
			OnChangePercent?.Invoke((float) Health / MaxHealth);
		}

		public void SubtractHealth(int amount) => AddHealth(-amount);

		public bool IsHealthOver() => Health == MinHealth;
	}
}