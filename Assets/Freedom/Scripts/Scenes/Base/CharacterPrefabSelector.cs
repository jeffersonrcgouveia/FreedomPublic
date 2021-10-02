using System;
using Freedom.Players.Selector.Base;
using UnityEngine;

namespace Freedom.Scenes.Base
{
	public class CharacterPrefabSelector : MonoBehaviour, ICharacterSelector
	{
		[field: SerializeField] public GameObject CharacterPrefab { get; set; }

		public Action<GameObject> OnSetCharacterPrefab { get; set; }

		GameObject _lastCharacterPrefab;

		void Start()
		{
			if (CharacterPrefab) OnSetCharacterPrefab?.Invoke(_lastCharacterPrefab = CharacterPrefab);
		}

		public void Update()
		{
			if (CharacterPrefab == _lastCharacterPrefab) return;
			_lastCharacterPrefab = CharacterPrefab;
			OnSetCharacterPrefab?.Invoke(CharacterPrefab);
		}
	}
}