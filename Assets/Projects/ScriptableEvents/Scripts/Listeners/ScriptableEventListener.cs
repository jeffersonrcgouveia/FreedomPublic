using ScriptableEvents.Events;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableEvents.Listeners
{
	public class ScriptableEventListener : MonoBehaviour
	{
		[SerializeField] ScriptableEvent @event;

		public ScriptableEvent Event
		{
			get => @event;
			set
			{
				@event = value;
				if (enabled) @event.AddListener(this);
			}
		}

		[field: SerializeField, Space] UnityEvent Response { get; set; }

		void OnEnable()
		{
			if (Event) Event.AddListener(this);
		}

		void OnDisable()
		{
			if (Event) Event.RemoveListener(this);
		}

		public void InvokeResponse() => Response.Invoke();
	}
}