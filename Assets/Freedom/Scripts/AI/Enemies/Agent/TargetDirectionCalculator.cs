using System;
using UnityEngine;

namespace Freedom.AI.Enemies.Agent
{
	public class TargetDirectionCalculator : MonoBehaviour
	{
		[field: SerializeField, Space] public Action<Vector3> OnCalculateTargetDirection { get; set; }

		public void Calculate(Transform target)
		{
			Vector3 direction = target.position - transform.position;
			OnCalculateTargetDirection?.Invoke(direction);
		}
	}
}