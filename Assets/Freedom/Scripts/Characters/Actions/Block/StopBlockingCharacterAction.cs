using Freedom.Characters.Actions.Base;
using Freedom.Characters.Animations;
using UnityEngine;

namespace Freedom.Characters.Actions.Block
{
    public class StopBlockingCharacterAction : CharacterAction
    {
        [SerializeField] BlockBoxesEnabler enabler;

        [SerializeField] CharacterActionsAnimation actionsAnimation;

        void OnEnable()
        {
            OnHandleAction += enabler.DisableBlockBoxes;
            OnHandleAction += StopAnimation;
        }

        void OnDisable()
        {
            OnHandleAction -= enabler.DisableBlockBoxes;
            OnHandleAction -= StopAnimation;
        }

        void StopAnimation() => actionsAnimation.Stop();
    }
}