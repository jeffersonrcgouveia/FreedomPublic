using System;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace Freedom.AI.Enemies
{
    public class EnemyAIPatrol : MonoBehaviour
    {
        [SerializeField] LayerMask groundLayerMask;

        [SerializeField] float walkPointRange = 10;

        [field: SerializeField, Space] public UnityEvent<Vector3> OnCreateWalkPoint { get; set; }

        public event Action<Vector3> OnCalculateWalkPointDirection;

        const float FollowWalkPointDistance = 2f;

        Vector3? _walkPoint;

        bool _isWalkPointSet;

        bool _canPatrol = true;

        void FixedUpdate()
        {
            if (!_canPatrol) return;
            Patrol();
        }

        void Patrol()
        {
            if (!_isWalkPointSet)
            {
                _walkPoint = CreateRandomPosition(walkPointRange);

                OnCreateWalkPoint.Invoke(_walkPoint.Value);

                if (_walkPoint == null) return;

                if (Physics.Raycast(_walkPoint.Value, -transform.up, FollowWalkPointDistance, groundLayerMask))
                {
                    _isWalkPointSet = true;
                }
            }

            Vector3 walkPointDirection = _walkPoint.Value - transform.position;

            if (_isWalkPointSet)
            {
                OnCalculateWalkPointDirection?.Invoke(walkPointDirection);
            }

            if (walkPointDirection.magnitude < 1)
            {
                _isWalkPointSet = false;
            }
        }

        Vector3 CreateRandomPosition(float range)
        {
            float x = Random.Range(-range, range);
            float z = Random.Range(-range, range);

            Vector3 position = transform.position;
            return new Vector3(position.x + x, position.y, position.z + z);
        }

        public void SetCanPatrol(bool value) => _canPatrol = value;

        public void RemoveWalkPoint() => _walkPoint = null;

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            if (_walkPoint != null) Gizmos.DrawLine(transform.position, _walkPoint.Value);
            Gizmos.DrawWireSphere(transform.position, walkPointRange);
        }
    }
}