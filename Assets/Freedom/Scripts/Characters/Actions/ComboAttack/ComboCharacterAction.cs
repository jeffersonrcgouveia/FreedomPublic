using Freedom.Characters.Actions.Base;
using Freedom.Characters.Actions.Block;
using Freedom.Characters.Animations;
using Freedom.Characters.Locomotion.Gait;
using UnityEngine;

namespace Freedom.Characters.Actions.ComboAttack
{
    public class ComboCharacterAction : CharacterAction
    {
        [SerializeField] ComboValidator comboValidator;

        [SerializeField] CooldownValidator comboCooldownsValidator;

        [SerializeField] EnableHitBoxesListener hitBoxesListener;

        [SerializeField] DamageApplier damageApplier;

        [SerializeField] CharacterGait characterGait;

        [SerializeField] CharacterActionsAnimation actionsAnimation;

        [SerializeField] CharacterActionsComboAnimation comboAnimation;

        [SerializeField] int actionIndex;

        [SerializeField] StartBlockingCharacterAction blockAction;

        void OnEnable()
        {
            OnHandleAction += comboCooldownsValidator.ValidateCooldown;
            comboCooldownsValidator.OnValidateCooldown += comboValidator.ValidateCombo;
            if (blockAction) comboCooldownsValidator.OnValidateCooldown += PreventBlocking;
            comboValidator.OnStartCombo += ExecuteFirstComboHit;
            comboValidator.OnUpdateComboCounter += comboAnimation.SetComboCounter;
            comboValidator.OnStartCombo += characterGait.StopSprinting;
            hitBoxesListener.OnHit += damageApplier.Damage;
        }

        void OnDisable()
        {
            OnHandleAction -= comboCooldownsValidator.ValidateCooldown;
            comboCooldownsValidator.OnValidateCooldown -= comboValidator.ValidateCombo;
            if (blockAction) comboCooldownsValidator.OnValidateCooldown -= PreventBlocking;
            comboValidator.OnStartCombo -= ExecuteFirstComboHit;
            comboValidator.OnUpdateComboCounter -= comboAnimation.SetComboCounter;
            comboValidator.OnStartCombo -= characterGait.StopSprinting;
            hitBoxesListener.OnHit -= damageApplier.Damage;
        }

        void ExecuteFirstComboHit()
        {
            actionsAnimation.PlayOneFrame(actionIndex);
            hitBoxesListener.PopulateHitBoxes();
        }

        void PreventBlocking() => blockAction.CanBlock = false;
    }
}