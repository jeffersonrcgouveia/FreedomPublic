using System.Collections.Generic;
using ScriptableEvents.Variables;
using UnityEngine;

namespace Freedom.Players.Selector
{
	public class CharacterSelectionArrows : MonoBehaviour
	{
		[SerializeField] CharacterSelector characterSelector;

		[SerializeField] GameObjectScriptableVariable selectedCharacterPrefabState;

		[SerializeField] List<GameObject> characters;

		int SelectedIndex { get => _selectedIndex; set => _selectedIndex = CalculateCharacterIndex(value); }

		int _selectedIndex;

		void Awake() => SelectCharacter(SelectedIndex);

		public void NextCharacter() => SelectCharacter(SelectedIndex + 1);

		public void PreviousCharacter() => SelectCharacter(SelectedIndex - 1);

		void SelectCharacter(int characterIndex)
		{
			SelectedIndex = characterIndex;
			GameObject characterPrefab = characters[SelectedIndex];
			characterSelector.CharacterPrefab = characterPrefab;
			selectedCharacterPrefabState.Data = characterPrefab;
		}

		int CalculateCharacterIndex(int characterIndex)
		{
			if (characterIndex >= characters.Count)
			{
				characterIndex = 0;
			}
			else if (characterIndex < 0)
			{
				characterIndex = characters.Count -1;
			}

			return characterIndex;
		}
	}
}