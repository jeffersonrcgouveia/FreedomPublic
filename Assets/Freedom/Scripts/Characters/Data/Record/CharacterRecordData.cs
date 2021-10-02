using UnityEngine;
using static Freedom.Characters.Data.Base.Constants.CharactersDataConstants;

namespace Freedom.Characters.Data.Record
{
	[CreateAssetMenu(menuName = CharactersPath + RecordData, fileName = RecordData)]
	public class CharacterRecordData : ScriptableObject /* DataBase<GameObject> */
	{
		[field: SerializeField] public GameObject Id { get; set; }
		[field: SerializeField] public string Name { get; set; }
		[field: SerializeField] public int Wave { get; set; }
		[field: SerializeField] public int EnemiesKilled { get; set; }
	}
}