using System.Collections.Generic;
using UnityEngine;
using static Freedom.Characters.Data.Base.Constants.CharactersDataConstants;

namespace Freedom.Characters.Data.Attributes
{
	[CreateAssetMenu(menuName = CharactersPath + AttributesDatabase, fileName = AttributesDatabase)]
	public class CharacterAttributesDatabase : ScriptableObject /* DatabaseBase<CharacterAttributesData, GameObject> */
	{
		[field: SerializeField] public List<CharacterAttributesData> Data { get; set; }

		Dictionary<GameObject, CharacterAttributesData> Cache { get; set; } = new Dictionary<GameObject, CharacterAttributesData>();

		public CharacterAttributesData FindById(GameObject id)
		{
			if (Data.Count != Cache.Count) CacheData();
			return Cache[id];
		}

		void CacheData()
		{
			Cache.Clear();
			foreach (CharacterAttributesData data in Data) Cache[data.Id] = data;
		}
	}
}