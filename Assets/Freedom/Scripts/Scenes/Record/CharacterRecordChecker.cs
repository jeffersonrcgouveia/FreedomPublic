using System;
using Freedom.Characters.Data.Record;
using Freedom.Scripts.Extensions.Projects.ScriptableEvents.Variables;
using UnityEngine;

namespace Freedom.Scenes.Record
{
	public class CharacterRecordChecker : MonoBehaviour
	{
		[SerializeField] PlayerPunctuationScriptableVariable punctuationState;

		public Action<bool, int> OnAchievedWaveRecord { get; set; }

		public Action<bool, int> OnAchievedEnemiesKilledRecord { get; set; }

		public Action OnAchievedAnyRecord { get; set; }

		CharacterRecordData _data;

		public void CheckAchievedRecords(CharacterRecordData data)
		{
			_data = data;
			CheckAchievedRecords();
		}

		public void CheckAchievedRecords()
		{
			bool hasAchievedWaveRecord = punctuationState.Wave > _data.Wave;
			var hasAchievedEnemiesKilledRecord = punctuationState.EnemiesKilled > _data.EnemiesKilled;

			OnAchievedWaveRecord?.Invoke(hasAchievedWaveRecord, punctuationState.Wave);
			OnAchievedEnemiesKilledRecord?.Invoke(hasAchievedEnemiesKilledRecord, punctuationState.EnemiesKilled);

			if (hasAchievedWaveRecord || hasAchievedEnemiesKilledRecord) OnAchievedAnyRecord?.Invoke();
		}
	}
}