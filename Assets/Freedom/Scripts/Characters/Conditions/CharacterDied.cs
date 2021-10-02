using System;
using Freedom.Characters.Actions;
using Freedom.Characters.Hurt;
using Freedom.Characters.Locomotion.Direction;
using Freedom.Commons;
using Freedom.Commons.Extensions;
using UnityEngine;
using UnityEngine.AI;

namespace Freedom.Characters.Conditions
{
	public class CharacterDied : MonoBehaviour
	{
		[SerializeField] CharacterDirection characterDirection;

		[SerializeField] CharacterActions characterActions;

		[SerializeField] GameObject locomotion;

		[SerializeField] GameObject hurt;

		[SerializeField] LayerMask uncollidableMask;

		public Action OnDie { get; set; }

		Collider _collider;

		Rigidbody _rigidbody;

		void Awake()
		{
			_collider = GetComponentInParent<Collider>();
			_rigidbody = GetComponentInParent<Rigidbody>();
		}

		public void Die()
		{
			_rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
			GameObject character = _collider.gameObject;
			character.layer = uncollidableMask.ValueIndex();
			Destroy(character.GetComponent<NavMeshAgent>());
			locomotion.SetActive(false);
			hurt.GetComponentInChildren<HurtBoxesEnabler>().SetHurtBoxesActive(false);
			hurt.SetActive(false);
			characterDirection.CanExecute = false;
			characterActions.SetCanAct(false);
			OnDie.Invoke();
		}
	}
}