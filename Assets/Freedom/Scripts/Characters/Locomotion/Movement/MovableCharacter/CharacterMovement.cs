using Freedom.Characters.Locomotion.Movement.MovableCharacter.Base;
using UnityEngine;

namespace Freedom.Characters.Locomotion.Movement.MovableCharacter
{
    [RequireComponent(typeof(CharacterVelocity))]
    public class CharacterMovement : MonoBehaviour, IMovableCharacter
    {
        Transform _rootTransform;

        CharacterVelocity _characterVelocity;

        void Awake()
        {
            _rootTransform = GetComponentInParent<CharacterRoot>().transform;
            _characterVelocity = GetComponent<CharacterVelocity>();
        }

        void OnEnable() => _characterVelocity.OnCalculateVelocity += Move;

        void OnDisable() => _characterVelocity.OnCalculateVelocity -= Move;

        public void Move(Vector3 velocity) => _rootTransform.position += velocity;
    }
}
