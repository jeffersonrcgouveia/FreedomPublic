using System;
using UnityEngine;

namespace Freedom.Characters.Actions.Base
{
    public class CharacterAction : MonoBehaviour
    {
        public event Action OnHandleAction;

        public bool CanAct { get; set; } = true;

        public void Execute()
        {
            if (CanAct) OnHandleAction?.Invoke();
        }
    }
}