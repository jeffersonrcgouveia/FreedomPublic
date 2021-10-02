using Freedom.Characters.Locomotion.Direction;
using Freedom.Characters.Locomotion.Gait;
using Freedom.Characters.Locomotion.Rotation.Calculators;
using UnityEngine;

namespace Freedom.Characters.Locomotion.Rotation
{
    public class CharacterRotation : MonoBehaviour
    {
        [SerializeField] CharacterDirection characterDirection;
        
        [SerializeField] CharacterGait characterGait;

        [SerializeField] float rotateSpeed = 15.0f;

        CharacterMovingRotationCalculator _movingCalculator;

        CharacterAimingRotationCalculator _aimingCalculator;

        Transform _rootTransform;

        void Start()
        {
            _movingCalculator = new CharacterMovingRotationCalculator();
            _aimingCalculator = new CharacterAimingRotationCalculator();
            _rootTransform = GetComponentInParent<CharacterRoot>().transform;
            characterGait.OnSprinting += RotateToMovingDirection;
            characterGait.OnNotSprinting += RotateToAimingDirection;
        }

        public void RotateToMovingDirection()
        {
            _rootTransform.rotation = _movingCalculator.Calculate(_rootTransform, characterDirection.MovingDirection, rotateSpeed);
        }

        public void RotateToAimingDirection()
        {
            _rootTransform.rotation = _aimingCalculator.Calculate(_rootTransform, characterDirection.AimingDirection, rotateSpeed);
        }
    }
}