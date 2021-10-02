using System;
using Freedom.Scenes.Game.SpawnManagers.Players.SpawnManager;
using Freedom.Scenes.Record;
using UnityEngine;

namespace Freedom.Scenes.Game.Loaders
{
	public class SceneLoaderCharacterRecordsFiller : MonoBehaviour
	{
		[SerializeField] PlayerSpawnManager spawnManager;
		[SerializeField] RecordsSceneLoader sceneLoader;
		[SerializeField] CharacterRecordDataLoader dataLoader;
		[SerializeField] CharacterRecordChecker checker;

		void OnEnable()
		{
			dataLoader.OnLoadData += checker.CheckAchievedRecords;
			checker.OnAchievedAnyRecord += sceneLoader.SwitchScene;
			spawnManager.OnSpawnCharacter += sceneLoader.RegisterLoadSceneEvent;
			spawnManager.OnSetCharacterPrefab += dataLoader.LoadData;
		}

		void OnDisable()
		{
			dataLoader.OnLoadData -= checker.CheckAchievedRecords;
			checker.OnAchievedAnyRecord -= sceneLoader.SwitchScene;
			spawnManager.OnSpawnCharacter -= sceneLoader.RegisterLoadSceneEvent;
			spawnManager.OnSetCharacterPrefab -= dataLoader.LoadData;
		}
	}
}