using Freedom.Scenes.Game.SpawnManagers.Enemies.SpawnManager;
using Freedom.Scenes.Game.SpawnManagers.Enemies.Waves;
using Freedom.Scripts.Extensions.Projects.ScriptableEvents.Variables;
using UnityEngine;

namespace Freedom.Scenes.Game
{
    public class PlayerPunctuationStateManager : MonoBehaviour
    {
        [SerializeField] EnemyWaveStateManager stateManager;
        [SerializeField] WaveEnemyHealthManager healthManager;

        [SerializeField] PlayerPunctuationScriptableVariable punctuationState;

        [SerializeField] bool resetPunctuationState = true;

        void Awake()
        {
            if (!resetPunctuationState) return;
            punctuationState.Wave = 0;
            punctuationState.EnemiesKilled = 0;
        }

        void OnEnable()
        {
            stateManager.OnSetWave += SetWaveState;
            healthManager.OnEnemyKilled += IncrementEnemiesKilledState;
        }

        void OnDisable()
        {
            stateManager.OnSetWave -= SetWaveState;
            healthManager.OnEnemyKilled -= IncrementEnemiesKilledState;
        }

        void SetWaveState(EnemyWaveScriptableVariable waveState) => punctuationState.Wave = waveState.Number;

        void IncrementEnemiesKilledState() => punctuationState.EnemiesKilled++;
    }
}