using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.AI.NavMesh;

namespace Freedom.AI.Enemies
{
    public class NavMeshBoundsChecker : MonoBehaviour
    {
        [field: SerializeField, Space] public UnityEvent OnPositionOutOfBounds { get; set; }

        const float Distance = 1f;

        public void CheckPosition(Vector3 position)
        {
            if (!ContainsPosition(position)) OnPositionOutOfBounds.Invoke();
        }

        bool ContainsPosition(Vector3 position) => SamplePosition(position, out _, Distance, AllAreas/*1 << GetAreaFromName("Walkable")*/);
    }
}