using UnityEngine;

namespace Freedom.Commons.Extensions
{
    public static class ObjectUnityEngineExtensions
    {
        public static void Destroy(this Object obj)
        {
            if (Application.isPlaying)
            {
                Object.Destroy(obj);
            }
            else
            {
                Object.DestroyImmediate(obj);
            }
        }
    }
}
