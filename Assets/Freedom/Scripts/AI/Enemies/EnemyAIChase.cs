using Freedom.AI.Enemies.Agent;
using UnityEngine;

namespace Freedom.AI.Enemies
{
    public class EnemyAIChase : MonoBehaviour
    {
        [field: SerializeField] public TargetFinder TargetFinder { get; private set; }

        bool _canChase = true;

        void FixedUpdate()
        {
            if (!_canChase) return;
            TargetFinder.TryFindTarget(transform.position);
        }

        public void SetCanChase(bool value)
        {
            _canChase = value;
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, TargetFinder.Range);
        }
    }
}