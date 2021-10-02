using Freedom.Camera;
using Freedom.Characters.Locomotion.Direction;
using UnityEngine;

namespace Freedom.Players.Camera
{
    [ExecuteInEditMode]
    public class PlayerCameraFiller : MonoBehaviour
    {
        [SerializeField] FollowCamera followCamera;
        [SerializeField] FollowMouseCamera followMouseCamera;

        [SerializeField, Space] CharacterDirection direction;

        public void PopulateFields(GameObject character)
        {
            followCamera.FollowedTransform = character.transform;
            direction = character.GetComponentInChildren<CharacterDirection>();
            followMouseCamera.OnCalculateMouseDirection += direction.SetAimingDirection;
        }
    }
}