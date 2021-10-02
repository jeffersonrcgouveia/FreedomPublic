using UnityEngine;

namespace Freedom.AI.Enemies
{
    public class FollowTarget : MonoBehaviour
    {
        public Transform Target { get; set; }

        void FixedUpdate()
        {
            if (Target) transform.position = Target.position;
        }
    }
}