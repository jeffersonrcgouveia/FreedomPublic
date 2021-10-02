using UnityEngine;

namespace Freedom.Characters.Actions.Roll
{   
    public class RollSpeed : MonoBehaviour
    {
        [SerializeField] RollEvents rollEvents;

        [SerializeField] float acceleration = 10;

        float _timeElapsed;

        public float CalculateRollSpeed()
        {
            _timeElapsed += Time.deltaTime / rollEvents.RollingDuration;
            return Mathf.Lerp(acceleration, 0, _timeElapsed);
        }

        public void ResetTimeElapsed() => _timeElapsed = 0;
    }
}