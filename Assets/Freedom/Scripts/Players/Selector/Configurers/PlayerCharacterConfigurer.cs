using Freedom.Camera;
using Freedom.Characters.Attributes;
using Freedom.Players.Camera;
using Freedom.Players.Inputs;
using Freedom.Players.Inputs.Fillers;
using Freedom.Players.UI.Filler;
using UnityEngine;

namespace Freedom.Players.Selector.Configurers
{
	[RequireComponent(typeof(CharacterSelector))]
	public class PlayerCharacterConfigurer : MonoBehaviour
	{
		[SerializeField] PlayerInput playerInput;

		[field: SerializeField] public FollowMouseCamera FollowMouseCamera { get; set; }

		[field: SerializeField] public PlayerUIFiller UIFiller { get; set; }

		CharacterSelector _characterSelector;

		void Awake() => _characterSelector = GetComponent<CharacterSelector>();

		void OnEnable() => _characterSelector.OnSetCharacter += ConfigureCharacter;

		void OnDisable() => _characterSelector.OnSetCharacter -= ConfigureCharacter;

		void ConfigureCharacter(GameObject character)
		{
			FollowMouseCamera.GetComponent<PlayerCameraFiller>().PopulateFields(character);
			FollowCamera followCamera = FollowMouseCamera.GetComponent<FollowCamera>();
			CharacterHealth characterHealth = character.GetComponentInChildren<CharacterHealth>();
			characterHealth.OnOver += () => followCamera.RestoreCalculatePositionCallback();
			UIFiller.PopulateFields(character);
			PlayerInputFiller playerInputFiller = character.GetComponent<PlayerInputFiller>();
			playerInputFiller.Camera = FollowMouseCamera;
			playerInputFiller.PopulateInput(playerInput);
		}
	}
}