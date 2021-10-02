using ScriptableEvents.Events.Base;
using UnityEngine;
using static ScriptableEvents.Constants.ScriptableEventsConstants;

namespace ScriptableEvents.Events
{
	[CreateAssetMenu(menuName =  MenuName + Vector3Name, fileName = Vector3Name)]
	public class Vector3ScriptableEvent : ScriptableEventBase<Vector3>
	{
	}
}