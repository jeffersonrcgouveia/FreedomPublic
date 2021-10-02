using ScriptableEvents.Variables.Base;
using UnityEngine;
using static ScriptableEvents.Constants.ScriptableVariablesConstants;

namespace ScriptableEvents.Variables
{
	[CreateAssetMenu(menuName =  MenuName + IntName, fileName = IntName)]
	public class IntScriptableVariable : ScriptableVariableBase<int>
	{
	}
}