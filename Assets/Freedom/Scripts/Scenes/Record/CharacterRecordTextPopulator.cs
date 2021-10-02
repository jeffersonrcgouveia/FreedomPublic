using Freedom.Characters.Data.Record;
using TMPro;
using UnityEngine;

namespace Freedom.Scenes.Record
{
	public class CharacterRecordTextPopulator : MonoBehaviour
	{
		[SerializeField] TextMeshProUGUI nameText;
		[SerializeField] TextMeshProUGUI waveText;
		[SerializeField] TextMeshProUGUI enemiesKilledText;

		public void SetTexts(CharacterRecordData data)
		{
			nameText.text = data.Name;
			waveText.text = data.Wave.ToString();
			enemiesKilledText.text = data.EnemiesKilled.ToString();
		}

		public void SaveWaveText(bool hasAchieved, int wave) => waveText.text = wave.ToString();

		public void SaveEnemiesKilledText(bool hasAchieved, int enemiesKilled) => enemiesKilledText.text = enemiesKilled.ToString();
	}
}