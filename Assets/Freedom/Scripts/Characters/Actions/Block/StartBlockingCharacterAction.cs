using System.Collections;
using Freedom.Characters.Actions.Base;
using Freedom.Characters.Animations;
using Freedom.Characters.Locomotion.Gait;
using UnityEngine;

namespace Freedom.Characters.Actions.Block
{
    public class StartBlockingCharacterAction : CharacterAction
    {
        [SerializeField] BlockBoxesEnabler enabler;

        [SerializeField] CharacterGait characterGait;

        [SerializeField] CharacterActionsAnimation actionsAnimation;

        [SerializeField] int actionIndex;

        public bool CanBlock { get; set; } = true;

        void OnEnable() => OnHandleAction += ExecuteAction;

        void OnDisable() => OnHandleAction -= ExecuteAction;

        void ExecuteAction()
        {
            if (!CanBlock) return;
            enabler.EnableBlockBoxes();
            characterGait.StopSprinting();
            actionsAnimation.Play(actionIndex);
        }
    }
}