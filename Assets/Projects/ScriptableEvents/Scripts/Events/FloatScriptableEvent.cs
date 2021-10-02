using ScriptableEvents.Events.Base;
using UnityEngine;
using static ScriptableEvents.Constants.ScriptableEventsConstants;

namespace ScriptableEvents.Events
{
	[CreateAssetMenu(menuName =  MenuName + FloatName, fileName = FloatName)]
	public class FloatScriptableEvent : ScriptableEventBase<float>
	{
	}
}