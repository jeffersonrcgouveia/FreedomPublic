using ScriptableEvents.Variables.Base;
using UnityEngine;
using static ScriptableEvents.Constants.ScriptableVariablesConstants;
using static Freedom.Scripts.Extensions.Projects.ScriptableEvents.Constants.ScriptableVariablesExtensionsConstants;

namespace Freedom.Scripts.Extensions.Projects.ScriptableEvents.Variables
{
	[CreateAssetMenu(menuName =  MenuName + EnemyWaveName, fileName = EnemyWaveName)]
	public class EnemyWaveScriptableVariable : ScriptableVariableBase
	{
		[field: SerializeField] public int Number { get; set; }

		[field: SerializeField] public int EnemiesCount { get; set; }
	}
}