using ScriptableEvents.Events.Base;
using UnityEngine;
using static ScriptableEvents.Constants.ScriptableEventsConstants;

namespace ScriptableEvents.Events
{
	[CreateAssetMenu(menuName =  MenuName + BoolName, fileName = BoolName)]
	public class BoolScriptableEvent : ScriptableEventBase<bool>
	{
	}
}