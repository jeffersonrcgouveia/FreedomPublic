using Freedom.Players.Selector;
using ScriptableEvents.Variables;
using UnityEngine;

namespace Freedom.Scenes.Game.SpawnManagers.Players.SpawnManager
{
    public class PlayerCharacterSpawnManagerStateLoader : MonoBehaviour
    {
        [SerializeField] GameObjectScriptableVariable characterPrefabState;

        IPlayerSpawnManager _spawnManager;

        void Awake() => _spawnManager = GetComponent<IPlayerSpawnManager>();

        void OnEnable() => _spawnManager.OnSpawnPlayer += PopulatePlayerFields;

        void OnDisable() => _spawnManager.OnSpawnPlayer -= PopulatePlayerFields;

        void PopulatePlayerFields(GameObject player)
        {
            CharacterSelector characterSelector = player.GetComponent<CharacterSelector>();
            characterSelector.CharacterPrefab = characterPrefabState.Data;
        }
    }
}