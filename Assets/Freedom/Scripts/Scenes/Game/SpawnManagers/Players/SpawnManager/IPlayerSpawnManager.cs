using System;
using UnityEngine;

namespace Freedom.Scenes.Game.SpawnManagers.Players.SpawnManager
{
    public interface IPlayerSpawnManager
    {
        public Action<GameObject> OnSpawnPlayer { get; set; }

        public Action<GameObject> OnSpawnCharacter { get; set; }
    }
}