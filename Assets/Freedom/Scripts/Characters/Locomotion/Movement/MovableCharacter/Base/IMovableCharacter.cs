using UnityEngine;

namespace Freedom.Characters.Locomotion.Movement.MovableCharacter.Base
{
	public interface IMovableCharacter
	{
		public void Move(Vector3 velocity);
	}
}
