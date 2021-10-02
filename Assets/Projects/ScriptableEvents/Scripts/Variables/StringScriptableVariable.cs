using ScriptableEvents.Variables.Base;
using UnityEngine;
using static ScriptableEvents.Constants.ScriptableVariablesConstants;

namespace ScriptableEvents.Variables
{
	[CreateAssetMenu(menuName =  MenuName + StringName, fileName = StringName)]
	public class StringScriptableVariable : ScriptableVariableBase<string>
	{
	}
}