using Freedom.Characters.Hurt;
using UnityEngine;

namespace Freedom.Characters.Actions.Base
{
    public class DamageApplier : MonoBehaviour
    {
        [SerializeField] int damage;

        public void Damage(GameObject otherHurt)
        {
            otherHurt.GetComponentInChildren<DamageReceiver>().ReceiveDamage(damage);
        }
    }
}