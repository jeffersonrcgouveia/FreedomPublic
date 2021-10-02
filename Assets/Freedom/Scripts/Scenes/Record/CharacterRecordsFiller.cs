using System;
using Freedom.Scenes.Base;
using Freedom.Scenes.CharacterSelection.Attributes;
using Freedom.Scenes.Game.SpawnManagers.Players.SpawnManager;
using UnityEngine;

namespace Freedom.Scenes.Record
{
	public class CharacterRecordsFiller : MonoBehaviour
	{
		[SerializeField] CharacterPrefabSelector selector;
		[SerializeField] CharacterSelectorStateLoader stateLoader;
		[SerializeField] CharacterRecordDataLoader dataLoader;
		[SerializeField] CharacterRecordChecker checker;
		[SerializeField] CharacterRecordDataSaver dataSaver;
		[SerializeField] CharacterRecordTextPopulator textPopulator;
		[SerializeField] CharacterRecordStyleApplier styleApplier;

		void OnEnable()
		{
			selector.OnSetCharacterPrefab += dataLoader.LoadData;
			dataLoader.OnLoadData += dataSaver.SetData;
			dataLoader.OnLoadData += textPopulator.SetTexts;
			dataLoader.OnLoadData += checker.CheckAchievedRecords;
			checker.OnAchievedWaveRecord += dataSaver.SaveWaveData;
			checker.OnAchievedEnemiesKilledRecord += dataSaver.SaveEnemiesKilledData;
			checker.OnAchievedWaveRecord += textPopulator.SaveWaveText;
			checker.OnAchievedEnemiesKilledRecord += textPopulator.SaveEnemiesKilledText;
			checker.OnAchievedWaveRecord += styleApplier.ApplyWaveTextStyle;
			checker.OnAchievedEnemiesKilledRecord += styleApplier.ApplyEnemiesKilledTextStyle;
			selector.CharacterPrefab = stateLoader.GetData();
		}

		void OnDisable()
		{
			selector.OnSetCharacterPrefab -= dataLoader.LoadData;
			dataLoader.OnLoadData -= dataSaver.SetData;
			dataLoader.OnLoadData -= textPopulator.SetTexts;
			dataLoader.OnLoadData -= checker.CheckAchievedRecords;
			checker.OnAchievedWaveRecord -= dataSaver.SaveWaveData;
			checker.OnAchievedEnemiesKilledRecord -= dataSaver.SaveEnemiesKilledData;
			checker.OnAchievedWaveRecord -= textPopulator.SaveWaveText;
			checker.OnAchievedEnemiesKilledRecord -= textPopulator.SaveEnemiesKilledText;
			checker.OnAchievedWaveRecord -= styleApplier.ApplyWaveTextStyle;
			checker.OnAchievedEnemiesKilledRecord -= styleApplier.ApplyEnemiesKilledTextStyle;
			selector.CharacterPrefab = stateLoader.GetData();
		}
	}
}