using Freedom.AI.Enemies.Agent;
using UnityEngine;

namespace Freedom.AI.Enemies
{
    public class EnemyAIAttack : MonoBehaviour
    {
        [field: SerializeField] public TargetFinder TargetFinder { get; private set; }

        void FixedUpdate()
        {
            TargetFinder.TryFindTarget(transform.position);
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, TargetFinder.Range);
        }
    }
}