using ScriptableEvents.Variables.Base;
using UnityEngine;
using static ScriptableEvents.Constants.ScriptableVariablesConstants;

namespace ScriptableEvents.Variables
{
	[CreateAssetMenu(menuName =  MenuName + BoolName, fileName = BoolName)]
	public class BoolScriptableVariable : ScriptableVariableBase<bool>
	{
	}
}