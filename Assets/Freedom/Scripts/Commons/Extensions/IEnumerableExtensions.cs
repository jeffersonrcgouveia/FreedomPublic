using System.Collections.Generic;
using UnityEngine;

namespace Freedom.Commons.Extensions
{
	public static class IEnumerableExtensions
	{
		/**
		 * Check if a collection of gameobjects is empty even after its items were destroyed, but not removed from the
		 * collection. This method doesn't work properly if the collection type (GameObject) is replaced by a generic type.
		 */
		public static bool IsEmpty(this IEnumerable<GameObject> list)
		{
			foreach (GameObject obj in list)
			{
				if (obj != null) return false;
			}

			return true;
		}

	}
}
