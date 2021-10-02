using UnityEngine;

namespace ScriptableEvents.Variables.Base
{
	public abstract class ScriptableVariableBase<T> : ScriptableVariableBase
	{
		[field: SerializeField] public T Data { get; set; }
	}

	public abstract class ScriptableVariableBase : ScriptableObject
	{
	}
}