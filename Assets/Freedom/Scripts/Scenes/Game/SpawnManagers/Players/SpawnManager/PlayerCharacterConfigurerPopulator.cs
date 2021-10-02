using Freedom.Camera;
using Freedom.Players.Selector.Configurers;
using Freedom.Players.UI.Filler;
using UnityEngine;

namespace Freedom.Scenes.Game.SpawnManagers.Players.SpawnManager
{
    [RequireComponent(typeof(PlayerSpawnManager))]
    public class PlayerCharacterConfigurerPopulator : MonoBehaviour
    {
        [SerializeField] FollowMouseCamera followMouseCamera;

        [SerializeField] PlayerUIFiller uIFiller;

        IPlayerSpawnManager _spawnManager;

        void Awake() => _spawnManager = GetComponent<PlayerSpawnManager>();

        void OnEnable() => _spawnManager.OnSpawnPlayer += PopulatePlayerFields;

        void OnDisable() => _spawnManager.OnSpawnPlayer -= PopulatePlayerFields;

        void PopulatePlayerFields(GameObject player)
        {
            PlayerCharacterConfigurer configurer = player.GetComponent<PlayerCharacterConfigurer>();
            configurer.FollowMouseCamera = followMouseCamera;
            configurer.UIFiller = uIFiller;
        }
    }
}