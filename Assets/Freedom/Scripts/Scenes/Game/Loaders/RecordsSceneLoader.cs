using Freedom.Characters.Conditions;
using Freedom.Scenes.Record;
using Tymski;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Freedom.Scenes.Game.Loaders
{
    public class RecordsSceneLoader : MonoBehaviour
    {
        [SerializeField] SceneReference recordScene;

        [SerializeField] SceneReference gameOverScene;

        CharacterRecordChecker _recordChecker;

        SceneReference _scene;

        void Awake()
        {
            _recordChecker = GetComponent<CharacterRecordChecker>();
            _scene = gameOverScene;
        }

        public void SwitchScene() => _scene = recordScene;

        public void RegisterLoadSceneEvent(GameObject character)
        {
            character.GetComponentInChildren<CharacterDied>().OnDie += LoadGameOverScene;
        }

        void LoadGameOverScene()
        {
            _recordChecker.CheckAchievedRecords();
            SceneManager.LoadScene(_scene, LoadSceneMode.Additive);
        }
    }
}