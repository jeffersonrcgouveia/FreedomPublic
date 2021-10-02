using Freedom.Characters.Locomotion.Gait;
using UnityEngine;

namespace Freedom.Characters.Animations
{
	public class CharacterGaitAnimation : MonoBehaviour
	{
		static readonly int IsWalking = Animator.StringToHash("IsWalking");
		static readonly int IsSprinting = Animator.StringToHash("IsSprinting");

		[SerializeField] CharacterGait characterGait;

		Animator _animator;

		void Awake() => _animator = GetComponent<Animator>();

		void OnEnable()
		{
			characterGait.OnSetWalking += PlayWalking;
			characterGait.OnSetSprinting += PlaySprinting;
		}

		void OnDisable()
		{
			characterGait.OnSetWalking -= PlayWalking;
			characterGait.OnSetSprinting -= PlaySprinting;
		}

		void PlayWalking(bool isWalking) => _animator.SetBool(IsWalking, isWalking);

		void PlaySprinting(bool isSprinting) => _animator.SetBool(IsSprinting, isSprinting);

		public void AllowSprinting() => characterGait.CanSprint = true;
	}
}