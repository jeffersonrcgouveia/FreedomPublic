using UnityEngine;
using UnityEngine.Events;

namespace Freedom.UI.ProgressBar.States
{
    [ExecuteInEditMode]
    public class ProgressBarLowFillListener : MonoBehaviour
    {
        [SerializeField, Range(0, 1)] float lowFillAmountValue = 0.2f;

        [field: SerializeField, Space] public UnityEvent<float> OnLowFillAmount { get; set; }

        [field: SerializeField] public UnityEvent<float> OnNormalFillAmount { get; set; }

        public void CheckState(float fillAmount)
        {
            (fillAmount <= lowFillAmountValue ? OnLowFillAmount : OnNormalFillAmount).Invoke(fillAmount);
        }
    }
}