using System;
using Freedom.Characters.Data.Record;
using Freedom.Scripts.Extensions.Projects.ScriptableEvents.Variables;
using UnityEngine;

namespace Freedom.Scenes.Record
{
	public class CharacterRecordChecker : MonoBehaviour
	{
		[SerializeField] PlayerPunctuationScriptableVariable punctuationState;

		public event Action<bool, int> OnAchievedWaveRecord;

		public event Action<bool, int> OnAchievedEnemiesKilledRecord;

		public event Action OnAchievedAnyRecord;

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