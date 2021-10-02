using System.Collections.Generic;
using Freedom.Characters.Colliders;
using UnityEngine;

namespace Freedom.Characters.Hurt
{
	public class HurtBoxesEnabler : MonoBehaviour
	{
		[SerializeField] GameObject hurt;

		[SerializeField] List<HurtBox> hurtBoxes;

		void Awake() => PopulateHurtBoxes();

		public void SetHurtBoxesActive(bool active)
		{
			foreach (HurtBox hurtBox in hurtBoxes) hurtBox.gameObject.SetActive(active);
		}

		void PopulateHurtBoxes()
		{
			foreach (HurtBox hurtBox in hurtBoxes) hurtBox.Hurt = hurt;
		}
	}
}