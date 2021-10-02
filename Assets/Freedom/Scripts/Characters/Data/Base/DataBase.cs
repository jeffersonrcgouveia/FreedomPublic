using UnityEngine;

namespace Freedom.Characters.Data.Base
{
	/// <summary>
	/// This class is not being used due serialization problems on generics scriptable objects
	/// </summary>
	/// <typeparam name="T">The entity type</typeparam>
	public abstract class DataBase<T> : ScriptableObject
	{
		[field: SerializeField] public T Id { get; set; }
	}
}