using System;
using Freedom.Characters.Data.Record;
using UnityEngine;

namespace Freedom.Scenes.Record
{
	public class CharacterRecordDataLoader : MonoBehaviour
	{
		[SerializeField] CharacterRecordDatabase database;

		public Action<CharacterRecordData> OnLoadData { get; set; }

		public void LoadData(GameObject characterPrefab)
		{
			CharacterRecordData data = database.FindById(characterPrefab);
			OnLoadData?.Invoke(data);
		}
	}
}