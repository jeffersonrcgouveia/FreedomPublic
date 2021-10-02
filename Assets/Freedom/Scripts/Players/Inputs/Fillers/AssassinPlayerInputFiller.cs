using Freedom.Characters.Actions.Base;
using Freedom.Players.Inputs.Buttons;
using UnityEngine;

namespace Freedom.Players.Inputs.Fillers
{
    public class AssassinPlayerInputFiller : PlayerInputFiller
    {
        [SerializeField] CharacterAction basicAttack;
        [SerializeField] CharacterAction heavyAttack;

        protected override void PopulateActions(PlayerInput playerInput)
        {
            ButtonDownInput basicAttackInput = playerInput.Action1.GetComponent<ButtonDownInput>();
            basicAttackInput.OnButtonDown += basicAttack.Execute;
            ButtonDownInput heavyAttackInput = playerInput.Action2.GetComponent<ButtonDownInput>();
            heavyAttackInput.OnButtonDown += heavyAttack.Execute;
        }
    }
}