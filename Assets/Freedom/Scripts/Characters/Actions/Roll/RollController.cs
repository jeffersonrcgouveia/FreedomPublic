using UnityEngine;

namespace Freedom.Characters.Actions.Roll
{   
    public class RollController : MonoBehaviour
    {
        [SerializeField] RollEvents rollEvents;

        [SerializeField] RollCharacterLocomotion rollCharacterLocomotion;

        [SerializeField] RollCharacterAnimation rollCharacterAnimation;

        [SerializeField] RollSpeed rollSpeed;

        void Awake()
        {
            rollEvents.OnRollingStart += StartRolling;
            rollEvents.OnRolling += UpdateRolling;
            rollEvents.OnRollingEnd += StopRolling;
        }

        void StartRolling()
        {
            rollCharacterLocomotion.SetAimingDirection();
            rollCharacterLocomotion.CanMove(false);
            rollCharacterAnimation.Play();
            rollSpeed.ResetTimeElapsed();
        }

        void UpdateRolling() => rollCharacterLocomotion.MoveTowardsDirection(rollSpeed.CalculateRollSpeed());

        void StopRolling()
        {
            rollCharacterLocomotion.CanMove(true);
            rollCharacterLocomotion.ResetAimingDirection();
            rollCharacterLocomotion.RegainCharacterGait();
        }
    }
}