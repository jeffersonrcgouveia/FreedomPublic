using ScriptableEvents.Variables.Base;
using UnityEngine;
using static ScriptableEvents.Constants.ScriptableVariablesConstants;

namespace ScriptableEvents.Variables
{
	[CreateAssetMenu(menuName =  MenuName + FloatName, fileName = FloatName)]
	public class FloatScriptableVariable : ScriptableVariableBase<float>
	{
	}
}