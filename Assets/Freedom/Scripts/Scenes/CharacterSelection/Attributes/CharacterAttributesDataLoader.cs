using System;
using Freedom.Characters.Data;
using Freedom.Characters.Data.Attributes;
using Freedom.Characters.Data.Base;
using Freedom.Players.Selector;
using UnityEngine;

namespace Freedom.Scenes.CharacterSelection.Attributes
{
	public class CharacterAttributesDataLoader : MonoBehaviour
	{
		[SerializeField] CharacterAttributesDatabase database;

		[field: SerializeField] public Action<CharacterAttributesData> OnLoadData { get; set; }

		[SerializeField] CharacterSelector characterSelector;

		void OnEnable() => characterSelector.OnSetCharacterPrefab += LoadData;

		void OnDisable() => characterSelector.OnSetCharacterPrefab -= LoadData;

		void LoadData(GameObject characterPrefab)
		{
			CharacterAttributesData data = database.FindById(characterPrefab);
			OnLoadData?.Invoke(data);
		}
	}
}