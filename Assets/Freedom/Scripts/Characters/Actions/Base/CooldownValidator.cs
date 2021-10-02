using System;
using UnityEngine;

namespace Freedom.Characters.Actions.Base
{
    public class CooldownValidator : MonoBehaviour
    {
        [SerializeField] float cooldown;

        public Action OnValidateCooldown { get; set; }

        float _timeStamp;

        public void ValidateCooldown()
        {
            if (_timeStamp > Time.time) return;
            OnValidateCooldown.Invoke();
            StartCooldownTimer();
        }

        void StartCooldownTimer() => _timeStamp = cooldown + Time.time;
    }
}