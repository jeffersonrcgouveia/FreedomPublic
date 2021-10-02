using System;
using Freedom.Scenes.Game.SpawnManagers.Enemies.SpawnManager;
using Freedom.Scripts.Extensions.Projects.ScriptableEvents.Variables;
using UnityEngine;

namespace Freedom.Scenes.Game.SpawnManagers.Enemies.Waves
{
    public class EnemyWaveStateManager : MonoBehaviour
    {
        [SerializeField] WaveEnemyHealthManager healthManager;

        [SerializeField] EnemyWaveScriptableVariable waveState;

        public Action<EnemyWaveScriptableVariable> OnSetWave { get; set; }

        void Awake() => SetWaveNumber(0);

        void OnEnable() => healthManager.OnWaveEnemiesKilled += IncrementWaveNumber;

        void OnDisable() => healthManager.OnWaveEnemiesKilled -= IncrementWaveNumber;

        void IncrementWaveNumber()
        {
            SetWaveNumber(waveState.Number + 1);
            OnSetWave?.Invoke(waveState);
        }

        void SetWaveNumber(int number)
        {
            waveState.Number = number;
            waveState.EnemiesCount = number;
        }
    }
}