using Freedom.Characters.Animations;
using UnityEngine;

namespace Freedom.Characters.Actions.ComboAttack.AnimationBehaviours
{
	public class ResetComboCounterBehaviour : StateMachineBehaviour
	{
		CharacterActionsComboAnimation _comboAnimation;

		[SerializeField] bool stateEnter;

		[SerializeField] bool stateExit;

		public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (!_comboAnimation) _comboAnimation = animator.GetComponent<CharacterActionsComboAnimation>();
			if (stateEnter) _comboAnimation.ResetComboCounter();
		}

		public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (stateExit) _comboAnimation.ResetComboCounter();
		}
	}
}
