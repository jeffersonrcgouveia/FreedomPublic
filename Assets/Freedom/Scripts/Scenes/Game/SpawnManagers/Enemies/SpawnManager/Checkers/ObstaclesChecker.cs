using UnityEngine;

namespace Freedom.Scenes.Game.SpawnManagers.Enemies.SpawnManager.Checkers
{
    public class ObstaclesChecker : MonoBehaviour
    {
        [SerializeField] LayerMask obstaclesMasks;

        [SerializeField] float minObstacleDistance = 10;

        public bool HasObstaclesClose(Vector3 position)
        {
            return Physics.CheckSphere(position, minObstacleDistance, obstaclesMasks);
        }
    }
}