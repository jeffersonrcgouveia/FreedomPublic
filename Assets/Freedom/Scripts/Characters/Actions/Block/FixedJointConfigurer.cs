using UnityEngine;

namespace Freedom.Characters.Actions.Block
{
    public class FixedJointConfigurer : MonoBehaviour
    {
        [SerializeField] Rigidbody mainRigidbody;

        void Awake() => GetComponent<FixedJoint>().connectedBody = mainRigidbody;
    }
}