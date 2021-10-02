using UnityEngine;
using UnityEngine.AI;

namespace Freedom.Players.Selector.Configurers
{
	[RequireComponent(typeof(CharacterSelector))]
	public class CharacterSelectionConfigurer : MonoBehaviour
	{
		[SerializeField] new Transform camera;
		[SerializeField] Transform characterPlatform;

		CharacterSelector _characterSelector;

		void Awake() => _characterSelector = GetComponent<CharacterSelector>();

		void OnEnable() => _characterSelector.OnSetCharacter += ConfigureCharacter;

		void OnDisable() => _characterSelector.OnSetCharacter -= ConfigureCharacter;

		void ConfigureCharacter(GameObject character)
		{
			Destroy(character.GetComponent<NavMeshAgent>());
			character.transform.position = characterPlatform.position;
			Vector3 cameraPosition = FindCameraHorizontalPosition();
			Transform characterMesh = character.GetComponentInChildren<Animator>().transform;
			characterMesh.LookAt(cameraPosition);
			characterPlatform.LookAt(cameraPosition);
		}

		Vector3 FindCameraHorizontalPosition()
		{
			Vector3 cameraPosition = camera.transform.position;
			return new Vector3(cameraPosition.x, 0, cameraPosition.z);
		}
	}
}