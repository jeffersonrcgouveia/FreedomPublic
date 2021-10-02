using Freedom.AI.Enemies;
using Freedom.AI.Enemies.Agent;
using Freedom.Characters.Actions.Base;
using Freedom.Characters.Actions.ComboAttack;
using Freedom.Characters.Locomotion.Direction;
using Freedom.Characters.Locomotion.Movement.MovableCharacter;
using UnityEngine;

namespace Freedom.Players.Selector.Configurers
{
	[RequireComponent(typeof(CharacterSelector))]
	public class AIPlayerCharacterConfigurer : MonoBehaviour
	{
		[SerializeField] FollowTarget aI;
		[SerializeField] EnemyAIPatrol patrol;
		[SerializeField] TargetDirectionCalculator chase;
		[SerializeField] TargetDirectionCalculator attack;

		CharacterSelector _characterSelector;

		void Awake() => _characterSelector = GetComponent<CharacterSelector>();

		void OnEnable() => _characterSelector.OnSetCharacter += ConfigureCharacter;

		void OnDisable() => _characterSelector.OnSetCharacter -= ConfigureCharacter;

		void ConfigureCharacter(GameObject character)
		{
			CharacterMovement characterMovement = character.GetComponentInChildren<CharacterMovement>();
			GameObject movement = characterMovement.gameObject;
			Destroy(characterMovement);
			movement.AddComponent<NavMeshAgentCharacterMovement>();
			CharacterDirection direction = character.GetComponentInChildren<CharacterDirection>();
			CharacterAction basicAttack = character.GetComponentInChildren<ComboCharacterAction>();

			aI.GetComponent<FollowTarget>().Target = character.transform;
			patrol.OnCalculateWalkPointDirection += direction.SetMovingAndAimingDirections;
			chase.OnCalculateTargetDirection += direction.SetMovingAndAimingDirections;
			attack.OnCalculateTargetDirection += dir => direction.SetMovingDirectionZero();
			attack.OnCalculateTargetDirection += dir => basicAttack.Execute();
		}
	}
}