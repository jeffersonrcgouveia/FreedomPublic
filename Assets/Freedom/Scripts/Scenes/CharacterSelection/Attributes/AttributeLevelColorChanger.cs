using System;
using Freedom.Characters.Data;
using Freedom.Characters.Data.Attributes;
using Freedom.Characters.Data.Attributes.Enums;
using TMPro;
using UnityEngine;

namespace Freedom.Scenes.CharacterSelection.Attributes
{
	public class AttributeLevelColorChanger : MonoBehaviour
	{
		const string NoColorSpecifiedForLevelMessage = "No color specified for the attribute level";

		[SerializeField] CharacterAttributesDataLoader dataLoader;

		[SerializeField] TextMeshProUGUI damageText;
		[SerializeField] TextMeshProUGUI attackSpeedText;
		[SerializeField] TextMeshProUGUI reachText;

		[SerializeField] Color highLevelColor;
		[SerializeField] Color mediumLevelColor;
		[SerializeField] Color lowLevelColor;

		void OnEnable() => dataLoader.OnLoadData += ApplyColors;

		void OnDisable() => dataLoader.OnLoadData -= ApplyColors;

		void ApplyColors(CharacterAttributesData data)
		{
			damageText.color = SwitchLevelColor(data.Damage);
			attackSpeedText.color = SwitchLevelColor(data.AttackSpeed);
			reachText.color = SwitchLevelColor(data.Reach);
		}

		Color SwitchLevelColor(AttributeLevel level)
		{
			return level switch
			{
				AttributeLevel.Low => lowLevelColor,
				AttributeLevel.Medium => mediumLevelColor,
				AttributeLevel.High => highLevelColor,
				_ => throw new ArgumentOutOfRangeException(nameof(level), level, NoColorSpecifiedForLevelMessage)
			};
		}
	}
}