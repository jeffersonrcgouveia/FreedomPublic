using Freedom.Scripts.Extensions.Projects.ScriptableEvents.Variables;
using TMPro;
using UnityEngine;

namespace Freedom.Scenes.EnemyWave
{
    public class EnemyWaveStateLoader : MonoBehaviour
    {
        [SerializeField] EnemyWaveScriptableVariable waveState;

        [SerializeField] TextMeshProUGUI waveText;

        [SerializeField] TextMeshProUGUI enemiesCountText;

        void OnEnable()
        {
            waveText.text = waveState.Number.ToString();
            enemiesCountText.text = waveState.EnemiesCount.ToString();
        }
    }
}