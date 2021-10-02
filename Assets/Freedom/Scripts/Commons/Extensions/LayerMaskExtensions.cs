using UnityEngine;

namespace Freedom.Commons.Extensions
{
    public static class LayerMaskExtensions
    {
        public static int ValueIndex(this LayerMask layerMask) => (int) Mathf.Log(layerMask.value, 2);
    }
}
