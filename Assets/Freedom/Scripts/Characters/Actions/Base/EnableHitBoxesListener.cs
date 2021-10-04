using System;
using System.Collections.Generic;
using Freedom.Characters.Colliders;
using UnityEngine;

namespace Freedom.Characters.Actions.Base
{
    public class EnableHitBoxesListener : MonoBehaviour
    {
        [SerializeField] List<HitBox> hitBoxes;

        public event Action OnEnableHitBoxes;

        public event Action OnDisableHitBoxes;

        public event Action<GameObject> OnHit;

        public void InvokeOnEnable() => OnEnableHitBoxes?.Invoke();

        public void InvokeOnDisable() => OnDisableHitBoxes?.Invoke();

        public void InvokeOnHit(GameObject other) => OnHit?.Invoke(other);

        public void PopulateHitBoxes()
        {
            foreach (HitBox hitBox in hitBoxes) hitBox.EnableListener = this;
        }
    }
}