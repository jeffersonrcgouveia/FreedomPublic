using System.Collections.Generic;
using UnityEngine;

namespace Freedom.Characters.Data.Base
{
	/// <summary>
	/// This class is not being used due serialization problems on generics scriptable objects
	/// </summary>
	/// <typeparam name="T">The entity type</typeparam>
	/// <typeparam name="TK">The entity's key type</typeparam>
	public abstract class DatabaseBase<T, TK> : ScriptableObject where T : DataBase<TK>
	{
		[field: SerializeField] public List<T> Data { get; set; }

		protected Dictionary<TK, T> Cache { get; private set; } = new Dictionary<TK, T>();

		public T FindById(TK id)
		{
			if (Data.Count != Cache.Count) CacheData();
			return Cache[id];
		}

		void CacheData()
		{
			Cache.Clear();
			foreach (T data in Data) Cache[data.Id] = data;
		}
	}
}