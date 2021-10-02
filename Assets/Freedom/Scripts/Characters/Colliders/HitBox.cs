using Freedom.Characters.Actions.Base;
using UnityEngine;

namespace Freedom.Characters.Colliders
{
	public class HitBox : MonoBehaviour
	{
		public EnableHitBoxesListener EnableListener { get; set; }

		void OnEnable()
		{
			if (EnableListener) EnableListener.InvokeOnEnable();
		}

		void OnDisable()
		{
			if (!EnableListener) return;
			EnableListener.InvokeOnDisable();
			EnableListener = null;
		}

		void OnTriggerEnter(Collider other)
		{
			HurtBox hurtBox = other.GetComponent<HurtBox>();
			if (hurtBox && EnableListener) EnableListener.InvokeOnHit(hurtBox.Hurt);
		}
	}
}