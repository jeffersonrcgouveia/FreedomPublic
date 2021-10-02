using Freedom.Characters.Animations;
using UnityEngine;

namespace Freedom.Characters.Colliders
{
	public class BlockBox : MonoBehaviour
	{
		[SerializeField] CharacterActionsBlockAnimation blockAnimation;

		void OnTriggerEnter(Collider other)
		{
			DisableHitBox(other);
			blockAnimation.PlayBlockHitAnimation();
		}

		void DisableHitBox(Collider other) => other.gameObject.SetActive(false);
	}
}