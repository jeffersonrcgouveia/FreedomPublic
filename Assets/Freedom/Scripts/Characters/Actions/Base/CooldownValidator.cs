using System;
using UnityEngine;

namespace Freedom.Characters.Actions.Base
{
    public class CooldownValidator : MonoBehaviour
    {
        [SerializeField] float cooldown;

        public event Action OnValidateCooldown;

        float _timeStamp;

        public void ValidateCooldown()
        {
            if (_timeStamp > Time.time) return;
            OnValidateCooldown?.Invoke();
            StartCooldownTimer();
        }

        void StartCooldownTimer() => _timeStamp = cooldown + Time.time;
    }
}