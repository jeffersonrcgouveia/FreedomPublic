using System;
using UnityEngine;

namespace Freedom.Characters.Actions.ComboAttack
{
    public class ComboValidator : MonoBehaviour
    {
        [SerializeField] int comboHits = 3;

        const int ComboCounterInitialValue = -1;

        int _comboCounter = ComboCounterInitialValue;

        public event Action OnStartCombo;

        public event Action<int> OnUpdateComboCounter;

        public void ValidateCombo()
        {
            if (_comboCounter == -1) OnStartCombo?.Invoke();

            _comboCounter = Mathf.Clamp(++_comboCounter, 0, comboHits - 1);
            OnUpdateComboCounter?.Invoke(_comboCounter);
        }

        public void ResetComboCounter() => OnUpdateComboCounter?.Invoke(_comboCounter = ComboCounterInitialValue);
    }
}