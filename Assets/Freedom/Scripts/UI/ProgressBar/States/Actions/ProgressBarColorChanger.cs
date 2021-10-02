using UnityEngine;
using UnityEngine.UI;

namespace Freedom.UI.ProgressBar.States.Actions
{
    public class ProgressBarColorChanger : MonoBehaviour
    {
        [SerializeField] Image fill;

        [SerializeField] Color color;

        Color _oldColor;

        bool _changed;

        public void ChangeColor()
        {
            if (_changed) return;
            _oldColor = fill.color;
            fill.color = color;
            _changed = true;
        }

        public void UnchangeColor()
        {
            if (!_changed) return;
            fill.color = _oldColor;
            _changed = false;
        }
    }
}