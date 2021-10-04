using System;
using UnityEngine;

namespace Freedom.Characters.Locomotion.Direction
{
    public class CharacterDirection : MonoBehaviour
    {
        public event Action<Vector3> OnUpdateMovingDirection;

        public event Action<Vector3> OnFixedUpdateMovingDirection;

        public Vector3 MovingDirection { get; private set; }

        public Vector3 AimingDirection { get; private set; }

        public bool CanExecute { get; set; } = true;

        void Update()
        {
            if (!CanExecute) return;
            OnUpdateMovingDirection?.Invoke(MovingDirection);
        }

        void FixedUpdate()
        {
            if (!CanExecute) return;
            OnFixedUpdateMovingDirection?.Invoke(MovingDirection);
        }

        public void CalculateMovingDirection(float horizontal, float vertical)
        {
            MovingDirection = new Vector3(horizontal, 0, vertical);
        }

        public void SetMovingAndAimingDirections(Vector3 direction)
        {
            SetMovingDirection(direction);
            SetAimingDirection(direction);
        }

        public void SetMovingDirection(Vector3 direction) => MovingDirection = direction;

        public void SetAimingDirection(Vector3 direction) => AimingDirection = direction;

        public void SetMovingDirectionZero() => SetMovingDirection(Vector3.zero);

		public bool IsMoving() => MovingDirection.magnitude > 0;
    }
}