using Freedom.Camera;
using Freedom.Players.Selector.Configurers;
using UnityEngine;

namespace Freedom.Scenes.Game.SpawnManagers.Players.SpawnManager
{
    public class PlayerCharacterBillboardConfigurerPopulator : MonoBehaviour
    {
        [SerializeField] FollowMouseCamera followMouseCamera;

        [field: SerializeField] public Color HealthBarFill { get; set; }
        
        IPlayerSpawnManager _spawnManager;

        void Awake() => _spawnManager = GetComponent<IPlayerSpawnManager>();

        void OnEnable() => _spawnManager.OnSpawnPlayer += PopulatePlayerFields;

        void OnDisable() => _spawnManager.OnSpawnPlayer -= PopulatePlayerFields;

        void PopulatePlayerFields(GameObject player)
        {
            PlayerCharacterBillboardConfigurer bbConfigurer = player.GetComponent<PlayerCharacterBillboardConfigurer>();
            bbConfigurer.CameraTransform = followMouseCamera.transform;
            bbConfigurer.HealthBarFill = HealthBarFill;
        }
    }
}