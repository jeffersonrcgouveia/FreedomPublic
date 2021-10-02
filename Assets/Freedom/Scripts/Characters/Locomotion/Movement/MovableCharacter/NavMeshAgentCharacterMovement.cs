using Freedom.Characters.Locomotion.Movement.MovableCharacter.Base;
using UnityEngine;
using UnityEngine.AI;

namespace Freedom.Characters.Locomotion.Movement.MovableCharacter
{
    [RequireComponent(typeof(CharacterVelocity))]
    public class NavMeshAgentCharacterMovement : MonoBehaviour, IMovableCharacter
    {
        NavMeshAgent _agent;

        CharacterVelocity _characterVelocity;

        void Awake() => _characterVelocity = GetComponent<CharacterVelocity>();

        void Start() => _agent = GetComponentInParent<CharacterRoot>().GetComponent<NavMeshAgent>();

        void OnEnable() => _characterVelocity.OnCalculateVelocity += Move;

        void OnDisable() => _characterVelocity.OnCalculateVelocity -= Move;

        public void Move(Vector3 velocity) => _agent.Move(velocity);
    }
}
