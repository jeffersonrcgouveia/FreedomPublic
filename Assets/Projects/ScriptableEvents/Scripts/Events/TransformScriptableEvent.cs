using ScriptableEvents.Events.Base;
using UnityEngine;
using static ScriptableEvents.Constants.ScriptableEventsConstants;

namespace ScriptableEvents.Events
{
	[CreateAssetMenu(menuName =  MenuName + TransformName, fileName = TransformName)]
	public class TransformScriptableEvent : ScriptableEventBase<Transform>
	{
	}
}