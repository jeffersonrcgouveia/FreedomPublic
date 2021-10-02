using Freedom.Characters.Conditions;
using UnityEngine;

namespace Freedom.Characters.Animations
{
	public class CharacterDieAnimation : MonoBehaviour
	{
		static readonly int IsDying = Animator.StringToHash("IsDying");

		[SerializeField] CharacterDied characterDied;

		Animator _animator;

		void Awake()
		{
			_animator = GetComponent<Animator>();
			characterDied.OnDie += Play;
		}

		public void Play() => _animator.SetBool(IsDying, true);
	}
}