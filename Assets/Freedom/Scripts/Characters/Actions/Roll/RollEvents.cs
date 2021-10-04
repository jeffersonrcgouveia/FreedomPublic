using System;
using System.Collections;
using UnityEngine;

namespace Freedom.Characters.Actions.Roll
{   
    public class RollEvents : MonoBehaviour
    {
        [field: SerializeField] public float RollingDuration { get; private set; } = 1;

        public event Action OnRollingStart;

        public event Action OnRolling;

        public event Action OnRollingEnd;

        bool _isRolling;

        void Update()
        {
            if (_isRolling) OnRolling?.Invoke();
        }

        public void Roll()
        {
            _isRolling = true;
            OnRollingStart?.Invoke();
            StartCoroutine(RollCoroutine());
        }

        IEnumerator RollCoroutine()
        {
            yield return new WaitForSeconds(RollingDuration);
            OnRollingEnd?.Invoke();
            _isRolling = false;
        }
    }
}