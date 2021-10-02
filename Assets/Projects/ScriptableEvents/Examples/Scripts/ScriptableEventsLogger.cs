using UnityEngine;

namespace ScriptableEvents.Examples
{
	public class ScriptableEventsLogger : MonoBehaviour
	{
		public void LogScriptableEvent() => Debug.Log("ScriptableEvent");

		public void LogGameObject(GameObject gameObject) => Debug.Log($"GameObject: {gameObject}");

		public void LogTransform(Transform transform) => Debug.Log($"Transform: {transform}");

		public void LogVector3(Vector3 vector3) => Debug.Log($"Vector3: {vector3}");

		public void LogInt(int number) => Debug.Log($"Int: {number}");

		public void LogFloat(float number) => Debug.Log($"Float: {number}");

		public void LogBool(bool flag) => Debug.Log($"Bool: {flag}");

		public void LogString(string text) => Debug.Log($"String: {text}");
	}
}