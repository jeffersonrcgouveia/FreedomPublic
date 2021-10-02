using Freedom.Characters.Attributes;
using Freedom.UI.Billboard;
using Freedom.UI.ProgressBar;
using UnityEngine;
using UnityEngine.UI;

namespace Freedom.Players.Selector.Configurers
{
	[RequireComponent(typeof(CharacterSelector))]
	public class PlayerCharacterBillboardConfigurer : MonoBehaviour
	{
		const float CharacterHeightOffset = 0.2f;

		const float BillboardZOffset = 1;

		[SerializeField] BillboardBehaviour billboardCanvas;

		[SerializeField] ProgressBarUpdater billboardHealthBar;

		[field: SerializeField] public Transform CameraTransform { get; set; }

		[field: SerializeField] public Color HealthBarFill { get; set; }

		CharacterSelector _characterSelector;

		void Awake() => _characterSelector = GetComponent<CharacterSelector>();

		void OnEnable() => _characterSelector.OnSetCharacter += ConfigureCharacter;

		void OnDisable() => _characterSelector.OnSetCharacter -= ConfigureCharacter;

		void ConfigureCharacter(GameObject character)
		{
			ConfigureBillboardCanvas(character);
			ConfigureBillboardHealthBar(character);
		}

		void ConfigureBillboardCanvas(GameObject character)
		{
			billboardCanvas.CameraTransform = CameraTransform;
			TransformFollower follower = billboardCanvas.GetComponent<TransformFollower>();
			follower.FollowTransform = character.transform;
			float heightOffset = character.GetComponent<CapsuleCollider>().height + CharacterHeightOffset;
			follower.PositionOffset = new Vector3(0, heightOffset, BillboardZOffset);
		}

		void ConfigureBillboardHealthBar(GameObject character)
		{
			billboardHealthBar.Fill.GetComponent<Image>().color = HealthBarFill;
			CharacterHealth characterHealth = character.GetComponentInChildren<CharacterHealth>();
			characterHealth.OnChangePercent += health => billboardHealthBar.FillAmount = health;
			characterHealth.OnOver += () => Destroy(billboardHealthBar.gameObject);
		}
	}
}