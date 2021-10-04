using System;
using Freedom.Characters.Locomotion.Direction;
using Freedom.Characters.Locomotion.Gait;
using UnityEngine;

namespace Freedom.Characters.Locomotion.Movement
{
    public class CharacterVelocity : MonoBehaviour
    {
        [SerializeField] CharacterDirection characterDirection;
        [SerializeField] CharacterGait characterGait;

        public event Action<Vector3> OnCalculateVelocity;

        float _currentSpeed;

        void Awake()
        {
            characterDirection.OnFixedUpdateMovingDirection += CalculateVelocity;
            characterGait.OnCalculateGaitSpeed += SetCurrentSpeed;
        }

        public void CalculateVelocity(Vector3 direction)
        {
            Vector3 velocity = direction.normalized * (_currentSpeed * Time.deltaTime);
            OnCalculateVelocity?.Invoke(velocity);
        }

        public void SetCurrentSpeed(float currentSpeed) => _currentSpeed = currentSpeed;
    }
}