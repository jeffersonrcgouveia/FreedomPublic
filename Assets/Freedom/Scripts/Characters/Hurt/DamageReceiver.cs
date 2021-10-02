using System;
using Freedom.Characters.Attributes;
using UnityEngine;

namespace Freedom.Characters.Hurt
{
	public class DamageReceiver : MonoBehaviour
	{
		[SerializeField] CharacterHealth characterHealth;

		public Action<int> OnReceiveDamage { get; set; }

		public void ReceiveDamage(int damage)
		{
			characterHealth.SubtractHealth(damage);
			OnReceiveDamage?.Invoke(damage);
		}
	}
}