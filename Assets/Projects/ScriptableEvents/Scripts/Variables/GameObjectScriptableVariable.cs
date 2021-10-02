using ScriptableEvents.Variables.Base;
using UnityEngine;
using static ScriptableEvents.Constants.ScriptableVariablesConstants;

namespace ScriptableEvents.Variables
{
	[CreateAssetMenu(menuName =  MenuName + GameObjectName, fileName = GameObjectName)]
	public class GameObjectScriptableVariable : ScriptableVariableBase<GameObject>
	{
	}
}