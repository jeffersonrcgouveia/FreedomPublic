using UnityEngine;

namespace Freedom.Characters.Actions.Block.AnimationBehaviours
{
	public class AllowBlockingBehaviour : StateMachineBehaviour
	{
		StartBlockingCharacterAction _blockAnimation;

		[SerializeField] bool stateEnter;

		[SerializeField] bool stateExit;

		public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (!_blockAnimation)
			{
				CharacterRoot characterRoot = animator.GetComponentInParent<CharacterRoot>();
				_blockAnimation = characterRoot.GetComponentInChildren<StartBlockingCharacterAction>();
			}
			if (_blockAnimation && stateEnter) _blockAnimation.CanBlock = true;
		}

		public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (_blockAnimation && stateExit) _blockAnimation.CanBlock = true;
		}
	}
}