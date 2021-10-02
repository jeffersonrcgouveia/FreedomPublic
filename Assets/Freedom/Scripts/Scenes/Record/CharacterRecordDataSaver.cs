using Freedom.Characters.Data.Record;
using UnityEngine;

namespace Freedom.Scenes.Record
{
	public class CharacterRecordDataSaver : MonoBehaviour
	{
		CharacterRecordData _data;

		public void SetData(CharacterRecordData data) => _data = data;

		public void SaveWaveData(bool hasAchieved, int wave)
		{
			if (hasAchieved) _data.Wave = wave;
		}

		public void SaveEnemiesKilledData(bool hasAchieved, int enemiesKilled)
		{
			if (hasAchieved) _data.EnemiesKilled = enemiesKilled;
		}
	}
}