using System.Collections;
using UnityEngine;

namespace Freedom.Characters.Animations
{
	public class CharacterActionsAnimation : MonoBehaviour
	{
		static readonly int IsActing = Animator.StringToHash("IsActing");
		static readonly int IsActingIndex = Animator.StringToHash("IsActingIndex");

		Animator _animator;

		void Awake() => _animator = GetComponent<Animator>();

		public void PlayOneFrame(int actionIndex) => StartCoroutine(ActionAnimationCoroutine(actionIndex));

		IEnumerator ActionAnimationCoroutine(int actionIndex)
		{
			Play(actionIndex);
			yield return null;
			Stop();
		}

		public void Play(int actionIndex)
		{
			_animator.SetBool(IsActing, true);
			_animator.SetInteger(IsActingIndex, actionIndex);
		}

		public void Stop() => _animator.SetBool(IsActing, false);

		public void Hit()
		{
			
		}
	}
}