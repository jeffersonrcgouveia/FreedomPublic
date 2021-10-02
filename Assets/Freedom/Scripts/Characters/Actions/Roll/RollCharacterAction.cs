using Freedom.Characters.Actions.Base;
using UnityEngine;

namespace Freedom.Characters.Actions.Roll
{
    public class RollCharacterAction : CharacterAction
    {
        [SerializeField] CooldownValidator cooldownValidator;

        [SerializeField] RollEvents rollEvents;

        void Awake()
        {
            OnHandleAction += cooldownValidator.ValidateCooldown;
            cooldownValidator.OnValidateCooldown += rollEvents.Roll;
        }
    }
}