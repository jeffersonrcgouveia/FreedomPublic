using Freedom.Characters.Data;
using Freedom.Characters.Data.Attributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Freedom.Scenes.CharacterSelection.Attributes
{
	public class CharacterAttributesTextPopulator : MonoBehaviour
	{
		[SerializeField] CharacterAttributesDataLoader dataLoader;

		[SerializeField] TextMeshProUGUI nameText;
		[SerializeField] TextMeshProUGUI damageText;
		[SerializeField] TextMeshProUGUI attackSpeedText;
		[SerializeField] TextMeshProUGUI reachText;

		RectTransform _nameParentLayoutGroup;

		void Awake() => _nameParentLayoutGroup = (RectTransform) nameText.transform.parent;

		void OnEnable() => dataLoader.OnLoadData += LoadCharacterAttributes;

		void OnDisable() => dataLoader.OnLoadData -= LoadCharacterAttributes;

		void LoadCharacterAttributes(CharacterAttributesData data)
		{
			nameText.text = data.Name;
			LayoutRebuilder.ForceRebuildLayoutImmediate(_nameParentLayoutGroup);
			damageText.text = data.Damage.ToString();
			attackSpeedText.text = data.AttackSpeed.ToString();
			reachText.text = data.Reach.ToString();
		}
	}
}