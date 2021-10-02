using System.Collections.Generic;
using ScriptableEvents.Listeners.Base;
using UnityEngine;

namespace ScriptableEvents.Events.Base
{
	public abstract class ScriptableEventBase<T> : ScriptableObject
	{
		List<ScriptableEventListenerBase<T>> Listeners { get; set; } = new List<ScriptableEventListenerBase<T>>();

		public void Invoke(T param)
		{
			for (int i = Listeners.Count - 1; i >= 0; i--) Listeners[i].InvokeResponse(param);
		}

		public void AddListener(ScriptableEventListenerBase<T> listener) => Listeners.Add(listener);

		public void RemoveListener(ScriptableEventListenerBase<T> listener) => Listeners.Remove(listener);
	}

	public abstract class ScriptableEventBase<T, T2> : ScriptableObject
	{
		List<ScriptableEventListenerBase<T, T2>> Listeners { get; set; } = new List<ScriptableEventListenerBase<T, T2>>();

		public void Invoke(T param, T2 param2)
		{
			for (int i = Listeners.Count - 1; i >= 0; i--) Listeners[i].InvokeResponse(param, param2);
		}

		public void AddListener(ScriptableEventListenerBase<T, T2> listener) => Listeners.Add(listener);

		public void RemoveListener(ScriptableEventListenerBase<T, T2> listener) => Listeners.Remove(listener);
	}
}