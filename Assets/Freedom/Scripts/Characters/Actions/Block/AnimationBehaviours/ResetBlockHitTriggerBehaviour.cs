using Freedom.Characters.Animations;
using UnityEngine;

namespace Freedom.Characters.Actions.Block.AnimationBehaviours
{
	public class ResetBlockHitTriggerBehaviour : StateMachineBehaviour
	{
		CharacterActionsBlockAnimation _blockAnimation;

		[SerializeField] bool stateEnter;

		[SerializeField] bool stateExit;

		public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (!_blockAnimation) _blockAnimation = animator.GetComponent<CharacterActionsBlockAnimation>();
			if (_blockAnimation && stateEnter) _blockAnimation.ResetBlockHitAnimation();
		}

		public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (_blockAnimation && stateExit) _blockAnimation.ResetBlockHitAnimation();
		}
	}
}