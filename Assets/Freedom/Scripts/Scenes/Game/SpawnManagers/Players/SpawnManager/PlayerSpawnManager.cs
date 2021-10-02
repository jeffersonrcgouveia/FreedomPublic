using System;
using Freedom.Players.Selector;
using UnityEngine;

namespace Freedom.Scenes.Game.SpawnManagers.Players.SpawnManager
{
    public class PlayerSpawnManager : MonoBehaviour, IPlayerSpawnManager
    {
        [SerializeField] GameObject playerPrefab;

        public Action<GameObject> OnSpawnPlayer { get; set; }

        public Action<GameObject> OnSetCharacterPrefab { get; set; }

        public Action<GameObject> OnSpawnCharacter { get; set; }

        void Start()
        {
            GameObject player = SpawnPlayer();
            CharacterSelector characterSelector = player.GetComponent<CharacterSelector>();
            if (OnSetCharacterPrefab != null) characterSelector.OnSetCharacterPrefab += OnSetCharacterPrefab;
            if (OnSpawnCharacter != null) characterSelector.OnSetCharacter += OnSpawnCharacter;
        }

        GameObject SpawnPlayer()
        {
            GameObject player = Instantiate(playerPrefab);
            OnSpawnPlayer?.Invoke(player);
            return player;
        }
    }
}