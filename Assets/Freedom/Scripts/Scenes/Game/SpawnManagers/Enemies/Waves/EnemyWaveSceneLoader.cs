using System;
using System.Collections;
using Freedom.Scripts.Extensions.Projects.ScriptableEvents.Variables;
using Tymski;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Freedom.Scenes.Game.SpawnManagers.Enemies.Waves
{
    [RequireComponent(typeof(EnemyWaveStateManager))]
    public class EnemyWaveSceneLoader : MonoBehaviour
    {
        [SerializeField] SceneReference waveScene;

        public event Action<EnemyWaveScriptableVariable> OnLoadEnemyWave;

        EnemyWaveStateManager _stateManager;

        void Awake() => _stateManager = GetComponent<EnemyWaveStateManager>();

        void OnEnable() => _stateManager.OnSetWave += LoadWaveScene;

        void OnDisable() => _stateManager.OnSetWave -= LoadWaveScene;

        void LoadWaveScene(EnemyWaveScriptableVariable state) => StartCoroutine(LoadWaveSceneCoroutine(state));

        IEnumerator LoadWaveSceneCoroutine(EnemyWaveScriptableVariable state)
        {
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene(waveScene, LoadSceneMode.Additive);
            yield return new WaitForSeconds(5);
            SceneManager.UnloadSceneAsync(waveScene);
            OnLoadEnemyWave?.Invoke(state);
        }
    }
}