using System;
using Freedom.Commons.Extensions;
using Freedom.Players.Selector;
using Freedom.Scenes.Game.SpawnManagers.Enemies.SpawnManager.Checkers;
using Freedom.Scenes.Game.SpawnManagers.Enemies.Waves;
using Freedom.Scenes.Game.SpawnManagers.Players.SpawnManager;
using Freedom.Scripts.Extensions.Projects.ScriptableEvents.Variables;
using UnityEngine;

namespace Freedom.Scenes.Game.SpawnManagers.Enemies.SpawnManager
{
    [RequireComponent(typeof(ObstaclesChecker))]
    public class EnemySpawnManager : MonoBehaviour, IPlayerSpawnManager
    {
        [SerializeField] EnemyWaveSceneLoader sceneLoader;

        [SerializeField] GameObject aIEnemyPrefab;

        [SerializeField] GameObject[] enemiesPrefabs;

        [SerializeField] Transform[] spawnPoints;

        public Action<GameObject> OnSpawnPlayer { get; set; }

        public Action<GameObject> OnSpawnCharacter { get; set; }

        ObstaclesChecker _obstaclesChecker;

        void Awake() => _obstaclesChecker = GetComponent<ObstaclesChecker>();

        void OnEnable() => sceneLoader.OnLoadEnemyWave += SpawnEnemies;

        void OnDisable() => sceneLoader.OnLoadEnemyWave -= SpawnEnemies;

        void SpawnEnemies(EnemyWaveScriptableVariable waveState) => SpawnEnemies(waveState.Number);

        void SpawnEnemies(int spawnCount)
        {
            while (spawnCount > 0)
            {
                Vector3 spawnPoint = spawnPoints.RandomValue().position;
                if (_obstaclesChecker.HasObstaclesClose(spawnPoint)) continue;
                SpawnEnemy(spawnPoint);
                spawnCount--;
            }
        }

        void SpawnEnemy(Vector3 spawnPoint)
        {
            GameObject aIPlayer = Instantiate(aIEnemyPrefab.gameObject, spawnPoint, Quaternion.identity);
            OnSpawnPlayer?.Invoke(aIPlayer);
            CharacterSelector characterSelector = aIPlayer.GetComponent<CharacterSelector>();
            characterSelector.CharacterPrefab = enemiesPrefabs.RandomValue();
            if (OnSpawnCharacter != null) characterSelector.OnSetCharacter += OnSpawnCharacter.Invoke;
        }
    }
}