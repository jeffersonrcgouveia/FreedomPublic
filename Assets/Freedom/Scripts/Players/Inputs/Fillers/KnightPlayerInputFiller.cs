using Freedom.Characters.Actions.Base;
using Freedom.Players.Inputs.Buttons;
using UnityEngine;

namespace Freedom.Players.Inputs.Fillers
{
    public class KnightPlayerInputFiller : PlayerInputFiller
    {
        [SerializeField] CharacterAction basicAttack;
        [SerializeField] CharacterAction blocking;
        [SerializeField] CharacterAction stopBlocking;

        protected override void PopulateActions(PlayerInput playerInput)
        {
            ButtonDownInput basicAttackInput = playerInput.Action1.GetComponent<ButtonDownInput>();
            basicAttackInput.OnButtonDown += basicAttack.Execute;
            ButtonHoldInput blockInput = playerInput.Action2.GetComponent<ButtonHoldInput>();
            blockInput.OnButton += blocking.Execute;
            blockInput.OnButtonUp += stopBlocking.Execute;
        }
    }
}