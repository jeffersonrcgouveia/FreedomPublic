using System;
using System.Collections.Generic;
using Freedom.Characters.Attributes;
using Freedom.Players.Selector;
using UnityEngine;

namespace Freedom.Scenes.Game.SpawnManagers.Enemies.SpawnManager
{
    public class WaveEnemyHealthManager : MonoBehaviour
    {
        [SerializeField] EnemySpawnManager spawnManager;

        public Action OnEnemyKilled { get; set; }

        public Action OnWaveEnemiesKilled { get; set; }

        readonly List<GameObject> _killedEnemies = new List<GameObject>();

        readonly Dictionary<GameObject, CharacterHealth> _enemiesHealth = new Dictionary<GameObject, CharacterHealth>();

        bool _eventInvoked;

        void OnEnable() => spawnManager.OnSpawnCharacter += RegisterEnemyCharacter;

        void OnDisable() => spawnManager.OnSpawnCharacter -= RegisterEnemyCharacter;

        void Update() => CheckKilledEnemies();

        void CheckKilledEnemies()
        {
            foreach (KeyValuePair<GameObject, CharacterHealth> pair in _enemiesHealth)
            {
                if (pair.Value.IsHealthOver())
                {
                    _killedEnemies.Add(pair.Key);
                    OnEnemyKilled?.Invoke();
                }
            }

            foreach (GameObject enemy in _killedEnemies)
            {
                _enemiesHealth.Remove(enemy);
            }
            _killedEnemies.Clear();

            if (_eventInvoked || _enemiesHealth.Count > 0) return;
            OnWaveEnemiesKilled?.Invoke();
            _eventInvoked = true;
        }

        void RegisterEnemyCharacter(GameObject character)
        {
            GameObject aIPlayer = character.GetComponentInParent<CharacterSelector>().gameObject;
            _enemiesHealth[aIPlayer] = character.GetComponentInChildren<CharacterHealth>();
            _eventInvoked = false;
        }
    }
}