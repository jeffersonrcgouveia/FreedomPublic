using ScriptableEvents.Events.Base;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableEvents.Listeners.Base
{
	public abstract class ScriptableEventListenerBase<T> : MonoBehaviour
	{
		[SerializeField] ScriptableEventBase<T> @event;

		
		public ScriptableEventBase<T> Event
		{
			get => @event;
			set
			{
				@event = value;
				if (enabled) @event.AddListener(this);
			}
		}

		[field: SerializeField, Space] UnityEvent<T> Response { get; set; }

		void OnEnable()
		{
			if (Event) Event.AddListener(this);
		}

		void OnDisable()
		{
			if (Event) Event.RemoveListener(this);
		}

		public void InvokeResponse(T param) => Response.Invoke(param);
	}

	public abstract class ScriptableEventListenerBase<T, T2> : MonoBehaviour
	{
		[SerializeField] ScriptableEventBase<T, T2> @event;

		public ScriptableEventBase<T, T2> Event
		{
			get => @event;
			set
			{
				@event = value;
				if (enabled) @event.AddListener(this);
			}
		}

		[field: SerializeField, Space] UnityEvent<T, T2> Response { get; set; }

		void OnEnable()
		{
			if (Event) Event.AddListener(this);
		}

		void OnDisable()
		{
			if (Event) Event.RemoveListener(this);
		}

		public void InvokeResponse(T param, T2 param2) => Response.Invoke(param, param2);
	}
}