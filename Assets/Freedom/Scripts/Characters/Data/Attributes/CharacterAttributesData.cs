using Freedom.Characters.Data.Attributes.Enums;
using Freedom.Characters.Data.Base;
using UnityEngine;
using static Freedom.Characters.Data.Base.Constants.CharactersDataConstants;

namespace Freedom.Characters.Data.Attributes
{
	[CreateAssetMenu(menuName = CharactersPath + AttributesData, fileName = AttributesData, order = 0)]
	public class CharacterAttributesData : ScriptableObject /* DataBase<GameObject> */
	{
		[field: SerializeField] public GameObject Id { get; set; }
		[field: SerializeField] public string Name { get; set; }
		[field: SerializeField] public AttributeLevel Damage { get; set; }
		[field: SerializeField] public AttributeLevel AttackSpeed { get; set; }
		[field: SerializeField] public AttributeLevel Reach { get; set; }
	}
}