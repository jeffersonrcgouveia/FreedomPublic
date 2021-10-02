using TMPro;
using UnityEngine;

namespace Freedom.Scenes.Record
{
	public class CharacterRecordStyleApplier : MonoBehaviour
	{
		const string RecordText = "(Record!)";

		[SerializeField] TextMeshProUGUI waveText;
		[SerializeField] TextMeshProUGUI enemiesKilledText;

		[SerializeField] Color recordColor;
		[SerializeField] float recordFontSize = 35;
		[SerializeField] float recordRotation = 10;
		[SerializeField] Vector4 recordMargin = new Vector4(0, 25, -35, 0);

		CharacterRecordChecker _recordChecker;

		void Awake() => _recordChecker = GetComponent<CharacterRecordChecker>();

		void OnEnable()
		{
			_recordChecker.OnAchievedWaveRecord += ApplyWaveTextStyle;
			_recordChecker.OnAchievedEnemiesKilledRecord += ApplyEnemiesKilledTextStyle;
		}

		void OnDisable()
		{
			_recordChecker.OnAchievedWaveRecord -= ApplyWaveTextStyle;
			_recordChecker.OnAchievedEnemiesKilledRecord -= ApplyEnemiesKilledTextStyle;
		}

		public void ApplyWaveTextStyle(bool hasAchieved, int wave)
		{
			if (hasAchieved) ApplyRecordStyle(waveText);
		}

		public void ApplyEnemiesKilledTextStyle(bool hasAchieved, int enemiesKilled)
		{
			if (hasAchieved) ApplyRecordStyle(enemiesKilledText);
		}

		void ApplyRecordStyle(TextMeshProUGUI text)
		{
			RectTransform rect = text.GetComponent<RectTransform>();
			rect.Rotate(new Vector3(0, 0, recordRotation));
			text.fontSize = recordFontSize;
			text.text = $"{text.text} {RecordText}";
			text.color = recordColor;
			text.margin = recordMargin;
		}
	}
}