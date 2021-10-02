using System;
using Freedom.Characters.Locomotion.Direction;
using UnityEngine;
using UnityEngine.Events;

namespace Freedom.Characters.Animations
{
    public class CharacterMovementAnimation : MonoBehaviour
    {
        static readonly int IsDirectionVertical = Animator.StringToHash("IsDirectionVertical");
        static readonly int Horizontal = Animator.StringToHash("Horizontal");
        static readonly int Vertical = Animator.StringToHash("Vertical");
        static readonly int IsMoving = Animator.StringToHash("IsMoving");

        const float MaxNormalizedValue = 1;

        [SerializeField] CharacterDirection characterDirection;

        [SerializeField] float smoothness = 0.3f;

        [field: SerializeField, Space] public UnityEvent OnStepLeft { get; set; }

        [field: SerializeField] public UnityEvent OnStepRight { get; set; }

        Animator _animator;

        void Awake()
        {
            characterDirection.OnUpdateMovingDirection += HandleAimingMovementAnimation;
            _animator = GetComponent<Animator>();
        }

        public void HandleAimingMovementAnimation(Vector3 movingDirection)
        {
            float forwardMagnitude = 0;
            float rightMagnitude = 0;

            bool isMoving = movingDirection.magnitude > 0;
            if (isMoving)
            {
                Vector3 aimingDirection = characterDirection.AimingDirection;
                float forwardDot = Vector3.Dot(movingDirection, aimingDirection);
                forwardMagnitude = Mathf.Clamp(forwardDot, -MaxNormalizedValue, MaxNormalizedValue);

                Vector3 perpendicularMouseDirection = new Vector3(aimingDirection.z, 0, -aimingDirection.x);
                float rightDot = Vector3.Dot(movingDirection, perpendicularMouseDirection);
                rightMagnitude = Mathf.Clamp(rightDot, -MaxNormalizedValue, MaxNormalizedValue);
            }
            _animator.SetBool(IsDirectionVertical, Math.Abs(forwardMagnitude) > Math.Abs(rightMagnitude));

            _animator.SetFloat(Horizontal, rightMagnitude, smoothness, Time.deltaTime);
            _animator.SetFloat(Vertical, forwardMagnitude, smoothness, Time.deltaTime);

            _animator.SetBool(IsMoving, isMoving);
        }

        public void FootL() => OnStepLeft.Invoke();

        public void FootR() => OnStepRight.Invoke();
    }
}
