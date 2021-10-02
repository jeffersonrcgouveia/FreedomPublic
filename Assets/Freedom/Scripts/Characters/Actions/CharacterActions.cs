using Freedom.Characters.Actions.Base;
using UnityEngine;

namespace Freedom.Characters.Actions
{
    public class CharacterActions : MonoBehaviour
    {
        CharacterAction[] _actions;

        void Awake() => _actions = GetComponentsInChildren<CharacterAction>();

        public void SetCanAct(bool value)
        {
            foreach (CharacterAction action in _actions)
            {
                action.CanAct = value;
            }
        }
    }
}