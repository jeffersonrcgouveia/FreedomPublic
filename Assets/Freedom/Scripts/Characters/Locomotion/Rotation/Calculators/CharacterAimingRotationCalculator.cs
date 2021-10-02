using UnityEngine;

namespace Freedom.Characters.Locomotion.Rotation.Calculators
{
    public class CharacterAimingRotationCalculator
    {
        public Quaternion Calculate(Transform transform, Vector3 aimingDirection, float rotateSpeed)
        {
            if (aimingDirection == Vector3.zero) return Quaternion.identity;
            Quaternion targetRotation = Quaternion.LookRotation(aimingDirection);
            Quaternion newRotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotateSpeed);
            return new Quaternion(0.0f, newRotation.y, 0.0f, newRotation.w);
        }
    }
}