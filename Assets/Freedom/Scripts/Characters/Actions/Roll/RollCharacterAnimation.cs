using Freedom.Characters.Animations;
using UnityEngine;

namespace Freedom.Characters.Actions.Roll
{   
    public class RollCharacterAnimation : MonoBehaviour
    {
        [SerializeField] CharacterActionsAnimation actionsAnimation;

        [SerializeField] int actionIndex = 20;

        public void Play() => actionsAnimation.PlayOneFrame(actionIndex);
    }
}