using System;
using Freedom.Characters;
using Freedom.Commons.Extensions;
using Freedom.Players.Selector.Base;

#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;

namespace Freedom.Players.Selector
{
	[ExecuteInEditMode]
	public class CharacterSelector : MonoBehaviour, ICharacterSelector
	{
		[SerializeField, HideInInspector] string characterPrefabPath;

		[field: SerializeField] public GameObject CharacterPrefab { get; set; }

		[field: SerializeField] public LayerMask CharacterLayer { get; set; }

		public event Action<GameObject> OnSetCharacterPrefab;

		public event Action<GameObject> OnSetCharacter;

		public event Action<GameObject> OnDestroyCharacter;

		GameObject _lastCharacterPrefab;

		GameObject _character;

		void Awake()
		{
			_character = FindCharacterInChildren();
			if (!_character) return;
#if UNITY_EDITOR
			CharacterPrefab = _lastCharacterPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(characterPrefabPath);
#endif
			OnSetCharacterPrefab?.Invoke(CharacterPrefab);
			OnSetCharacter?.Invoke(_character);
		}

		GameObject FindCharacterInChildren()
		{
			CharacterRoot characterRoot = GetComponentInChildren<CharacterRoot>();
			return characterRoot ? characterRoot.gameObject : null;
		}

		public void Update()
		{
			if (CharacterPrefab == _lastCharacterPrefab) return;
			_lastCharacterPrefab = CharacterPrefab;
			OnSetCharacterPrefab?.Invoke(CharacterPrefab);
			if (_character)
			{
				OnDestroyCharacter?.Invoke(_character);
				_character.Destroy();
			}

			if (!CharacterPrefab)
			{
				characterPrefabPath = null;
				return;
			}
#if UNITY_EDITOR
			characterPrefabPath = AssetDatabase.GetAssetPath(CharacterPrefab);
#endif
			_character = Instantiate(CharacterPrefab, transform);
			if (CharacterLayer.ValueIndex() > 0) _character.layer = CharacterLayer.ValueIndex();
			OnSetCharacter?.Invoke(_character);
		}
	}
}