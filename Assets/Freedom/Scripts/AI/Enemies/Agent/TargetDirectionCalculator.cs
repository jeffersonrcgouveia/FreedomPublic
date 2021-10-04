using System;
using UnityEngine;

namespace Freedom.AI.Enemies.Agent
{
	public class TargetDirectionCalculator : MonoBehaviour
	{
		public event Action<Vector3> OnCalculateTargetDirection;

		public void Calculate(Transform target)
		{
			Vector3 direction = target.position - transform.position;
			OnCalculateTargetDirection?.Invoke(direction);
		}
	}
}