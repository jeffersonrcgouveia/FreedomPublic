using Freedom.Characters.Locomotion.Direction;
using Freedom.Characters.Locomotion.Gait;
using Freedom.Characters.Locomotion.Movement;
using Freedom.Characters.Locomotion.Rotation;
using UnityEngine;

namespace Freedom.Characters.Actions.Roll
{   
    public class RollCharacterLocomotion : MonoBehaviour
    {
        [SerializeField] CharacterDirection characterDirection;

        [SerializeField] CharacterRotation characterRotation;

        [SerializeField] CharacterGait characterGait;

        [SerializeField] CharacterVelocity characterVelocity;

        Rigidbody _rigidbody;

        Vector3 _aimingDirection;

        void Awake() => _rigidbody = GetComponentInParent<Rigidbody>();

        public void MoveTowardsDirection(float speed)
        {
            characterVelocity.SetCurrentSpeed(speed);
            characterVelocity.CalculateVelocity(CalculateDirection());
            characterRotation.RotateToMovingDirection();
        }

        Vector3 CalculateDirection()
        {
            Vector3 direction = characterDirection.IsMoving() ? characterDirection.MovingDirection : _aimingDirection;
            return new Vector3(direction.x, 0, direction.z).normalized;
        }

        public void SetAimingDirection()
        {
            if (!characterDirection.IsMoving()) _aimingDirection = characterDirection.AimingDirection;
        }

        public void ResetAimingDirection() => _aimingDirection = Vector3.zero;

        public void RegainCharacterGait()
        {
            _rigidbody.velocity = Vector3.zero;
            characterGait.InvokeEvents();
        }

        public void CanMove(bool value)
        {
            characterDirection.CanExecute = value;
            characterGait.CanInvokeSprintingEvents = value;
        }
    }
}