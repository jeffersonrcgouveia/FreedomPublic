using ScriptableEvents.Events.Base;
using UnityEngine;
using static ScriptableEvents.Constants.ScriptableEventsConstants;

namespace ScriptableEvents.Events
{
	[CreateAssetMenu(menuName =  MenuName + GameObjectName, fileName = GameObjectName)]
	public class GameObjectScriptableEvent : ScriptableEventBase<GameObject>
	{
	}
}