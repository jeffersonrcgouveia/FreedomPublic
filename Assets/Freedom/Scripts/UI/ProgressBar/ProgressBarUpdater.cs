using UnityEngine;
using UnityEngine.Events;

namespace Freedom.UI.ProgressBar
{
    [ExecuteInEditMode]
    public class ProgressBarUpdater : MonoBehaviour
    {
        [field: SerializeField] public RectTransform Fill { get; set; }

        [field: SerializeField, Range(0, 1)] public float FillAmount { get; set; } = 0.5f;

        [field: SerializeField, Space] public UnityEvent<float> OnChange { get; set; }

        float _lastFillAmount;

        void Update() => UpdateValue();

        void UpdateValue()
        {
            if (FillAmount != _lastFillAmount)
            {
                _lastFillAmount = FillAmount = Mathf.Clamp01(FillAmount);
                Fill.anchorMax = new Vector2(FillAmount, Fill.anchorMax.y);
                OnChange.Invoke(FillAmount);
            }
        }
    }
}
