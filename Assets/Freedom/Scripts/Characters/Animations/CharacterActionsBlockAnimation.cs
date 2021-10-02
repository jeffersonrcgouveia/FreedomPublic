using UnityEngine;

namespace Freedom.Characters.Animations
{
	public class CharacterActionsBlockAnimation : MonoBehaviour
	{
		public static readonly int BlockHit = Animator.StringToHash("BlockHit");

		Animator _animator;

		void Awake() => _animator = GetComponent<Animator>();

		public void PlayBlockHitAnimation() => _animator.SetTrigger(BlockHit);

		public void ResetBlockHitAnimation() => _animator.ResetTrigger(BlockHit);
	}
}