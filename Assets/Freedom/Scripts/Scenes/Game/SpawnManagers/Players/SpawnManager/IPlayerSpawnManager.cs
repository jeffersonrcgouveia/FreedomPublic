using System;
using UnityEngine;

namespace Freedom.Scenes.Game.SpawnManagers.Players.SpawnManager
{
    public interface IPlayerSpawnManager
    {
        public event Action<GameObject> OnSpawnPlayer;

        public event Action<GameObject> OnSpawnCharacter;
    }
}