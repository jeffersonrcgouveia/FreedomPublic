using UnityEngine;

namespace Freedom.Characters.Locomotion.Rotation.Calculators
{
    public class CharacterMovingRotationCalculator
    {
        public Quaternion Calculate(Transform transform, Vector3 movingDirection, float rotateSpeed)
        {
            if (movingDirection.magnitude == 0) return transform.rotation;
            Quaternion targetRotation = Quaternion.LookRotation(movingDirection);
            return Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotateSpeed);
        }
    }
}