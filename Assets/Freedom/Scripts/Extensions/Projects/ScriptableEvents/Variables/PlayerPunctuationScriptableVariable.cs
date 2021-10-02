using ScriptableEvents.Variables.Base;
using UnityEngine;
using static ScriptableEvents.Constants.ScriptableVariablesConstants;
using static Freedom.Scripts.Extensions.Projects.ScriptableEvents.Constants.ScriptableVariablesExtensionsConstants;

namespace Freedom.Scripts.Extensions.Projects.ScriptableEvents.Variables
{
	[CreateAssetMenu(menuName =  MenuName + PlayerPunctuationName, fileName = PlayerPunctuationName)]
	public class PlayerPunctuationScriptableVariable : ScriptableVariableBase
	{
		[field: SerializeField] public int Wave { get; set; }

		[field: SerializeField] public int EnemiesKilled { get; set; }
	}
}