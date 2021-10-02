using System.Collections.Generic;
using UnityEngine;
using static Freedom.Characters.Data.Base.Constants.CharactersDataConstants;

namespace Freedom.Characters.Data.Record
{
	[CreateAssetMenu(menuName = CharactersPath + RecordDatabase, fileName = RecordDatabase)]
	public class CharacterRecordDatabase : ScriptableObject /* DatabaseBase<CharacterRecordData, GameObject> */
	{
		[field: SerializeField] public List<CharacterRecordData> Data { get; set; }

		Dictionary<GameObject, CharacterRecordData> Cache { get; set; } = new Dictionary<GameObject, CharacterRecordData>();

		public CharacterRecordData FindById(GameObject id)
		{
			if (Data.Count != Cache.Count) CacheData();
			return Cache[id];
		}

		void CacheData()
		{
			Cache.Clear();
			foreach (CharacterRecordData data in Data) Cache[data.Id] = data;
		}
	}
}