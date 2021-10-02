using Freedom.Characters.Actions.Base;
using Freedom.Characters.Animations;
using Freedom.Characters.Locomotion.Gait;
using UnityEngine;

namespace Freedom.Characters.Actions.PhysicalAttack
{
    public class PhysicalAttackCharacterAction : CharacterAction
    {
        [SerializeField] CooldownValidator cooldownValidator;

        [SerializeField] EnableHitBoxesListener hitBoxesListener;

        [SerializeField] DamageApplier damageApplier;

        [SerializeField] CharacterGait characterGait;

        [SerializeField] CharacterActionsAnimation actionsAnimation;

        [SerializeField] int actionIndex;

        void OnEnable()
        {
            OnHandleAction += cooldownValidator.ValidateCooldown;
            cooldownValidator.OnValidateCooldown += PlayAnimation;
            cooldownValidator.OnValidateCooldown += hitBoxesListener.PopulateHitBoxes;
            cooldownValidator.OnValidateCooldown += characterGait.StopSprinting;
            hitBoxesListener.OnHit += damageApplier.Damage;
        }

        void OnDisable()
        {
            OnHandleAction -= cooldownValidator.ValidateCooldown;
            cooldownValidator.OnValidateCooldown -= PlayAnimation;
            cooldownValidator.OnValidateCooldown -= hitBoxesListener.PopulateHitBoxes;
            cooldownValidator.OnValidateCooldown -= characterGait.StopSprinting;
            hitBoxesListener.OnHit -= damageApplier.Damage;
        }

        void PlayAnimation() => actionsAnimation.PlayOneFrame(actionIndex);
    }
}