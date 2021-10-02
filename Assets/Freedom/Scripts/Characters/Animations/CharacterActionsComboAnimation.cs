using Freedom.Characters.Actions.Base;
using Freedom.Characters.Actions.ComboAttack;
using UnityEngine;

namespace Freedom.Characters.Animations
{
	public class CharacterActionsComboAnimation : MonoBehaviour
	{
		public static readonly int ComboCounter = Animator.StringToHash("ComboCounter");

		[SerializeField] ComboValidator comboValidator;

		[SerializeField] EnableHitBoxesListener enableHitBoxesListener;

		Animator _animator;

		void Awake() => _animator = GetComponent<Animator>();

		public void SetComboCounter(int counter) => _animator.SetInteger(ComboCounter, counter);

		public void ResetComboCounter() => comboValidator.ResetComboCounter();

		public void PopulateHitBoxes() => enableHitBoxesListener.PopulateHitBoxes();
	}
}