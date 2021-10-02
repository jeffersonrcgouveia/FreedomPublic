using System;
using UnityEngine;

namespace Freedom.Players.Selector.Base
{
	public interface ICharacterSelector
	{
		public GameObject CharacterPrefab { get; set; }

		public Action<GameObject> OnSetCharacterPrefab { get; set; }
	}
}