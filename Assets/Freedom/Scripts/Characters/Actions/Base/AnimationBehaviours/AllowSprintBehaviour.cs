using Freedom.Characters.Locomotion.Gait;
using UnityEngine;

namespace Freedom.Characters.Actions.Base.AnimationBehaviours
{
	public class AllowSprintBehaviour : StateMachineBehaviour
	{
		CharacterGait _characterGait;

		[SerializeField] bool stateEnter;

		[SerializeField] bool stateExit;

		public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (!_characterGait)
			{
				_characterGait = animator.GetComponentInParent<CharacterRoot>().GetComponentInChildren<CharacterGait>();
			}
			if (stateEnter) _characterGait.CanSprint = true;
		}

		public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (stateExit) _characterGait.CanSprint = true;
		}
	}
}
