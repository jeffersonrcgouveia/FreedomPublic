using Freedom.Characters.Actions;
using Freedom.Characters.Hurt;
using Freedom.Characters.Locomotion.Direction;
using UnityEngine;

namespace Freedom.Characters.Animations
{
	public class CharacterHurtAnimation : MonoBehaviour
	{
		static readonly int Hit = Animator.StringToHash("Hit");

		[SerializeField] CharacterDirection characterDirection;

		[SerializeField] CharacterActions characterActions;

		[SerializeField] DamageReceiver characterReceiver;

		Animator _animator;

		void Awake()
		{
			_animator = GetComponent<Animator>();
			characterReceiver.OnReceiveDamage += Play;
		}

		public void Play(int damage) => _animator.SetTrigger(Hit);

		public void StopMoving()
		{
			characterDirection.CanExecute = false;
			characterActions.SetCanAct(false);
		}

		public void AllowMoving()
		{
			characterDirection.CanExecute = true;
			characterActions.SetCanAct(true);
		}
	}
}